using NervionPlayers_Ent.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nervionPlayers_API.Models
{
    public class ResultadoPartidoNombre:ResultadoPartido
    {
        #region Atributos
        private String nombreEquipo;
        #endregion

        #region Constructores

        public ResultadoPartidoNombre(ResultadoPartido resultadoPartido, string nombreEquipo):base(resultadoPartido)
        {
            this.nombreEquipo = nombreEquipo;
        }
        #endregion

        #region Propiedades

        public string NombreEquipo
        {
            get
            {
                return nombreEquipo;
            }

            set
            {
                nombreEquipo = value;
            }
        }
        #endregion

    }
}
