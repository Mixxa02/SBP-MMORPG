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
    public class StazaSadrziPredmetController : ControllerBase
    {
        [HttpGet(Name = "GetSadrzaji")]
        public IEnumerable<StazaSadrzPredmetPregled> Get()
        {
            return DTOManager.vratiSadrzaje().ToArray();
        }
        [HttpDelete(Name = "DeleteSadrzaj")]
        public ActionResult Delete(int id)
        {
            try
            {
                DTOManager.obrisiSadrzaj(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost(Name = "AddSadrzaj")]
        public ActionResult Post(StazaSadrzPredmetPregled k)
        {
            try
            {
                DTOManager.sacuvajSadrzaj(k);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
