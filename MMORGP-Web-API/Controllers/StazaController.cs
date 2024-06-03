using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using MMORGP_Web_API.Entiteti;
using System.Threading.Tasks;
using MMORGP_Web_API;

namespace MMORGP_Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StazaController : ControllerBase
    {
        [HttpGet(Name = "GetStaze")]
        public IEnumerable<StazaPregled> Get()
        {
            return DTOManager.vratiStaze().ToArray();
        }

        [HttpDelete(Name = "DeleteStaza")]
        public ActionResult Delete(string naziv)
        {
            try
            {
                DTOManager.obrisiStazu(naziv);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Name = "AddStaza")]
        public ActionResult Post(StazaBasic staza, string tipStaze, int brigr, int brUb, int igrId, string tim)
        {
            try
            {
                DTOManager.sacuvajStazu(staza, tipStaze, brigr, brUb, igrId, tim);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("UpdateStazaIgrac")]
        public async Task<ActionResult> Put(StazaZaIgracaBasic staza)
        {
            try
            {
                DTOManager.izmeniStazuZaIgraca(staza);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("UpdateStazaTim")]
        public async Task<ActionResult> Put(StazaZaTimBasic staza)
        {
            try
            {
                DTOManager.izmeniStazuZaTim(staza);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
