using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using MMORGP_Web_API;
using Microsoft.AspNetCore.Routing;
using System.Net.Mime;
using MMORGP_Web_API.Entiteti;

namespace MMORGP_Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IgracController : ControllerBase
    {
        [HttpGet]
        [Route("GetIgraci")]
        public IEnumerable<IgracPregled> Get()
        {
            return DTOManager.vratiIgrace().ToArray();
        }

        [HttpDelete]
        [Route("DeleteIgrac")]
        public ActionResult Delete(int id)
        {
            try
            {
                DTOManager.obrisiIgraca(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddIgrac")]
        public ActionResult Post(IgracBasic igrac, string naziv, int id)
        {
            try
            {
                DTOManager.sacuvajIgraca(igrac, naziv, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateIgrac")]
        public ActionResult Put(IgracBasic igrac, string naziv, int id)
        {
            try
            {
                DTOManager.azurirajIgraca(igrac, naziv, id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}