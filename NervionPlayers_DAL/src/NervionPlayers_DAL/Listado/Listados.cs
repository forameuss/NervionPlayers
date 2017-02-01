using DALClassLibrary;
using NervionPlayers_Ent.Modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
namespace NervionPlayers_DAL.Listado
{
    public class Listados
    {
        /// <summary>
        /// Metodo que obtiene una ObservableCollection<Alumno> de todos los alumnos
        /// </summary>
        /// <returns>ObservableCollection<Alumno> alumnos</returns>
        public ObservableCollection<Alumno> listadoAlumnos()
        {
            ObservableCollection<Alumno> alumnos = new ObservableCollection<Alumno>();
            Connection con = new Connection("AlumnoNervion", ".N3tApe$7aH");
            Alumno oAlumno;

            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            comando.CommandText = String.Format("Select * FROM {0}", ContratoDB.Alumno_DB.ALUMNO_DB_TABLE_NAME);
            SqlDataReader lector;

            try
            {
                conexion = con.openConnection();
                comando.Connection = conexion;
                lector = comando.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        oAlumno = new Alumno();
                        oAlumno.Id = Convert.ToInt32(lector[ContratoDB.Alumno_DB.ALUMNO_DB_ID]);
                        oAlumno.Nombre = Convert.ToString(lector[ContratoDB.Alumno_DB.ALUMNO_DB_NOMBRE]);
                        oAlumno.Apellidos = Convert.ToString(lector[ContratoDB.Alumno_DB.ALUMNO_DB_APELLIDOS]);
                        oAlumno.Alias = Convert.ToString(lector[ContratoDB.Alumno_DB.ALUMNO_DB_ALIAS]);
                        oAlumno.Correo = Convert.ToString(lector[ContratoDB.Alumno_DB.ALUMNO_DB_CORREO]);
                        oAlumno.Curso = Convert.ToByte(lector[ContratoDB.Alumno_DB.ALUMNO_DB_CURSO]);
                        //oAlumno.Contraseña = Convert.ToString(lector[ContratoDB.Alumno_DB.ALUMNO_DB_CONTRASEÑA];
                        try
                        {
                            oAlumno.Foto = (byte[])lector[ContratoDB.Alumno_DB.ALUMNO_DB_FOTO];
                        }
                        catch (InvalidCastException)
                        {
                            oAlumno.Foto = null;
                        }

                        oAlumno.Confirmado = Convert.ToBoolean(lector[ContratoDB.Alumno_DB.ALUMNO_DB_CONFIRMADO]);
                        oAlumno.Letra = Convert.ToString(lector[ContratoDB.Alumno_DB.ALUMNO_DB_LETRA]);
                        oAlumno.Observaciones = Convert.ToString(lector[ContratoDB.Alumno_DB.ALUMNO_DB_OBSERVACIONES]);

                        alumnos.Add(oAlumno);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }

            return (alumnos);

        }

