using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace nervionPlayers_API.Models
{
    public class NPController : Controller
    {
        // GET: NP
        public ActionResult Index()
        {
            return View();
        }

        #region METODOS POST

        /// <summary>
        /// Metodo que crea un nuevo equipo
        /// Falta ponerle los parametros
        /// Dentro del metodo crear un nuevo equipo
        /// </summary>
        /// <param name=""></param>
        [HttpPost]
        public void PostEquipos()
        {

        }
        /// <summary>
        /// Metodo que crea un nuevo alumno
        /// Falta ponerle los parametros
        /// Dentro del metodo crear un nuevo alumno
        /// </summary>
        [HttpPost]
        public void PostAlumnos()
        {

        }
        /// <summary>
        /// Metodo que crea un nuevo Partido
        /// Falta ponerle los parametros
        /// Dentro del metodo crear un nuevo Partido
        /// </summary>
        [HttpPost]
        public void PostPartidos()
        {

        }
        /// <summary>
        /// Metodo que crea un nuevo Duelo
        /// Falta ponerle los parametros
        /// Dentro del metodo crear un nuevo Duelo
        /// </summary>
        [HttpPost]
        public void PostDuelos()
        {

        }
        /// <summary>
        /// Metodo que crea un nuevo Deporte
        /// Falta ponerle los parametros
        /// Dentro del metodo crear un nuevo Deporte
        /// </summary>
        [HttpPost]
        public void PostDeportes()
        {

        }
        #endregion
        #region  METODOS PUT
        /// <summary>
        /// Metodo que realiza la actualizacion de un Equipo
        /// Descomentar linea de encima del metodo
        /// Dentro del metodo hay que actualizar el Equipo
        /// </summary>
        /// <param name="idEquipo">Es el ID del Partido que el usuario desea actualizar</param>
        //[HttpPut("{idEquipo}")]
        public void PutEquipos(int idEquipo)
        {

        }

        /// <summary>
        /// Metodo que realiza la actualizacion de un Aumno
        /// Descomentar linea de encima del metodo
        /// Dentro del metodo hay que actualizar el Alumno
        /// </summary>
        /// <param name="idAlumno">Es el ID del Alumno que el usuario desea actualizar</param>
        //[HttpPut("{idAlumno}")]
        public void PutAlumnos(int idAlumno)
        {

        }
        /// <summary>
        /// Metodo que realiza la actualizacion de un Partido
        /// Descomentar linea de encima del metodo
        /// Dentro del metodo hay que actualizar el Partido
        /// </summary>
        /// <param name="idPartido">Es el ID del Partido que el usuario desea actualizar</param>
        //[HttpPut("{idPartido}")]
        public void PutPartidos(int idPartido)
        {

        }
        /// <summary>
        /// Metodo que realiza la actualizacion de un Duelo
        /// Descomentar linea de encima del metodo
        /// Dentro del metodo hay que actualizar el Duelo
        /// </summary>
        /// <param name="idDuelo">Es el ID del Duelos que el usuario desea actualizar</param>
        //[HttpPut("{idDuelo}")]
        public void PutDuelos(int idDuelo)
        {

        }

        /// <summary>
        /// Metodo que realiza la actualizacion de un Deporte
        /// Descomentar linea de encima del metodo
        /// Dentro del metodo hay que actualizar el Deporte
        /// </summary>
        /// <param name="idDeporte">Es el ID del Deporte que el usuario desea actualizar</param>
        //[HttpPut("{idDeporte}")]
        public void PutDeportes(int idDeporte)
        {

        }
        #endregion
        #region METODOS DELETE
        /// <summary>
        /// Metodo que borra un Equipo 
        /// Descomentar linea de encima del metodo
        /// Falta meter la funcionalidad del metodo
        /// </summary>
        /// <param name="idEquipo">El Id del Equipo que el usuario desea borrar</param>
        //[HttpDelete("{idEquipo}")]
        public void DeleteEquipos(int idEquipo)
        {


        }
        /// <summary>
        /// Metodo que borra un Alumno
        /// Descomentar linea de encima del metodo
        /// Falta meter funcionalidad del metodo
        /// </summary>
        /// <param name="idAlumno">El id del Alumno que el usuario desea borrar</param>
        //[HttpDelete("{idAlumno}")]
        public void DeleteAlumnos(int idAlumno)
        {


        }
        /// <summary>
        /// Metodo que borra un Partido
        /// Descomentar linea de encima del metodo
        /// Falta meter funcionalidad del metodo
        /// </summary>
        /// <param name="idPartido">El id del Partido que el usuario desea borrar</param>
        //[HttpDelete("{idPartido}")]
        public void DeletePartidos(int idPartido)
        {


        }
        /// <summary>
        /// Metodo que borra un Duelo
        /// Descomentar linea de encima del metodo
        /// Falta meter funcionalidad del metodo
        /// </summary>
        /// <param name="idDuelo">El id del Duelo que el usuario desea borrar</param>
        //[HttpDelete("{idDuelo}")]
        public void DeleteDuelos(int idDuelo)
        {


        }
        /// <summary>
        /// Metodo que borra un Deporte
        /// Descomentar linea de encima del metodo
        /// Falta meter funcionalidad del metodo
        /// </summary>
        /// <param name="idDeporte">El id del Deporte que el usuario desea borrar</param>
        //[HttpDelete("{idDeporte}")]
        public void DeleteDeportes(int idDeporte)
        {


        }
        #endregion
    }
}
