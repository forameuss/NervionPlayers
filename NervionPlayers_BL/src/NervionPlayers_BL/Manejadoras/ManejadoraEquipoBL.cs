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
      * Nombre<=20
      *  */

namespace NervionPlayers_BL.Manejadoras
{
    public class ManejadoraEquipoBL
    {
        #region const & Var
        private const int NOMBRE_MAXIMO_CARACTER = 20;

        ManejadoraEquipoDAL manejadoraEquipoDAL;
        #endregion

        #region Constructores
        public ManejadoraEquipoBL()
        {
            manejadoraEquipoDAL = new ManejadoraEquipoDAL();
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Obtiene un equipo
        /// </summary>
        /// <param name="id">int del id del quipo a buscar</param>
        /// <returns>Equipo</returns>
        public Equipo obtenerEquipo(int id)
        {
            return manejadoraEquipoDAL.obtenerEquipo(id);
        }

        /// <summary>
        /// Inserta un Equipo en la base de datos
        /// </summary>
        /// <param name="equipo">Equipo a insertar</param>
        /// <returns>int con el numero de filas modificadas</returns>
        public int insertarEquipo(Equipo equipo)
        {
            if(equipo.Nombre.Length > NOMBRE_MAXIMO_CARACTER)
            {
                throw new InvalidValueException("El nombre del quipo no puede tener mas de "+NOMBRE_MAXIMO_CARACTER+" caracteres");
            }
            return manejadoraEquipoDAL.insertarEquipo(equipo);
        }

        /// <summary>
        /// Borra un Equipo de la base de datos
        /// </summary>
        /// <param name="id">int del id del quipo a borrar</param>
        /// <returns>int con numero de filas afectadas</returns>
        public int borrarEquipo(int id)
        {
            return manejadoraEquipoDAL.borrarEquipo(id);
        }

        /// <summary>
        /// Actualiza el Equipo en la base de datos
        /// </summary>
        /// <param name="equipo">Equipo</param>
        /// <returns>int con el numero de filas afectadas</returns>
        public int actualizarEquipo(Equipo equipo)
        {
            if (equipo.Nombre.Length > NOMBRE_MAXIMO_CARACTER)
            {
                throw new InvalidValueException("El nombre del quipo no puede tener mas de " + NOMBRE_MAXIMO_CARACTER + " caracteres");
            }
            return manejadoraEquipoDAL.actualizarEquipo(equipo);
        }

        #endregion
    }
}
