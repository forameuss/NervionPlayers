using NervionPlayers_DAL.Listado;
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
            ObservableCollection<Alumno> alumnosEquipo1 = miLista.listadoAlumnos(1);
            foreach (var al in alumnosEquipo1)
            {
                Console.WriteLine(al.Nombre);
            }
            Console.Read(); //Para que pare la ejecución y me de tiempo a ver el resultado
        }
    }
}