        /// <summary>
        /// Método que devuelve todos los Alumnso de un equipo
        /// </summary>
        /// <param name="idEquipo"></param>
        /// <returns></returns>
        public ObservableCollection<Alumno> listadoAlumnos(int idEquipo)
        {
            ObservableCollection<Alumno> alumnos = new ObservableCollection<Alumno>();
            Connection con = new Connection("AlumnoNervion", ".N3tApe$7aH");
            Alumno oAlumno;

            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            comando.CommandText = String.Format(
                "Select A.{0},A.{1},A.{2},A.{3},A.{4},A.{5},A.{6},A.{7},A.{8},A.{9},A.{10}"
                + " FROM {11} as A"
                + " inner join {12} as AE on A.{0}=AE.{13}"
                + " where {14}={15}",
                ContratoDB.Alumno_DB.ALUMNO_DB_ID,
                ContratoDB.Alumno_DB.ALUMNO_DB_NOMBRE,
                ContratoDB.Alumno_DB.ALUMNO_DB_APELLIDOS,
                ContratoDB.Alumno_DB.ALUMNO_DB_ALIAS,
                ContratoDB.Alumno_DB.ALUMNO_DB_CORREO,
                ContratoDB.Alumno_DB.ALUMNO_DB_FECHA_CREACION,
                ContratoDB.Alumno_DB.ALUMNO_DB_CURSO,
                ContratoDB.Alumno_DB.ALUMNO_DB_LETRA,
                ContratoDB.Alumno_DB.ALUMNO_DB_OBSERVACIONES,
                ContratoDB.Alumno_DB.ALUMNO_DB_CONFIRMADO,
                ContratoDB.Alumno_DB.ALUMNO_DB_FOTO,
                ContratoDB.Alumno_DB.ALUMNO_DB_TABLE_NAME,
                ContratoDB.alumnosEquipos_DB.ALUMNOSEQUIPOS_DB_TABLE_NAME,
                ContratoDB.alumnosEquipos_DB.ALUMNOSEQUIPOS_DB_ID_ALUMNO,
                ContratoDB.alumnosEquipos_DB.ALUMNOSEQUIPOS_DB_ID_EQUIPO,
                idEquipo
                );

            SqlDataReader lector;

            try
            {
                conexion = con.openConnection();
                comando.Connection = conexion;
                lector = comando.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        oAlumno = new Alumno();
                        oAlumno.Id = Convert.ToInt32(lector[ContratoDB.Alumno_DB.ALUMNO_DB_ID]);
                        oAlumno.Nombre = Convert.ToString(lector[ContratoDB.Alumno_DB.ALUMNO_DB_NOMBRE]);
                        oAlumno.Apellidos = Convert.ToString(lector[ContratoDB.Alumno_DB.ALUMNO_DB_APELLIDOS]);
                        oAlumno.Alias = Convert.ToString(lector[ContratoDB.Alumno_DB.ALUMNO_DB_ALIAS]);
                        oAlumno.Correo = Convert.ToString(lector[ContratoDB.Alumno_DB.ALUMNO_DB_CORREO]);
                        oAlumno.Curso = (Byte)lector[ContratoDB.Alumno_DB.ALUMNO_DB_CURSO];
                        //oAlumno.Contraseña = Convert.ToString(lector[ContratoDB.Alumno_DB.ALUMNO_DB_CONTRASEÑA];
                        try
                        {
                            oAlumno.Foto = (byte[])lector[ContratoDB.Alumno_DB.ALUMNO_DB_FOTO];
                        }
                        catch (InvalidCastException)
                        {
                            oAlumno.Foto = null;
                        }
                        oAlumno.Confirmado = Convert.ToBoolean(lector[ContratoDB.Alumno_DB.ALUMNO_DB_CONFIRMADO]);
                        oAlumno.Letra = Convert.ToString(lector[ContratoDB.Alumno_DB.ALUMNO_DB_LETRA]);
                        oAlumno.Observaciones = Convert.ToString(lector[ContratoDB.Alumno_DB.ALUMNO_DB_OBSERVACIONES]);

                        alumnos.Add(oAlumno);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }

            return (alumnos);

        }

