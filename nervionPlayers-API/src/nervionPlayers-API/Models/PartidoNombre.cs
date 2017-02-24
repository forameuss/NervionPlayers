using NervionPlayers_Ent.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nervionPlayers_API.Models
{
    public class PartidoNombre:Partido
    {
        #region Atributos
        private String nombreLocal;
        private String nombreVisitante;
        private String nombreDeporte;

        #endregion

        #region Constructores
        public PartidoNombre(Partido partido, string nombreLocal, string nombreVisitante, string nombreDeporte):base(partido)
        {
            this.nombreLocal = nombreLocal;
            this.nombreVisitante = nombreVisitante;
            this.nombreDeporte = nombreDeporte;
        }
        #endregion

        #region Propiedades

        public string NombreLocal
        {
            get
            {
                return nombreLocal;
            }

            set
            {
                nombreLocal = value;
            }
        }

        public string NombreVisitante
        {
            get
            {
                return nombreVisitante;
            }

            set
            {
                nombreVisitante = value;
            }
        }

        public string NombreDeporte
        {
            get
            {
                return nombreDeporte;
            }

            set
            {
                nombreDeporte = value;
            }
        }
        #endregion
    }
}
