using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace nervionPlayers_API.Controllers
{
    //CAMBIAR
   // [Route("api/[controller]")]
    public class AlumnosController : Controller
    {
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        #region GETs
        /// <summary>
        /// Metodo que devuelve un listado de todos los alumnos
        /// </summary>
        /// <returns>Listado de todos los alumnos</returns>
        [HttpGet]
        public IEnumerable<Alumno> GetAlumnos()
        {
            //clsListadosAlumnosBL lista = new clsListadosAlumnosBL();

            //return lista.listadoAlumnosBL();
        }


        /// <summary>
        /// Metodo que obtiene la informacion de un alumno concreto
        /// </summary>
        /// <param name="id">Identificador del alumno</param>
        /// <returns>Devuelve un alumno concreto</returns>
        [HttpGet("{id}")]
        public Alumno GetAlumno(int id)
        {

            //if (alumno != null)
            //{
            //    return new ObjectResult(alumno);
            //}
            //else {
            //    return Not Found();
            //}

            return null;
        }
        #endregion
        #region POST
        /// <summary>
        /// Metodo que crea un nuevo alumno
        /// </summary>
        /// <param name="value">Valores para la creacion del nuevo alumno</param>
        [HttpPost]
        public void PostAlumnos([FromBody] Alumno value)
        {

        }
        #endregion
        #region PUT
        /// <summary>
        /// Metodo que actualiza un Alumno
        /// </summary>
        /// <param name="id">Id del Alumno que el usuario desea actualizar</param>
        /// <param name="value">Valores para la actualizacion del usuario</param>
        [HttpPut("{id}")]
        public void PutAlumnos(int id, [FromBody]Alumno value)
        {

        }
        #endregion
        #region DELETE
        /// <summary>
        /// Metodo que elimina un Alumno
        /// </summary>
        /// <param name="id">Id del Alumno que el usuario desea eliminar</param>
        [HttpDelete("{id}")]
        public void DeleteAlumnos(int id)
        {


        }
        #endregion  
    }
}
