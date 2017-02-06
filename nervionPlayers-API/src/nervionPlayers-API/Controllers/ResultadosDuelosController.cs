using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace nervionPlayers_API.Controllers
{
    public class ResultadosDuelosController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        #region GET
        /// <summary>
        /// Metodo que devuelve el resultado de todos los duelos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ResultadosDuelos> GetResultadosDuelos()
        {
            return null;
        }

        /// <summary>
        /// Metodo que devuelve el resultado de un duelo en concreto
        /// </summary>
        /// <param name="id">Codigo del duelo concreto</param>
        [HttpGet("{id}")]
        public ResultadosDuelos GetResultadosDuelos(int id)
        {

            //if (partido != null)
            //{
            //    return new ObjectResult(partido);
            //}
            //else {
            //    return Not Found();
            //}
            return null;
        }
        #endregion

        #region POST
        /// <summary>
        /// Metodo que crea un nuevo resultado para un duelo
        /// </summary>
        /// <param name="value">Valor del resultado de un duelo nuevo </param>
        [HttpPost]
        public void PostResultadosDuelos([FromBody] ResultadosDuelos value)
        {
            // new clsManejadoraResultadosDuelosBL().insertResultadosDuelosBL(value);
        }
        #endregion

        #region PUT
        /// <summary>
        /// Metodo que actualiza un resultado de un duelo concreto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void PutResultadosDuelos(int id, [FromBody]ResultadosDuelos value)
        {

        }
        #endregion

        #region DELETE
        /// <summary>
        /// Metodo que borra un resultado de un duelo
        /// </summary>
        /// <param name="id">Id del resultado del duelo que desea el usuario borrar</param>
        [HttpDelete("{id}")]
        public void DeleteResultadosDuelos(int id)
        {
            //clsManejadoraResultadosDuelosBL manejadora = new clsManejadoraResultadosDuelosBL();
            //manejadora.deleteEquipoBLConfirmar(id);
        }
        #endregion
    }
}
