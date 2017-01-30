using DALClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NervionPlayers_DAL.Manejadoras
{
    public class ManejadoraDeporteDAL
    {
        private Connection con;

        public ManejadoraEquipoDAL()
        {
            con = new Connection("AlumnoNervion", ".N3tApe$7aH");
        }

        /// <summary>
        /// Busca en la base de datos y devuelve un Deporte con el id recibido
        /// </summary>
        /// <param name="id">Recibe la id del Equipo a buscar</param>
        /// <returns>retorna el Equipo</returns>
        public Deporte obtenerDeporte(int id)
        {
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();
            Deporte oDeporte = new Deporte();
            SqlDataReader lector;

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = String.Format("Select * From {0} Where {1} = {2}", ContratoDB.Deportes_DB.DEPORTES_DB_TABLE_NAME, ContratoDB.Deportes_DB.DEPORTES_DB_ID, id);
                miComando.Connection = conexion;
                lector = miComando.ExecuteReader();

                if (lector.HasRows)
                {
                    if (lector.Read())
                    {
                        oDeporte.Id = (int)lector[ContratoDB.Deportes_DB.DEPORTES_DB_ID];
                        oDeporte.Nombre = (string)lector[ContratoDB.Deportes_DB.DEPORTES_DB_NOMBRE];
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

            return oDeporte;
        }

        /// <summary>
        /// Añade un nuevo deporte en la base de datos
        /// </summary>
        /// <param name="deporte">Recibe un  tipo Deporte</param>
        /// <returns>retorna el numero de filas afectadas , int</returns>
        public int insertarEquipo(Deporte deporte)
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
        /// Funcion que borra un Deporte de la base de datos 
        /// </summary>
        /// <param name="id">Recibe el id del Deporte a borrar</param>
        /// <returns>int , retorna el numero de filas afectadas</returns>
        public int borrardeporte(int id)
        {
            int filasafectadas = 0;
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = String.Format("Delete from {0} where {1} = {2}", ContratoDB.Deportes_DB.DEPORTES_DB_TABLE_NAME, ContratoDB.Deportes_DB.DEPORTES_DB_ID, id);
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
