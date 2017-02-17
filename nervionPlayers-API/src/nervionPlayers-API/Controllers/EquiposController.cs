using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NervionPlayers_BL;
using NervionPlayers_BL.Manejadoras;
using NervionPlayers_Ent.Modelos;
using NervionPlayers_BL.Model;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace nervionPlayers_API.Controllers
{

    [Route("api/[controller]")]
    public class EquiposController : Controller
    {
        ListadosBL lista = new ListadosBL();
        ManejadoraEquipoBL manejadoraEquipos = new ManejadoraEquipoBL();

        // GET: NP
        public ActionResult Index()
        {
            return View();
        }
        #region GET
        /// <summary>
        /// Metodo que devuelve un listado con todos los equipos
        /// </summary>
        /// <returns>Devuelve un listado de equipos</returns>
        [HttpGet]
        public IEnumerable<Equipo> GetEquipos()
        {
            return lista.listadoEquiposBL();
        }
        /// <summary>
        /// Metodo que devuelve un equipo concreto
        /// </summary>
        /// <param name="id">Identificador del equipo concreto</param>
        /// <returns>Devuelve un equipo concreto</returns>
        [HttpGet("{id}")]
        public Equipo GetEquipo(int id)
        {

            Equipo equipo = new Equipo();

            equipo = manejadoraEquipos.obtenerEquipo(id);

            if (equipo == null)
            {
                Response.StatusCode = 404; //Not found
            }

            return equipo;
        }
        #endregion

        #region POST
        /// <summary>
        /// Metodo que crea un nuevo equipo
        /// </summary>
        /// <param name="value">Valores del Json para la creacion del nuevo usuario</param>
        [HttpPost]
        public void PostEquipos([FromBody] Equipo value)
        {
            int filas = 0;

            try
            {

                filas = manejadoraEquipos.insertarEquipo(value);

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
        /// Metodo que realiza la actualizacion de un Equipo
        /// Descomentar linea de encima del metodo
        /// Dentro del metodo hay que actualizar el Equipo
        /// </summary>
        /// <param name="idEquipo">Es el ID del Partido que el usuario desea actualizar</param>
        [HttpPut("{id}")]
        public void PutEquipos([FromBody]Equipo value)
        {
            Equipo equipo = manejadoraEquipos.obtenerEquipo(value.Id);

            if (equipo == null)
            {
                Response.StatusCode = 404; //Not found
            }
            else
            {
                try
                {

                    manejadoraEquipos.actualizarEquipo(value);

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
        /// Metodo que borra un Equipo 
        /// Descomentar linea de encima del metodo
        /// Falta meter la funcionalidad del metodo
        /// </summary>
        /// <param name="id">El Id del Equipo que el usuario desea borrar</param>
        [HttpDelete("{id}")]
        public void DeleteEquipos(int id)
        {
            int filas = manejadoraEquipos.borrarEquipo(id);
            if (filas < 1) { Response.StatusCode = 404; } //Not found
        }
        #endregion

        #region METODOS PARA LA TABLA ALUMNOSEQUIPOS
        /// <summary>
        ///  Metodo que devuelve un grupo de alumnos pertenecientes a un equipo concreto con la idEquipo
        /// </summary>
        /// <param name="id">Identificador del grupo </param>
        /// <returns>Devuelve la informacion los alumnos que estan en ese equipo</returns>
        
        //Comprobar si nos lleva a la ruta directamente
        [HttpGet("{id}/Alumnos")]
        public IEnumerable<Alumno> GetAlumnosEquipo(int id)
        {
            return lista.listadoAlumnosBL(id);
       }

        
        /// <summary>
        /// Metodo que devuelve un grupo de partidos en los que ha participado un equipo
        /// </summary>
        /// <param name="id">Id del equipo</param>
        /// <returns>Devuelve los partidos que ha jugado un equipo</returns>
        [HttpGet("{id}/Partidos")]
        public IEnumerable<Partido> GetPartidosEquipo(int id)
        {

            return lista.listadoPartidosBL(id);
        }
        
        #endregion
    }
}
