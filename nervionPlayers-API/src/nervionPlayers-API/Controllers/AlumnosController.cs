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
        /// Ruta: /alumnos
        /// Metodo que devuelve un IEnumerable de Alumnos
        /// </summary>
        /// <returns>IEnumerable de Alumnos</returns>
        [HttpGet]
        public IEnumerable<Alumnno> GetAlumnos()
        {
            //clsListadosAlumnosBL lista = new clsListadosAlumnosBL();

            //return lista.listadoAlumnosBL();
        }


        /// <summary>
        /// Ruta: /alumnos/id
        /// Metodo que devuelve un Alumno con la id especificada
        /// </summary>
        /// <returns>un Alumno</returns>
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
        /// Falta ponerle los parametros
        /// Dentro del metodo crear un nuevo alumno
        /// </summary>
        [HttpPost]
        public void PostAlumnos([FromBody] Alumno value)
        {

        }
        #endregion
        #region PUT
        /// <summary>
        /// Metodo que realiza la actualizacion de un Aumno
        /// Descomentar linea de encima del metodo
        /// Dentro del metodo hay que actualizar el Alumno
        /// </summary>
        /// <param name="idAlumno">Es el ID del Alumno que el usuario desea actualizar</param>
        [HttpPut("{id}")]
        public void PutAlumnos(int id, [FromBody]Alumno value)
        {

        }
        #endregion
        #region DELETE
        /// <summary>
        /// Metodo que borra un Alumno
        /// Descomentar linea de encima del metodo
        /// Falta meter funcionalidad del metodo
        /// </summary>
        /// <param name="idAlumno">El id del Alumno que el usuario desea borrar</param>
        [HttpDelete("{id}")]
        public void DeleteAlumnos(int id)
        {


        }
        #endregion  
    }
}
