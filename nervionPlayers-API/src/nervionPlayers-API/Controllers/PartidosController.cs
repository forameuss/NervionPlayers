using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace ControllersNP.Controllers
{
    [Route("api/[controller]")]
    public class PartidosController : Controller
    {
        // GET: Partidos
        public ActionResult Index()
        {
            return View();
        }

        #region GET

        //  /partidos

        /// <summary>
        /// Ruta: /partidos
        /// Metodo que devuelve un IEnumerable de Partidos
        /// </summary>
        /// <returns>IEnumerable de Partidos</returns>
        [HttpGet]
        public IEnumerable<Partido> GetPartidos()
        {
            return null;
        }

        //  /partidos/{id}

        /// <summary>
        /// Ruta: /partidos/id
        /// Metodo que devuelve un partido con la id especificada
        /// </summary>
        /// <returns>un Partido</returns>
        [HttpGet("{id}")]
        public Partido GetPartido()
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
        /// Metodo que crea un nuevo Partido
        /// Falta ponerle los parametros
        /// Dentro del metodo crear un nuevo Partido
        /// </summary>
        [HttpPost]
        public void PostPartidos()
        {

        }

        #endregion

        #region PUT

        /// <summary>
        /// Metodo que realiza la actualizacion de un Partido
        /// Descomentar linea de encima del metodo
        /// Dentro del metodo hay que actualizar el Partido
        /// </summary>
        /// <param name="idPartido">Es el ID del Partido que el usuario desea actualizar</param>
        //[HttpPut("{idPartido}")]
        public void PutPartidos(int idPartido)
        {

        }

        #endregion

        #region DELETE

        /// <summary>
        /// Metodo que borra un Partido
        /// Descomentar linea de encima del metodo
        /// Falta meter funcionalidad del metodo
        /// </summary>
        /// <param name="idPartido">El id del Partido que el usuario desea borrar</param>
        //[HttpDelete("{idPartido}")]
        public void DeletePartidos(int idPartido)
        {


        }

        #endregion
    }
}