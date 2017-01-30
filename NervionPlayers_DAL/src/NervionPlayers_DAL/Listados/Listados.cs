using DALClassLibrary;
using NervionPlayers_Ent.Modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NervionPlayers_DAL.Listados
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
            Alumno oAlumno = new Alumno();

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
                        oAlumno.Id = (int)lector[ContratoDB.Alumno_DB.ALUMNO_DB_ID];
                        oAlumno.Nombre = (string)lector[ContratoDB.Alumno_DB.ALUMNO_DB_NOMBRE];
                        oAlumno.Apellidos = (string)lector[ContratoDB.Alumno_DB.ALUMNO_DB_APELLIDOS];
                        oAlumno.Alias = (string)lector[ContratoDB.Alumno_DB.ALUMNO_DB_ALIAS];
                        oAlumno.Correo = (string)lector[ContratoDB.Alumno_DB.ALUMNO_DB_CORREO];
                        oAlumno.Curso = (Byte)lector[ContratoDB.Alumno_DB.ALUMNO_DB_CURSO];
                        oAlumno.Contraseña = (String)lector[ContratoDB.Alumno_DB.ALUMNO_DB_CONTRASEÑA];
                        oAlumno.Foto = (Byte[])lector[ContratoDB.Alumno_DB.ALUMNO_DB_FOTO];
                        oAlumno.Confirmado = (bool)lector[ContratoDB.Alumno_DB.ALUMNO_DB_CONFIRMADO];
                        oAlumno.Letra = (String)lector[ContratoDB.Alumno_DB.ALUMNO_DB_LETRA];
                        oAlumno.Observaciones = (String)lector[ContratoDB.Alumno_DB.ALUMNO_DB_OBSERVACIONES];

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
            Equipo oEquipo = new Equipo();

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
                        oEquipo.Id = (int)lector[ContratoDB.Equipos_DB.EQUIPOS_DB_ID];
                        oEquipo.Id_Creador = (int)lector[ContratoDB.Equipos_DB.EQUIPOS_DB_ID_CREADOR];
                        oEquipo.Nombre = (string)lector[ContratoDB.Equipos_DB.EQUIPOS_DB_NOMBRE];
                        oEquipo.Foto = (Byte[])lector[ContratoDB.Equipos_DB.EQUIPOS_DB_FOTO];
                        oEquipo.Confirmado = (bool)lector[ContratoDB.Equipos_DB.EQUIPOS_DB_CONFIRMADO];

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
            Partido oPartido = new Partido();

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
                        oPartido.Id = (int)lector[ContratoDB.Partidos_DB.PARTIDOS_DB_ID];
                        oPartido.Id_Deporte = (int)lector[ContratoDB.Partidos_DB.PARTIDOS_DB_ID_DEPORTE];
                        oPartido.Id_Local = (int)lector[ContratoDB.Partidos_DB.PARTIDOS_DB_ID_LOCAL];
                        oPartido.Id_Visitante = (int)lector[ContratoDB.Partidos_DB.PARTIDOS_DB_ID_VISITANTE];
                        oPartido.Resultado_Local = (int)lector[ContratoDB.Partidos_DB.PARTIDOS_DB_RESULTADO_LOCAL];
                        oPartido.Resultado_Visitante = (int)lector[ContratoDB.Partidos_DB.PARTIDOS_DB_RESULTADO_VISITANTE];
                        oPartido.Lugar = (String)lector[ContratoDB.Partidos_DB.PARTIDOS_DB_LUGAR];
                        oPartido.Foto = (Byte[])lector[ContratoDB.Partidos_DB.PARTIDOS_DB_FOTO];
                        oPartido.Notas = (String)lector[ContratoDB.Partidos_DB.PARTIDOS_DB_NOTAS];
                        oPartido.Fecha_Partido = (DateTime)lector[ContratoDB.Partidos_DB.PARTIDOS_DB_FECHA_PARTIDO];
                        oPartido.Fecha_Creacion = (DateTime)lector[ContratoDB.Partidos_DB.PARTIDOS_DB_FECHA_CREACION];

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
            Duelo oDuelo = new Duelo();

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
                        oDuelo.Id = (int)lector[ContratoDB.Duelos_DB.DUELOS_DB_ID];
                        oDuelo.Id_Deporte = (int)lector[ContratoDB.Duelos_DB.DUELOS_DB_ID_DEPORTE];
                        oDuelo.Id_Local = (int)lector[ContratoDB.Duelos_DB.DUELOS_DB_ID_LOCAL];
                        oDuelo.Id_Visitante = (int)lector[ContratoDB.Duelos_DB.DUELOS_DB_ID_VISITANTE];
                        oDuelo.Resultado_Local = (int)lector[ContratoDB.Duelos_DB.DUELOS_DB_RESULTADO_LOCAL];
                        oDuelo.Resultado_Visitante = (int)lector[ContratoDB.Duelos_DB.DUELOS_DB_RESULTADO_VISITANTE];
                        oDuelo.Lugar = (String)lector[ContratoDB.Duelos_DB.DUELOS_DB_LUGAR];
                        oDuelo.Foto = (Byte[])lector[ContratoDB.Duelos_DB.DUELOS_DB_FOTO];
                        oDuelo.Notas = (String)lector[ContratoDB.Duelos_DB.DUELOS_DB_NOTAS];
                        oDuelo.Fecha_Duelo = (DateTime)lector[ContratoDB.Duelos_DB.DUELOS_DB_FECHA_DUELO];
                        oDuelo.Fecha_Creacion = (DateTime)lector[ContratoDB.Duelos_DB.DUELOS_DB_FECHA_CREACION];

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
            Deporte oDeporte = new Deporte();

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
                        oDeporte.Id = (int)lector[ContratoDB.Deportes_DB.DEPORTES_DB_ID];
                        oDeporte.Nombre = (string)lector[ContratoDB.Deportes_DB.DEPORTES_DB_NOMBRE];

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
            AlumnoEquipo oAlumnoEquipo = new AlumnoEquipo();

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
                        oAlumnoEquipo.Id_Alumno = (int)lector[ContratoDB.alumnosEquipos_DB.ALUMNOSEQUIPOS_DB_ID_ALUMNO];
                        oAlumnoEquipo.Id_Equipo = (int)lector[ContratoDB.alumnosEquipos_DB.ALUMNOSEQUIPOS_DB_ID_EQUIPO];
                        oAlumnoEquipo.Fecha_Creacion = (DateTime)lector[ContratoDB.alumnosEquipos_DB.ALUMNOSEQUIPOS_DB_FECHA_CREACION];

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
            ResultadoPartido oResultadoPartido = new ResultadoPartido();

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
                        oResultadoPartido.Id = (int)lector[ContratoDB.ResultadosPartidos_DB.RESULTADOSPARTIDOS_DB_ID];
                        oResultadoPartido.Id_Equipo = (int)lector[ContratoDB.ResultadosPartidos_DB.RESULTADOSPARTIDOS_DB_ID_EQUIPO];
                        oResultadoPartido.Ganados = (int)lector[ContratoDB.ResultadosPartidos_DB.RESULTADOSPARTIDOS_DB_GANADOS];
                        oResultadoPartido.Empatados = (int)lector[ContratoDB.ResultadosPartidos_DB.RESULTADOSPARTIDOS_DB_EMPATADOS];
                        oResultadoPartido.Perdidos = (int)lector[ContratoDB.ResultadosPartidos_DB.RESULTADOSPARTIDOS_DB_PERDIDOS];

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
            ResultadoDuelo oResultadoDuelo = new ResultadoDuelo();

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
                        oResultadoDuelo.Id = (int)lector[ContratoDB.ResultadosDuelos_DB.RESULTADOSDUELOS_DB_ID];
                        oResultadoDuelo.Id_Alumno = (int)lector[ContratoDB.ResultadosDuelos_DB.RESULTADOSDUELOS_DB_ID_ALUMNO];
                        oResultadoDuelo.Ganados = (int)lector[ContratoDB.ResultadosDuelos_DB.RESULTADOSDUELOS_DB_GANADOS];
                        oResultadoDuelo.Empatados = (int)lector[ContratoDB.ResultadosDuelos_DB.RESULTADOSDUELOS_DB_EMPATADOS];
                        oResultadoDuelo.Perdidos = (int)lector[ContratoDB.ResultadosDuelos_DB.RESULTADOSDUELOS_DB_PERDIDOS];

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
