using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Colpatria.SOAT.DAL;
using Colpatria.SOAT.BLL;

namespace Colpatria.SOAT.Api.Controllers
{
    public class PolizaController : Controller
    {
        /// <summary>
        /// realiza inyección de dependiencias al instancias las interfacez de polizas
        /// </summary>
        private IPolizaRepository _polizarepository;
        public PolizaController(IPolizaRepository polizapository)
        {
            _polizarepository = polizapository;
        }
        /// <summary>
        ///Obtiene los datos del suuario segun la placa
        /// </summary>
        /// <param name="placa"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Get(string placa)
        {
            var poliza = await _polizarepository.GetPolizaTomador(placa);
            return Ok(poliza);
        }
        /// <summary>
        /// Crea las polizas con validaciones segun la prueba
        /// </summary>
        /// <param name="poliza"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Post(PolizaTomadorViewModel poliza)
        {
            var result = await _polizarepository.Create(poliza);
            return Ok(result);
        }
    }
}
