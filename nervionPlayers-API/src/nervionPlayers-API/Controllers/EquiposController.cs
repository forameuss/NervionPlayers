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
        #region GETs
        /// <summary>
        /// Ruta: /equipos
        /// Metodo que devuelve un IEnumerable de equipos
        /// </summary>
        /// <returns>IEnumerable de equipos</returns>
        [HttpGet]
        public IEnumerable<Equipo> GetEquipos()
        {
            return null;
        }

        //  /equipos/{id }

        /// <summary>
        /// Ruta: /equipos/id
        /// Metodo que devuelve un Equipo con la id especificada
        /// </summary>
        /// <returns>un Equipo</returns>
        [HttpGet("{id}")]
        public Equipo GetEquipo(int id)
        {

            return null;
        }
        #endregion
        #region POST
        /// Metodo que crea un nuevo equipo
        /// Falta ponerle los parametros
        /// Dentro del metodo crear un nuevo equipo
        /// </summary>
        /// <param name=""></param>
        [HttpPost]
        public void PostEquipos([FromBody] Equipo value)
        {

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

        }
        #endregion
        #region DELETE
        /// <summary>
        /// Metodo que borra un Equipo 
        /// Descomentar linea de encima del metodo
        /// Falta meter la funcionalidad del metodo
        /// </summary>
        /// <param name="idEquipo">El Id del Equipo que el usuario desea borrar</param>
        [HttpDelete("{id}")]
        public void DeleteEquipos(int id)
        {


        }
        #endregion
        #region METODOS PARA LA TABLA ALUMNOSEQUIPOS
        //equipo / id / alumno
        /// <summary>
        /// Ruta: /equipos/{idEquipo}/alumno
        /// Metodo que devuelve un grupo de alumnos pertenecientes a un equipo concreto con la idEquipo
        /// </summary>
        /// <returns>IEnumerable<Alumnnos></returns>
        /// 
        //Comprobar si nos lleva a la ruta directamente a 
        [HttpGet("{id}"),ActionName("Alumnos")]
        public IEnumerable<Alumnno> GetAlumnosEquipo(int id)
        {

            //if (alumnoEquipo != null)
            //{
            //    return new ObjectResult(alumnoEquipo);
            //}
            //else {
            //    return Not Found();
            //}

            return null;
        }


        //Hace referencia a la tabla AlumnosGrupos

        //alumno / id / equipo
        /// <summary>
        /// Ruta: /alumnos/{idAlumno}/equipo
        /// Metodo que devuelve un grupo de equipos a los que pertenece un alumno
        /// se pasa el idAlumno
        /// </summary>
        /// <returns>IEnumerable<Equipos></returns>
        [HttpGet("{id}"), ActionName("Equipos")]
        public IEnumerable<Equipo> GetEquiposAlumno(int id)
        {

            return null;
        }

        //equipo / id / partidos
        /// <summary>
        /// Ruta: /equipo/{idEquipo}/partidos
        /// Metodo que devuelve un grupo de partidos en los que ha participado un equipo
        /// se pasa el idEquipo
        /// </summary>
        /// <returns>IEnumerable<Partidos></returns>
        [HttpGet("{id}"), ActionName("Partidos")]
        public IEnumerable<Partido> GetPartidosEquipo(int id)
        {

            return null;
        }


        //alumno / id / duelos
        /// <summary>
        /// Ruta: /alumno/{idAlumno}/duelos
        /// Metodo que devuelve un grupo de duelos en los que ha participado un alumno
        /// se pasa el idAlumno
        /// </summary>
        /// <returns>IEnumerable<Duelos></returns>
        [HttpGet("{id}"), ActionName("Duelos")]
        public IEnumerable<Duelo> GetDuelosAlumno(int id)
        {

            return null;
        }

        #endregion
    }
}
