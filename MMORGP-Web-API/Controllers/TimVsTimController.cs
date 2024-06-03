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
    public class TimVsTimController : ControllerBase
    {
        [HttpGet(Name = "GetBorbe")]
        public IEnumerable<TimVsTimPregled> Get()
        {
            return DTOManager.vratiBorbe().ToArray();
        }
        [HttpPost(Name = "AddBorba")]
        public ActionResult Post(TimVsTimPregled k)
        {
            try
            {
                DTOManager.sacuvajBorbu(k);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
