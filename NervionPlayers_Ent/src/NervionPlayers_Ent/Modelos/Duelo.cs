using System;
/**************
* Restricciones
* *************
* Lugar<=30 caracteres
* No se insertará en BBDD las fecha de Creación
* 
*/
namespace NervionPlayers_Ent.Modelos
{
    public class Duelo
    {
        #region Atributos
        private int id;
        private int id_Local;
        private int id_Visitante;
        private int id_Deporte;
        private DateTime fecha_Creacion;
        private DateTime fecha_Duelo;
        private Byte[] foto;
        private int resultado_Local;
        private int resultado_Visitante;
        private String lugar;
        private String notas;

        #endregion

        #region Constructores
        public Duelo() { }

        public Duelo(int id, int id_Local, int id_Visitante, int id_Deporte, DateTime fecha_Creacion, DateTime fecha_Duelo,
                Byte[] foto, int resultado_Local, int resultado_Visitante, String lugar, String notas)
        {
            this.id = id;
            this.id_Local = id_Local;
            this.id_Visitante = id_Visitante;
            this.id_Deporte = id_Deporte;
            this.fecha_Creacion = fecha_Creacion;
            this.fecha_Duelo = fecha_Duelo;
            this.foto = foto;
            this.resultado_Local = resultado_Local;
            this.resultado_Visitante = resultado_Visitante;
            this.lugar = lugar;
            this.notas = notas;
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

        public int Id_Local
        {
            get
            {
                return id_Local;
            }

            set
            {
                id_Local = value;
            }
        }

        public int Id_Visitante
        {
            get
            {
                return id_Visitante;
            }

            set
            {
                id_Visitante = value;
            }
        }

        public int Id_Deporte
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

        public DateTime Fecha_Duelo
        {
            get
            {
                return fecha_Duelo;
            }

            set
            {
                fecha_Duelo = value;
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

        public int Resultado_Local
        {
            get
            {
                return resultado_Local;
            }

            set
            {
                resultado_Local = value;
            }
        }

        public int Resultado_Visitante
        {
            get
            {
                return resultado_Visitante;
            }

            set
            {
                resultado_Visitante = value;
            }
        }

        public string Lugar
        {
            get
            {
                return lugar;
            }

            set
            {
                lugar = value;
            }
        }

        public string Notas
        {
            get
            {
                return notas;
            }

            set
            {
                notas = value;
            }
        }
        #endregion

        #region Métodos

        #endregion
    }
}