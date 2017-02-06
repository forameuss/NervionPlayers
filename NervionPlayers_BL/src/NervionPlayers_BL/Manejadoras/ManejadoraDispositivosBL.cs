using NervionPlayers_DAL.Manejadoras;
using NervionPlayers_Ent.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NervionPlayers_BL.Manejadoras
{    
    /// <summary>
    /// Manejadora BL de la clase Dispositivo.
    /// </summary>
    public class ManejadoraDispositivosBL
    {
        #region Variables
        private ManejadoraDispositivoDAL manejadora;
        #endregion

        #region Constructor
        /// <summary>
        /// Manejadora de Dispositivos
        /// </summary>
        public ManejadoraDispositivosBL()
        {
            manejadora = new ManejadoraDispositivoDAL();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Obtiene un dispositivo a partir de una id
        /// </summary>
        /// <param name="id">Id del dispositivo</param>
        /// <returns>Devuelve el dispositivo si se encuentra o null en caso contrario</returns>
        public Dispositivo obtenerDispositivo(int id)
        {            
            return manejadora.obtenerDispositivo(id);
        }

        /// <summary>
        /// Inserta un dispositivo en la base de datos
        /// </summary>
        /// <param name="dispositivo">Dispositivo a insertar</param>
        /// <returns>Devuelve el número de filas afectadas.</returns>
        public int insertarDispositivo(Dispositivo dispositivo)
        {
            return manejadora.insertarDispositivo(dispositivo);
        }

        /// <summary>
        /// Borra un dispositivo de la base de datos
        /// </summary>
        /// <param name="id">Id del dispositivo a borrar</param>
        /// <returns>Devuelve el número de filas afectadas</returns>
        public int borrarDispositivo(int id)
        {
            return manejadora.borrarDispositivo(id);
        }

        /// <summary>
        /// Actualiza un dispositivo de la base de datos
        /// </summary>
        /// <param name="dispositivo">Dispositivo a actualizar</param>
        /// <returns>Devuelve el número de filas afectadas</returns>
        public int actualizarDispositivo(Dispositivo dispositivo)
        {
            return manejadora.actualizarDispositivo(dispositivo);
        }
        #endregion
    }
}
