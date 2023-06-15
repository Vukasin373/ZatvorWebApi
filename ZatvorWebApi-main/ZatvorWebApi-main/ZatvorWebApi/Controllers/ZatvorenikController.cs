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
    public class Zatvorenik : ControllerBase
    {
        #region ZatvorenikBase
        [HttpGet]
        [Route("VratiZatvorenikeZatvora/{ZatvorId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult VratiZatvorenikeZatvora(int ZatvorId)
        {
            try
            {
                return new JsonResult(DataProvider.VratiZatvorenikeZatvora(ZatvorId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("VratiZatvorenika/{ZatvorenikId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult VratiZatvorenika(int ZatvorenikId)
        {
            try
            {
                return new JsonResult(DataProvider.VratiZatvorenika(ZatvorenikId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("SacuvajZatvorenika")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult SacuvajZatvorenika([FromBody] ZatvorenikView z)
        {
            try
            {
                DataProvider.SacuvajZatvorenika(z);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniZatvorenika")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult IzmeniZatvorenika([FromBody] ZatvorenikView p)
        {
            try
            {
                DataProvider.IzmeniZatvorenika(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("ObrisiZatvorenika/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ObrisiZatvorenika(int id)
        {
            try
            {
                DataProvider.ObrisiZatvorenika(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion

        #region ZastupaAdvokat
        [HttpPost]
        [Route("AngazujAdvokata")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AngazujAdvokata([FromBody] ZastupaView z)
        {
            try
            {
                DataProvider.SacuvajZastupa(z);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("GetZastupa/{zatvorenikId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetZastupa(int zatvorenikId)
        {
            try
            {
                return new JsonResult(DataProvider.GetZastupa(zatvorenikId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("DeleteZastupa/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteZastupa(int id)
        {
            try
            {
                DataProvider.DeleteZastupa(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion

        #region PoseteAdvokat

        [HttpPost]
        [Route("PosetaZatvoreniku")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AngazujAdvokata([FromBody] PosecujeView z)
        {
            try
            {
                DataProvider.SacuvajPosecuje(z);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("GetZatvorenikPosecuje/{zatvorenikId}")]  ////////////////////////////////////////////////  PROVERI !!
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetZatvorenikPosecuje(int zatvorenikId)
        {
            try
            {
                return new JsonResult(DataProvider.GetZatvorenikPosecuje(zatvorenikId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("DeletePosecuje/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeletePosecuje(int id)
        {
            try
            {
                DataProvider.DeletePosecuje(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #endregion

        #region PrestupPocinio

        [HttpPost]
        [Route("SacuvajPocinio")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult SacuvajPocinio([FromBody] PocinioView z)
        {
            try
            {
                DataProvider.SacuvajPocinio(z);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("GetZatvorenikPocinio/{zatvorenikId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetZatvorenikPocinio(int zatvorenikId)
        {
            try
            {
                return new JsonResult(DataProvider.GetZatvorenikPocinio(zatvorenikId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpDelete]
        [Route("DeletePocinio/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeletePocinio(int id)
        {
            try
            {
                DataProvider.DeletePocinio(id);
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
