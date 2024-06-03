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
    public class KupovinaController : ControllerBase
    {
        [HttpGet(Name = "GetKupovine")]
        public IEnumerable<KupovinaPregled> Get()
        {
            return DTOManager.vratiKupovine().ToArray();
        }
        [HttpPost(Name = "AddKupovina")]
        public ActionResult Post(KupovinaPregled k)
        {
            try
            {
                DTOManager.sacuvajKupovinu(k);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
