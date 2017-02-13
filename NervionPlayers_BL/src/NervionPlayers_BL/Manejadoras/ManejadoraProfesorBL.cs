using NervionPlayers_BL.Model;
using NervionPlayers_DAL.Manejadoras;
using NervionPlayers_Ent.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NervionPlayers_BL.Manejadoras
{
    /// <summary>
    /// Clase Manejadora Profesor DAL, valida y maneja al objeto <see cref="Profesor"/>
    /// </summary>
    public class ManejadoraProfesorBL
    {
        private ManejadoraProfesorDAL manejadora;

        /// <summary>
        /// Instancia la manejadora de DAL
        /// </summary>
        public ManejadoraProfesorBL()
        {
            manejadora = new ManejadoraProfesorDAL();
        }

        /// <summary>
        /// Obtiene un profesor a traves de su Id, devuelve el objeto en caso de encontrar o nulo.
        /// </summary>
        /// <param name="id">Identificador del profesor</param>
        /// <returns>Valor devuelto por <see cref="ManejadoraProfesorDAL"/></returns>
        public Profesor obtenerProfesor(int id)
        {
            return manejadora.obtenerProfesor(id);
        }

        /// <summary>
        /// Inserta un profesor tras la llamada a <see cref="ManejadoraProfesorDAL"/>, devuelte un int
        /// en el cual se reflejará el numero de filas afectadas.
        /// </summary>
        /// <exception cref="InvalidValueException">En caso de que profesor sea nulo</exception>
        /// <param name="profesor">Objeto profesor</param>
        /// <returns>Valor devuelto por <see cref="ManejadoraProfesorDAL"/></returns>
        public int insertarProfesor(Profesor profesor)
        {
            if (profesor == null)
                throw new InvalidValueException("El profesor es nulo");

            return manejadora.insertarProfesor(profesor);
        }

        /// <summary>
        /// Borra un profesor a la base de datos tras la llamada a <see cref="ManejadoraProfesorDAL"/>
        /// devuelve un valor int en el cual se reflejará el numero de filas afectadas.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int borrarProfesor(int id)
        {
            return manejadora.borrarProfesor(id);
        }

        /// <summary>
        /// Actualiza el profesor tras la llamada a <see cref="ManejadoraProfesorDAL"/>
        /// devuelve un valor int en el cual se reflejará el numero de filas afectadas.
        /// Se validará si el objeto no es Nulo
        /// </summary>
        /// <exception cref="InvalidValueException">En caso de que el objeto sea nulo</exception>
        /// <param name="profesor">Objeto no nulo</param>
        /// <returns>Valor devuelto por <see cref="ManejadoraProfesorDAL"/></returns>
        public int actualizarProfesor(Profesor profesor)
        {
            if (profesor == null)
                throw new InvalidValueException("El objeto profesor es nulo");

            return manejadora.actualizarProfesor(profesor);
        }

    }
}
