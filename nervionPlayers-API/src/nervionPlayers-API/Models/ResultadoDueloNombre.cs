using NervionPlayers_Ent.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nervionPlayers_API.Models
{
    public class ResultadoDueloNombre:ResultadoDuelo
    {
        #region Atributos
        private String nombreAlumno;



        #endregion

        #region Constructores

        public ResultadoDueloNombre(ResultadoDuelo resultadoDuelo,string nombreAlumno):base(resultadoDuelo)
        {
            this.nombreAlumno = nombreAlumno;
        }
        #endregion

        #region Propiedades

        public string NombreAlumno
        {
            get
            {
                return nombreAlumno;
            }

            set
            {
                nombreAlumno = value;
            }
        }
        #endregion

    }
}