        /// <summary>
        /// Metodo que obtiene una ObservableCollection<Equipo> de todos los equipos
        /// </summary>
        /// <returns>ObservableCollection<Equipo> equipos</returns>
        public ObservableCollection<Equipo> listadoEquipos()
        {
            ObservableCollection<Equipo> equipos = new ObservableCollection<Equipo>();
            Connection con = new Connection("AlumnoNervion", ".N3tApe$7aH");
            Equipo oEquipo;

            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            comando.CommandText = String.Format("Select * FROM {0}", ContratoDB.Equipos_DB.EQUIPOS_DB_TABLE_NAME);
            SqlDataReader lector;

            try
            {
                conexion = con.openConnection();
                comando.Connection = conexion;
                lector = comando.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        oEquipo = new Equipo();
                        oEquipo.Id = Convert.ToInt32(lector[ContratoDB.Equipos_DB.EQUIPOS_DB_ID]);
                        oEquipo.Id_Creador = Convert.ToInt32(lector[ContratoDB.Equipos_DB.EQUIPOS_DB_ID_CREADOR]);
                        oEquipo.Nombre = Convert.ToString(lector[ContratoDB.Equipos_DB.EQUIPOS_DB_NOMBRE]);
                        try
                        {
                            oEquipo.Foto = (byte[])lector[ContratoDB.Equipos_DB.EQUIPOS_DB_FOTO];
                        }
                        catch (InvalidCastException)
                        {
                            oEquipo.Foto = null;
                        }
                        oEquipo.Confirmado = Convert.ToBoolean(lector[ContratoDB.Equipos_DB.EQUIPOS_DB_CONFIRMADO]);

                        equipos.Add(oEquipo);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }

            return (equipos);
        }

        /// <summary>
        /// Metodo que obtiene una ObservableCollection<Equipo> de todos los equipos del alumno con la id
        ///     pasada como parametro
        /// </summary>
        /// <param name="idAlumno"></param>
        /// <returns>ObservableCollection<Equipo> equipos</returns>
        public ObservableCollection<Equipo> listadoEquipos(int idAlumno)
        {
            ObservableCollection<Equipo> equipos = new ObservableCollection<Equipo>();
            Connection con = new Connection("AlumnoNervion", ".N3tApe$7aH");
            Equipo oEquipo;

            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            comando.CommandText = String.Format("Select * FROM {0} AS E Inner Join {1} AS AE ON E.{2}=AE.{3} "
                                                + "where  AE.{4} = {5}", ContratoDB.Equipos_DB.EQUIPOS_DB_TABLE_NAME, ContratoDB.alumnosEquipos_DB.ALUMNOSEQUIPOS_DB_TABLE_NAME, ContratoDB.Equipos_DB.EQUIPOS_DB_ID
                                                            , ContratoDB.alumnosEquipos_DB.ALUMNOSEQUIPOS_DB_ID_EQUIPO, ContratoDB.alumnosEquipos_DB.ALUMNOSEQUIPOS_DB_ID_ALUMNO, idAlumno);
            SqlDataReader lector;

            try
            {
                conexion = con.openConnection();
                comando.Connection = conexion;
                lector = comando.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        oEquipo = new Equipo();
                        oEquipo.Id = Convert.ToInt32(lector[ContratoDB.Equipos_DB.EQUIPOS_DB_ID]);
                        oEquipo.Id_Creador = Convert.ToInt32(lector[ContratoDB.Equipos_DB.EQUIPOS_DB_ID_CREADOR]);
                        oEquipo.Nombre = Convert.ToString(lector[ContratoDB.Equipos_DB.EQUIPOS_DB_NOMBRE]);
                        try
                        {
                            oEquipo.Foto = (byte[])lector[ContratoDB.Equipos_DB.EQUIPOS_DB_FOTO];
                        }
                        catch (InvalidCastException)
                        {
                            oEquipo.Foto = null;
                        }
                        oEquipo.Confirmado = Convert.ToBoolean(lector[ContratoDB.Equipos_DB.EQUIPOS_DB_CONFIRMADO]);

                        equipos.Add(oEquipo);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }

            return (equipos);
        }

