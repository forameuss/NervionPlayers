using NervionPlayers_DAL.Manejadoras;
using NervionPlayers_Ent.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NervionPlayers_BL.Manejadoras
{
    public class ManejadoraAlumnoDeporteBL
    {
        private ManejadoraAlumnoDeporte miMane = new ManejadoraAlumnoDeporte();

        public int insertarAlumnoDeporte(AlumnoDeporte oAlumnoDeporte)
        {
            return miMane.insertarAlumnoDeporte(oAlumnoDeporte);
        }

        public int borraAlumnoDeporte(int id_Alumno,int id_Deporte)
        {
            return miMane.borrarAlumnoDeporte(id_Alumno, id_Deporte);
        }
    }
}
