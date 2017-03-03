using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NervionPlayers_Ent.Modelos
{
    public class AlumnoDeporte
    {
        #region Atributos
        private int id_Alumno;
        private int id_Deporte;


        #endregion

        #region Constructores

        public AlumnoDeporte()
        {

        }

        public AlumnoDeporte(int id_alumno, int id_Deporte)
        {
            this.Id_Alumno = id_alumno;
            this.id_Deporte = id_Deporte;
        }

        #endregion

        #region Propiedades
        public int Id_Alumno
        {
            get
            {
                return id_Alumno;
            }

            set
            {
                id_Alumno = value;
            }
        }

        public int iId_Deporte
        {
            get
            {
                return id_Deporte;
            }

            set
            {
                id_Deporte = value;
            }
        }
        
        #endregion
    }
}
