using DALClassLibrary;
using NervionPlayers_Ent.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NervionPlayers_DAL.Manejadoras
{
    public class ManejadoraAlumnoEquipoDAL
    {
        private Connection con;

        public ManejadoraAlumnoEquipoDAL()
        {
            con = new Connection("AlumnoNervion", ".N3tApe$7aH");
        }

        //NO ES NECESARIO HACER EL GET DE ALUMNOEQUIPO

        /// <summary>
        /// Añade un nuevo oAlumnoEquipo en la base de datos
        /// </summary>
        /// <param name="AlumnoEquipo">Recibe un  tipo AlumnoEquipo</param>
        /// <returns>retorna el numero de filas afectadas , int</returns>
        public int insertarAlumnoEquipo(AlumnoEquipo oAlumnoEquipo)
        {
            int filasAfectadas = 0;
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = @"INSERT INTO [dbo].[@table_Name] (@Id_Alumno_DB,@Id_Equipo_DB).
                                    VALUES (@Id_Alumno,@Id_Equipo)";
                miComando.Connection = conexion;

                //Parametros Tabla
                miComando.Parameters.AddWithValue("@Id_Alumno_DB", ContratoDB.alumnosEquipos_DB.ALUMNOSEQUIPOS_DB_ID_ALUMNO);
                miComando.Parameters.AddWithValue("@Id_Equipo_DB", ContratoDB.alumnosEquipos_DB.ALUMNOSEQUIPOS_DB_ID_EQUIPO);
                miComando.Parameters.AddWithValue("@table_Name", ContratoDB.alumnosEquipos_DB.ALUMNOSEQUIPOS_DB_TABLE_NAME);

                //Parametros Equipo
                miComando.Parameters.AddWithValue("@Id_Alumno", oAlumnoEquipo.Id_Alumno);
                miComando.Parameters.AddWithValue("@Id_Equipo", oAlumnoEquipo.Id_Equipo);

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
        /// Funcion que borra un AlumnoEquipo de la base de datos 
        /// </summary>
        /// <param name="id">Recibe el id del AlumnoEquipo a borrar</param>
        /// <returns>int , retorna el numero de filas afectadas</returns>
        public int borrarAlumnoEquipo(int id_Alumno,int id_Equipo)
        {
            int filasafectadas = 0;
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();

            try
            {
                conexion = con.openConnection();//MIRAR BIEN QUE SE USA PARA BORRAR
                miComando.CommandText = String.Format("Delete from {0} where {1} = {2} AND {3} = {4}", 
                                                        ContratoDB.alumnosEquipos_DB.ALUMNOSEQUIPOS_DB_TABLE_NAME, 
                                                        ContratoDB.alumnosEquipos_DB.ALUMNOSEQUIPOS_DB_ID_ALUMNO, id_Alumno,
                                                        ContratoDB.alumnosEquipos_DB.ALUMNOSEQUIPOS_DB_ID_EQUIPO,id_Equipo);
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