        /// <summary>
        /// Metodo que obtiene una ObservableCollection<Partido> de todos los partidos
        /// </summary>
        /// <returns>ObservableCollection<Partido> Partidos</returns>
        public ObservableCollection<Partido> listadoPartidos()
        {
            ObservableCollection<Partido> partidos = new ObservableCollection<Partido>();
            Connection con = new Connection("AlumnoNervion", ".N3tApe$7aH");
            Partido oPartido;

            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            comando.CommandText = String.Format("Select * FROM {0}", ContratoDB.Partidos_DB.PARTIDOS_DB_TABLE_NAME);
            SqlDataReader lector;

            try
            {
                conexion = con.openConnection();
                comando.Connection = conexion;
                lector = comando.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        oPartido = new Partido();
                        oPartido.Id = Convert.ToInt32(lector[ContratoDB.Partidos_DB.PARTIDOS_DB_ID]);
                        oPartido.Id_Deporte = Convert.ToInt32(lector[ContratoDB.Partidos_DB.PARTIDOS_DB_ID_DEPORTE]);
                        oPartido.Id_Local = Convert.ToInt32(lector[ContratoDB.Partidos_DB.PARTIDOS_DB_ID_LOCAL]);
                        oPartido.Id_Visitante = Convert.ToInt32(lector[ContratoDB.Partidos_DB.PARTIDOS_DB_ID_VISITANTE]);
                        oPartido.Resultado_Local = Convert.ToInt32(lector[ContratoDB.Partidos_DB.PARTIDOS_DB_RESULTADO_LOCAL]);
                        oPartido.Resultado_Visitante = Convert.ToInt32(lector[ContratoDB.Partidos_DB.PARTIDOS_DB_RESULTADO_VISITANTE]);
                        oPartido.Lugar = Convert.ToString(lector[ContratoDB.Partidos_DB.PARTIDOS_DB_LUGAR]);
                        try
                        {
                            oPartido.Foto = (byte[])lector[ContratoDB.Partidos_DB.PARTIDOS_DB_FOTO];
                        }
                        catch (InvalidCastException)
                        {
                            oPartido.Foto = null;
                        }
                        oPartido.Notas = Convert.ToString(lector[ContratoDB.Partidos_DB.PARTIDOS_DB_NOTAS]);
                        oPartido.Fecha_Partido = Convert.ToDateTime(lector[ContratoDB.Partidos_DB.PARTIDOS_DB_FECHA_PARTIDO]);
                        oPartido.Fecha_Creacion = Convert.ToDateTime(lector[ContratoDB.Partidos_DB.PARTIDOS_DB_FECHA_CREACION]);

                        partidos.Add(oPartido);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }

            return (partidos);
        }

        /// <summary>
        /// Metodo que obtiene una ObservableCollection<Duelo> de todos los Duelos
        /// </summary>
        /// <returns>ObservableCollection<Duelo> Duelos</returns>
        public ObservableCollection<Duelo> listadoDuelos()
        {
            ObservableCollection<Duelo> duelos = new ObservableCollection<Duelo>();
            Connection con = new Connection("AlumnoNervion", ".N3tApe$7aH");
            Duelo oDuelo;

            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            comando.CommandText = String.Format("Select * FROM {0}", ContratoDB.Duelos_DB.DUELOS_DB_TABLE_NAME);
            SqlDataReader lector;

            try
            {
                conexion = con.openConnection();
                comando.Connection = conexion;
                lector = comando.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        oDuelo = new Duelo();
                        oDuelo.Id = Convert.ToInt32(lector[ContratoDB.Duelos_DB.DUELOS_DB_ID]);
                        oDuelo.Id_Deporte = Convert.ToInt32(lector[ContratoDB.Duelos_DB.DUELOS_DB_ID_DEPORTE]);
                        oDuelo.Id_Local = Convert.ToInt32(lector[ContratoDB.Duelos_DB.DUELOS_DB_ID_LOCAL]);
                        oDuelo.Id_Visitante = Convert.ToInt32(lector[ContratoDB.Duelos_DB.DUELOS_DB_ID_VISITANTE]);
                        oDuelo.Resultado_Local = Convert.ToInt32(lector[ContratoDB.Duelos_DB.DUELOS_DB_RESULTADO_LOCAL]);
                        oDuelo.Resultado_Visitante = Convert.ToInt32(lector[ContratoDB.Duelos_DB.DUELOS_DB_RESULTADO_VISITANTE]);
                        oDuelo.Lugar = Convert.ToString(lector[ContratoDB.Duelos_DB.DUELOS_DB_LUGAR]);
                        try
                        {
                            oDuelo.Foto = (byte[])lector[ContratoDB.Duelos_DB.DUELOS_DB_FOTO];
                        }
                        catch (InvalidCastException)
                        {
                            oDuelo.Foto = null;
                        }
                        oDuelo.Notas = Convert.ToString(lector[ContratoDB.Duelos_DB.DUELOS_DB_NOTAS]);
                        oDuelo.Fecha_Duelo = Convert.ToDateTime(lector[ContratoDB.Duelos_DB.DUELOS_DB_FECHA_DUELO]);
                        oDuelo.Fecha_Creacion = Convert.ToDateTime(lector[ContratoDB.Duelos_DB.DUELOS_DB_FECHA_CREACION]);

                        duelos.Add(oDuelo);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }

            return (duelos);
        }

