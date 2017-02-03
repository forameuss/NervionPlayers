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
        public InvalidValueException(String str) { }
        public InvalidValueException(String str, int line) : base(str + " at line " + line) { }
        public InvalidValueException(String str, Exception inner) : base(str, inner) { }
    }
}
