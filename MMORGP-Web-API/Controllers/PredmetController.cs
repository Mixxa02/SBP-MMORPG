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
    public class PredmetController : ControllerBase
    {
        [HttpGet(Name = "GetPredmeti")]
        public IEnumerable<PredmetPregled> Get()
        {
            return DTOManager.vratiPredmete().ToArray();
        }

        [HttpDelete(Name = "DeletePredmet")]
        public ActionResult Delete(string naziv)
        {
            try
            {
                DTOManager.obrisiPredmet(naziv);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Name = "AddPredmet")]
        public ActionResult Post(PredmetBasic pr, string tipPredmeta, string nadimci, int bonisk, string rase, string staza)
        {
            try
            {
                DTOManager.sacuvajPredmet(pr, tipPredmeta, nadimci, bonisk, rase);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("UpdatePredmetKljucni")]
        public async Task<ActionResult> Put(KljucniPredmetBasic predmet)
        {
            try
            {
                DTOManager.izmeniKljucniPredmet(predmet);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("UpdatePredmetXP")]
        public async Task<ActionResult> Put(PredmetXPBasic predmet)
        {
            try
            {
                DTOManager.izmeniPredmetXP(predmet);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
