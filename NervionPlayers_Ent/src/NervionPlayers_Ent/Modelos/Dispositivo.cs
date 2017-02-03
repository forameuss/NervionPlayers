using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NervionPlayers_Ent.Modelos
{
    public class Dispositivo
    {
        #region Atributos
        private int id;
        private int id_Alumno;
        private String token;
        private DateTime fecha_Creacion;
        private DateTime fecha_Modificacion;
        private bool activo;

        #endregion
        #region Constructores
        public Dispositivo() { }

        public Dispositivo(int id, int id_Alumno, string token, DateTime fecha_Creacion, DateTime fecha_Modificacion, bool activo)
        {
            this.id = id;
            this.id_Alumno = id_Alumno;
            this.token = token;
            this.fecha_Creacion = fecha_Creacion;
            this.fecha_Modificacion = fecha_Modificacion;
            this.activo = activo;
        }
        #endregion

        #region Propiedades

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

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

        public string Token
        {
            get
            {
                return token;
            }

            set
            {
                token = value;
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

        public DateTime Fecha_Modificacion
        {
            get
            {
                return fecha_Modificacion;
            }

            set
            {
                fecha_Modificacion = value;
            }
        }

        public bool Activo
        {
            get
            {
                return activo;
            }

            set
            {
                activo = value;
            }
        }

        #endregion
    }
}
