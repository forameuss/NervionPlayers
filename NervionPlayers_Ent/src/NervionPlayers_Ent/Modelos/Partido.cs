/***************
 * Restricciones
 * *************
 * No se insertará en BBDD las fecha de Creación
 * Fecha de partido posterior a fecha de creación
 * lugar<=30
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NervionPlayers_Ent.Modelos
{
    public class Partido
    {
        #region Atributos

        private int id;
        private int id_Local;
        private int id_Visitante;
        private int id_Deporte;
        private DateTime fecha_Partido;
        private DateTime fecha_Creacion;
        private Byte[] foto;
        private int resultado_Local;
        private int resultado_Visitante;
        private String lugar;
        private String notas;

     

        #endregion

        #region Constructores

        public Partido()
        {

        }

        public Partido(int id, int id_Local, int id_Visitante, int id_Deporte, DateTime fecha_Partido, DateTime fecha_Creacion, byte[] foto, int resultado_Local, int resultado_Visitante, string lugar, string notas)
        {
            Id = id;
            Id_Local = id_Local;
            Id_Visitante = id_Visitante;
            Id_Deporte = id_Deporte;
            Fecha_Partido = fecha_Partido;
            Fecha_Creacion = fecha_Creacion;
            Foto = foto;
            Resultado_Local = resultado_Local;
            Resultado_Visitante = resultado_Visitante;
            Lugar = lugar;
            Notas = notas;
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

        public DateTime Fecha_Partido
        {
            get
            {
                return fecha_Partido;
            }

            set
            {
                fecha_Partido = value;
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

        #region Metodos

        #endregion

    }
}
