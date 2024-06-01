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
        [HttpPut(Name = "UpdateLik")]
        public async Task<ActionResult> Put(LikBasic lik, int id)
        {
            try
            {
                if (lik.Klasa == "LOPOV")
                {
                    DTOManager.izmeniLopova((MMORGP_Web_API.LopovBasic)lik);
                    return Ok();
                }
                else if (lik.Klasa == "SVESTENIK")
                {
                    DTOManager.izmeniSvestenika((MMORGP_Web_API.SvestenikBasic)lik);
                    return Ok();
                }
                else if (lik.Klasa == "STRELAC")
                {
                    DTOManager.izmeniStrelca((MMORGP_Web_API.StrelacBasic)lik);
                    return Ok();
                }
                else if (lik.Klasa == "OKLOPNIK")
                {
                    DTOManager.izmeniOklopnika((MMORGP_Web_API.OklopnikBasic)lik);
                    return Ok();
                }
                else if (lik.Klasa == "BORAC")
                {
                    DTOManager.izmeniBorca((MMORGP_Web_API.BoracBasic)lik);
                    return Ok();
                }
                else if (lik.Klasa == "CAROBNJAK")
                {
                    DTOManager.izmeniCarobnjaka((MMORGP_Web_API.CarobnjakBasic)lik);
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