        /// <summary>
        /// Metodo que obtiene una ObservableCollection<Deporte> de todos los Deportes
        /// </summary>
        /// <returns>ObservableCollection<Deporte> Deportes</returns>
        public ObservableCollection<Deporte> listadoDeportes()
        {
            ObservableCollection<Deporte> deportes = new ObservableCollection<Deporte>();
            Connection con = new Connection("AlumnoNervion", ".N3tApe$7aH");
            Deporte oDeporte;

            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            comando.CommandText = String.Format("Select * FROM {0}", ContratoDB.Deportes_DB.DEPORTES_DB_TABLE_NAME);
            SqlDataReader lector;

            try
            {
                conexion = con.openConnection();
                comando.Connection = conexion;
                lector = comando.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        oDeporte = new Deporte();
                        oDeporte.Id = Convert.ToInt32(lector[ContratoDB.Deportes_DB.DEPORTES_DB_ID]);
                        oDeporte.Nombre = Convert.ToString(lector[ContratoDB.Deportes_DB.DEPORTES_DB_NOMBRE]);

                        deportes.Add(oDeporte);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }

            return (deportes);
        }

        /// <summary>
        /// Metodo que obtiene una ObservableCollection<AlumnoEquipo> de todos los AlumnoEquipo
        /// </summary>
        /// <returns>ObservableCollection<AlumnoEquipo> AlumnoEquipos</returns>
        public ObservableCollection<AlumnoEquipo> listadoAlumnosEquipos()
        {
            ObservableCollection<AlumnoEquipo> alumnosEquipos = new ObservableCollection<AlumnoEquipo>();
            Connection con = new Connection("AlumnoNervion", ".N3tApe$7aH");
            AlumnoEquipo oAlumnoEquipo;

            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            comando.CommandText = String.Format("Select * FROM {0}", ContratoDB.alumnosEquipos_DB.ALUMNOSEQUIPOS_DB_TABLE_NAME);
            SqlDataReader lector;

            try
            {
                conexion = con.openConnection();
                comando.Connection = conexion;
                lector = comando.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        oAlumnoEquipo = new AlumnoEquipo();
                        oAlumnoEquipo.Id_Alumno = Convert.ToInt32(lector[ContratoDB.alumnosEquipos_DB.ALUMNOSEQUIPOS_DB_ID_ALUMNO]);
                        oAlumnoEquipo.Id_Equipo = Convert.ToInt32(lector[ContratoDB.alumnosEquipos_DB.ALUMNOSEQUIPOS_DB_ID_EQUIPO]);
                        oAlumnoEquipo.Fecha_Creacion = Convert.ToDateTime(lector[ContratoDB.alumnosEquipos_DB.ALUMNOSEQUIPOS_DB_FECHA_CREACION]);

                        alumnosEquipos.Add(oAlumnoEquipo);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }

            return (alumnosEquipos);
        }

