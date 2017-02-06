﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ControllersNP.Controllers
{
    [Route("api/[controller]")]
    public class DeportesController : Controller
    {



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
            return null;
        }

        /// <summary>
        /// Metodo que devuelve la informacion de un deporte concreto
        /// </summary>
        /// <param name="id">Id del deporte</param>
        /// <returns>Devuelve la informacion de un deporte concreto</returns>
        [HttpGet("{id}")]
        public Deporte GetDeporte(int id)
        {

            //if (deporte != null)
            //{
            //    return new ObjectResult(deporte);
            //}
            //else {
            //    return Not Found();
            //}

            return null;
        }

        #endregion

        #region POST
        /// <summary>
        /// Metodo que crea un nuevo deporte
        /// </summary>
        /// <param name="value">Valores del nuevo deporte </param>
        [HttpPost]
        public void PostDeportes([FromBody] Equipo value)
        {

        }
        #endregion

        #region PUT
        /// <summary>
        /// Metodo que actualiza un deporte en concreto
        /// </summary>
        /// <param name="id">Id del deporte concreto que el usuario desea actualizar</param>
        /// <param name="value">Valores que el usuario quiere actualizar</param>
        [HttpPut("{id}")]
        public void PutDeportes(int id, [FromBody]Deporte value)
        {

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


        }
        #endregion

    }
}