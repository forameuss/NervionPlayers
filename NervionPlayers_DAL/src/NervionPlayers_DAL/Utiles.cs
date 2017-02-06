using DALClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NervionPlayers_DAL
{
    /// <summary>
    /// Colección de métodos de utilidad. 
    /// </summary>
    public class Utiles
    {
        private Connection con;

        #region Constructor
        public Utiles()
        {
            con = new Connection("AlumnoNervion", ".N3tApe$7aH");
        }
        #endregion

        
        #region Métodos
        /// <summary>
        /// Devuelve un entero segun la respuesta: 
        /// <para>0 - No existe</para>
        /// <para>1 - Alumno</para>
        /// <para>2 - Profesor</para>
        /// </summary>
        /// <param name="alias">Alias del usuario a buscar.</param>
        /// <returns>Devuelve el entero que indica el código.</returns>
        public int getTipo(String alias)
        {
            int res = 0;
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();            
            SqlDataReader lector;


            try
            {
                //Comprobar si es Alumno
                conexion = con.openConnection();
                miComando.CommandText = String.Format("Select * From {0} Where {1} = {2}", ContratoDB.Alumno_DB.ALUMNO_DB_TABLE_NAME, ContratoDB.Alumno_DB.ALUMNO_DB_ALIAS, alias);
                miComando.Connection = conexion;
                lector = miComando.ExecuteReader();
                if (lector.HasRows)
                    res = 1;
                else
                {
                    //Comprobar si es Profesor
                    miComando.CommandText = String.Format("Select * From {0} Where {1} = {2}", ContratoDB.Profesores_DB.TABLA, ContratoDB.Profesores_DB.ALIAS, alias);
                    miComando.Connection = conexion;
                    lector = miComando.ExecuteReader();
                    if (lector.HasRows)
                        res = 2;
                }


            } catch(Exception e)
            {
                throw e;
            }

            con.CloseConnection();
            return res;
        }      


        #endregion
    }
}
