using DALClassLibrary;
using NervionPlayers_Ent.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NervionPlayers_DAL.Manejadoras
{
    public class ManejadoraDispositivoDAL
    {
        private Connection con;

        public ManejadoraDispositivoDAL()
        {
            con = new Connection("ProfesorNervion", "1iNu#L0par7€T0");
        }

        /// <summary>
        /// Obtiene un dispositivo con el id especificado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Dispositivo obtenerDispositivo(int id)
        {
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();
            Dispositivo miDispositivo = new Dispositivo();
            SqlDataReader lector;

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = String.Format("Select * From {0} Where {1} = {2}", ContratoDB.Dispositivos.TABLA,ContratoDB.Dispositivos.ID, id);
                miComando.Connection = conexion;
                lector = miComando.ExecuteReader();

                if (lector.HasRows)
                {
                    if (lector.Read())
                    {
                        miDispositivo.Id = Convert.ToInt32(lector[ContratoDB.Dispositivos.ID]);
                        miDispositivo.Id_Alumno = Convert.ToInt32(lector[ContratoDB.Dispositivos.ID_ALUMNO]);
                        miDispositivo.Token = Convert.ToString(lector[ContratoDB.Dispositivos.TOKEN]);
                        miDispositivo.Fecha_Creacion = Convert.ToDateTime(lector[ContratoDB.Dispositivos.FECHA_CREACION]);
                        miDispositivo.Fecha_Modificacion = Convert.ToDateTime(lector[ContratoDB.Dispositivos.FECHA_MODIFICACION]);
                        miDispositivo.Activo = Convert.ToBoolean(lector[ContratoDB.Dispositivos.ACTIVO]);

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

            return miDispositivo;
        }
        /// <summary>
        /// Inserta un dispositivo
        /// </summary>
        /// <param name="dispositivo"></param>
        /// <returns>Devuelve el número de filas afectadas</returns>
        public int insertarDispositivo(Dispositivo dispositivo)
        {
            int filasAfectadas = 0;
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();

            try
            {

                conexion = con.openConnection();
                miComando.CommandText = @"INSERT INTO[dbo].[@table_name] (@Id_Alumno_DB, @Token_DB, 
                                                 @Fecha_Creacion_DB , @Fecha_Modificacion_DB, @Activo_DB)
                                                 VALUES (@Id_Alumno, @Token, 
                                                 @Fecha_Creacion , @Fecha_Modificacion, @Activo)";
                miComando.Connection = conexion;

                //Parametros Tabla
                miComando.Parameters.AddWithValue("@table_name", ContratoDB.Dispositivos.TABLA);
                miComando.Parameters.AddWithValue("@Id_Alumno_DB", ContratoDB.Dispositivos.ID_ALUMNO);
                miComando.Parameters.AddWithValue("@Token_DB", ContratoDB.Dispositivos.TOKEN);
                miComando.Parameters.AddWithValue("@Fecha_Creacion_DB", ContratoDB.Dispositivos.FECHA_CREACION);
                miComando.Parameters.AddWithValue("@Fecha_Modificacion_DB", ContratoDB.Dispositivos.FECHA_MODIFICACION);
                miComando.Parameters.AddWithValue("@Activo_DB", ContratoDB.Dispositivos.ACTIVO);
                //Parametros Alumno
                miComando.Parameters.AddWithValue("@Id", dispositivo.Id);
                miComando.Parameters.AddWithValue("@Id_Alumno", dispositivo.Id_Alumno);
                miComando.Parameters.AddWithValue("@Token", dispositivo.Token);
                miComando.Parameters.AddWithValue("@Fecha_Creacion", dispositivo.Fecha_Creacion);
                miComando.Parameters.AddWithValue("@Fecha_Modificacion", dispositivo.Fecha_Modificacion);
                miComando.Parameters.AddWithValue("@Activo", dispositivo.Activo);

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
        
        public int borrarDispositivo(int id)
        {
            int filasafectadas = 0;
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = String.Format("Delete from {0} where {1} = {2}", ContratoDB.Dispositivos.TABLA, ContratoDB.Dispositivos.ID, id);
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

        public int actualizarDispositivo(Dispositivo dispositivo)
        {
            int filasAfectadas = 0;
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();

            try
            {

                conexion = con.openConnection();
                miComando.CommandText = @"Update [@table_name] set @Id_Alumno_DB=@Id_Alumno,
                                        @Token_DB=@Token,  
                                        @Fecha_Modificacion_DB=@Fecha_Modificacion,
                                        @Activo_DB=@Activo
                                        where @Id_DB=@Id";
                miComando.Connection = conexion;

                //Parametros Tabla
                miComando.Parameters.AddWithValue("@table_name", ContratoDB.Dispositivos.TABLA);
                miComando.Parameters.AddWithValue("@Id_DB", ContratoDB.Dispositivos.ID);
                miComando.Parameters.AddWithValue("@Id_Alumno_DB", ContratoDB.Dispositivos.ID_ALUMNO);
                miComando.Parameters.AddWithValue("@Token_DB", ContratoDB.Dispositivos.TOKEN);
                miComando.Parameters.AddWithValue("@Fecha_Creacion_DB", ContratoDB.Dispositivos.FECHA_CREACION);
                miComando.Parameters.AddWithValue("@Fecha_Modificacion_DB", ContratoDB.Dispositivos.FECHA_MODIFICACION);
                miComando.Parameters.AddWithValue("@Activo_DB", ContratoDB.Dispositivos.ACTIVO);
                //Parametros Alumno
                miComando.Parameters.AddWithValue("@Id", dispositivo.Id);
                miComando.Parameters.AddWithValue("@Id_Alumno", dispositivo.Id_Alumno);
                miComando.Parameters.AddWithValue("@Token", dispositivo.Token);
                miComando.Parameters.AddWithValue("@Fecha_Creacion", dispositivo.Fecha_Creacion);
                miComando.Parameters.AddWithValue("@Fecha_Modificacion", dispositivo.Fecha_Modificacion);
                miComando.Parameters.AddWithValue("@Activo", dispositivo.Activo);

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
