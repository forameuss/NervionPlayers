using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NervionPlayers_Ent.Modelos
{
    public class AlumnoEquipo
    {
        #region Atributos
        private int id_Alumno;
        private int id_Equipo;
        private DateTime fecha_Creacion;

        
        #endregion

        #region Constructores

        public AlumnoEquipo()
        {

        }

        public AlumnoEquipo(int id_alumno,int id_equipo,DateTime fecha_Creacion)
        {
            this.Id_Alumno = id_alumno;
            this.Id_Equipo = id_equipo;
            this.Fecha_Creacion = fecha_Creacion;
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

        public int Id_Equipo
        {
            get
            {
                return id_Equipo;
            }

            set
            {
                id_Equipo = value;
            }
        }

        public DateTime Fecha_Creacion
        {
            get
            {
                return fecha_Creacion;
            }

            set
            {
                fecha_Creacion = value;
            }
        }
        #endregion
    }
}
