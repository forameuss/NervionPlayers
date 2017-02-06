using NervionPlayers_DAL.Manejadoras;
using NervionPlayers_Ent.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NervionPlayers_BL.Manejadoras
{
    public class ManejadoraResultadoPartidoBL
    {

        #region Var & Const

        private ManejadoraResultadoPartidoDAL manejadora;

        #endregion

        #region Constructor

        /// <summary>
        /// Inicializa <see cref="ManejadoraResultadoPartidoDAL"/>
        /// </summary>
        public ManejadoraResultadoPartidoBL()
        {
            manejadora = new ManejadoraResultadoPartidoDAL();
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Obtiene un <see cref="ResultadoPartido"/> a traves de un id
        /// </summary>
        /// <param name="id">Id del partido</param>
        /// <returns>Devuelve un objeto <see cref="ResultadoPartido"/> o Null en caso de no encontrarlo</returns>
        public ResultadoPartido obtenerResultadoPartido(int id)
        {
            ResultadoPartido resultadopartido = manejadora.obtenerResultadoPartido(id);
            return resultadopartido;
        }

        /// <summary>
        /// Permite insertar un <see cref="ResultadoPartido"/>
        /// </summary>
        /// <param name="resultadoPartido"></param>
        /// <returns>Valor devuelto por <see cref="ManejadoraResultadoPartidoDAL.insertarResultadoPartido(ResultadoPartido)"/></returns>
        public int insertarResultadoPartido(ResultadoPartido resultadoPartido)
        {
            return manejadora.insertarResultadoPartido(resultadoPartido);
        }

        /// <summary>
        /// Borra un <see cref="ResultadoPartido"/> a traves de su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Valor devuelto por <see cref="ManejadoraResultadoPartidoDAL.borrarResultadoPartido(int)"/></returns>
        public int borrarResultadoPartido(int id)
        {
            return manejadora.borrarResultadoPartido(id);
        }

        /// <summary>
        /// Actualiza un <see cref="ResultadoPartido"/>
        /// </summary>
        /// <param name="resultadoPartido"></param>
        /// <returns>Valor devuelto por <see cref="ManejadoraResultadoPartidoDAL.actualizarResultadoPartido(ResultadoPartido)"/></returns>
        public int actualizarResultaoPartido(ResultadoPartido resultadoPartido)
        {
            return manejadora.actualizarResultadoPartido(resultadoPartido);
        }

        #endregion
    }
}
