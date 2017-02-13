using DALClassLibrary;
using NervionPlayers_Ent.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CryptoHelper;

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

            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();
            Profesor oProfesor = new Profesor();
            SqlDataReader lector;

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = String.Format("Select * From {0} Where {1} = {2}", ContratoDB.Profesores_DB.TABLA, ContratoDB.Profesores_DB.ID, id);
                miComando.Connection = conexion;
                lector = miComando.ExecuteReader();

                if (lector.HasRows)
                {
                    if (lector.Read())
                    {
                        oProfesor.Id = Convert.ToInt32(lector[ContratoDB.Profesores_DB.ID]);
                        oProfesor.Nombre = Convert.ToString(lector[ContratoDB.Profesores_DB.NOMBRE]);
                        oProfesor.Apellidos = Convert.ToString(lector[ContratoDB.Profesores_DB.APELLIDOS]);
                        //oProfesor.Contraseña = Convert.ToString(lector[ContratoDB.Profesores_DB.CONTRASEÑA]);
                        oProfesor.Correo = Convert.ToString(lector[ContratoDB.Profesores_DB.CORREO]);
                        oProfesor.Fecha_Creacion = Convert.ToDateTime(lector[ContratoDB.Profesores_DB.FECHA_CREACION]);
                        oProfesor.Observaciones = Convert.ToString(lector[ContratoDB.Profesores_DB.OBSERVACIONEs]);
                        try
                        {
                            oProfesor.Foto = (byte[])lector[ContratoDB.Profesores_DB.FOTO];
                        }
                        catch (InvalidCastException)
                        {
                            oProfesor.Foto = null;
                        }
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

            return oProfesor;
        }

        /// <summary>
        /// Añade un nuevo Profesor en la base de datos
        /// </summary>
        /// <param name="profesor">Recibe un  tipo Profesor</param>
        /// <returns>retorna el numero de filas afectadas , int</returns>
        public int insertarProfesor(Profesor profesor)
        {
            int filasAfectadas = 0;
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();

            try
            {

                conexion = con.openConnection();
                miComando.CommandText = @"INSERT INTO[dbo].[@table_name] (@Nombre_DB,@Contraseña_DB, @Apellidos_DB, 
                                                 @Correo_DB, @Foto_DB, @Fecha_Creacion_DB, @Observaciones_DB) VALUES
                                                  (@Nombre,@Contraseña, @Apellidos, 
                                                 @Correo, @Foto, 
                                                  @Fecha_Creacion, @Observaciones)";
                miComando.Connection = conexion;

                //Parametros Tabla
                miComando.Parameters.AddWithValue("@Nombre_DB", ContratoDB.Profesores_DB.NOMBRE);
                miComando.Parameters.AddWithValue("@Apellidos_DB", ContratoDB.Profesores_DB.APELLIDOS);
                miComando.Parameters.AddWithValue("@Correo_DB", ContratoDB.Profesores_DB.CORREO);
                miComando.Parameters.AddWithValue("@Contraseña_DB", ContratoDB.Profesores_DB.CONTRASEÑA);
                miComando.Parameters.AddWithValue("@Foto_DB", ContratoDB.Profesores_DB.FOTO);
                miComando.Parameters.AddWithValue("@Fecha_Creacion_DB", ContratoDB.Profesores_DB.FECHA_CREACION);
                miComando.Parameters.AddWithValue("@Observaciones_DB", ContratoDB.Profesores_DB.OBSERVACIONEs);
                miComando.Parameters.AddWithValue("@table_Name", ContratoDB.Profesores_DB.TABLA);

                //Parametros Profesor
                miComando.Parameters.AddWithValue("@Nombre", profesor.Nombre);
                miComando.Parameters.AddWithValue("@Apellidos", profesor.Apellidos);
                miComando.Parameters.AddWithValue("@Correo", profesor.Correo);
                miComando.Parameters.AddWithValue("@Contraseña", Crypto.HashPassword(profesor.Contraseña));
                miComando.Parameters.AddWithValue("@Foto", profesor.Foto);
                miComando.Parameters.AddWithValue("@Fecha_Creacion", profesor.Fecha_Creacion);
                miComando.Parameters.AddWithValue("@Observaciones", profesor.Observaciones);

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
        /// Funcion que borra un Profesor de la base de datos 
        /// </summary>
        /// <param name="id">Recibe el id del Partido a borrar</param>
        /// <returns>int , retorna el numero de filas afectadas</returns>
        public int borrarProfesor(int id)
        {

            int filasafectadas = 0;
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = String.Format("Delete from {0} where {1} = {2}", ContratoDB.Profesores_DB.TABLA, ContratoDB.Profesores_DB.ID, id);
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
        /// Funcion que actualiza un Profesor de la base de datos
        /// </summary>
        /// <param name="profesor">Objeto Profesor NO NULO</param>
        /// <returns>int del numero de filas afectadas</returns>
        public int actualizarProfesor(Profesor profesor)
        {

            if (profesor == null)
                throw new ArgumentNullException("Profesor es nulo");

            int filasAfectadas = 0;
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = @"UPDATE [@table_Name] set @Nombre_DB=@Nombre, @Apellidos_DB=@Apellidos,
                                                                  @Correo_DB=@Correo, @Contraseña_DB=@Contraseña,
                                                                  @Foto_DB=@Foto, @Fecha_Creacion_DB=@Fecha_Creacion,
                                                                @Observaciones_DB=@Observacione
                                            WHERE @Id_DB=@Id";



                miComando.Connection = conexion;

                //Parametros Tabla
                miComando.Parameters.AddWithValue("@Id_DB", ContratoDB.Profesores_DB.ID);
                miComando.Parameters.AddWithValue("@Nombre_DB", ContratoDB.Profesores_DB.NOMBRE);
                miComando.Parameters.AddWithValue("@Apellidos_DB", ContratoDB.Profesores_DB.APELLIDOS);
                miComando.Parameters.AddWithValue("@Correo_DB", ContratoDB.Profesores_DB.CORREO);
                miComando.Parameters.AddWithValue("@Contraseña_DB", ContratoDB.Profesores_DB.CONTRASEÑA);
                miComando.Parameters.AddWithValue("@Foto_DB", ContratoDB.Profesores_DB.FOTO);
                miComando.Parameters.AddWithValue("@Fecha_Creacion_DB", ContratoDB.Profesores_DB.FECHA_CREACION);
                miComando.Parameters.AddWithValue("@Observaciones_DB", ContratoDB.Profesores_DB.OBSERVACIONEs);
                miComando.Parameters.AddWithValue("@table_Name", ContratoDB.Profesores_DB.TABLA);

                //Parametros Profesor
                miComando.Parameters.AddWithValue("@Id", profesor.Id);
                miComando.Parameters.AddWithValue("@Nombre", profesor.Nombre);
                miComando.Parameters.AddWithValue("@Apellidos", profesor.Apellidos);
                miComando.Parameters.AddWithValue("@Correo", profesor.Correo);
                miComando.Parameters.AddWithValue("@Contraseña",Crypto.HashPassword(profesor.Contraseña));
                miComando.Parameters.AddWithValue("@Foto", profesor.Foto);
                miComando.Parameters.AddWithValue("@Fecha_Creacion", profesor.Fecha_Creacion);
                miComando.Parameters.AddWithValue("@Observaciones", profesor.Observaciones);

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

