using NervionPlayers_DAL.Listado;
using NervionPlayers_Ent.Modelos;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace NervionPlayers_BL
{
    public class ListadosBL
    {
        Listados listadosDAL;
        public ListadosBL()
        {
            listadosDAL = new Listados();
        }

        /// <summary>
        /// Obtiene el listado de alumnos
        /// </summary>
        /// <returns>ObservableCollection Alumnos</returns>
        public ObservableCollection<Alumno> listadoAlumnosBL()
        {
            return listadosDAL.listadoAlumnos();
        }
               
        /// <summary>
        /// Obtiene un listado de los alumnos de un equipo
        /// </summary>
        /// <param name="idEquipo">int , id del equipo del que se quieren obtener los alumnos</param>
        /// <returns>Observable Collection de Alumno</returns>
        public ObservableCollection<Alumno> listadoAlumnosBL(int idEquipo)
        {
            return listadosDAL.listadoAlumnos(idEquipo);
        }

        /// <summary>
        /// Obtiene un listado de los equipos
        /// </summary>
        /// <returns>Observable Collection de Equipo</returns>
        public ObservableCollection<Equipo> listadoEquiposBL() {
            return listadosDAL.listadoEquipos();
        }

        /// <summary>
        /// Obtiene los equipos asociados a un Alumno
        /// </summary>
        /// <param name="idAlumno"></param>
        /// <returns>ObservableCollection de Equipo</returns>
        public ObservableCollection<Equipo> listadoEquiposBL(int idAlumno)
        {
            return listadosDAL.listadoEquipos(idAlumno);

        }

        /// <summary>
        /// Obtiene un listados de todos los partidos
        /// </summary>
        /// <returns>ObservableCollection de Partido</returns>
        public ObservableCollection<Partido> listadoPartidosBL()
        {
            return listadosDAL.listadoPartidos();
        }

        /// <summary>
        /// Obtiene un listado de los partidos de un equipos
        /// </summary>
        /// <param name="idEquipo">id del equipo</param>
        /// <returns>ObservableCollection </returns>
        public ObservableCollection<Partido> listadoPartidosBL(int idEquipo)
        {
            return listadosDAL.listadoPartidos(idEquipo);

        }

        /// <summary>
        /// Obtiene un listado de los Duelos
        /// </summary>
        /// <returns>ObservableCollectio de Duelo</returns>
        public ObservableCollection<Duelo> listadoDuelosBL()
        {
            return listadosDAL.listadoDuelos();

        }

        /// <summary>
        /// Obtiene un listado de los Duelos asociados a un alumno
        /// </summary>
        /// <param name="idAlumno">id del alumno</param>
        /// <returns>ObservableCollection de Duelo</returns>
        public ObservableCollection<Duelo> listadoDuelosBL(int idAlumno)
        {
            return listadosDAL.listadoDuelos(idAlumno);

        }

        /// <summary>
        /// Obtiene el listado de todos los deportes
        /// </summary>
        /// <returns>ObservableCollection de Deporte</returns>
        public ObservableCollection<Deporte> listadoDeportesBL()
        {
            return listadosDAL.listadoDeportes();
        }
        
        /// <summary>
        /// Obtiene un listado de AlumnoEquipos
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<AlumnoEquipo> listadoAlumnosEquiposBL()
        {
            return listadosDAL.listadoAlumnosEquipos();
        }

        /// <summary>
        /// Obtiene un listado de los resultados de los partido
        /// </summary>
        /// <returns>ObservableCollection de ResultadoPartido</returns>
        public ObservableCollection<ResultadoPartido> listadoResultadoPartidosBL()
        {
            return listadosDAL.listadoResultadoPartidos();
        }

        /// <summary>
        /// Obtiene un listado de los resultados de los duelos
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<ResultadoDuelo> listadoResultadoDuelosBL()
        {
            return listadosDAL.listadoResultadoDuelos();
        }

        /// <summary>
        /// Obtiene un litado de los Dispositivos
        /// </summary>
        /// <returns>ObservaleCollection de Dispositivos</returns>
        public ObservableCollection<Dispositivo> listadoDispositivosBL()
        {
            return listadosDAL.listadoDispositivos();

        }

        /// <summary>
        /// Obtiene un listado de todos lso dispositivos de un alumno
        /// </summary>
        /// <param name="id">Id del alumno</param>
        /// <returns></returns>
        public ObservableCollection<Dispositivo> listadoDispositivosBL(int id)
        {
            return listadosDAL.listadoDispositivos();

        }

    /// <summary>
    /// Obtiene un listado de Profesores
    /// </summary>
    /// <returns>Observablecollection de Profesor</returns>
    public ObservableCollection<Profesor> listadoProfesor()
        {
            return listadosDAL.listadoProfesores();
        }
        
    }
}
