using Microsoft.AspNetCore.Mvc;
using NervionPlayers_BL;
using NervionPlayers_BL.Manejadoras;
using NervionPlayers_BL.Model;
using NervionPlayers_Ent.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControllersNP.Controllers
{
    [Route("api/[controller]")]
    public class DuelosController : Controller
    {
        ListadosBL listaDuelos = new ListadosBL();
        ManejadoraDueloBL manejadoraDuelos = new ManejadoraDueloBL();
        // GET: Duelos
        public ActionResult Index()
        {
            return View();
        }

        #region GET
        /// <summary>
        ///  Metodo que devuelve todos los Duelos que se han llevado a cabo
        /// </summary>
        /// <returns>Deuelve una lista de todos los Duelos</returns>
        [HttpGet]
        public IEnumerable<Duelo> GetDuelos()
        {
            return listaDuelos.listadoDuelosBL();
        }

        /// <summary>
        /// Metodo que devuelve un duelo concreto
        /// </summary>
        /// <param name="id">Id del duelo</param>
        /// <returns>Devuelve un duelo concreto</returns>
        [HttpGet("{id}")]
        public Duelo GetDuelo(int id)
        {
            Duelo duelo = new Duelo();

            duelo = manejadoraDuelos.obtenerDuelo(id);

            if (duelo == null)
            {
                Response.StatusCode = 404; //Not found
            }
            return duelo;
        }

        #endregion

        #region POST
        /// <summary>
        /// Metodo que crea un nuevo duelo
        /// </summary>
        /// <param name="value">Valores para la creacion de un nuevo duelo</param>
        [HttpPost]
        public void PostDuelos([FromBody] Duelo value)
        {
            int filas = 0;

            try
            {

                filas = manejadoraDuelos.insertarDuelo(value);

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
        /// Metodo que actualiza un duelo
        /// </summary>
        /// <param name="id">Id del duelo que el usuario desea actualizar</param>
        /// <param name="value">Valores que el usuario quiere actualizar</param>
        [HttpPut("{id}")]
        public void PutDuelos(int id, [FromBody]Duelo value)
        {
            Duelo resP = manejadoraDuelos.obtenerDuelo(value.Id);

            if (resP == null)
            {
                Response.StatusCode = 404; //Not found
            }
            else
            {
                try
                {

                    manejadoraDuelos.actualizarDuelo(value);

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
        /// Metodo que elimina un duelo
        /// </summary>
        /// <param name="id">Id del duelo que el usuario desea borrar</param>
        [HttpDelete("{id}")]
        public void DeleteDuelos(int id)
        {
            int filas = manejadoraDuelos.borrarDuelo(id);
            if (filas < 1) { Response.StatusCode = 404; } //Not found

        }

        #endregion
    }
}