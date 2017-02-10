using NervionPlayers_BL.Model;
using NervionPlayers_Ent.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Globalization;
using NervionPlayers_DAL.Manejadoras;

namespace NervionPlayers_BL.Manejadoras
{
    /// <summary>
    /// MAnejadora para Alumnos. Aquí se va.idarán los datos de entrada. Se controlarán por Throws.
    /// </summary>
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
        #region const & Var
        private const int NOMBRE_MAXIMO_CARACTER = 30;
        private const int APELLIDO_MAXIMO_CARACTER = 30;
        private const int PASS_MAXIMO_CARACTER = 255;
        private const int LETRA_MAXIMO_CARACTER = 10;
        private const int CURSO_MINIMO_ACEPTADO = 5;
        private const int CURSO_MAXIMO_ACEPTADO = 8;

        private ManejadoraAlumnoDAL manejadora;
        #endregion

        #region Constructor

        /// <summary>
        /// Manejadora Alumno, gestiona todos las posibles acciones con alumno.
        /// </summary>
        public ManejadoraAlumnoBL()
        {
            manejadora = new ManejadoraAlumnoDAL();
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Obtiene un alumno desde su id, devuelve o null si no se encuentra el objeto o el objeto en si.
        /// </summary>
        /// <param name="id"></param>
        /// <returns><see cref="Alumno"/> o Null/></returns>
        public Alumno obtenerAlumno(int id)
        {
            Alumno alumno = manejadora.obtenerAlumno(id);

            return alumno;
        }

        /// <summary>
        /// Inserta un alumno tras la llamada a <seealso cref="ManejadoraAlumnoDAL"/>.
        /// </summary>
        /// <remarks>El alumno debe cumplir las especificaciones de <seealso cref="Alumno"/></remarks>
        /// <exception cref="InvalidValueException">En caso de no cumplir con las especificaciones</exception>
        /// <param name="alumno">Objeto alumno</param>
        /// <returns><see cref="ManejadoraAlumnoDAL"/></returns>
        public int insertarAlumno(Alumno alumno)
        {
            //Comprobacion de los datos del alumno

            if (alumno.Nombre.Length > NOMBRE_MAXIMO_CARACTER)
                throw new InvalidValueException("El nombre del alumno excede el maximo permitido de " + NOMBRE_MAXIMO_CARACTER);

            if (alumno.Apellidos.Length > APELLIDO_MAXIMO_CARACTER)
                throw new InvalidValueException("El apellido del alumno excede el maximo permitod de " + APELLIDO_MAXIMO_CARACTER);

            if (!isPassValid(alumno.Contraseña))
                throw new InvalidValueException("La contraseña del alumno no cumple con los requisitos");

            if (!isPassValid(alumno.Correo))
                throw new InvalidValueException("El correo no es valido");

            if (alumno.Curso < CURSO_MINIMO_ACEPTADO || alumno.Curso > CURSO_MAXIMO_ACEPTADO)
                throw new InvalidValueException("El curso no es aceptado (un rango de " + CURSO_MINIMO_ACEPTADO + " a " + CURSO_MINIMO_ACEPTADO + ")");

            //Todo es correcto se llama a DAL
            return manejadora.insertarAlumno(alumno);
        }

        /// <summary>
        /// Permite borrar un alumno a trves de su id
        /// </summary>
        /// <param name="id">Id del alumnos</param>
        /// <returns>valor devuelto por <see cref="ManejadoraAlumnoDAL.borrarAlumno(int)"/></returns>
        public int borrarAlumno(int id)
        {
            return manejadora.borrarAlumno(id);
        }

        /// <summary>
        /// Permite actualizar un alumno si se ha cumplido todas las especificaciones de <see cref="Alumno"/>
        /// </summary>
        /// <param name="alumno">Objeto <see cref="Alumno"/></param>
        /// <returns>Valor devuelto por <see cref="ManejadoraAlumnoDAL.actualizarAlumno(Alumno)"/></returns>
        public int actualizarAlumno(Alumno alumno)
        {
            //Comprobacion de los datos del alumno

            if (alumno.Nombre.Length > NOMBRE_MAXIMO_CARACTER)
                throw new InvalidValueException("El nombre del alumno excede el maximo permitido de " + NOMBRE_MAXIMO_CARACTER);

            if (alumno.Apellidos.Length > APELLIDO_MAXIMO_CARACTER)
                throw new InvalidValueException("El apellido del alumno excede el maximo permitod de " + APELLIDO_MAXIMO_CARACTER);

            if (!isPassValid(alumno.Contraseña))
                throw new InvalidValueException("La contraseña del alumno no cumple con los requisitos");

            if (!isPassValid(alumno.Correo))
                throw new InvalidValueException("El correo no es valido");

            //Todo es correcto se llama a DAL
            return manejadora.actualizarAlumno(alumno);
        }

        #endregion

        #region Validators

        /// <summary>
        /// Valida si el email es valido
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private bool isValidEmail(String email)
        {
            bool isValid = false;
            String mEmail;

            if (String.IsNullOrEmpty(email))
            {
                isValid = false;

            }
            else
            {
                try
                {
                    //Combierte los caracteres de email que vieneen despues del @ para validar el email, en caso de excepcion en
                    // la conversion unicode saltara como invalido por accion de Excepcion.
                    mEmail = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                          RegexOptions.None, TimeSpan.FromMilliseconds(200));

                    isValid = Regex.IsMatch(mEmail,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
                }
                catch (Exception) //Deberia recoger dos excepciones solo [ArgumentException & RegexMatchTimeoutException]
                {
                    isValid = false;
                }
            }

            return isValid;
        }

        /// <summary>
        /// Comprueba el dominio de correo.
        /// </summary>
        /// <param name="match">Parte del dominio del correo. EJ ex@example.com (example.com)</param>
        /// <returns></returns>
        private string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;

            //CUIDADO: Genera una exception
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                throw;
            }

            return match.Groups[1].Value + domainName;
        }

        /// <summary>
        /// Verifica si la contraseña cumple o no con los requisitos.
        /// <para>Si su tamaño es el <see cref="PASS_MAXIMO_CARACTER"/>, existe una mayusula y un numero, ademas si contiene caracteres espeicales.</para>
        /// </summary>
        /// <param name="pass">Contraseña</param>
        /// <returns>false en caso de no cumplir y true en caso de si cumplir</returns>
        private bool isPassValid(String pass)
        {
            bool isValid = false;
            Regex RgxUrl = new Regex("[^a-z0-9]");
            bool isSpecialChar = RgxUrl.IsMatch(pass);
            bool isUpper = pass.Any(x => char.IsUpper(x));
            bool isDigit = pass.Any(x => char.IsDigit(x));

            //Si su tamaño es el <see cref="PASS_MAXIMO_CARACTER"/>, existe una mayusula y un numero, ademas si contiene caracteres espeicales.
            if (pass.Length < PASS_MAXIMO_CARACTER && isUpper && isDigit && isSpecialChar)
            {
                isValid = true;
            }

            return isValid;
        }
    }

    #endregion
}
