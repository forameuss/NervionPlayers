using NervionPlayers_BL.Model;
using NervionPlayers_DAL.Manejadoras;
using NervionPlayers_Ent.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NervionPlayers_BL.Manejadoras
{
    public class ManejadoraDeporteBL
    {
        #region Var

        private ManejadoraDeporteDAL manejadora;

        #endregion

        #region Constructores
        /// <summary>
        /// Instancia a <see cref="ManejadoraDeporteDAL"/>
        /// </summary>
        public ManejadoraDeporteBL()
        {
            manejadora = new ManejadoraDeporteDAL();
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Obtiene un deporte a traves de <see cref="Alumno.Id"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objeto <see cref="Deporte"/> o Null</returns>
        public Deporte obtenerDeporte(int id)
        {
            Deporte deporte = manejadora.obtenerDeporte(id);

            return deporte;
        }

        public int insertarDeporte(int id)
        {
            return 0;
        }

        public int borrarDeporte(int id)
        {
            return 0;
        }

        public int actualizarDeporte(Deporte deporte)
        {
            return 0;
        }

        #endregion
    }
}
