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
            Alumno alumno = new Alumno();

            alumno = manejadoraAlumnos.obtenerAlumno(id);

            if (alumno == null)
            {
                Response.StatusCode = 404; //Not found
            }
            return alumno;
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
            int filas = 0;

            try
            {

                filas = manejadoraAlumnos.insertarAlumno(value);

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
        /// Metodo que actualiza un Alumno
        /// </summary>
        /// <param name="id">Id del Alumno que el usuario desea actualizar</param>
        /// <param name="value">Valores para la actualizacion del usuario</param>
        [HttpPut("{id}")]
        public void PutAlumnos([FromBody]Alumno value)
        {
            Alumno alumno = manejadoraAlumnos.obtenerAlumno(value.Id);

            if (alumno == null)
            {
                Response.StatusCode = 404; //Not found
            }
            else
            {
                manejadoraAlumnos.actualizarAlumno(value);
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
            int filas = manejadoraAlumnos.borrarAlumno(id);
            if (filas < 1) { Response.StatusCode = 404; } //Not found

        }
        #endregion

        #region Metodos para la tabla alumnosDuelos

        //Hace referencia a la tabla AlumnosGrupos
        /// <summary>
        /// Metodo que devuelve un grupo de equipos a los que pertenece un alumno
        /// </summary>
        /// <param name="id">Identificador del alumno</param>
        /// <returns>Devuelve los equipos o equipo a los que pertenece el alumno</returns>
        [HttpGet("{id}/Equipos")]
        public IEnumerable<Equipo> GetEquiposAlumno(int id)
        {
            return listado.listadoEquiposBL(id);
        }


        /// <summary>
        ///  Metodo que devuelve un grupo de duelos en los que ha participado un alumno
        /// </summary>
        /// <param name="id">El id del Alumno</param>
        /// <returns>Devulve los duelos en los que ha participado un alumno</returns>
        [HttpGet("{id}/Duelos")]
        public IEnumerable<Duelo> GetDuelosAlumno(int id)
        {
            return listado.listadoDuelosBL(id);
        }

        #endregion
    }
}
