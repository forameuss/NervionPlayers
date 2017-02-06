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
        /// <summary>
        ///  Metodo que devuelve todos los Duelos que se han llevado a cabo
        /// </summary>
        /// <returns>Deuelve una lista de todos los Duelos</returns>
        [HttpGet]
        public IEnumerable<Duelo> GetDuelos()
        {
            return null;
        }

        /// <summary>
        /// Metodo que devuelve un duelo concreto
        /// </summary>
        /// <param name="id">Id del duelo</param>
        /// <returns>Devuelve un duelo concreto</returns>
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
        /// Metodo que crea un nuevo duelo
        /// </summary>
        /// <param name="value">Valores para la creacion de un nuevo duelo</param>
        [HttpPost]
        public void PostDuelos([FromBody] Duelo value)
        {

        }
        #endregion

        #region PUT
        /// <summary>
        /// Metodo que actualiza un duelo
        /// </summary>
        /// <param name="id">Id del duelo que el usuario desea actualizar</param>
        /// <param name="value">Valores que el usuario quiere actualizar</param>
        [HttpPut("{id}")]
        public void PutDuelos(int id, [FromBody]Duelo value)
        {

        }

        #endregion

        #region DELETE

        /// <summary>
        /// Metodo que elimina un duelo
        /// </summary>
        /// <param name="id">Id del duelo que el usuario desea borrar</param>
        [HttpDelete("{id}")]
        public void DeleteDuelos(int id)
        {


        }

        #endregion
    }
}