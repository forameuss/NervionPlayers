using NervionPlayers_DAL.Listado;
using NervionPlayers_DAL.Manejadoras;
using NervionPlayers_Ent.Modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Listados miLista = new Listados();

            //PRUEBA DE ListadoAlumnos() -->Correcta
            /*ObservableCollection<Alumno> alumnosEquipo1 = miLista.listadoAlumnos();
            foreach (var al in alumnosEquipo1)
            {
                Console.WriteLine(al.Nombre);
            }
            Console.Read(); //Para que pare la ejecución y me de tiempo a ver el resultado*/

            //PRUEBA DE ListadoAlumnos(int idEquipo) -->Correcta
            /*ObservableCollection<Alumno> alumnosEquipo1 = miLista.listadoAlumnos(1);
            foreach (var al in alumnosEquipo1)
            {
                Console.WriteLine(al.Nombre);
            }
            Console.Read(); */

            //PRUEBA DE ListadoDeportes() -->Correcta
            /*ObservableCollection<Deporte> deportes = miLista.listadoDeportes();
            foreach (var al in deportes)
            {
                Console.WriteLine(al.Nombre);
            }
            Console.Read();*/

            //PRUEBA DE ListadoEquipos() -->Correcta
            /*ObservableCollection<Equipo> equipo = miLista.listadoEquipos();
            foreach (var al in equipo)
            {
                Console.WriteLine(al.Nombre);
            }
            Console.Read();*/

            //PRUEBA DE ListadoEquipos(int idAlumo) -->Correcta
             ObservableCollection<Equipo> equipo = miLista.listadoEquipos(2);
             foreach (var al in equipo)
             {
                 Console.WriteLine(al.Nombre);
             }
             Console.Read();

            //PRUEBA DE getAlumnoDAL(int idAlumo) -->Correcta
            //ManejadoraAlumnoDAL man = new ManejadoraAlumnoDAL();
            ManejadoraDueloDAL man = new ManejadoraDueloDAL();
            //Alumno a = man.obtenerAlumno(1);
            Duelo d = man.obtenerDuelo(1);
            Console.Read();
             
        }
    }
}
