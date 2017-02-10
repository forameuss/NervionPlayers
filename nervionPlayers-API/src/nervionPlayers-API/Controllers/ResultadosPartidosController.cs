using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NervionPlayers_Ent.Modelos;
using NervionPlayers_BL.Manejadoras;
using NervionPlayers_BL;
using NervionPlayers_BL.Model;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace nervionPlayers_API.Controllers
{
    public class ResultadosPartidosController : Controller
    {
        ManejadoraResultadoPartidoBL manejaResPartBL = new ManejadoraResultadoPartidoBL();
        ListadosBL listaBL = new ListadosBL();

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
        public IEnumerable<ResultadoPartido> GetResultadosPartidos()
        {
            return listaBL.listadoResultadoPartidosBL();
        }
        /// <summary>
        /// Metodo que devuelve el resultado de un partido concreto
        /// </summary>
        /// <param name="id">Identificador del resultado del partido</param>
        /// <returns>Devuelve el resultado del partido</returns>
        [HttpGet("{id}")]
        public ObjectResult GetresultadoPartido(int id)
        {
            ObjectResult res;
            ResultadoPartido resPart = new ResultadoPartido();

            resPart = manejaResPartBL.obtenerResultadoPartido(id);

            if (resPart != null)
            {
                res = new ObjectResult(resPart);
            }
            else
            {
                res =  new ObjectResult(NotFound());
            }

            return res;
        }

        #endregion

        #region POST

        /// <summary>
        /// Metodo que crea un nuevo resultado de un partido
        /// </summary>
        /// <param name="value">Valores referentes al nuevo resultado</param>
        [HttpPost]
        public void PostResultadoPartido([FromBody] ResultadoPartido value)
        {
            int filas;
            try {

              filas = manejaResPartBL.insertarResultadoPartido(value);

            } catch (InvalidValueException e) {
                //devolver el error
            }

            //filas=1 exito
           
        }

        #endregion

        #region PUT
        /// <summary>
        /// Metodo que actualiza el resultado de un partido concreto
        /// </summary>
        /// <param name="id">Identificador del resultado del partido</param>
        /// <param name="value">Valores que pasa el usuario para actualizar el resultado del partido</param>
      //  [HttpPut("{id}")]
        [HttpPut]
        public void PutResultadoPartido([FromBody]ResultadoPartido value) //(int id, [FromBody]ResultadoPartido value)
        {
            //comprobar que el id existe (devuelven filas afectadas)
            manejaResPartBL.actualizarResultaoPartido(value);
        }

        #endregion

        #region DELETE

        /// <summary>
        /// Metodo que borra un resultado concreto
        /// </summary>
        /// <param name="id">Identificador del partido que el usuario desea borrar</param>
        [HttpDelete("{id}")]
        public void DeleteResultadoPartido(int id)
        {   //avisar de que se ha borrado con exito (filasAfectadas=1)
            manejaResPartBL.borrarResultadoPartido(id);
        }


        #endregion

    }
}
