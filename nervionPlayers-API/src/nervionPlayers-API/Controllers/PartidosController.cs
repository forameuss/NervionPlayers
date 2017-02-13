using Microsoft.AspNetCore.Mvc;
using NervionPlayers_BL;
using NervionPlayers_BL.Manejadoras;
using NervionPlayers_BL.Model;
using NervionPlayers_Ent.Modelos;
using System.Collections.Generic;


namespace ControllersNP.Controllers
{
    [Route("api/[controller]")]
    public class PartidosController : Controller
    {

        ManejadoraPartidoBL manejaPartBL = new ManejadoraPartidoBL();
        ListadosBL listaBL = new ListadosBL();
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

            return listaBL.listadoPartidosBL();
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
            Partido Part = new Partido();

            Part = manejaPartBL.obtenerPartido(id);

            if (Part == null)
            {
                Response.StatusCode = 404; //Not found
            }

            return Part;
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
            int filas = 0;

            try
            {
              filas = manejaPartBL.insertarPartido(value);
            }
            catch (InvalidValueException e)
            {

                Response.StatusCode = 400; //Bad request
            }

            //quitar esto cuando la DAL nos lance el error
            if (filas < 1)
            {
                Response.StatusCode = 400; //Bad request
            }

        }

        #endregion

        #region PUT

        /// <summary>
        /// Metodo que realiza la actualizacion de un Partido
        /// Descomentar linea de encima del metodo
        /// Dentro del metodo hay que actualizar el Partido
        /// </summary>
        /// <param name="id">Es el ID del Partido que el usuario desea actualizar</param>
    //    [HttpPut("{id}")]
        [HttpPut]
        public void PutPartidos([FromBody] Partido value)
        {
            //comprobar que el id existe (devuelven filas afectadas)
            manejaPartBL.actualizarPartido(value);

            Partido resP = manejaPartBL.obtenerPartido(value.Id);

            if (resP == null)
            {
                Response.StatusCode = 404; //Not found
            }
            else
            {
                manejaPartBL.actualizarPartido(value);
            }
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
            //avisar de que se ha borrado con exito (filasAfectadas=1)
            int filas =   manejaPartBL.borrarPartido(id);
            if (filas < 1) { Response.StatusCode = 404; } //Not found

        }

        #endregion
    }
}