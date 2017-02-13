using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NervionPlayers_Ent.Modelos;
using NervionPlayers_BL;
using NervionPlayers_DAL.Listado;
using NervionPlayers_BL.Manejadoras;
using NervionPlayers_BL.Model;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace nervionPlayers_API.Controllers
{
    //CAMBIAR
    [Route("api/[controller]")]
    public class AlumnosController : Controller
    {
        ListadosBL listado = new ListadosBL();
        ManejadoraAlumnoBL manejadoraAlumnos = new ManejadoraAlumnoBL();

        #region GETs
        /// <summary>
        /// Metodo que devuelve un listado de todos los alumnos
        /// </summary>
        /// <returns>Listado de todos los alumnos</returns>
        [HttpGet]
        public IEnumerable<Alumno> GetAlumnos()
        {
           return listado.listadoAlumnosBL();          
        }
        /// <summary>
        /// Metodo que obtiene la informacion de un alumno concreto
        /// </summary>
        /// <param name="id">Identificador del alumno</param>
        /// <returns>Devuelve un alumno concreto</returns>
        [HttpGet("{id}")]
        public Alumno GetAlumno(int id)
        {
            return manejadoraAlumnos.obtenerAlumno(id);
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
            try
            {
                manejadoraAlumnos.insertarAlumno(value);
            }
            catch (InvalidValueException invalido)
            {
                //Falta devolver error
            }
                     
        }
        #endregion
        #region PUT
        /// <summary>
        /// Metodo que actualiza un Alumno
        /// </summary>
        /// <param name="id">Id del Alumno que el usuario desea actualizar</param>
        /// <param name="value">Valores para la actualizacion del usuario</param>
        [HttpPut("{id}")]
        public void PutAlumnos([FromBody]Alumno value)
        {
            try
            {
                manejadoraAlumnos.actualizarAlumno(value);
            }
            catch(InvalidValueException invalido)
            {
                    //Devolver errr
            }
           
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
            try
            {
                manejadoraAlumnos.borrarAlumno(id);
            }
            catch (InvalidValueException invalido)
            {
                //Falta error
            }
            
        }
        #endregion  
    }
}
