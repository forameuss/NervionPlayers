using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace nervionPlayers_API.Controllers
{
    public class ResultadosPartidosController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        #region GET
        /// <summary>
        /// Ruta: /resultadosPartidos
        /// Metodo que devuelve un IEnumerable de resultadosPartidos
        /// </summary>
        /// <returns>IEnumerable de resultadosPartidos</returns>
        [HttpGet]
        public IEnumerable<ResultadosPartidos> GetResultadosPartidos()
        {
            return null;
        }

        //  /resultadosPartidos/{id}

        /// <summary>
        /// Ruta: /resultadosPartidos/id
        /// Metodo que devuelve un resultadosPartidos con la id especificada
        /// </summary>
        /// <returns>un resultadosPartidos</returns>
        [HttpGet("{id}")]
        public ResultadosPartidos GetresultadosPartidos(int id)
        {

            //if (resultadosPartidos != null)
            //{
            //    return new ObjectResult(resultadosPartidos);
            //}
            //else {
            //    return Not Found();
            //}

            return null;
        }

        #endregion

        #region POST

        /// <summary>
        /// Metodo que crea un nuevo ResultadosPartidos
        /// 
        /// Dentro del metodo crear un nuevo Duelo
        /// </summary>
        [HttpPost]
        public void PostResultadosPartidos([FromBody] ResultadosPartidos value)
        {

        }

        #endregion

        #region PUT

        /// <summary>
        /// Metodo que realiza la actualizacion de un ResultadosPartidos
        /// Dentro del metodo hay que actualizar el ResultadosPartidos
        /// </summary>
        /// <param name="id">Es el ID del ResultadosPartidos que el usuario desea actualizar</param>
        [HttpPut("{id}")]
        public void PutResultadosPartidos(int id, [FromBody]ResultadosPartidos value)
        {

        }

        #endregion

        #region DELETE

        /// <summary>
        /// Metodo que borra un ResultadosPartidos
        /// Falta meter funcionalidad del metodo
        /// </summary>
        /// <param name="idDuelo">El id del ResultadosPartidos que el usuario desea borrar</param>
        [HttpDelete("{id}")]
        public void DeleteResultadosPartidos(int id)
        {


        }


        #endregion

    }
}
