using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace nervionPlayers_API.Controllers
{
    public class ResultadosPartidosController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        #region GET
        /// <summary>
        /// Ruta: /resultadosPartidos
        /// Metodo que devuelve un IEnumerable de resultadosPartidos
        /// </summary>
        /// <returns>IEnumerable de resultadosPartidos</returns>
        [HttpGet]
        public IEnumerable<ResultadosPartidos> GetResultadosPartidos()
        {
            return null;
        }
        /// <summary>
        /// Metodo que devuelve el resultado de un partido concreto
        /// </summary>
        /// <param name="id">Identificador del resultado del partido</param>
        /// <returns>Devuelve el resultado del partido</returns>
        [HttpGet("{id}")]
        public ResultadosPartidos GetresultadosPartidos(int id)
        {

            //if (resultadosPartidos != null)
            //{
            //    return new ObjectResult(resultadosPartidos);
            //}
            //else {
            //    return Not Found();
            //}

            return null;
        }

        #endregion

        #region POST

        /// <summary>
        /// Metodo que crea un nuevo resultado de un partido
        /// </summary>
        /// <param name="value">Valores referentes al nuevo resultado</param>
        [HttpPost]
        public void PostResultadosPartidos([FromBody] ResultadosPartidos value)
        {
            //clsManejadoraResultadosPartidosBL manejadoraBL = new clsManejadoraResultadosPartidosBL();
            //manejadoraBL.postResultadosPartidosBL(value);
        }

        #endregion

        #region PUT
        /// <summary>
        /// Metodo que actualiza el resultado de un partido concreto
        /// </summary>
        /// <param name="id">Identificador del resultado del partido</param>
        /// <param name="value">Valores que pasa el usuario para actualizar el resultado del partido</param>
        [HttpPut("{id}")]
        public void PutResultadosPartidos(int id, [FromBody]ResultadosPartidos value)
        {
            //clsManejadoraResultadosPartidosBL manejadoraBL = new clsManejadoraResultadosPartidosBL();
            //manejadoraBL.putResultadosPartidosBL(value);
        }

        #endregion

        #region DELETE

        /// <summary>
        /// Metodo que borra un resultado concreto
        /// </summary>
        /// <param name="id">Identificador del partido que el usuario desea borrar</param>
        [HttpDelete("{id}")]
        public void DeleteResultadosPartidos(int id)
        {
            //clsManejadoraResultadosPartidosBL manejadoraBL = new clsManejadoraResultadosPartidoBsL();
            //manejadoraBL.deleteResultadosPartidosBL(id);
        }


        #endregion

    }
}
