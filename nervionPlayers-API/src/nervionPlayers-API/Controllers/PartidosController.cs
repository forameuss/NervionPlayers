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
        public ObjectResult GetPartido(int id)
        {
            ObjectResult res;
            Partido Part = new Partido();

            Part = manejaPartBL.obtenerPartido(id);

            if (Part != null)
            {
                res = new ObjectResult(Part);
            }
            else
            {
                res = new ObjectResult(NotFound());
            }

            return res;
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
            int filas;
            try
            {

                filas = manejaPartBL.insertarPartido(value);

            }
            catch (InvalidValueException e)
            {
                //devolver el error
            }

            //filas=1 exit

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
            manejaPartBL.borrarPartido(id);

        }

        #endregion
    }
}