        /// <summary>
        /// Metodo que obtiene una ObservableCollection<ResultadoPartido> de todos los ResultadoPartidos
        /// </summary>
        /// <returns>ObservableCollection<ResultadoPartido> ResultadoPartidos</returns>
        public ObservableCollection<ResultadoPartido> listadoResultadoPartidos()
        {
            ObservableCollection<ResultadoPartido> resultadoPartidos = new ObservableCollection<ResultadoPartido>();
            Connection con = new Connection("AlumnoNervion", ".N3tApe$7aH");
            ResultadoPartido oResultadoPartido;

            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            comando.CommandText = String.Format("Select * FROM {0}", ContratoDB.ResultadosPartidos_DB.RESULTADOSPARTIDOS_DB_TABLE_NAME);
            SqlDataReader lector;

            try
            {
                conexion = con.openConnection();
                comando.Connection = conexion;
                lector = comando.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        oResultadoPartido = new ResultadoPartido();
                        oResultadoPartido.Id = Convert.ToInt32(lector[ContratoDB.ResultadosPartidos_DB.RESULTADOSPARTIDOS_DB_ID]);
                        oResultadoPartido.Id_Equipo = Convert.ToInt32(lector[ContratoDB.ResultadosPartidos_DB.RESULTADOSPARTIDOS_DB_ID_EQUIPO]);
                        oResultadoPartido.Ganados = Convert.ToInt32(lector[ContratoDB.ResultadosPartidos_DB.RESULTADOSPARTIDOS_DB_GANADOS]);
                        oResultadoPartido.Empatados = Convert.ToInt32(lector[ContratoDB.ResultadosPartidos_DB.RESULTADOSPARTIDOS_DB_EMPATADOS]);
                        oResultadoPartido.Perdidos = Convert.ToInt32(lector[ContratoDB.ResultadosPartidos_DB.RESULTADOSPARTIDOS_DB_PERDIDOS]);

                        resultadoPartidos.Add(oResultadoPartido);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }

            return (resultadoPartidos);
        }

        /// <summary>
        /// Metodo que obtiene una ObservableCollection<ResultadoDuelo> de todos los ResultadoDuelos
        /// </summary>
        /// <returns>ObservableCollection<ResultadoDuelo> ResultadoDuelos</returns>
        public ObservableCollection<ResultadoDuelo> listadoResultadoDuelos()
        {
            ObservableCollection<ResultadoDuelo> resultadoDuelos = new ObservableCollection<ResultadoDuelo>();
            Connection con = new Connection("AlumnoNervion", ".N3tApe$7aH");
            ResultadoDuelo oResultadoDuelo;

            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            comando.CommandText = String.Format("Select * FROM {0}", ContratoDB.ResultadosDuelos_DB.RESULTADOSDUELOS_DB_TABLE_NAME);
            SqlDataReader lector;

            try
            {
                conexion = con.openConnection();
                comando.Connection = conexion;
                lector = comando.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        oResultadoDuelo = new ResultadoDuelo();
                        oResultadoDuelo.Id = Convert.ToInt32(lector[ContratoDB.ResultadosDuelos_DB.RESULTADOSDUELOS_DB_ID]);
                        oResultadoDuelo.Id_Alumno = Convert.ToInt32(lector[ContratoDB.ResultadosDuelos_DB.RESULTADOSDUELOS_DB_ID_ALUMNO]);
                        oResultadoDuelo.Ganados = Convert.ToInt32(lector[ContratoDB.ResultadosDuelos_DB.RESULTADOSDUELOS_DB_GANADOS]);
                        oResultadoDuelo.Empatados = Convert.ToInt32(lector[ContratoDB.ResultadosDuelos_DB.RESULTADOSDUELOS_DB_EMPATADOS]);
                        oResultadoDuelo.Perdidos = Convert.ToInt32(lector[ContratoDB.ResultadosDuelos_DB.RESULTADOSDUELOS_DB_PERDIDOS]);

                        resultadoDuelos.Add(oResultadoDuelo);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }

            return (resultadoDuelos);
        }
    }
}
