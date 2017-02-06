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

        /// <summary>
        /// Metodo que devuelve un listado de Partidos
        /// </summary>
        /// <returns>Devuelve un listado de partidos</returns>
        [HttpGet]
        public IEnumerable<Partido> GetPartidos()
        {
           // List<Partido> partidos = new clsManejadoraPartidoBL().getPartidosBL();

            //if (partidos != null)
            //{
            //    return new ObjectResult(partidos);
            //}
            //else
            //{
            //    return NotFound();
            //}

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
            // Partido  partido= new clsManejadoraPartidoBL().getPartidoBL(id);

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
        public void PostPartidos([FromBody] Partido value)
        {
            //clsManejadoraPartidoBL manejadoraBL = new clsManejadoraPartidoBL();
            //manejadoraBL.postPartidoBL(value);

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
            //clsManejadoraPartidoBL manejadoraBL = new clsManejadoraPartidoBL();
            //manejadoraBL.putPartidoBL(value);
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
            //clsManejadoraPartidoBL manejadoraBL = new clsManejadoraPartidoBL();
            //manejadoraBL.deletePartidoBL(id);

        }

        #endregion
    }
}