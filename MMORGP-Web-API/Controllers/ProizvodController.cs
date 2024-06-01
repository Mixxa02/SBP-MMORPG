﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using MMORGP_Web_API;

namespace MMORGP_Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProizvodController : ControllerBase
    {
        [HttpGet(Name = "GetProizvodi")]
        public IEnumerable<ProizvodPregled> Get()
        {
            return DTOManager.vratiProizvode().ToArray();
        }

        [HttpDelete(Name = "DeleteProizvod")]
        public ActionResult Delete(string naziv)
        {
            try
            {
                DTOManager.obrisiProizvod(naziv);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost(Name = "AddProizvod")]
        public ActionResult Post(ProizvodBasic pro, string tipProizvoda, int poeni)
        {
            try
            {
                DTOManager.sacuvajProizvod(pro, tipProizvoda, poeni);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut(Name = "UpdateProizvod")]
        public async Task<ActionResult> Put(ProizvodBasic proizvod, string naziv)
        {
            try
            {
                if (proizvod.Tip == "OKLOP")
                {
                    DTOManager.izmeniOklop((MMORGP_Web_API.OklopBasic)proizvod, naziv);
                    return Ok();
                }
                else
                {
                    DTOManager.izmeniOruzje((MMORGP_Web_API.OruzjeBasic)proizvod, naziv);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
