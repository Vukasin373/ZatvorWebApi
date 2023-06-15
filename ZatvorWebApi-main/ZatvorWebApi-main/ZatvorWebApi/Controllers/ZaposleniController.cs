using DatabaseAccess;
using DatabaseAccess.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZatvorWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Zaposleni : ControllerBase
    {
        #region Generalno
        [HttpGet]
        [Route("VratiSveZaposlene/")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult VratiSveZaposlene()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveZaposlene());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiZaposleni/{ZaposleniId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult VratiZaposleni(int ZaposleniId)
        {
            try
            {
                return new JsonResult(DataProvider.VratiZaposleni(ZaposleniId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("AzurirajZaposleni")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AzurirajZaposleni([FromBody] ZaposleniView p)
        {
            try
            {
                DataProvider.AzurirajZaposleni(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("ObrisiZaposleni/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ObrisiZaposleni(int id)
        {
            try
            {
                DataProvider.ObrisiZaposleni(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion

        #region Upravnik
        [HttpGet]
        [Route("VratiSveUpravnik/")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult VratiSveUpravnik()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveUpravnik());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiUpravnik/{UpravnikId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult VratiUpravnik(int UpravnikId)
        {
            try
            { 
                return new JsonResult(DataProvider.VratiUpravnik(UpravnikId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajUpravnik")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajUpravnik([FromBody] ZaposleniUpravnikView z)
        {
            try
            {
                DataProvider.DodajUpravnik(z);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("AzurirajUpravnik")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AzurirajUpravnik([FromBody] ZaposleniUpravnikView p)
        {
            try
            {
                DataProvider.AzurirajUpravnik(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("ObrisiUpravnik/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ObrisiUpravnik(int id)
        {
            try
            {
                DataProvider.ObrisiUpravnik(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion

        #region Admninistracija
        [HttpGet]
        [Route("VratiSveUAdministracija/")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult VratiSveUAdministracija()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveUAdministracija());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiUAdministracija/{UAdministracijaId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult VratiUAdministracija(int UAdministracijaId)
        {
            try
            {
                return new JsonResult(DataProvider.VratiUAdministracija(UAdministracijaId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajUAdministracija")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajUAdministracija([FromBody] ZaposlenUAdministracijaView z)
        {
            try
            {
                DataProvider.DodajUAdministracija(z);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("AzurirajUAdministracija")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AzurirajUAdministracija([FromBody] ZaposlenUAdministracijaView p)
        {
            try
            {
                DataProvider.AzurirajUAdministracija(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("ObrisiUAdministracija/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ObrisiUAdministracija(int id)
        {
            try
            {
                DataProvider.ObrisiUAdministracija(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion

        #region Obezbedjenje
        [HttpGet]
        [Route("VratiSveRadnikObezbedjenja/")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult VratiSveRadnikObezbedjenja()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveRadnikObezbedjenja());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiRadnikObezbedjenja/{ObezbedjenjeId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult VratiRadnikObezbedjenja(int ObezbedjenjeId)
        {
            try
            {
                return new JsonResult(DataProvider.VratiRadnikObezbedjenja(ObezbedjenjeId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajRadnikObezbedjenja")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajRadnikObezbedjenja([FromBody] ZaposleniRadnikObezbedjenjaView z)
        {
            try
            {
                DataProvider.DodajRadnikObezbedjenja(z);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("AzurirajRadnikObezbedjenja")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AzurirajRadnikObezbedjenja([FromBody] ZaposleniRadnikObezbedjenjaView p)
        {
            try
            {
                DataProvider.AzurirajRadnikObezbedjenja(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("ObrisiRadnikObezbedjenja/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ObrisiRadnikObezbedjenja(int id)
        {
            try
            {
                DataProvider.ObrisiRadnikObezbedjenja(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion

        #region Psiholog
        [HttpGet]
        [Route("VratiSvePsiholog/")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult VratiSvePsiholog()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSvePsiholog());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiPsiholog/{PsihologId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult VratiPsiholog(int PsihologId)
        {
            try
            {
                return new JsonResult(DataProvider.VratiPsiholog(PsihologId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajPsiholog")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajPsiholog([FromBody] ZaposleniPsihologView z)
        {
            try
            {
                DataProvider.DodajPsiholog(z);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("AzurirajPsiholog")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AzurirajPsiholog([FromBody] ZaposleniPsihologView p)
        {
            try
            {
                DataProvider.AzurirajPsiholog(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("ObrisiPsiholog/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ObrisiPsiholog(int id)
        {
            try
            {
                DataProvider.ObrisiPsiholog(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion

        #region LekarskiPregled

        [Route("DodajLekarskiPregled/{zaposleniId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajLekarskiPregled([FromBody] LekarskiPregledView z, [FromRoute] int zaposleniId)
        {
            try
            {
                DataProvider.DodajLekarskiPregled(z, zaposleniId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("GetLekarskiPregled/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetLekarskiPregled(int id)
        {
            try
            {
                return new JsonResult(DataProvider.GetLekarskiPregled(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniLekarskiPregled")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult IzmeniLekarskiPregled([FromBody] LekarskiPregledView p)
        {
            try
            {
                DataProvider.IzmeniLekarskiPregled(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("ObrisiLekarskiPregled/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult ObrisiLekarskiPregled(int id)
        {
            try
            {
                DataProvider.ObrisiLekarskiPregled(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion

        #region DozvolaZaOruzje

        [Route("DodajDozvoluZaOruzje/{zaposleniId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajDozvoluZaOruzje([FromBody] DozvolaZaOruzjeView z, [FromRoute] int zaposleniId)
        {
            try
            {
                DataProvider.DodajDozvoluZaOruzje(z, zaposleniId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("GetDozvoluZaOruzje/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetDozvoluZaOruzje(int id)
        {
            try
            {
                return new JsonResult(DataProvider.VratiDozvoluZaOruzje(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniDozvoluZaOruzje")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult IzmeniDozvoluZaOruzje([FromBody] DozvolaZaOruzjeView p)
        {
            try
            {
                DataProvider.IzmeniDozvoluZaOruzje(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("ObrisiDozvoluZaOruzje/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult ObrisiDozvoluZaOruzje(int id)
        {
            try
            {
                DataProvider.ObrisiDozvoluZaOruzje(id);
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
