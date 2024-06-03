using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using MMORGP_Web_API;
using MMORGP_Web_API.Entiteti;

namespace MMORGP_Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LikController : ControllerBase
    {
        [HttpGet(Name = "VratiLikove")]
        public IEnumerable<LikPregled> Get()
        {
            return DTOManager.vratiLikove().ToArray();
        }

        [HttpDelete(Name = "DeleteLik")]
        public ActionResult Delete(int id)
        {
            try
            {
                DTOManager.obrisiLika(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Name = "AddLik")]
        public ActionResult Post(LikBasic lik, string klasaLika, string rasaLika, int igracID, int zamke, int buka, string religija,
            string blagoslov, char lecenje, char luksamostrel, int oklop, char oberuke, char stit, string magije)
        {
            try
            {
                DTOManager.sacuvajLika(lik, klasaLika, rasaLika, zamke, buka, religija, blagoslov, lecenje, luksamostrel, oklop, oberuke, stit, magije);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpPut]
        [Route("UpdateLikLopov")]
        public async Task<ActionResult> Put(LopovBasic lik)
        {
            try
            {
                DTOManager.izmeniLopova(lik);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("UpdateLikSvestenik")]
        public async Task<ActionResult> Put(SvestenikBasic lik)
        {
            try
            {
                DTOManager.izmeniSvestenika(lik);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("UpdateLikStrelac")]
        public async Task<ActionResult> Put(StrelacBasic lik)
        {
            try
            {
                DTOManager.izmeniStrelca(lik);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("UpdateLikCarobnjak")]
        public async Task<ActionResult> Put(CarobnjakBasic lik)
        {
            try
            {
                DTOManager.izmeniCarobnjaka(lik);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("UpdateLikBorac")]
        public async Task<ActionResult> Put(BoracBasic lik)
        {
            try
            {
                DTOManager.izmeniBorca(lik);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("UpdateLikOklopnik")]
        public async Task<ActionResult> Put(OklopnikBasic lik)
        {
            try
            {
                DTOManager.izmeniOklopnika(lik);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
