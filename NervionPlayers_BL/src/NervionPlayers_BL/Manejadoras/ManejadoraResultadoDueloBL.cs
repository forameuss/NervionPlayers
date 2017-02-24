using NervionPlayers_BL.Model;
using NervionPlayers_DAL.Manejadoras;
using NervionPlayers_Ent.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/***************
      * Restricciones
      * *************
      * Lugar<=30 caracteres
      *  */

namespace NervionPlayers_BL.Manejadoras
{
    public class ManejadoraResultadoDueloBL
    {
        #region const & Var
        private const int RESULTADO_MINIMO = 0;

        ManejadoraResultadoDueloDAL manejadoraResultadoDueloDal;
        #endregion

        #region Constructor
        public ManejadoraResultadoDueloBL()
        {
            manejadoraResultadoDueloDal = new ManejadoraResultadoDueloDAL();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Obtiene un ResultadoDuelo
        /// </summary>
        /// <param name="id">id del ResultadoDuelo a buscar</param>
        /// <returns>ResultadoDuelo</returns>
        public ResultadoDuelo obtenerResultadoDuelo(int id)
        {
            return manejadoraResultadoDueloDal.obtenerResultadoDuelo(id);
        }

        /// <summary>
        /// Inserta un ResultadoDuelo en la base de datos, valida que resultados sean iguales o mayores que 0
        /// </summary>
        /// <param name="resultadoDuelo">ResultadoDuelo</param>
        /// <returns>int con el numero de filas afectadas</returns>
        public int insertarResultadoDuelo(ResultadoDuelo resultadoDuelo)
        {
            if(resultadoDuelo.Ganados<RESULTADO_MINIMO || resultadoDuelo.Empatados<RESULTADO_MINIMO || resultadoDuelo.Perdidos < RESULTADO_MINIMO)
            {
                throw new InvalidValueException("El Numero de duelos ganados debe ser igual o mayor que "+RESULTADO_MINIMO);
            }
            if (resultadoDuelo.Perdidos < RESULTADO_MINIMO)
            {
                throw new InvalidValueException("El Numero de Perdidos debe ser igual o mayor que " + RESULTADO_MINIMO);
            }
            if (resultadoDuelo.Empatados < RESULTADO_MINIMO)
            {
                throw new InvalidValueException("El Numero de duelos Empatados debe ser igual o mayor que " + RESULTADO_MINIMO);
            }

            return manejadoraResultadoDueloDal.insertarResultadoDuelo(resultadoDuelo);
        }

        /// <summary>
        /// Borrara el ResultadoDuelo de la base de datos
        /// </summary>
        /// <param name="id">int del id del ResultadoDuelo a borrar</param>
        /// <returns>int con el numero de filas afectadas</returns>
        public int borrarResultadoDuelo(int id)
        {
            return manejadoraResultadoDueloDal.borrarResultadoDuelo(id);
        }

        /// <summary>
        /// Actualiza el contenido de ResultadoDuelo en la base de datos
        /// </summary>
        /// <param name="resultadoDuelo">ResultadoDuelo</param>
        /// <returns>int con el numero de filas afectadas</returns>
        public int actualizarResultadoDuelo(ResultadoDuelo resultadoDuelo)
        {
            if (resultadoDuelo.Ganados < RESULTADO_MINIMO || resultadoDuelo.Empatados < RESULTADO_MINIMO || resultadoDuelo.Perdidos < RESULTADO_MINIMO)
            {
                throw new InvalidValueException("El Numero de duelos ganados debe ser igual o mayor que " + RESULTADO_MINIMO);
            }
            if (resultadoDuelo.Perdidos < RESULTADO_MINIMO)
            {
                throw new InvalidValueException("El Numero de Perdidos debe ser igual o mayor que " + RESULTADO_MINIMO);
            }
            if (resultadoDuelo.Empatados < RESULTADO_MINIMO)
            {
                throw new InvalidValueException("El Numero de duelos Empatados debe ser igual o mayor que " + RESULTADO_MINIMO);
            }
            return manejadoraResultadoDueloDal.actualizarResultadoDuelo(resultadoDuelo);
        }

        #endregion
    }
}
