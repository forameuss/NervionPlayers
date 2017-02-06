using NervionPlayers_BL.Model;
using NervionPlayers_DAL.Manejadoras;
using NervionPlayers_Ent.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NervionPlayers_BL.Manejadoras
{
    public class ManejadoraDueloBL
    {

        #region Var & Const

        private const int LUGAR_MAX_DUELO = 30;
        private ManejadoraDueloDAL manejadora;

        #endregion

        #region Constructores
        /// <summary>
        /// Inicializa <see cref="ManejadoraDueloDAL"/>
        /// </summary>
        public ManejadoraDueloBL()
        {
            manejadora = new ManejadoraDueloDAL();
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Obtiene un duelo a traves de su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objeto duelo o null</returns>
        public Duelo obtenerDuelo(int id)
        {
            Duelo duelo = manejadora.obtenerDuelo(id);

            return duelo;
        }

        /// <summary>
        /// Inserta un duelo si cumple todos los requisitos. Lugar menos o igual que <see cref="LUGAR_MAX_DUELO"/>
        /// </summary>
        /// <exception cref="InvalidValueException">En caso de no cumplir los requisitos</exception>
        /// <param name="duelo"></param>
        /// <returns>Valor devuelto por <see cref="ManejadoraDueloDAL.insertarDuelo(Duelo)"/></returns>
        public int insertarDuelo(Duelo duelo)
        {
            if (duelo.Lugar.Length > LUGAR_MAX_DUELO)
                throw new InvalidValueException("El lugar del duelo excede el maximo permitido de caracteres (" + LUGAR_MAX_DUELO + ")");

            return manejadora.insertarDuelo(duelo);
        }

        /// <summary>
        /// Borra un duelo a traves de su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Valor devuelto por <see cref="ManejadoraDueloDAL.borrarDuelo(int)"/></returns>
        public int borrarDuelo(int id)
        {
            return manejadora.borrarDuelo(id);
        }

        /// <summary>
        /// Actualiza un duelo en caso de cumplir los requisitos. Lugar menos o igual que <see cref="LUGAR_MAX_DUELO"/>
        /// </summary>
        /// <exception cref="InvalidValueException">En caso de no cumplir los requisitos</exception>
        /// <param name="duelo"></param>
        /// <returns>Valor devuelto por <see cref="ManejadoraDueloDAL.actualizarDuelo(Duelo)"/></returns>
        public int actualizarDuelo(Duelo duelo)
        {
            if (duelo.Lugar.Length > LUGAR_MAX_DUELO)
                throw new InvalidValueException("El lugar del duelo excede el maximo permitido de caracteres (" + LUGAR_MAX_DUELO + ")");

            return manejadora.actualizarDuelo(duelo);
        }

        #endregion
    }
}
