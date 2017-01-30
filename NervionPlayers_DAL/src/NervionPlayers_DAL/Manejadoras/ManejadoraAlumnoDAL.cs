using DALClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace NervionPlayers_DAL.Manejadoras
{
    public class ManejadoraAlumnoDAL
    {

        private Connection con;

        public ManejadoraAlumnoDAL()
        {
            con = new Connection("AlumnoNervion", ".N3tApe$7aH");
        }

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

                       //oAlumno.Id = (int)lector[0];
                        //oAlumno.Nombre = (string)lector[1];
                        //oAlumno.Apellidos = (string)lector[2];
                        //oAlumno.Alias = (DateTime)lector[3];
                        //oAlumno.Correo = (string)lector[4];
                       
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

        public int insertarAlumno(Alumno alumno)
        {
            int filasAfectadas = 0;
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();
            Alumno oAlumno = new Alumno();
            SqlDataReader lector;

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = String.Format("");
                miComando.Connection = conexion;
                lector = miComando.ExecuteReader();

                if (lector.HasRows)
                {
                    if (lector.Read())
                    {
                        filasAfectadas = miComando.ExecuteNonQuery();
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

            return filasAfectadas;
        }

        public int borrarAlumno(int id)
        {
            int filasafectadas = 0;
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();
            Alumno oAlumno = new Alumno();
            SqlDataReader lector;

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = String.Format("");
                miComando.Connection = conexion;
                lector = miComando.ExecuteReader();

                if (lector.HasRows)
                {
                    if (lector.Read())
                    {
                        filasafectadas = miComando.ExecuteNonQuery();
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

            return filasafectadas;
        }
    }
}
