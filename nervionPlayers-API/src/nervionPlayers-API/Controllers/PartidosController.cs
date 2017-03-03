using Microsoft.AspNetCore.Mvc;
using nervionPlayers_API.Models;
using NervionPlayers_BL;
using NervionPlayers_BL.Manejadoras;
using NervionPlayers_BL.Model;
using NervionPlayers_Ent.Modelos;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ControllersNP.Controllers
{
    [Route("api/[controller]")]
    public class PartidosController : Controller
    {

        ManejadoraPartidoBL manejaPartBL = new ManejadoraPartidoBL();
        ListadosBL listaBL = new ListadosBL();
        // GET: Partidos
        public ActionResult Index()
        {
            return View();
        }

        #region GET

        /// <summary>
        /// Metodo que devuelve un listado de Partidos
        /// </summary>
        /// <returns>Devuelve un listado de partidos</returns>
        [HttpGet]
        public IEnumerable<Partido> GetPartidos()
        {

            return listaBL.listadoPartidosBL();
        }

        //  /partidos/{id}

        /// <summary>
        /// Ruta: /partidos/id
        /// Metodo que devuelve un partido con la id especificada
        /// </summary>
        /// <returns>un Partido</returns>
        [HttpGet("{id}")]
        public Partido GetPartido(int id)
        {
            Partido Part = new Partido();

            Part = manejaPartBL.obtenerPartido(id);

            if (Part == null)
            {
                Response.StatusCode = 404; //Not found
            }

            return Part;
        }
       
        #endregion

        #region POST

        /// <summary>
        /// Metodo que crea un nuevo Partido
        /// Falta ponerle los parametros
        /// Dentro del metodo crear un nuevo Partido
        /// </summary>
        [HttpPost]
        public void PostPartidos([FromBody] Partido value)
        {
            int filas = 0;

            try
            {
              filas = manejaPartBL.insertarPartido(value);
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
        /// Metodo que realiza la actualizacion de un Partido
        /// Descomentar linea de encima del metodo
        /// Dentro del metodo hay que actualizar el Partido
        /// </summary>
        /// <param name="id">Es el ID del Partido que el usuario desea actualizar</param>
        [HttpPut]
        public void PutPartidos([FromBody] Partido value)
        {
            //comprobar que el id existe (devuelven filas afectadas)
            manejaPartBL.actualizarPartido(value);

            Partido resP = manejaPartBL.obtenerPartido(value.Id);

            if (resP == null)
            {
                Response.StatusCode = 404; //Not found
            }
            else
            {
                try
                {
                    manejaPartBL.actualizarPartido(value);
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
        /// Metodo que borra un Partido
        /// Descomentar linea de encima del metodo
        /// Falta meter funcionalidad del metodo
        /// </summary>
        /// <param name="id">El id del Partido que el usuario desea borrar</param>
        [HttpDelete("{id}")]
        public void DeletePartidos(int id)
        {
            //avisar de que se ha borrado con exito (filasAfectadas=1)
            int filas =   manejaPartBL.borrarPartido(id);
            if (filas < 1) { Response.StatusCode = 404; } //Not found

        }

        #endregion

        #region get partido/equiposDeporte
        /// <summary>
        /// Metodo que devuelve un listado con los partidow y el nombre del local, nombre del visitante y nombre del deporte
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve una lista de partidos con los nombres de los equipos visitate y local y el nombre del deporte</returns>
        [HttpGet("EquiposDeporte")]
        public List<PartidoNombre> GetPartidosEquiposDeporte()
        {
            List<Partido> listaPartidos = listaBL.listadoPartidosBL().ToList();
            List<PartidoNombre> listaPartidosNombres = new List<PartidoNombre>();

            Partido partido = new Partido();
            Equipo equipoLocal = new Equipo();
            Equipo equipoVisitante = new Equipo();
            Deporte deporte = new Deporte();

            ManejadoraEquipoBL manejaEquipo = new ManejadoraEquipoBL();
            ManejadoraDeporteBL manejaDeporte = new ManejadoraDeporteBL();

            for (int i = 0; i < listaPartidos.Count(); i++)
            {
                partido = listaPartidos[i];
                equipoLocal = manejaEquipo.obtenerEquipo(partido.Id_Local);
                equipoVisitante = manejaEquipo.obtenerEquipo(partido.Id_Visitante);
                deporte = manejaDeporte.obtenerDeporte(partido.Id_Deporte);

                listaPartidosNombres.Add(new PartidoNombre(partido, equipoLocal.Nombre, equipoVisitante.Nombre, deporte.Nombre));
            }

            return listaPartidosNombres;
        }
        #endregion
    }
}