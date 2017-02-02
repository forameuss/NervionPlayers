//TODO Actualizar
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
            con = new Connection("ProfesorNervion", "1iNu#L0par7€T0");
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
                        oEquipo.Id = Convert.ToInt32(lector[ContratoDB.Equipos_DB.EQUIPOS_DB_ID]);
                        oEquipo.Id_Creador = Convert.ToInt32(lector[ContratoDB.Equipos_DB.EQUIPOS_DB_ID_CREADOR]);
                        oEquipo.Nombre = Convert.ToString(lector[ContratoDB.Equipos_DB.EQUIPOS_DB_NOMBRE]);
                        try
                        {
                            oEquipo.Foto = (byte[])lector[ContratoDB.Equipos_DB.EQUIPOS_DB_FOTO];
                        }
                        catch (InvalidCastException)
                        {
                            oEquipo.Foto = null;
                        }
                        oEquipo.Confirmado = Convert.ToBoolean(lector[ContratoDB.Equipos_DB.EQUIPOS_DB_CONFIRMADO]);
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
                miComando.CommandText = @"INSERT INTO [dbo].[@table_Name](@Id_Creador_DB ,@Nombre_DB,@Foto_DB,@confirmado_DB)
                                        VALUES (@Id_Creador,@Nombre,@Foto,@Confirmado)";
                miComando.Connection = conexion;

                //Parametros Tabla
                miComando.Parameters.AddWithValue("@Id_Creador_DB", ContratoDB.Equipos_DB.EQUIPOS_DB_ID_CREADOR);
                miComando.Parameters.AddWithValue("@Nombre_DB", ContratoDB.Equipos_DB.EQUIPOS_DB_NOMBRE);
                miComando.Parameters.AddWithValue("@Foto_DB", ContratoDB.Equipos_DB.EQUIPOS_DB_FOTO);
                miComando.Parameters.AddWithValue("@confirmado_DB", ContratoDB.Equipos_DB.EQUIPOS_DB_CONFIRMADO);
                miComando.Parameters.AddWithValue("@table_Name", ContratoDB.Equipos_DB.EQUIPOS_DB_TABLE_NAME);

                //Parametros Equipo
                miComando.Parameters.AddWithValue("@Nombre", equipo.Nombre);
                miComando.Parameters.AddWithValue("@Id_Creador", equipo.Id_Creador);
                miComando.Parameters.AddWithValue("@Foto", equipo.Foto);
                miComando.Parameters.AddWithValue("@Confirmado", equipo.Confirmado);

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

        /// <summary>
        /// Funcion para actualizar un equipod e la DB
        /// </summary>
        /// <param name="equipo">Ojeto equipo NO NULO</param>
        /// <returns>Numero de filas afectadas</returns>
        public int actualizarEquipo(Equipo equipo) 
        {
            if (equipo == null)
                throw new ArgumentNullException("Equipo es nulo");

            int filasAfectadas = 0;
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = @"UPDATE [@table_name] SET @IdCreador_Equipo_DB=@IdCreado_Equipo, 
                                        @Nombre_Equipo_DB=@Nombre_Equipo, @Foto_Equipo_DB=@Foto_Equipo,
                                        @FechaCreacion_Equipo_DB=@FechaCreacion_Equipo, 
                                        @Confirmado_Equipo_DB=@Confirmado_Equipo
                                        WHERE @Id_DB=@Id";

                //Parametros DB
                miComando.Parameters.AddWithValue("@table_name", ContratoDB.Equipos_DB.EQUIPOS_DB_TABLE_NAME);
                miComando.Parameters.AddWithValue("@IdCreador_Equipo_DB", ContratoDB.Equipos_DB.EQUIPOS_DB_ID_CREADOR);
                miComando.Parameters.AddWithValue("@Nombre_Equipo_DB", ContratoDB.Equipos_DB.EQUIPOS_DB_NOMBRE);
                miComando.Parameters.AddWithValue("@Foto_Equipo_DB", ContratoDB.Equipos_DB.EQUIPOS_DB_FOTO);
                miComando.Parameters.AddWithValue("@FechaCreacion_Equipo_DB", ContratoDB.Equipos_DB.EQUIPOS_DB_FECHA_CREACION);
                miComando.Parameters.AddWithValue("@Confirmado_Equipo_DB", ContratoDB.Equipos_DB.EQUIPOS_DB_CONFIRMADO);
                miComando.Parameters.AddWithValue("@Id_DB", ContratoDB.Equipos_DB.EQUIPOS_DB_ID);

                //Parametros Equipo
                miComando.Parameters.AddWithValue("@IdCreado_Equipo", equipo.Id_Creador);
                miComando.Parameters.AddWithValue("@Nombre_Equipo", equipo.Nombre);
                miComando.Parameters.AddWithValue("@Foto_Equipo", equipo.Foto);
                miComando.Parameters.AddWithValue("@Confirmado_Equipo", equipo.Confirmado);
                miComando.Parameters.AddWithValue("@Id", equipo.Id);

                filasAfectadas = miComando.ExecuteNonQuery();

            } catch(SqlException)
            {
                throw;
            } finally
            {
                con.CloseConnection();
            }

            return filasAfectadas;
        }
    }
}
