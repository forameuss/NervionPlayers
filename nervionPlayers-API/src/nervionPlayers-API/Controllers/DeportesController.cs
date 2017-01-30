using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ControllersNP.Controllers
{
    [Route("api/[controller]")]
    public class DeportesController : Controller
    {



        // GET: Deportes
        public ActionResult Index()
        {
            return View();
        }

        #region GETs

        //  /deportes

        /// <summary>
        /// Ruta: /deportes
        /// Metodo que devuelve un IEnumerable de Deportes
        /// </summary>
        /// <returns>IEnumerable de Deportes</returns>
        [HttpGet]
        public IEnumerable<Deporte> GetDeportes()
        {
            return null;
        }

        //  /deportes/{id}

        /// <summary>
        /// Ruta: /deportes/id
        /// Metodo que devuelve un deporte con la id especificada
        /// </summary>
        /// <returns>un Deporte</returns>
        [HttpGet("{id}")]
        public Deporte GetDeporte()
        {

            //if (deporte != null)
            //{
            //    return new ObjectResult(deporte);
            //}
            //else {
            //    return Not Found();
            //}

            return null;
        }

        #endregion

        #region POST
        /// <summary>
        /// Metodo que crea un nuevo Deporte
        /// Falta ponerle los parametros
        /// Dentro del metodo crear un nuevo Deporte
        /// </summary>
        [HttpPost]
        public void PostDeportes()
        {

        }
        #endregion

        #region PUT
        /// <summary>
        /// Metodo que realiza la actualizacion de un Deporte
        /// Descomentar linea de encima del metodo
        /// Dentro del metodo hay que actualizar el Deporte
        /// </summary>
        /// <param name="idDeporte">Es el ID del Deporte que el usuario desea actualizar</param>
        //[HttpPut("{idDeporte}")]
        public void PutDeportes(int idDeporte)
        {

        }
        #endregion

        #region DELETE
        /// <summary>
        /// Metodo que borra un Deporte
        /// Descomentar linea de encima del metodo
        /// Falta meter funcionalidad del metodo
        /// </summary>
        /// <param name="idDeporte">El id del Deporte que el usuario desea borrar</param>
        //[HttpDelete("{idDeporte}")]
        public void DeleteDeportes(int idDeporte)
        {


        }
        #endregion

    }
}