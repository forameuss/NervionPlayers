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

        public Alumno obtenerAlumno(int id) {

            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();
            Alumno oAlumno = new Alumno();
            SqlDataReader lector;

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = "SELECT * FROM personas WHERE IDPersona=" + id;
                miComando.Connection = conexion;
                lector = miComando.ExecuteReader();

                if (lector.HasRows)
                {
                    if (lector.Read())
                    {

                        oAlumno.Id = (int)lector[0];
                        oAlumno.Nombre = (string)lector[1];
                        oAlumno.Apellidos = (string)lector[2];
                        oAlumno.Alias = (DateTime)lector[3];
                        oAlumno.Correo = (string)lector[4];
                        oPersona.telefono = (string)lector[5];
                    }
                }

            }
            catch (SqlException ex)
            {

                throw ex;
            }


            return oPersona;
        }
    }
}
