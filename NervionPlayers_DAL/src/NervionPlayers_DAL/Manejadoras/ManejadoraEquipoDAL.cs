using DALClassLibrary;
using NervionPlayers_Ent.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NervionPlayers_DAL.Manejadoras
{
    public class ManejadoraEquipoDAL
    {
        private Connection con;

        public ManejadoraEquipoDAL()
        {
            con = new Connection("AlumnoNervion", ".N3tApe$7aH");
        }

        /// <summary>
        /// Busca en la base de datos y devuelve un Equipo con el id recibido
        /// </summary>
        /// <param name="id">Recibe la id del Equipo a buscar</param>
        /// <returns>retorna el Equipo</returns>
        public Equipo obtenerEquipo(int id)
        {
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();
            Equipo oEquipo = new Equipo();
            SqlDataReader lector;

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = String.Format("Select * From {0} Where {1} = {2}", ContratoDB.Equipos_DB.EQUIPOS_DB_TABLE_NAME, ContratoDB.Equipos_DB.EQUIPOS_DB_ID, id);
                miComando.Connection = conexion;
                lector = miComando.ExecuteReader();

                if (lector.HasRows)
                {
                    if (lector.Read())
                    {
                        oEquipo.Id = (int)lector[ContratoDB.Equipos_DB.EQUIPOS_DB_ID];
                        oEquipo.Id_Creador = (int)lector[ContratoDB.Equipos_DB.EQUIPOS_DB_ID_CREADOR];
                        oEquipo.Nombre = (string)lector[ContratoDB.Equipos_DB.EQUIPOS_DB_NOMBRE];
                        oEquipo.Foto = (Byte[])lector[ContratoDB.Equipos_DB.EQUIPOS_DB_FOTO];
                        oEquipo.Confirmado = (bool)lector[ContratoDB.Equipos_DB.EQUIPOS_DB_CONFIRMADO];

                    }
                }

            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }

            return oEquipo;
        }

        /// <summary>
        /// Añade un nuevoEquipo en la base de datos
        /// </summary>
        /// <param name="equipo">Recibe un  tipo Equipo</param>
        /// <returns>retorna el numero de filas afectadas , int</returns>
        public int insertarEquipo(Equipo equipo)
        {
            int filasAfectadas = 0;
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();


            try
            {
                conexion = con.openConnection();
                miComando.CommandText = String.Format("");
                miComando.Connection = conexion;

                filasAfectadas = miComando.ExecuteNonQuery();


            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }

            return filasAfectadas;
        }

        /// <summary>
        /// Funcion que borra un Equipo de la base de datos 
        /// </summary>
        /// <param name="id">Recibe el id del Equipo a borrar</param>
        /// <returns>int , retorna el numero de filas afectadas</returns>
        public int borrarEquipo(int id)
        {
            int filasafectadas = 0;
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = String.Format("Delete from {0} where {1} = {2}", ContratoDB.Equipos_DB.EQUIPOS_DB_TABLE_NAME, ContratoDB.Equipos_DB.EQUIPOS_DB_ID, id);
                miComando.Connection = conexion;

                filasafectadas = miComando.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }

            return filasafectadas;
        }
    }
}
