using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Zatvor.Entiteti;
using DatabaseAccess;
using DatabaseAccess.DTOs;

namespace ZatvorWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FirmaController : ControllerBase
    {
        #region BaseFirma
        [HttpGet]
        [Route("VratiSveFirme")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult VratiSveFirme()
        {
            try
            {
                return new JsonResult(DataProvider.GetFirme());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajFirme")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult AddFirma([FromBody] FirmaView f)
        {
            try
            {
                DataProvider.SacuvajFirmu(f);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniFirmu/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeFirma(int id, [FromBody] FirmaView f)
        {
            try
            {
                DataProvider.IzmeniFirmu(id, f);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiFirmu/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteFirma(int id)
        {
            try
            {
                DataProvider.ObrisiFirmu(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion

        #region KontaktFirme

        [HttpPost]
        [Route("SacuvajFirmaKontakt/{idFirme}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult SacuvajFirmaKontakt([FromRoute] int  idFirme, [FromBody] FirmaKontaktView f)
        {
            try
            {
                DataProvider.SacuvajFirmaKontakt(f, idFirme);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

       
        [HttpGet]
        [Route("GetKontaktiFirme/{firmaId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult GetKontaktiFirme(int firmaId)
        {
            try
            {
                return new JsonResult(DataProvider.GetKontaktiFirme(firmaId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniFirmaKontakt")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult IzmeniFirmaKontakt([FromBody] FirmaKontaktView f)
        {
            try
            {
                DataProvider.IzmeniFirmaKontakt( f);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpDelete]
        [Route("ObrisiFirmaKontakt/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ObrisiFirmaKontakt(int id)
        {
            try
            {
                DataProvider.ObrisiFirmaKontakt(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #endregion
        #region OdgovornaLicaFirme

        [HttpPost]
        [Route("SacuvajFirmaOdgovornoLice/{idFirme}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult SacuvajFirmaOdgovornoLice([FromRoute] int idFirme, [FromBody] FirmaOdgovornaLicaView f)
        {
            try
            {
                DataProvider.SacuvajFirmaOdgovornoLice(f, idFirme);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpGet]
        [Route("GetOdgovornaLicaFirme/{firmaId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult GetOdgovornaLicaFirme(int firmaId)
        {
            try
            {
                return new JsonResult(DataProvider.GetOdgovornaLicaFirme(firmaId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("IzmeniFirmaOdgovornoLice")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult IzmeniFirmaOdgovornoLice([FromBody] FirmaOdgovornaLicaView f)
        {
            try
            {
                DataProvider.IzmeniFirmaOdgovornoLice(f);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpDelete]
        [Route("ObrisiFirmaOdgovornoLice/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ObrisiFirmaOdgovornoLice(int id)
        {
            try
            {
                DataProvider.ObrisiFirmaOdgovornoLice(id);
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

