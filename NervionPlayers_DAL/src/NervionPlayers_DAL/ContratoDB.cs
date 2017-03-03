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
            public static String ALUMNO_DB_ALIAS = "Alias";
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
            public static String EQuIPOS_DB_CATEGORIA = "Categoria";
            public static String EQUIPOS_DB_NOMBRE = "Nombre";
            public static String EQUIPOS_DB_FOTO = "Foto";
            public static String EQUIPOS_DB_FECHA_CREACION = "Fecha_Creacion";
            public static String EQUIPOS_DB_CONFIRMADO = "Confirmado";
        }

        public static class Deportes_DB
        {
            public static String DEPORTES_DB_TABLE_NAME = "Deportes";
            public static String DEPORTES_DB_ID = "Id";
            public static String DEPORTES_DB_NOMBRE = "Nombre";

        }

        public static class Partidos_DB
        {
            public static String PARTIDOS_DB_TABLE_NAME = "Partidos";
            public static String PARTIDOS_DB_ID = "Id";
            public static String PARTIDOS_DB_ID_LOCAL = "Id_Local";
            public static String PARTIDOS_DB_ID_VISITANTE = "Id_Visitante";
            public static String PARTIDOS_DB_ID_DEPORTE = "Id_Deporte";
            public static String PARTIDOS_DB_FECHA_PARTIDO = "Fecha_Partido";
            public static String PARTIDOS_DB_RESULTADO_LOCAL = "Resultado_Local";
            public static String PARTIDOS_DB_RESULTADO_VISITANTE = "Resultado_Visitante";
            public static String PARTIDOS_DB_FECHA_CREACION = "Fecha_Creacion";
            public static String PARTIDOS_DB_LUGAR = "Lugar";
            public static String PARTIDOS_DB_NOTAS = "Notas";
            public static String PARTIDOS_DB_FOTO = "Foto";

        }

        public static class Duelos_DB
        {
            public static String DUELOS_DB_TABLE_NAME = "Duelos";
            public static String DUELOS_DB_ID = "Id";
            public static String DUELOS_DB_ID_LOCAL = "Id_Local";
            public static String DUELOS_DB_ID_VISITANTE = "Id_Visitante";
            public static String DUELOS_DB_ID_DEPORTE = "Id_Deporte";
            public static String DUELOS_DB_FECHA_DUELO = "Fecha_Duelo";
            public static String DUELOS_DB_RESULTADO_LOCAL = "Resultado_Local";
            public static String DUELOS_DB_RESULTADO_VISITANTE = "Resultado_Visitante";
            public static String DUELOS_DB_FECHA_CREACION = "Fecha_Creacion";
            public static String DUELOS_DB_LUGAR = "Lugar";
            public static String DUELOS_DB_NOTAS = "Notas";
            public static String DUELOS_DB_FOTO = "Foto";

        }

        public static class alumnosEquipos_DB
        {
            public static String ALUMNOSEQUIPOS_DB_TABLE_NAME = "AlumnosEquipos";
            public static String ALUMNOSEQUIPOS_DB_ID_ALUMNO = "Id_Alumno";
            public static String ALUMNOSEQUIPOS_DB_ID_EQUIPO = "Id_Equipo";
            public static String ALUMNOSEQUIPOS_DB_FECHA_CREACION = "Fecha_Creacion";

        }

        public static class AlumnosDeportes_DB
        {

            public static String ALUMNOSDEPORTES_DB_TABLE_NAME = "AlumnosDeportes";
            public static String ALUMNOSDEPORTES_DB_ID_ALUMNO = "Id_Alumno";
            public static String ALUMNOSDEPORTES_DB_ID_DEPORTE = "Id_Deporte";
        }

        public static class ResultadosDuelos_DB
        {
            public static String RESULTADOSDUELOS_DB_TABLE_NAME = "ResultadosDuelos";
            public static String RESULTADOSDUELOS_DB_ID = "Id";
            public static String RESULTADOSDUELOS_DB_ID_DEPORTE = "Id_Deporte";
            public static String RESULTADOSDUELOS_DB_ID_ALUMNO = "Id_Alumno";
            public static String RESULTADOSDUELOS_DB_GANADOS = "Ganados";
            public static String RESULTADOSDUELOS_DB_EMPATADOS = "Empatados";
            public static String RESULTADOSDUELOS_DB_PERDIDOS = "Perdidos";
        }
        public static class ResultadosPartidos_DB
        {
            public static String RESULTADOSPARTIDOS_DB_TABLE_NAME = "ResultadosPartidos";
            public static String RESULTADOSPARTIDOS_DB_ID = "Id";
            public static String RESULTADOSPARTIDOS_DB_ID_EQUIPO = "Id_Equipo";
            public static String RESULTADOSPARTIDOS_DB_EMPATADOS = "Empatados";
            public static String RESULTADOSPARTIDOS_DB_PERDIDOS = "Perdidos";
            public static String RESULTADOSPARTIDOS_DB_GANADOS = "Ganados";
        }

        public static class Dispositivos
        {
            public const String TABLA = "Dispositivos";
            public const String ID = "Id";
            public const String ID_ALUMNO = "Id_Alumno";
            public const String TOKEN = "Token";
            public const String FECHA_CREACION = "Fecha_Creacion";
            public const String FECHA_MODIFICACION = "Fecha_Modificacion";
            public const String ACTIVO = "Activo";
        }

        public static class Profesores_DB
        {
            public const String TABLA = "Profesores";
            public const String ID = "Id";
            public const String NOMBRE = "Nombre";
            public const String CONTRASEÑA= "Contraseña";
            public const String APELLIDOS = "Apellidos";
            public const String CORREO = "Correo";
            public const String FOTO = "Foto";
            public const String OBSERVACIONEs = "Observaciones";
            public const String FECHA_CREACION = "Fecha_Creacion";
            public const String ALIAS = "Alias";
        }

    }
}
