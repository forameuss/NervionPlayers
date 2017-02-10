using NervionPlayers_DAL.Manejadoras;
using NervionPlayers_Ent.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NervionPlayers_BL.Manejadoras
{
    /// <summary>
    /// Manejadora para Alumno Equipos, se conectara con la capa DAL de <see cref="ManejadoraAlumnoEquipoDAL"/>
    /// y usará <see cref="AlumnoEquipo"/>
    /// </summary>
    public class ManejadoraAlumnoEquipoBL
    {
        #region Var

        private ManejadoraAlumnoEquipoDAL manejadora;

        #endregion

        #region Contructor
        
        /// <summary>
        /// Inicializa el objeto <see cref="ManejadoraAlumnoEquipoDAL"/>
        /// </summary>
        public ManejadoraAlumnoEquipoBL()
        {
            manejadora = new ManejadoraAlumnoEquipoDAL();
        }

        #endregion


        /// <summary>
        /// Insertara un objeto <see cref="AlumnoEquipo"/>
        /// </summary>
        /// <param name="oAlumnoEquipo"></param>
        /// <returns>Parametro devuelto por <see cref="ManejadoraAlumnoEquipoDAL.insertarAlumnoEquipo(AlumnoEquipo)"/></returns>
        public int insertarAlumnoEquipo(AlumnoEquipo oAlumnoEquipo)
        {
            return manejadora.insertarAlumnoEquipo(oAlumnoEquipo);
        }

        /// <summary>
        /// Borra un objeto <see cref="AlumnoEquipo"/> con los identificadores de <see cref="Alumno"/> y <see cref="Equipo"/>
        /// </summary>
        /// <param name="id_Alumno">Id del alumno</param>
        /// <param name="id_Equipo">Id del equipo</param>
        /// <returns>Parametro devuelto por <see cref="ManejadoraAlumnoEquipoDAL.borrarAlumnoEquipo(int, int)"/></returns>
        public int borrarAlumnoEquipo(int id_Alumno, int id_Equipo)
        {
            return manejadora.borrarAlumnoEquipo(id_Alumno, id_Equipo);
        }
    }
}
