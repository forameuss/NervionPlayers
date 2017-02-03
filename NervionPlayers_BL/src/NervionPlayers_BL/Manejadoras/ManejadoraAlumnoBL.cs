using NervionPlayers_BL.Model;
using NervionPlayers_Ent.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NervionPlayers_BL.Manejadoras
{
    public class ManejadoraAlumnoBL
    {

        /***************
         * Restricciones
         * *************
         * Nombre<=30
         * Apellidos<=50
         * Contraseña<=255 contendrá mínimo un caracter en mayúscula, un número y un carácter especial
         * Alias<=20
         * Correo<=50 será *@*.* donde * es cualquiera cadena
         * Letra<=10
         * No se insertará en BBDD las fecha de Creación
         * Curso: 5 corresponderá a 1 bachillerato,6 a segundo de bachillerato, 7 a primero de ciclo y 8 a segundo de ciclo
         */

        /// <summary>
        /// MAnejadora para Alumnos. Aquí se va.idarán los datos de entrada. Se controlarán por Throws.
        /// </summary>
            private const int NOMBRE_MAXIMO_CARACTER = 30;
            private const int APELLIDO_MAXIMO_CARACTER = 30;
            private const int PASS_MAXIMO_CARACTER = 255;
            private const int LETRA_MAXIMO_CARACTER = 10;

            public Alumno obtenerAlumno(int id)
            {

                return null;
            }

            public int insertarAlumno(Alumno alumno)
            {
                if (alumno.Nombre.Length > NOMBRE_MAXIMO_CARACTER)
                    throw new InvalidValueException("El nombre del alumno excede el maximo permitido de " + NOMBRE_MAXIMO_CARACTER);

                if (alumno.Apellidos.Length > APELLIDO_MAXIMO_CARACTER)
                    throw new InvalidValueException("El apellido del alumno excede el maximo permitod de " + APELLIDO_MAXIMO_CARACTER);

                if (!isPassValid(alumno.Contraseña))
                    throw new InvalidValueException("La contraseña del alumno no cumple con los requisitos");

                return 0;
            }

            public int borrarAlumno(int id)
            {
                return 0;
            }

            public int actualizarAlumno(Alumno alumno)
            {
                return 0;
            }

            /// <summary>
            /// Verifica si la contraseña cumple o no con los requisitos
            /// </summary>
            /// <param name="pass">Contraseña</param>
            /// <returns>false en caso de no cumplir y true en caso de si cumplir</returns>
            public bool isPassValid(String pass)
            {
                bool isValid = false;
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
            bool isUpper = pass.Any(x => char.IsUpper(x));
            bool isDigit = pass.Any(x => char.IsDigit(x));

            ///Si su tamaño es el <see cref="PASS_MAXIMO_CARACTER"/>, existe una mayusula y un numero, ademas si contiene caracteres espeicales.
            ///TODO añadir si hay caracteres especiales.
            if (pass.Length > PASS_MAXIMO_CARACTER && isUpper && isDigit)
                {
                    isValid = true;
                }

                return isValid;
            }
        }
}
