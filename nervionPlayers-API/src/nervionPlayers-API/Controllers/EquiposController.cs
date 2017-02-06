using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace nervionPlayers_API.Controllers
{
    //    [Route("api/[controller]")]
    public class EquiposController : Controller
    {
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
            //clsListadosEquiposBL lista = new clsListadosEquiposBL();

            //return lista.listadoEquiposBL();
        }
        /// <summary>
        /// Metodo que devuelve un equipo concreto
        /// </summary>
        /// <param name="id">Identificador del equipo concreto</param>
        /// <returns>Devuelve un equipo concreto</returns>
        [HttpGet("{id}")]
        public Equipo GetEquipo(int id)
        {
            // team = new clsManejadoraEquipoBL().getEquipoBL(id);

            //if (team != null)
            //{
            //    return new ObjectResult(team);
            //}
            //else
            //{
            //    return NotFound();
            //}
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
           // new clsManejadoraEquiposBL().insertEquipoBL(value);
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
        public void PutEquipos(int id, [FromBody]Equipo value)
        {
           // new clsManejadoraEquipo().updateEquipoBL(value);
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
            //clsManejadoraEquipoBL manejadora = new clsManejadoraEquipoBL();
            //manejadora.deleteEquipoBLConfirmar(id);
        }
        #endregion

        #region METODOS PARA LA TABLA ALUMNOSEQUIPOS
        /// <summary>
        ///  Metodo que devuelve un grupo de alumnos pertenecientes a un equipo concreto con la idEquipo
        /// </summary>
        /// <param name="id">Identificador del grupo </param>
        /// <returns>Devuelve la informacion los alumnos que estan en ese equipo</returns>

        //Comprobar si nos lleva a la ruta directamente
        [HttpGet("{id}"),ActionName("Alumnos")]
        public IEnumerable<Alumnno> GetAlumnosEquipo(int id)
        {
            return null;
        }


        //Hace referencia a la tabla AlumnosGrupos
        /// <summary>
        /// Metodo que devuelve un grupo de equipos a los que pertenece un alumno
        /// </summary>
        /// <param name="id">Identificador del alumno</param>
        /// <returns>Devuelve los equipos o equipo a los que pertenece el alumno</returns>
        [HttpGet("{id}"), ActionName("Equipos")]
        public IEnumerable<Equipo> GetEquiposAlumno(int id)
        {

            return null;
        }

        /// <summary>
        /// Metodo que devuelve un grupo de partidos en los que ha participado un equipo
        /// </summary>
        /// <param name="id">Id del equipo</param>
        /// <returns>Devuelve los partidos que ha jugado un equipo</returns>
        [HttpGet("{id}"), ActionName("Partidos")]
        public IEnumerable<Partido> GetPartidosEquipo(int id)
        {

            return null;
        }


        /// <summary>
        ///  Metodo que devuelve un grupo de duelos en los que ha participado un alumno
        /// </summary>
        /// <param name="id">El id del Alumno</param>
        /// <returns>Devulve los duelos en los que ha participado un alumno</returns>
        [HttpGet("{id}"), ActionName("Duelos")]
        public IEnumerable<Duelo> GetDuelosAlumno(int id)
        {

            return null;
        }

        #endregion
    }
}
