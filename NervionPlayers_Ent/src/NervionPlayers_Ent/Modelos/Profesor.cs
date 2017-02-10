using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NervionPlayers_Ent.Modelos
{
    public class Profesor
    {
        #region Atributos
        private int id;
        private String nombre;
        private String apellidos;
        private String contraseña;
        private String correo;
        private DateTime fecha_Creacion;
        private String observaciones;
        private Byte[] foto;

        #endregion

        #region Constructores
        public Profesor()
        {
        }

        public Profesor(int id, string nombre, string apellidos, string contraseña, string correo, DateTime fecha_Creacion, string observaciones, byte[] foto)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.contraseña = contraseña;
            this.correo = correo;
            this.fecha_Creacion = fecha_Creacion;
            this.observaciones = observaciones;
            this.foto = foto;
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

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }
        

        public string Correo
        {
            get
            {
                return correo;
            }

            set
            {
                correo = value;
            }
        }

        public DateTime Fecha_Creacion
        {
            get
            {
                return fecha_Creacion;
            }
        }
        
        

        public string Observaciones
        {
            get
            {
                return observaciones;
            }

            set
            {
                observaciones = value;
            }
        }
        

        public string Contraseña
        {
            get
            {
                return contraseña;
            }

            set
            {
                contraseña = value;
            }
        }

        public string Apellidos
        {
            get
            {
                return apellidos;
            }

            set
            {
                apellidos = value;
            }
        }

        public byte[] Foto
        {
            get
            {
                return foto;
            }

            set
            {
                foto = value;
            }
        }

        #endregion

        #region Métodos

        #endregion
    }
}
