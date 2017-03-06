using DALClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using NervionPlayers_Ent.Modelos;
using System.Security.Cryptography;
using System.Text;
using CryptoHelper;

namespace NervionPlayers_DAL.Manejadoras
{
    public class ManejadoraAlumnoDAL
    {

        private Connection con;

        public ManejadoraAlumnoDAL()
        {
            con = new Connection("ProfesorNervion", "1iNu#L0par7€T0");
        }

        /// <summary>
        /// Busca en la base de datos y devuelve un Alumno con el id recibido
        /// </summary>
        /// <param name="id">Recibe la id del alumno a buscar</param>
        /// <returns>retorna el Alumno</returns>
        public Alumno obtenerAlumno(int id)
        {
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();
            Alumno oAlumno = new Alumno();
            SqlDataReader lector;

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = String.Format("Select * From {0} Where {1} = {2}", ContratoDB.Alumno_DB.ALUMNO_DB_TABLE_NAME, ContratoDB.Alumno_DB.ALUMNO_DB_ID, id);
                miComando.Connection = conexion;
                lector = miComando.ExecuteReader();

                if (lector.HasRows)
                {
                    if (lector.Read())
                    {
                        oAlumno.Id = Convert.ToInt32(lector[ContratoDB.Alumno_DB.ALUMNO_DB_ID]);
                        oAlumno.Nombre = Convert.ToString(lector[ContratoDB.Alumno_DB.ALUMNO_DB_NOMBRE]);
                        oAlumno.Apellidos = Convert.ToString(lector[ContratoDB.Alumno_DB.ALUMNO_DB_APELLIDOS]);
                        oAlumno.Alias = Convert.ToString(lector[ContratoDB.Alumno_DB.ALUMNO_DB_ALIAS]);
                        oAlumno.Correo = Convert.ToString(lector[ContratoDB.Alumno_DB.ALUMNO_DB_CORREO]);
                        oAlumno.Curso = Convert.ToByte(lector[ContratoDB.Alumno_DB.ALUMNO_DB_CURSO]);
                        try
                        {
                            oAlumno.Foto = (byte[])lector[ContratoDB.Alumno_DB.ALUMNO_DB_FOTO];
                        }
                        catch (InvalidCastException)
                        {
                            oAlumno.Foto = null;
                        }

                        oAlumno.Confirmado = Convert.ToBoolean(lector[ContratoDB.Alumno_DB.ALUMNO_DB_CONFIRMADO]);
                        oAlumno.Letra = Convert.ToString(lector[ContratoDB.Alumno_DB.ALUMNO_DB_LETRA]);
                        oAlumno.Observaciones = Convert.ToString(lector[ContratoDB.Alumno_DB.ALUMNO_DB_OBSERVACIONES]);

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

            return oAlumno;
        }

        public Alumno obtenerAlumno(String cadena, String password)
        {
            Alumno alumno = new Alumno();
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();
            SqlDataReader lector;
            String cadenaCorreo = String.Format("Select * From {0} Where {1} = {2}", ContratoDB.Alumno_DB.ALUMNO_DB_TABLE_NAME, ContratoDB.Alumno_DB.ALUMNO_DB_CORREO, cadena);
            String cadenaAlias = String.Format("Select * From {0} Where {1} = {2}", ContratoDB.Alumno_DB.ALUMNO_DB_TABLE_NAME, ContratoDB.Alumno_DB.ALUMNO_DB_ALIAS, cadena);
            conexion = con.openConnection();
            miComando.Connection = conexion;
            

            //Si la cadena contiene @ significa que es el correo
            if (cadena.Contains("@"))
            {
                miComando.CommandText = cadenaCorreo;
                lector = miComando.ExecuteReader();
                //Si contiene filas es que el alumno con ese correo existe existe
                if(lector.HasRows)
                {
                   
                    //Comprobamos que la contraseña es correcta
                    
                }
            }
            //Si no , la cadena es el alias
            else
            {
                miComando.CommandText = cadenaAlias;
                lector = miComando.ExecuteReader();
                //Si contiene filas es que el alumno con ese alias existe existe
                if (lector.HasRows)
                {
                    //Comprobamos que la contraseña es correcta
                }
            }

            return alumno;
        }

        /// <summary>
        /// Añade un nuevo Alumno en la base de datos
        /// </summary>
        /// <param name="alumno">Recibe un  tipo Alumno</param>
        /// <returns>retorna el alumno</returns>
        public Alumno insertarAlumno(Alumno alumno)
        {
            Alumno miAlumno;
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();

            try
            {

                conexion = con.openConnection();
                miComando.CommandText = @"INSERT INTO[dbo].[@table_name] (@Nombre_DB,@Contraseña_DB, @Apellidos_DB, 
                                                 @Alias_DB , @Correo_DB, @Foto_DB, @Curso_DB, 
                                                  @Letra_DB, @Observaciones_DB, @Confirmado_DB) VALUES
                                                  (@Nombre,@Contraseña, @Apellidos, 
                                                 @Alias , @Correo, @Foto, @Curso, 
                                                  @Letra, @Observaciones, @Confirmado)";
                miComando.Connection = conexion;

                //Parametros Tabla
                miComando.Parameters.AddWithValue("@Nombre_DB", ContratoDB.Alumno_DB.ALUMNO_DB_NOMBRE);
                miComando.Parameters.AddWithValue("@Apellidos_DB", ContratoDB.Alumno_DB.ALUMNO_DB_APELLIDOS);
                miComando.Parameters.AddWithValue("@Alias_DB", ContratoDB.Alumno_DB.ALUMNO_DB_ALIAS);
                miComando.Parameters.AddWithValue("@Correo_DB", ContratoDB.Alumno_DB.ALUMNO_DB_CORREO);
                miComando.Parameters.AddWithValue("@Contraseña_DB", ContratoDB.Alumno_DB.ALUMNO_DB_CONTRASEÑA);
                miComando.Parameters.AddWithValue("@Foto_DB", ContratoDB.Alumno_DB.ALUMNO_DB_FOTO);
                miComando.Parameters.AddWithValue("@Curso_DB", ContratoDB.Alumno_DB.ALUMNO_DB_CURSO);
                miComando.Parameters.AddWithValue("@Confirmado_DB", ContratoDB.Alumno_DB.ALUMNO_DB_CONFIRMADO);
                miComando.Parameters.AddWithValue("@Letra_DB", ContratoDB.Alumno_DB.ALUMNO_DB_LETRA);
                miComando.Parameters.AddWithValue("@Observaciones_DB", ContratoDB.Alumno_DB.ALUMNO_DB_OBSERVACIONES);
                miComando.Parameters.AddWithValue("@table_Name", ContratoDB.Alumno_DB.ALUMNO_DB_TABLE_NAME);

                //Parametros Alumno
                miComando.Parameters.AddWithValue("@Nombre", alumno.Nombre);
                miComando.Parameters.AddWithValue("@Apellidos", alumno.Apellidos);
                miComando.Parameters.AddWithValue("@Alias", alumno.Alias);
                miComando.Parameters.AddWithValue("@Correo", alumno.Correo);
                miComando.Parameters.AddWithValue("@Contraseña", Crypto.HashPassword(alumno.Contraseña));
                miComando.Parameters.AddWithValue("@Foto", alumno.Foto);
                miComando.Parameters.AddWithValue("@Curso", alumno.Curso);
                miComando.Parameters.AddWithValue("@Confirmado", alumno.Confirmado);
                miComando.Parameters.AddWithValue("@Letra", alumno.Letra);
                miComando.Parameters.AddWithValue("@Observaciones", alumno.Observaciones);

                miComando.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }

            return obtenerAlumno(alumno.Alias,alumno.Contraseña);
        }

        /// <summary>
        /// Funcion que borra un Alumno de la base de datos 
        /// </summary>
        /// <param name="id">Recibe el id del Alumno a borrar</param>
        /// <returns>int , retorna el numero de filas afectadas</returns>
        public int borrarAlumno(int id)
        {
            int filasafectadas = 0;
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = String.Format("Delete from {0} where {1} = {2}", ContratoDB.Alumno_DB.ALUMNO_DB_TABLE_NAME, ContratoDB.Alumno_DB.ALUMNO_DB_ID, id);
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
        /// Funcion que actualiza un alumno de la base de datos
        /// </summary>
        /// <param name="alumno">Objeto Alumno NO NULO</param>
        /// <returns>int del numero de filas afectadas</returns>
        public int actualizarAlumno(Alumno alumno)
        {
            if (alumno == null)
                throw new ArgumentNullException("Alumno es nulo");

            int filasAfectadas = 0;
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = @"UPDATE [@table_Name] set @Nombre_DB=@Nombre_Alumno, @Apellidos_DB=@Apellidos_Alumno,
                                                                  @Alias_DB=@Alias_Alumno, @Correo_DB=@Correo_Alumno, @Contraseña_DB=@Contraseña_Alumno,
                                                                  @Foto_DB=@Foto_Alumno, @Curso_DB=@Curso_Alumno,@Confirmado_DB=@Confirmado_Alumno,@Letra_DB=@Letra_Alumno,
                                                                @Observaciones_DB=@Observaciones_Alumno
                                            WHERE @Id_DB=@Id_Alumno";



                miComando.Connection = conexion;

                //Parametros Tabla
                miComando.Parameters.AddWithValue("@Nombre_DB", ContratoDB.Alumno_DB.ALUMNO_DB_NOMBRE);
                miComando.Parameters.AddWithValue("@Apellidos_DB", ContratoDB.Alumno_DB.ALUMNO_DB_APELLIDOS);
                miComando.Parameters.AddWithValue("@Alias_DB", ContratoDB.Alumno_DB.ALUMNO_DB_ALIAS);
                miComando.Parameters.AddWithValue("@Correo_DB", ContratoDB.Alumno_DB.ALUMNO_DB_CORREO);
                miComando.Parameters.AddWithValue("@Contraseña_DB", ContratoDB.Alumno_DB.ALUMNO_DB_CONTRASEÑA);
                miComando.Parameters.AddWithValue("@Foto_DB", ContratoDB.Alumno_DB.ALUMNO_DB_FOTO);
                miComando.Parameters.AddWithValue("@Curso_DB", ContratoDB.Alumno_DB.ALUMNO_DB_CURSO);
                miComando.Parameters.AddWithValue("@Confirmado_DB", ContratoDB.Alumno_DB.ALUMNO_DB_CONFIRMADO);
                miComando.Parameters.AddWithValue("@Letra_DB", ContratoDB.Alumno_DB.ALUMNO_DB_LETRA);
                miComando.Parameters.AddWithValue("@Observaciones_DB", ContratoDB.Alumno_DB.ALUMNO_DB_OBSERVACIONES);
                miComando.Parameters.AddWithValue("@table_Name", ContratoDB.Alumno_DB.ALUMNO_DB_TABLE_NAME);
                miComando.Parameters.AddWithValue("@Id_DB", ContratoDB.Alumno_DB.ALUMNO_DB_ID);

                //Parametros Alumno
                miComando.Parameters.AddWithValue("@Nombre_Alumno", alumno.Nombre);
                miComando.Parameters.AddWithValue("@Apellidos_Alumno", alumno.Apellidos);
                miComando.Parameters.AddWithValue("@Alias_Alumno", alumno.Alias);
                miComando.Parameters.AddWithValue("@Correo_Alumno", alumno.Correo);
                miComando.Parameters.AddWithValue("@Contraseña_Alumno",Crypto.HashPassword(alumno.Contraseña));
                miComando.Parameters.AddWithValue("@Foto_Alumno", alumno.Foto);
                miComando.Parameters.AddWithValue("@Curso_Alumno", alumno.Curso);
                miComando.Parameters.AddWithValue("@Confirmado_Alumno", alumno.Confirmado);
                miComando.Parameters.AddWithValue("@Letra_Alumno", alumno.Letra);
                miComando.Parameters.AddWithValue("@Observaciones_Alumno", alumno.Observaciones);
                miComando.Parameters.AddWithValue("@Id_Alumno", alumno.Id);

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