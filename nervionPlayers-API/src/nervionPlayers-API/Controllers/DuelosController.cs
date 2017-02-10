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

            return manejadoraDuelos.obtenerDuelo(id);
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
            try
            {
                manejadoraDuelos.insertarDuelo(value);
            }
            catch (InvalidValueException invalido)
            {
                //Falta devolver error
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
            try
            {
                manejadoraDuelos.actualizarDuelo(value);
            }catch(InvalidValueException invalido)
            {
                //Falta devolver error
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
            try
            {
                manejadoraDuelos.borrarDuelo(id);
            }
            catch (InvalidValueException invalido)
            {
                //Falta devolver error
            }

        }

        #endregion
    }
}