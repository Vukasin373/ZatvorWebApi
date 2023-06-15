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
    public class PrestupController : ControllerBase
    {
        [HttpGet]
        [Route("VratiSvePrestupe")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult VratiSvePrestupe()
        {
            try
            {
                return new JsonResult(DataProvider.GetPrestupi());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajPrestup")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult AddPrestup([FromBody] PrestupView p)
        {
            try
            {
                DataProvider.SacuvajPrestup(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniPrestup")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeAdvokat([FromBody] PrestupView p)
        {
            try
            {
                DataProvider.IzmeniPrestup(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiPrestup/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeletePrestup(int id)
        {
            try
            {
                DataProvider.ObrisiPrestup(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
