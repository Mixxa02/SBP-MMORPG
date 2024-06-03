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
    public class SesijaController : ControllerBase
    {
        [HttpGet(Name = "GetSesije")]
        public IEnumerable<SesijaPregled> Get()
        {
            return DTOManager.vratiSesije().ToArray();
        }
        [HttpPost(Name = "AddSesija")]
        public ActionResult Post(SesijaBasic k, string id)
        {
            try
            {
                DTOManager.sacuvajSesiju(k, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
