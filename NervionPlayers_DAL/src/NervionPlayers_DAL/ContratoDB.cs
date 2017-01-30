using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NervionPlayers_DAL
{
    public class ContratoDB
    {

        public static class Alumno_DB
        {
            public static String ALUMNO_DB_TABLE_NAME ="Alumnos";
            public static String ALUMNO_DB_ID = "Id";
            public static String ALUMNO_DB_NOMBRE ="Nombre";
            public static String ALUMNO_DB_CONTRASEÑA = "Contraseña";
            public static String ALUMNO_DB_APELLIDOS = "Apellidos";
            public static String ALUMNO_DB_ALIAS = "alias";
            public static String ALUMNO_DB_CORREO = "Correo";
            public static String ALUMNO_DB_FOTO = "Foto";
            public static String ALUMNO_DB_FECHA_CREACION = "Fecha_Creacion";
            public static String ALUMNO_DB_CURSO = "Curso";
            public static String ALUMNO_DB_LETRA = "Letra";
            public static String ALUMNO_DB_OBSERVACIONES = "Observaciones";
            public static String ALUMNO_DB_CONFIRMADO = "Confirmado";

        }

        public static class Equipos_DB
        {
            public static String EQUIPOS_DB_TABLE_NAME = "Equipos";
            public static String EQUIPOS_DB_ID = "Id";
            public static String EQUIPOS_DB_ID_CREADOR= "Id_Creador";
            public static string EQUIPOS_DB_NOMBRE = "Nombre";
            public static String EQUIPOS_DB_FOTO = "Foto";
            public static String EQUIPOS_DB_FECHA_CREACION = "Fecha_Creacion";
            public static String EQUIPOS_DB_CONFIRMADO = "Confirmado";

        }

       
    }
}
