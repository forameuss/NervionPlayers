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
    [Route("api/[controller]")]
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
        public ResultadoPartido GetresultadoPartido(int id)
        {
            ResultadoPartido resPart = new ResultadoPartido();

            resPart = manejaResPartBL.obtenerResultadoPartido(id);

            if (resPart == null)
            {
                Response.StatusCode = 404; //Not found
            }

            return resPart;
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
           int filas = 0;
            
            try {

            filas =  manejaResPartBL.insertarResultadoPartido(value);

            } catch (InvalidValueException e) {
                           
               Response.StatusCode = 400; //Bad request
            }

            //quitar esto cuando la DAL nos lance el error
            if (filas < 1) {
                Response.StatusCode = 400; //Bad request
            }
           
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
           ResultadoPartido resP =  manejaResPartBL.obtenerResultadoPartido(value.Id);

            if (resP == null) {
                Response.StatusCode = 404; //Not found
            } else {
                manejaResPartBL.actualizarResultaoPartido(value);
            }

            
            
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
            int filas = manejaResPartBL.borrarResultadoPartido(id);
            if (filas < 1) { Response.StatusCode = 404; } //Not found
        }


        #endregion

    }
}
