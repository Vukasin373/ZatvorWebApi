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
    public class AdvokatController:ControllerBase
    {
        [HttpGet]
        [Route("VratiSveAdvokate")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult VratiSveAdvokate()
        {
            try
            {
                return new JsonResult(DataProvider.GetAdvokati());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajAdvokata")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult AddAdvokat([FromBody]AdvokatView a)
        {
            try
            {
                DataProvider.SacuvajAdvokata(a);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniAdvokata")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeAdvokat([FromBody] AdvokatView a)
        {
            try
            {
                DataProvider.IzmeniAdvokata(a);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiAdvokata/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteAdvokata(int id)
        {
            try
            {
                DataProvider.ObrisiAdvokata(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
