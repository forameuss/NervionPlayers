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
        #region Var & Const

        private const int NOMBRE_MAX_DEPORTE = 20;
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

        /// <summary>
        /// Permite insertar un deporte en caso de cumplir con los requisitos <see cref="Deporte.Nombre"/>
        /// menor que <see cref="NOMBRE_MAX_DEPORTE"/>
        /// </summary>
        /// <exception cref="InvalidValueException">En caso de no cumplir con los requisitos</exception>
        /// <param name="deporte"></param>
        /// <returns>Salida de <see cref="ManejadoraDeporteDAL.insertarDeporte(Deporte)"/></returns>
        public int insertarDeporte(Deporte deporte)
        {
            if (deporte.Nombre.Length > NOMBRE_MAX_DEPORTE)
                throw new InvalidValueException("El nombre del deporte supera lo permitido");

            return manejadora.insertarDeporte(deporte);
        }

        /// <summary>
        /// Permite borrar el deporte a traves de un id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Salida de <see cref="ManejadoraDeporteDAL.borrardeporte(int)"/></returns>
        public int borrarDeporte(int id)
        {
            return manejadora.borrardeporte(id);
        }

        /// <summary>
        /// Permite actualizar un deporte en caso que cumpla con los requisitos.
        /// </summary>
        /// <exception cref="InvalidValueException">En caso de no cumplir con los requisitos</exception>
        /// <param name="deporte"></param>
        /// <returns></returns>
        public int actualizarDeporte(Deporte deporte)
        {
            if (deporte.Nombre.Length > NOMBRE_MAX_DEPORTE)
                throw new InvalidValueException("El nombre del deporte supera lo permitido");

            return manejadora.actualizarDeporte(deporte);
        }

        #endregion
    }
}
