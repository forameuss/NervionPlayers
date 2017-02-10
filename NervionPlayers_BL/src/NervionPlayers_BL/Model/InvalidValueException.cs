using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NervionPlayers_BL.Model
{
    /// <summary>
    /// Clase dedicada para las excepciones de la BL, generalmente cuando haya un valor que no cumpla con los requisitos propuestos
    /// aparecerá este exception.
    /// </summary>
    public class InvalidValueException : Exception
    {
        /// <summary>
        /// Excepcion que saltará al encontrar un valor invalido p que viole las condiciones propuestas.
        /// </summary>
        /// <param name="str">Informacion de la excepcion</param>
        public InvalidValueException(String str) { }

        /// <summary>
        /// Excepcion que saltará al encontrar un valor invalido p que viole las condiciones propuestas.
        /// </summary>
        /// <param name="str">Informacion de la excepcion</param>
        /// <param name="line">Linea del error</param>
        public InvalidValueException(String str, int line) : base(str + " at line " + line) { }

        /// <summary>
        /// Excepcion que saltará al encontrar un valor invalido p que viole las condiciones propuestas.
        /// </summary>
        /// <param name="str">Informacion de la excpcion</param>
        /// <param name="inner">Inner administrado</param>
        public InvalidValueException(String str, Exception inner) : base(str, inner) { }
    }
}
