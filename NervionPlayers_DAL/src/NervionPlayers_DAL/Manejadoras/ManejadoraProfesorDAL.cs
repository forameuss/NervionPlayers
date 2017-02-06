using DALClassLibrary;
using NervionPlayers_Ent.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NervionPlayers_DAL.Manejadoras
{
    
    public class ManejadoraProfesorDAL
    {
        private Connection con;
        public ManejadoraProfesorDAL()
        {
            con = new Connection("ProfesorNervion", "1iNu#L0par7€T0");
        }

        /// <summary>
        /// Busca en la base de datos y devuelve un Profesor con el id recibido
        /// </summary>
        /// <param name="id">Recibe la id del profesor a buscar</param>
        /// <returns>retorna el Profesor</returns>
        public Profesor obtenerProfesor(int id)
        {

            return oPartido;
        }

        /// <summary>
        /// Añade un nuevo Profesor en la base de datos
        /// </summary>
        /// <param name="profesor">Recibe un  tipo Profesor</param>
        /// <returns>retorna el numero de filas afectadas , int</returns>
        public int insertarProfesor(Profesor profesor)
        {

            return filasAfectadas;
        }



        /// <summary>
        /// Funcion que borra un Profesor de la base de datos 
        /// </summary>
        /// <param name="id">Recibe el id del Partido a borrar</param>
        /// <returns>int , retorna el numero de filas afectadas</returns>
        public int borrarProfesor(int id)
        {


            return filasafectadas;
        }

        /// <summary>
        /// Funcion que actualiza un Partido de la base de datos
        /// </summary>
        /// <param name="partido">Objeto Partido NO NULO</param>
        /// <returns>int del numero de filas afectadas</returns>
        public int actualizarprofesor(Profesor profesor)
        {
            
            return filasAfectadas;
        }

    }
}
