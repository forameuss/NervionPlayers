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
        public ObservableCollection<Alumno> listadoAlumnosBL()
        {
            return listadosDAL.listadoAlumnos();
        }
               

        public ObservableCollection<Alumno> listadoAlumnosBL(int idEquipo)
        {
            return listadosDAL.listadoAlumnos(idEquipo);
        }

        public ObservableCollection<Equipo> listadoEquiposBL() {
            return listadosDAL.listadoEquipos();
        }

        public ObservableCollection<Equipo> listadoEquiposBL(int idAlumno)
        {
            return listadosDAL.listadoEquipos(idAlumno);

        }

        public ObservableCollection<Partido> listadoPartidosBL()
        {
            return listadosDAL.listadoPartidos();
        }

        public ObservableCollection<Partido> listadoPartidosBL(int idEquipo)
        {
            return listadosDAL.listadoPartidos(idEquipo);

        }

        public ObservableCollection<Duelo> listadoDuelosBL()
        {
            return listadosDAL.listadoDuelos();

        }

        public ObservableCollection<Duelo> listadoDuelosBL(int idAlumno)
        {
            return listadosDAL.listadoDuelos(idAlumno);

        }

        public ObservableCollection<Deporte> listadoDeportesBL()
        {
            return null;
        }

        public ObservableCollection<Deporte> listadoDeportesBL(int idDeporte)
        {
            return null;
        }

        public ObservableCollection<AlumnoEquipo> listadoAlumnosEquiposBL()
        {
            return null;
        }

        public ObservableCollection<ResultadoPartido> listadoResultadoPartidosBL()
        {
            return null;
        }

        public ObservableCollection<ResultadoDuelo> listadoResultadoDuelosBL()
        {
            return null;
        }

        public ObservableCollection<Dispositivo> listadoDispositivosBL()
        {
            return null;

        }

        public ObservableCollection<Dispositivo> listadoDispositivosBL(int idAlumno)
        {
            return null;
        }



    }
}
