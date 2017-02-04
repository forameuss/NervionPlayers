using DALClassLibrary;
using NervionPlayers_Ent.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NervionPlayers_DAL.Manejadoras
{
    public class ManejadoraPartidoDAL
    {
        private Connection con;

        public ManejadoraPartidoDAL()
        {
            con = new Connection("ProfesorNervion", "1iNu#L0par7€T0");
        }

        /// <summary>
        /// Busca en la base de datos y devuelve un Partido con el id recibido
        /// </summary>
        /// <param name="id">Recibe la id del partido a buscar</param>
        /// <returns>retorna el Partido</returns>
        public Partido obtenerPartido(int id)
        {
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();
            Partido oPartido = new Partido();
            SqlDataReader lector;

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = String.Format("Select * From {0} Where {1} = {2}", ContratoDB.Partidos_DB.PARTIDOS_DB_TABLE_NAME, ContratoDB.Partidos_DB.PARTIDOS_DB_ID, id);
                miComando.Connection = conexion;
                lector = miComando.ExecuteReader();

                if (lector.HasRows)
                {
                    if (lector.Read())
                    {
                        oPartido.Id = Convert.ToInt32(lector[ContratoDB.Partidos_DB.PARTIDOS_DB_ID]);
                        oPartido.Id_Deporte = Convert.ToInt32(lector[ContratoDB.Partidos_DB.PARTIDOS_DB_ID_DEPORTE]);
                        oPartido.Id_Local = Convert.ToInt32(lector[ContratoDB.Partidos_DB.PARTIDOS_DB_ID_LOCAL]);
                        oPartido.Id_Visitante = Convert.ToInt32(lector[ContratoDB.Partidos_DB.PARTIDOS_DB_ID_VISITANTE]);
                        oPartido.Resultado_Local = Convert.ToInt32(lector[ContratoDB.Partidos_DB.PARTIDOS_DB_RESULTADO_LOCAL]);
                        oPartido.Resultado_Visitante = Convert.ToInt32(lector[ContratoDB.Partidos_DB.PARTIDOS_DB_RESULTADO_VISITANTE]);
                        oPartido.Lugar = Convert.ToString(lector[ContratoDB.Partidos_DB.PARTIDOS_DB_LUGAR]);
                        try
                        {
                            oPartido.Foto = (byte[])lector[ContratoDB.Partidos_DB.PARTIDOS_DB_FOTO];
                        }
                        catch (InvalidCastException)
                        {
                            oPartido.Foto = null;
                        }
                        oPartido.Notas = Convert.ToString(lector[ContratoDB.Partidos_DB.PARTIDOS_DB_NOTAS]);
                        oPartido.Fecha_Partido = Convert.ToDateTime(lector[ContratoDB.Partidos_DB.PARTIDOS_DB_FECHA_PARTIDO]);
                        oPartido.Fecha_Creacion = Convert.ToDateTime(lector[ContratoDB.Partidos_DB.PARTIDOS_DB_FECHA_CREACION]);

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

            return oPartido;
        }

        /// <summary>
        /// Añade un nuevo Partido en la base de datos
        /// </summary>
        /// <param name="partido">Recibe un  tipo Partido</param>
        /// <returns>retorna el numero de filas afectadas , int</returns>
        public int insertarPartido(Partido partido)
        {
            int filasAfectadas = 0;
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = @"INSERT INTO [dbo].[@table_Name](@Id_Local_DB,@Id_Visitante_DB,@Id_Deporte_DB
                                            ,@Fecha_Partido_DB,
                                        @Foto_DB,@Resultado_Local_DB ,@Resultado_Visitante_DB,@Lugar_DB,@Notas_DB) VALUES 
                                        (@Id_Local,@Id_Visitante,@Id_Deporte,@Fecha_Partido,@Foto,@Resultado_Local,@Resultado_Visitante,@Lugar,@Notas)";
                miComando.Connection = conexion;

                //Parametros Tabla
                miComando.Parameters.AddWithValue("@Id_Local_DB ", ContratoDB.Partidos_DB.PARTIDOS_DB_ID_LOCAL);
                miComando.Parameters.AddWithValue("@Id_Visitante_DB", ContratoDB.Partidos_DB.PARTIDOS_DB_ID_VISITANTE);
                miComando.Parameters.AddWithValue("@Id_Deporte_DB", ContratoDB.Partidos_DB.PARTIDOS_DB_ID_DEPORTE);
                miComando.Parameters.AddWithValue("@Fecha_Partido_DB", ContratoDB.Partidos_DB.PARTIDOS_DB_FECHA_PARTIDO);
                miComando.Parameters.AddWithValue("@Foto_DB", ContratoDB.Partidos_DB.PARTIDOS_DB_FOTO);
                miComando.Parameters.AddWithValue("@Resultado_Local_DB", ContratoDB.Partidos_DB.PARTIDOS_DB_RESULTADO_LOCAL);
                miComando.Parameters.AddWithValue("@Resultado_Visitante_DB", ContratoDB.Partidos_DB.PARTIDOS_DB_RESULTADO_VISITANTE);
                miComando.Parameters.AddWithValue("@Lugar_DB", ContratoDB.Partidos_DB.PARTIDOS_DB_LUGAR);
                miComando.Parameters.AddWithValue("@Notas_DB", ContratoDB.Partidos_DB.PARTIDOS_DB_NOTAS);
                miComando.Parameters.AddWithValue("@table_Name", ContratoDB.Partidos_DB.PARTIDOS_DB_TABLE_NAME);

                //Parametros Partido
                miComando.Parameters.AddWithValue("@Id_Local", partido.Id_Local);
                miComando.Parameters.AddWithValue("@Id_Visitante", partido.Id_Visitante);
                miComando.Parameters.AddWithValue("@Id_Deporte", partido.Id_Deporte);
                miComando.Parameters.AddWithValue("@Fecha_Partido", partido.Fecha_Partido);
                miComando.Parameters.AddWithValue("@Foto", partido.Foto);
                miComando.Parameters.AddWithValue("@Resultado_Local", partido.Resultado_Local);
                miComando.Parameters.AddWithValue("@Resultado_Visitante", partido.Resultado_Visitante);
                miComando.Parameters.AddWithValue("@Lugar", partido.Lugar);
                miComando.Parameters.AddWithValue("@Notas", partido.Notas);

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
        /// Funcion que borra un Partido de la base de datos 
        /// </summary>
        /// <param name="id">Recibe el id del Partido a borrar</param>
        /// <returns>int , retorna el numero de filas afectadas</returns>
        public int borrarPartido(int id)
        {
            int filasafectadas = 0;
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = String.Format("Delete from {0} where {1} = {2}", ContratoDB.Partidos_DB.PARTIDOS_DB_TABLE_NAME, ContratoDB.Partidos_DB.PARTIDOS_DB_ID, id);
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
        /// Funcion que actualiza un Partido de la base de datos
        /// </summary>
        /// <param name="partido">Objeto Partido NO NULO</param>
        /// <returns>int del numero de filas afectadas</returns>
        public int actualizarPartido(Partido partido)
        {
            if (partido == null)
                throw new ArgumentNullException("Partido es nulo");

            int filasAfectadas = 0;
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = @"UPDATE [@table_Name] set @Id_Local_DB=@Id_Local, @Id_Visitante_DB=@Id_Visitante,
                                                                  @Id_Deporte_DB=@Id_Deporte, @Foto_DB=@Foto, @Lugar_DB=@Lugar,
                                                                  @Notas_DB=@Notas, @Resultado_Local_DB=@Resultado_Local,@Resultado_Visitante_DB=@Resultado_Visitante,
                                                                @Fecha_Duelo_DB=@Fecha_Duelo
                                            WHERE @Id_DB=@Id";



                miComando.Connection = conexion;

                //Parametros Tabla
                miComando.Parameters.AddWithValue("@Id_DB", ContratoDB.Partidos_DB.PARTIDOS_DB_ID);
                miComando.Parameters.AddWithValue("@Id_Local_DB ", ContratoDB.Partidos_DB.PARTIDOS_DB_ID_LOCAL);
                miComando.Parameters.AddWithValue("@Id_Visitante_DB", ContratoDB.Partidos_DB.PARTIDOS_DB_ID_VISITANTE);
                miComando.Parameters.AddWithValue("@Id_Deporte_DB", ContratoDB.Partidos_DB.PARTIDOS_DB_ID_DEPORTE);
                miComando.Parameters.AddWithValue("@Fecha_Partido_DB", ContratoDB.Partidos_DB.PARTIDOS_DB_FECHA_PARTIDO);
                miComando.Parameters.AddWithValue("@Foto_DB", ContratoDB.Partidos_DB.PARTIDOS_DB_FOTO);
                miComando.Parameters.AddWithValue("@Resultado_Local_DB", ContratoDB.Partidos_DB.PARTIDOS_DB_RESULTADO_LOCAL);
                miComando.Parameters.AddWithValue("@Resultado_Visitante_DB", ContratoDB.Partidos_DB.PARTIDOS_DB_RESULTADO_VISITANTE);
                miComando.Parameters.AddWithValue("@Lugar_DB", ContratoDB.Partidos_DB.PARTIDOS_DB_LUGAR);
                miComando.Parameters.AddWithValue("@Notas_DB", ContratoDB.Partidos_DB.PARTIDOS_DB_NOTAS);
                miComando.Parameters.AddWithValue("@table_Name", ContratoDB.Partidos_DB.PARTIDOS_DB_TABLE_NAME);

                //Parametros Partido
                miComando.Parameters.AddWithValue("@Id", partido.Id);
                miComando.Parameters.AddWithValue("@Id_Local", partido.Id_Local);
                miComando.Parameters.AddWithValue("@Id_Visitante", partido.Id_Visitante);
                miComando.Parameters.AddWithValue("@Id_Deporte", partido.Id_Deporte);
                miComando.Parameters.AddWithValue("@Fecha_Partido", partido.Fecha_Partido);
                miComando.Parameters.AddWithValue("@Foto", partido.Foto);
                miComando.Parameters.AddWithValue("@Resultado_Local", partido.Resultado_Local);
                miComando.Parameters.AddWithValue("@Resultado_Visitante", partido.Resultado_Visitante);
                miComando.Parameters.AddWithValue("@Lugar", partido.Lugar);
                miComando.Parameters.AddWithValue("@Notas", partido.Notas);

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
    }
}
