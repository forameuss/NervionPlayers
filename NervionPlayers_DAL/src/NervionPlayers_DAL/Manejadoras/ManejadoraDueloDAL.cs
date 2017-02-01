using DALClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NervionPlayers_DAL.Manejadoras
{
    public class ManejadoraDueloDAL
    {
        private Connection con;

        public ManejadoraDueloDAL()
        {
            con = new Connection("ProfesorNervion", "1iNu#L0par7€T0");
        }

        /// <summary>
        /// Busca en la base de datos y devuelve un Duelo con el id recibido
        /// </summary>
        /// <param name="id">Recibe la id del Duelo a buscar</param>
        /// <returns>retorna el Duelo</returns>
        public Duelo obtenerDuelo(int id)
        {
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();
            Duelo oDuelo = new Duelo();
            SqlDataReader lector;

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = String.Format("Select * From {0} Where {1} = {2}", ContratoDB.Duelos_DB.DUELOS_DB_TABLE_NAME, ContratoDB.Duelos_DB.DUELOS_DB_ID, id);
                miComando.Connection = conexion;
                lector = miComando.ExecuteReader();

                if (lector.HasRows)
                {
                    if (lector.Read())
                    {
                        oDuelo.Id = (int)lector[ContratoDB.Duelos_DB.DUELOS_DB_ID];
                        oDuelo.Id_Deporte = (int)lector[ContratoDB.Duelos_DB.DUELOS_DB_ID_DEPORTE];
                        oDuelo.Id_Local = (int)lector[ContratoDB.Duelos_DB.DUELOS_DB_ID_LOCAL];
                        oDuelo.Id_Visitante = (int)lector[ContratoDB.Duelos_DB.DUELOS_DB_ID_VISITANTE];
                        oDuelo.Resultado_Local = (int)lector[ContratoDB.Duelos_DB.DUELOS_DB_RESULTADO_LOCAL];
                        oDuelo.Resultado_Visitante = (int)lector[ContratoDB.Duelos_DB.DUELOS_DB_RESULTADO_VISITANTE];
                        oDuelo.Lugar = (String)lector[ContratoDB.Duelos_DB.DUELOS_DB_LUGAR];
                        try
                        {
                            oDuelo.Foto = (byte[])lector[ContratoDB.Duelos_DB.DUELOS_DB_FOTO];
                        }
                        catch (InvalidCastException)
                        {
                            oDuelo.Foto = null;
                        }
                        oDuelo.Notas = (String)lector[ContratoDB.Duelos_DB.DUELOS_DB_NOTAS];
                        oDuelo.Fecha_Duelo = (DateTime)lector[ContratoDB.Duelos_DB.DUELOS_DB_FECHA_DUELO];
                        oDuelo.Fecha_Creacion = (DateTime)lector[ContratoDB.Duelos_DB.DUELOS_DB_FECHA_CREACION];

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

            return oDuelo;
        }

        /// <summary>
        /// Añade un nuevo Duelo en la base de datos
        /// </summary>
        /// <param name="duelo">Recibe un  tipo Duelo</param>
        /// <returns>retorna el numero de filas afectadas , int</returns>
        public int insertarDuelo(Duelo duelo)
        {
            int filasAfectadas = 0;
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = @"INSERT INTO [dbo].[@table_Name](@Id_Local_DB,@Id_Visitante_DB,@Id_Deporte_DB
                                            ,@Fecha_Duelo_DB,
                                        @Foto_DB,@Resultado_Local_DB ,@Resultado_Visitante_DB,@Lugar_DB,@Notas_DB) VALUES 
                                        (@Id_Local,@Id_Visitante,@Id_Deporte,@Fecha_Duelo,@Foto,@Resultado_Local,@Resultado_Visitante,@Lugar,@Notas)";
                miComando.Connection = conexion;

                //Parametros Tabla
                miComando.Parameters.AddWithValue("@Id_Local_DB", ContratoDB.Duelos_DB.DUELOS_DB_ID_LOCAL);
                miComando.Parameters.AddWithValue("@Id_Visitante_DB", ContratoDB.Duelos_DB.DUELOS_DB_ID_VISITANTE);
                miComando.Parameters.AddWithValue("@Id_Deporte_DB", ContratoDB.Duelos_DB.DUELOS_DB_ID_DEPORTE);
                miComando.Parameters.AddWithValue("@Foto_DB", ContratoDB.Duelos_DB.DUELOS_DB_FOTO);
                miComando.Parameters.AddWithValue("@Lugar_DB", ContratoDB.Duelos_DB.DUELOS_DB_LUGAR);
                miComando.Parameters.AddWithValue("@Notas_DB", ContratoDB.Duelos_DB.DUELOS_DB_NOTAS);
                miComando.Parameters.AddWithValue("@Resultado_Local_DB", ContratoDB.Duelos_DB.DUELOS_DB_RESULTADO_LOCAL);
                miComando.Parameters.AddWithValue("@Resultado_Visitante_DB", ContratoDB.Duelos_DB.DUELOS_DB_RESULTADO_VISITANTE);
                miComando.Parameters.AddWithValue("@Fecha_Duelo_DB", ContratoDB.Duelos_DB.DUELOS_DB_FECHA_DUELO);
                miComando.Parameters.AddWithValue("@table_Name", ContratoDB.Duelos_DB.DUELOS_DB_TABLE_NAME);

                //Parametros Duelo
                miComando.Parameters.AddWithValue("@Id_Local",duelo.Id_Local);
                miComando.Parameters.AddWithValue("@Id_Visitante", duelo.Id_Visitante);
                miComando.Parameters.AddWithValue("@Id_Deporte", duelo.Id_Deporte);
                miComando.Parameters.AddWithValue("@Foto", duelo.Foto);
                miComando.Parameters.AddWithValue("@Lugar", duelo.Lugar);
                miComando.Parameters.AddWithValue("@Notas", duelo.Notas);
                miComando.Parameters.AddWithValue("@Resultado_Local", duelo.Resultado_Local);
                miComando.Parameters.AddWithValue("@Resultado_Visitante",duelo.Resultado_Visitante);
                miComando.Parameters.AddWithValue("@Fecha_Duelo", duelo.Fecha_Duelo);

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
        /// Funcion que borra un Duelo de la base de datos 
        /// </summary>
        /// <param name="id">Recibe el id del Duelo a borrar</param>
        /// <returns>int , retorna el numero de filas afectadas</returns>
        public int borrarDuelo(int id)
        {
            int filasafectadas = 0;
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = String.Format("Delete from {0} where {1} = {2}", ContratoDB.Duelos_DB.DUELOS_DB_TABLE_NAME, ContratoDB.Duelos_DB.DUELOS_DB_ID, id);
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
