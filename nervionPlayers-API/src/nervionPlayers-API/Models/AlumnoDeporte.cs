using NervionPlayers_Ent.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nervionPlayers_API.Models
{
    public class AlumnoDeporte : Alumno
    {
        #region Atributos
        private int idDeporte;
        private String nombreDeporte;
        #endregion

        #region Constructores
        public AlumnoDeporte(Alumno alumno, Deporte deporte) : base(alumno) {
            this.idDeporte = deporte.Id;
            this.nombreDeporte = deporte.Nombre;
        }
        #endregion

        #region Getters y Setters
        public int IdDeporte
        {
            get
            {
                return idDeporte;
            }

            set
            {
                idDeporte = value;
            }
        }

        public String NombreDeporte {
            get {
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
