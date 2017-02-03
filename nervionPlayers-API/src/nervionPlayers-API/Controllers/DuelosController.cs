using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControllersNP.Controllers
{
    [Route("api/[controller]")]
    public class DuelosController : Controller
    {
        // GET: Duelos
        public ActionResult Index()
        {
            return View();
        }

        #region GET

        //  /duelos

        /// <summary>
        /// Ruta: /duelos
        /// Metodo que devuelve un IEnumerable de Duelos
        /// </summary>
        /// <returns>IEnumerable de Duelos</returns>
        [HttpGet]
        public IEnumerable<Duelo> GetDuelos()
        {
            return null;
        }

        //  /duelos/{id}

        /// <summary>
        /// Ruta: /duelos/id
        /// Metodo que devuelve un Duelo con la id especificada
        /// </summary>
        /// <returns>un Duelo</returns>
        [HttpGet("{id}")]
        public Duelo GetDuelo(int id)
        {

            //if (duelo != null)
            //{
            //    return new ObjectResult(duelo);
            //}
            //else {
            //    return Not Found();
            //}

            return null;
        }

        #endregion
        #region POST

        /// <summary>
        /// Metodo que crea un nuevo Duelo
        /// Falta ponerle los parametros
        /// Dentro del metodo crear un nuevo Duelo
        /// </summary>
        [HttpPost]
        public void PostDuelos([FromBody] Duelo value)
        {

        }
        #endregion
        #region PUT

        /// <summary>
        /// Metodo que realiza la actualizacion de un Duelo
        /// Descomentar linea de encima del metodo
        /// Dentro del metodo hay que actualizar el Duelo
        /// </summary>
        /// <param name="id">Es el ID del Duelos que el usuario desea actualizar</param>
        [HttpPut("{id}")]
        public void PutDuelos(int id, [FromBody]Duelo value)
        {

        }

        #endregion
        #region DELETE

        /// <summary>
        /// Metodo que borra un Duelo
        /// Descomentar linea de encima del metodo
        /// Falta meter funcionalidad del metodo
        /// </summary>
        /// <param name="idDuelo">El id del Duelo que el usuario desea borrar</param>
        [HttpDelete("{id}")]
        public void DeleteDuelos(int id)
        {


        }

        #endregion
    }
}