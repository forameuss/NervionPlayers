using DALClassLibrary;
using NervionPlayers_Ent.Modelos;
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

        public ManejadoraDeporteDAL()
        {
            con = new Connection("ProfesorNervion", "1iNu#L0par7€T0");
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
                        oDeporte.Id = Convert.ToInt32(lector[ContratoDB.Deportes_DB.DEPORTES_DB_ID]);
                        oDeporte.Nombre = Convert.ToString(lector[ContratoDB.Deportes_DB.DEPORTES_DB_NOMBRE]);
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
        public int insertarDeporte(Deporte deporte)
        {
            int filasAfectadas = 0;
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = @"INSERT INTO [dbo].[@table_Name] ([@Nombre_DB]) VALUES(@Nombre)";
                miComando.Connection = conexion;

                //Parametros tabla
                miComando.Parameters.AddWithValue("@tableName", ContratoDB.Deportes_DB.DEPORTES_DB_TABLE_NAME);
                miComando.Parameters.AddWithValue("@Nombre_DB", ContratoDB.Deportes_DB.DEPORTES_DB_NOMBRE);

                //Parametros Deporte
                miComando.Parameters.AddWithValue("@Nombre", deporte.Nombre);

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

        /// <summary>
        /// Funcion que actualiza un deporte de la base de datos
        /// </summary>
        /// <param name="deporte">Objeto Deporte</param>
        /// <returns>int del numero de filas afectadas</returns>
        public int actualizarDeporte(Deporte deporte)
        {
            int filasAfectadas = 0;
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = @"UPDATE [@table_name] set @Nombre_Deporte_DB=@Nombre_Deporte
                                        WHERE @Id_DB=@Id_Deporte";
                miComando.Connection = conexion;

                //Parametros Tabla
                miComando.Parameters.AddWithValue("@table_name", ContratoDB.Deportes_DB.DEPORTES_DB_TABLE_NAME);
                miComando.Parameters.AddWithValue("@Nombre_Deporte_DB", ContratoDB.Deportes_DB.DEPORTES_DB_NOMBRE);
                miComando.Parameters.AddWithValue("@Id_DB", ContratoDB.Deportes_DB.DEPORTES_DB_ID);

                //Parametros Deporte
                miComando.Parameters.AddWithValue("@Nombre_Deporte", deporte.Nombre);
                miComando.Parameters.AddWithValue("@Id_Deporte", deporte.Id);

                filasAfectadas = miComando.ExecuteNonQuery();

            } catch (SqlException ex)
            {
                throw ex;
            } finally
            {
                con.CloseConnection();
            }

            return filasAfectadas;
        }
    }
}
