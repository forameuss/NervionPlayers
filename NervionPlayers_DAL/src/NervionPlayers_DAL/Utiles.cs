using DALClassLibrary;
using System;
using System.Collections.Generic;
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
        
        //TODO: Termninar método
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


            return res;
        }
        


        #endregion
    }
}
