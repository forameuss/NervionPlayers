using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NervionPlayers_BL.Manejadoras;
using NervionPlayers_BL;
using NervionPlayers_BL.Model;
using NervionPlayers_Ent.Modelos;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace nervionPlayers_API.Controllers
{
    [Route("api/[controller]")]
    public class ResultadosDuelosController : Controller
    {

        ManejadoraResultadoDueloBL manejaResDueloBL = new ManejadoraResultadoDueloBL();
        ListadosBL listaBL = new ListadosBL();

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
        public IEnumerable<ResultadoDuelo> GetResultadosDuelos()
        {
            return listaBL.listadoResultadoDuelosBL();
        }

        /// <summary>
        /// Metodo que devuelve el resultado de un duelo en concreto
        /// </summary>
        /// <param name="id">Codigo del duelo concreto</param>
        [HttpGet("{id}")]
        public ResultadoDuelo GetResultadoDuelo(int id)
        {

            ResultadoDuelo resDuelo = new ResultadoDuelo();

            resDuelo = manejaResDueloBL.obtenerResultadoDuelo(id);

            if (resDuelo == null)
            {
                Response.StatusCode = 404; //Not found
            }

            return resDuelo;
        }
        #endregion

        #region POST
        /// <summary>
        /// Metodo que crea un nuevo resultado para un duelo
        /// </summary>
        /// <param name="value">Valor del resultado de un duelo nuevo </param>
        [HttpPost]
        public void PostResultadoDuelo([FromBody] ResultadoDuelo value)
        {
            int filas = 0;
            try
            {

                filas = manejaResDueloBL.insertarResultadoDuelo(value);

            }
            catch (InvalidValueException e)
            {
                Response.StatusCode = 400; //Bad request
            }

            //filas=1 exito //esto se puede quitar cuando envien la excepcion
            if (filas < 1) {
                Response.StatusCode = 400; //Bad request
            }
        }
        #endregion

        #region PUT
        /// <summary>
        /// Metodo que actualiza un resultado de un duelo concreto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void PutResultadoDuelo(int id, [FromBody]ResultadoDuelo value)
        {
            //comprobar que el id existe (devuelven filas afectadas)

            ResultadoDuelo resDuelo = manejaResDueloBL.obtenerResultadoDuelo(value.Id);

            if (resDuelo == null)
            {
                Response.StatusCode = 404; //Not found
            }
            else
            {
                try
                {

                    manejaResDueloBL.actualizarResultadoDuelo(value);

                }
                catch (InvalidValueException e)
                {
                    Response.StatusCode = 400; //Bad request
                }
                
            }
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Metodo que borra un resultado de un duelo
        /// </summary>
        /// <param name="id">Id del resultado del duelo que desea el usuario borrar</param>
        [HttpDelete("{id}")]
        public void DeleteResultadoDuelo(int id)
        {
            //avisar de que se ha borrado con exito (filasAfectadas=1)
            int filas = manejaResDueloBL.borrarResultadoDuelo(id);
            if (filas < 1) { Response.StatusCode = 404; } //Not found
        }
        #endregion
    }
}
