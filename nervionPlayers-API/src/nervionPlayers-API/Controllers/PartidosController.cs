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
        public Partido GetPartido(int id)
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
        public void PostPartidos([FromBody] Duelo value)
        {

        }

        #endregion

        #region PUT

        /// <summary>
        /// Metodo que realiza la actualizacion de un Partido
        /// Descomentar linea de encima del metodo
        /// Dentro del metodo hay que actualizar el Partido
        /// </summary>
        /// <param name="id">Es el ID del Partido que el usuario desea actualizar</param>
        [HttpPut("{id}")]
        public void PutPartidos(int id, [FromBody]Duelo value)
        {

        }

        #endregion

        #region DELETE

        /// <summary>
        /// Metodo que borra un Partido
        /// Descomentar linea de encima del metodo
        /// Falta meter funcionalidad del metodo
        /// </summary>
        /// <param name="id">El id del Partido que el usuario desea borrar</param>
        [HttpDelete("{id}")]
        public void DeletePartidos(int id)
        {


        }

        #endregion
    }
}