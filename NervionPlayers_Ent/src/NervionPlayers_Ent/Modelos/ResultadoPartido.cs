/**************
* Restricciones
* *************
* ganados,empatados y perdidos>=0
* 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NervionPlayers_Ent.Modelos
{
    public class ResultadoPartido
    {
        #region Atributos

        private int id;
        private int id_Equipo;
        private int ganados;
        private int empatados;
        private int perdidos;


        #endregion

        #region Constructores

        public ResultadoPartido()
        {

        }
        public ResultadoPartido(int id, int id_Equipo, int ganados, int empatados, int perdidos)
        {
            Id = id;
            Id_Equipo = id_Equipo;
            Ganados = ganados;
            Empatados = empatados;
            Perdidos = perdidos;
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

        public int Ganados
        {
            get
            {
                return ganados;
            }

            set
            {
                ganados = value;
            }
        }

        public int Empatados
        {
            get
            {
                return empatados;
            }

            set
            {
                empatados = value;
            }
        }

        public int Perdidos
        {
            get
            {
                return perdidos;
            }

            set
            {
                perdidos = value;
            }
        }
        #endregion
    }
}
