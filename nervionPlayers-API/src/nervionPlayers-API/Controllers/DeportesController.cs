using Microsoft.AspNetCore.Mvc;
using NervionPlayers_BL;
using NervionPlayers_BL.Manejadoras;
using NervionPlayers_Ent.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using NervionPlayers_BL.Model;
using System.Collections.ObjectModel;

namespace ControllersNP.Controllers
{
    [Route("api/[controller]")]
    public class DeportesController : Controller
    {
        ListadosBL listado = new ListadosBL();
        ManejadoraDeporteBL manejadoraDeporte = new ManejadoraDeporteBL();

        // GET: Deportes
        public ActionResult Index()
        {
            return View();
        }

        #region GET

        /// <summary>
        /// Metodo que devuelve un listado de todos los deportes
        /// </summary>
        /// <returns>Devuelve un listado de todos los deportes</returns>
        [HttpGet]
        public IEnumerable<Deporte> GetDeportes()
        {
            return listado.listadoDeportesBL();
        }

        /// <summary>
        /// Metodo que devuelve la informacion de un deporte concreto
        /// </summary>
        /// <param name="id">Id del deporte</param>
        /// <returns>Devuelve la informacion de un deporte concreto</returns>
        [HttpGet("{id}")]
        public Deporte GetDeporte(int id)
        {
            Deporte deporte = new Deporte();

            deporte = manejadoraDeporte.obtenerDeporte(id);

            if (deporte == null)
            {
                Response.StatusCode = 404; //Not found
            }
            return deporte;
        }


        /// <summary>
        /// Método que devuelve todos los partidos de un deporte
        /// </summary>
        /// <param name="id">El id del deporte</param>
        /// <returns></returns>
        [HttpGet("{id}/Partidos")]
        public IEnumerable<Partido> GetPartidosDeporte(int id)
        {
            ListadosBL miManejadora = new ListadosBL();
            ObservableCollection<Partido> partidos = miManejadora.listadoPartidosBL();
            ObservableCollection<Partido> partidosDevolver = new ObservableCollection<Partido>();
            for (int i = 0; i < partidos.Count; i++)
            {
                if (partidos[i].Id_Deporte == id)
                {
                    partidosDevolver.Add(partidos[i]);
                }
            }

            if (partidosDevolver == null)
            {
                Response.StatusCode = 404; //Not found
            }
            return partidosDevolver;
        }
        #endregion

        #region POST
        /// <summary>
        /// Metodo que crea un nuevo deporte
        /// </summary>
        /// <param name="value">Valores del nuevo deporte </param>
        [HttpPost]
        public void PostDeportes([FromBody] Deporte value)
        {
            int filas = 0;

            try
            {

                filas = manejadoraDeporte.insertarDeporte(value);

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
        /// Metodo que actualiza un deporte en concreto
        /// </summary>
        /// <param name="id">Id del deporte concreto que el usuario desea actualizar</param>
        /// <param name="value">Valores que el usuario quiere actualizar</param>
        [HttpPut("{id}")]
        public void PutDeportes([FromBody]Deporte value)
        {
            Deporte deporte = manejadoraDeporte.obtenerDeporte(value.Id);

            if (deporte == null)
            {
                Response.StatusCode = 404; //Not found
            }
            else
            {
                try
                {

                    manejadoraDeporte.actualizarDeporte(value);

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
        /// Metodo que elimina un deporte concreto
        /// </summary>
        /// <param name="id">Id del deporte que el usuario desea borrar</param>
        [HttpDelete("{id}")]
        public void DeleteDeportes(int id)
        {
            int filas = manejadoraDeporte.borrarDeporte(id);
            if (filas < 1) { Response.StatusCode = 404; } //Not found

        }
        #endregion

    }
}