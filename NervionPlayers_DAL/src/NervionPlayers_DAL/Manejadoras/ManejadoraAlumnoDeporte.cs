using DALClassLibrary;
using NervionPlayers_Ent.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NervionPlayers_DAL.Manejadoras
{
    public class ManejadoraAlumnoDeporte
    {
        private Connection con;

        public ManejadoraAlumnoDeporte()
        {
            con = new Connection("ProfesorNervion", "1iNu#L0par7€T0");
        }

        //NO ES NECESARIO HACER EL GET DE ALUMNOEQUIPO

        /// <summary>
        /// Añade un nuevo oAlumnoDeporte en la base de datos
        /// </summary>
        /// <param name="AlumnoDeporte">Recibe un  tipo AlumnoDeporte</param>
        /// <returns>retorna el numero de filas afectadas , int</returns>
        public int insertarAlumnoDeporte(AlumnoDeporte oAlumnoDeporte)
        {
            int filasAfectadas = 0;
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = @"INSERT INTO [dbo].[@table_Name] (@Id_Alumno_DB,@Id_Deporte_DB).
                                    VALUES (@Id_Alumno,@Id_Deporte)";
                miComando.Connection = conexion;

                //Parametros Tabla
                miComando.Parameters.AddWithValue("@Id_Alumno_DB", ContratoDB.AlumnosDeportes_DB.ALUMNOSDEPORTES_DB_ID_ALUMNO);
                miComando.Parameters.AddWithValue("@Id_Deporte_DB", ContratoDB.AlumnosDeportes_DB.ALUMNOSDEPORTES_DB_ID_DEPORTE);
                miComando.Parameters.AddWithValue("@table_Name", ContratoDB.AlumnosDeportes_DB.ALUMNOSDEPORTES_DB_TABLE_NAME);

                //Parametros Equipo
                miComando.Parameters.AddWithValue("@Id_Alumno", oAlumnoDeporte.Id_Alumno);
                miComando.Parameters.AddWithValue("@Id_Deporte", oAlumnoDeporte.iId_Deporte);

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
        /// Método que borra un ALumnoDeporte
        /// </summary>
        /// <param name="id_Alumno"></param>
        /// <param name="id_Deporte"></param>
        /// <returns></returns>
        public int borrarAlumnoDeporte(int id_Alumno, int id_Deporte)
        {
            int filasafectadas = 0;
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();

            try
            {
                conexion = con.openConnection();//MIRAR BIEN QUE SE USA PARA BORRAR
                miComando.CommandText = String.Format("Delete from {0} where {1} = {2} AND {3} = {4}",
                                                        ContratoDB.AlumnosDeportes_DB.ALUMNOSDEPORTES_DB_TABLE_NAME,
                                                        ContratoDB.AlumnosDeportes_DB.ALUMNOSDEPORTES_DB_ID_ALUMNO, id_Alumno,
                                                        ContratoDB.AlumnosDeportes_DB.ALUMNOSDEPORTES_DB_ID_DEPORTE, id_Deporte);
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
