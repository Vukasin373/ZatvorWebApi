using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DatabaseAccess;
using Zatvor.Entiteti;
using DatabaseAccess.DTOs;

namespace ZatvorWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZatvorskaJedinicaController : ControllerBase
    {
        #region ZatvorskeJedinice

        [HttpGet]
        [Route("VratiSveZatvorskeJedinice/")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult VratiSveZatvore()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveZatvorskeJedinice());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiZaposleneZatvora/{ZatvorId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult VratiSveZaposleneZatvora(int ZatvorId)
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveZaposleneZatvora(ZatvorId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiZatvorskuJedinicu/{zatvorId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult VratiZatvorskuJedinicu(int zatvorId)
        {
            try
            {
                return new JsonResult(DataProvider.VratiZatvorskaJedinica(zatvorId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajZatvorskaJedinica")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajZatvorskaJedinica([FromBody] ZatvorskaJedinicaView z)
        {
            if(z.OtvoreniF == 'N' && z.PoluOtvoreniF== 'N' && z.StrogiF== 'N' )
                return BadRequest("Zatvor mora da bude neki tip !");

            try
            {
                DataProvider.DodajZatvorskaJedinica(z);
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message == "ORA-00001: unique constraint (S17513.SYS_C00277591) violated")
                    return BadRequest("Vec postoji zatvorska jedinica sa ovom sifrom !");
                else
                    return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPut]
        [Route("AzurirajZatvorskaJedinica")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AzurirajZatvorskaJedinica([FromBody] ZatvorskaJedinicaView p)
        {
            try
            {
                DataProvider.AzurirajZatvorskaJedinica(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("ObrisiZatvorskaJedinica/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ObrisiZatvorskaJedinica(int id)
        {
            try
            {
                DataProvider.ObrisiZatvorskaJedinica(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajSaradnjuSaFirmom/{id}")]             /////////////////////// PROVERI, NECE DA RADI, NE ZNA SE ZASTO
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajSaradnjuSaFirmom([FromRoute] int id, [FromBody] SaradjujeView z)
        {
           

            try
            {
                DataProvider.SacuvajSaradjuje(z, id);
                return Ok();
            }
            catch (Exception ex)
            {
                    return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("GetFirmaSaradjuje/{zatvorId}")]  
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetFirmaSaradjuje(int zatvorId)
        {
            try
            {
                return new JsonResult(DataProvider.GetFirmaSaradjuje(zatvorId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("DeleteSaradjuje/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteSaradjuje(int id)
        {
            try
            {
                DataProvider.DeleteSaradjuje(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion

        #region TerminPosete
        [HttpPost]
        [Route("SacuvajTerminPosete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult SacuvajTerminPosete([FromBody] StrogTerminView z)
        {
            try
            {
                DataProvider.SacuvajTerminPosete(z);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("GetTerminPoseteZatvora/{zatvorId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetTerminPoseteZatvora(int zatvorId)
        {
            try
            {
                return new JsonResult(DataProvider.GetTerminPoseteZatvora(zatvorId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("DeleteTerminPosete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteTerminPosete(int id)
        {
            try
            {
                DataProvider.DeleteTerminPosete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion

        #region ZOTipa

        [HttpPost]
        [Route("DodajZOTipa")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajZOTipa([FromBody] ZOTipaView z)
        {
            try
            {
                DataProvider.DodajZOTipa(z);
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message == "ORA-00001: unique constraint (S17513.SYS_C00277591) violated")
                    return BadRequest("Vec postoji zatvorska jedinica sa ovom sifrom !");
                else
                    return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpGet]
        [Route("VratiSveZOTipa/")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult VratiSveZOTipa()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveZOTipa());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiZOTipa/{zatvorId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult VratiZOTipa(int zatvorId)
        {
            try
            {
                return new JsonResult(DataProvider.VratiZOTipa(zatvorId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("AzurirajZOTipa")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AzurirajZOTipa([FromBody] ZOTipaView p)
        {
            try
            {
                DataProvider.AzurirajZOTipa(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("ObrisiZOTipa/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ObrisiZOTipa(int id)
        {
            try
            {
                DataProvider.ObrisiZOTipa(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion

        #region ZPOTipa

        [HttpPost]
        [Route("DodajZPOTipa")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajZPOTipa([FromBody] ZPOTipaView z)
        {
            try
            {
                DataProvider.DodajZPOTipa(z);
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message == "ORA-00001: unique constraint (S17513.SYS_C00277591) violated")
                    return BadRequest("Vec postoji zatvorska jedinica sa ovom sifrom !");
                else
                    return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpGet]
        [Route("VratiSveZPOTipa/")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult VratiSveZPOTipa()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveZPOTipa());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiZPOTipa/{zatvorId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult VratiZPOTipa(int zatvorId)
        {
            try
            {
                return new JsonResult(DataProvider.VratiZPOTipa(zatvorId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("AzurirajZPOTipa")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AzurirajZPOTipa([FromBody] ZPOTipaView p)
        {
            try
            {
                DataProvider.AzurirajZPOTipa(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("ObrisiZPOTipa/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ObrisiZPOTipa(int id)
        {
            try
            {
                DataProvider.ObrisiZPOTipa(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion

        #region ZSTipa
        [HttpPost]
        [Route("DodajZSTipa")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajZSTipa([FromBody] ZSTipaView z)
        {
            try
            {
                DataProvider.DodajZSTipa(z);
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message == "ORA-00001: unique constraint (S17513.SYS_C00277591) violated")
                    return BadRequest("Vec postoji zatvorska jedinica sa ovom sifrom !");
                else
                    return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpGet]
        [Route("VratiSveZSTipa/")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult VratiSveZSTipa()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveZSTipa());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiZSTipa/{zatvorId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult VratiZSTipa(int zatvorId)
        {
            try
            {
                return new JsonResult(DataProvider.VratiZSTipa(zatvorId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("AzurirajZSTipa")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AzurirajZSTipa([FromBody] ZSTipaView p)
        {
            try
            {
                DataProvider.AzurirajZSTipa(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("ObrisiZSTipa/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ObrisiZSTipa(int id)
        {
            try
            {
                DataProvider.ObrisiZSTipa(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion

        #region ZOPOTipa
        [HttpPost]
        [Route("DodajZOPOTipa")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajZOPOTipa([FromBody] ZOPOTipaView z)
        {
            try
            {
                DataProvider.DodajZOPOTipa(z);
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message == "ORA-00001: unique constraint (S17513.SYS_C00277591) violated")
                    return BadRequest("Vec postoji zatvorska jedinica sa ovom sifrom !");
                else
                    return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpGet]
        [Route("VratiSveZOPOTipa/")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult VratiSveZOPOTipa()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveZOPOTipa());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiZOPOTipa/{zatvorId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult VratiZOPOTipa(int zatvorId)
        {
            try
            {
                return new JsonResult(DataProvider.VratiZOPOTipa(zatvorId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("AzurirajZOPOTipa")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AzurirajZOPOTipa([FromBody] ZOPOTipaView p)
        {
            try
            {
                DataProvider.AzurirajZOPOTipa(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("ObrisiZOPOTipa/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ObrisiZOPOTipa(int id)
        {
            try
            {
                DataProvider.ObrisiZOPOTipa(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion

        #region ZOSTipa
        [HttpPost]
        [Route("DodajZOSTipa")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajZOSTipa([FromBody] ZOSTipaView z)
        {
            try
            {
                DataProvider.DodajZOSTipa(z);
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message == "ORA-00001: unique constraint (S17513.SYS_C00277591) violated")
                    return BadRequest("Vec postoji zatvorska jedinica sa ovom sifrom !");
                else
                    return BadRequest(ex.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("VratiSveZOSTipa/")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult VratiSveZOSTipa()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveZOSTipa());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiZOSTipa/{zatvorId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult VratiZOSTipa(int zatvorId)
        {
            try
            {
                return new JsonResult(DataProvider.VratiZOSTipa(zatvorId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("AzurirajZOSTipa")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AzurirajZOSTipa([FromBody] ZOSTipaView p)
        {
            try
            {
                DataProvider.AzurirajZOSTipa(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("ObrisiZOSTipa/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ObrisiZOSTipa(int id)
        {
            try
            {
                DataProvider.ObrisiZOSTipa(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion

        #region ZPOSTipa
        [HttpPost]
        [Route("DodajZPOSTipa")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajZPOSTipa([FromBody] ZPOSTipaView z)
        {
            try
            {
                DataProvider.DodajZPOSTipa(z);
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message == "ORA-00001: unique constraint (S17513.SYS_C00277591) violated")
                    return BadRequest("Vec postoji zatvorska jedinica sa ovom sifrom !");
                else
                    return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpGet]
        [Route("VratiSveZPOSTipa/")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult VratiSveZPOSTipa()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveZPOSTipa());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiZPOSTipa/{zatvorId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult VratiZPOSTipa(int zatvorId)
        {
            try
            {
                return new JsonResult(DataProvider.VratiZPOSTipa(zatvorId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("AzurirajZPOSTipa")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AzurirajZPOSTipa([FromBody] ZPOSTipaView p)
        {
            try
            {
                DataProvider.AzurirajZPOSTipa(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("ObrisiZPOSTipa/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ObrisiZPOSTipa(int id)
        {
            try
            {
                DataProvider.ObrisiZPOSTipa(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion

        #region ZOPOSTipa
        [HttpPost]
        [Route("DodajZOPOSTipa")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajZOPOSTipa([FromBody] ZOPOSTipaView z)
        {
            try
            {
                DataProvider.DodajZOPOSTipa(z);
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message == "ORA-00001: unique constraint (S17513.SYS_C00277591) violated")
                    return BadRequest("Vec postoji zatvorska jedinica sa ovom sifrom !");
                else
                    return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpGet]
        [Route("VratiSveZOPOSTipa/")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult VratiSveZOPOSTipa()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveZOPOSTipa());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiZOPOSTipa/{zatvorId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult VratiZOPOSTipa(int zatvorId)
        {
            try
            {
                return new JsonResult(DataProvider.VratiZOPOSTipa(zatvorId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("AzurirajZOPOSTipa")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AzurirajZOPOSTipa([FromBody] ZOPOSTipaView p)
        {
            try
            {
                DataProvider.AzurirajZOPOSTipa(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("ObrisiZOPOSTipa/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ObrisiZOPOSTipa(int id)
        {
            try
            {
                DataProvider.ObrisiZOPOSTipa(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion
    }
}
