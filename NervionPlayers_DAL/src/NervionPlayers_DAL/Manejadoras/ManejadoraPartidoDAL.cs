using DALClassLibrary;
using NervionPlayers_Ent.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NervionPlayers_DAL.Manejadoras
{
    public class ManejadoraPartidoDAL
    {
        private Connection con;

        public ManejadoraPartidoDAL()
        {
            con = new Connection("ProfesorNervion", "1iNu#L0par7€T0");
        }

        /// <summary>
        /// Busca en la base de datos y devuelve un Partido con el id recibido
        /// </summary>
        /// <param name="id">Recibe la id del partido a buscar</param>
        /// <returns>retorna el Partido</returns>
        public Partido obtenerPartido(int id)
        {
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();
            Partido oPartido = new Partido();
            SqlDataReader lector;

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = String.Format("Select * From {0} Where {1} = {2}", ContratoDB.Partidos_DB.PARTIDOS_DB_TABLE_NAME, ContratoDB.Partidos_DB.PARTIDOS_DB_ID, id);
                miComando.Connection = conexion;
                lector = miComando.ExecuteReader();

                if (lector.HasRows)
                {
                    if (lector.Read())
                    {
                        oPartido.Id = (int)lector[ContratoDB.Partidos_DB.PARTIDOS_DB_ID];
                        oPartido.Id_Deporte = (int)lector[ContratoDB.Partidos_DB.PARTIDOS_DB_ID_DEPORTE];
                        oPartido.Id_Local = (int)lector[ContratoDB.Partidos_DB.PARTIDOS_DB_ID_LOCAL];
                        oPartido.Id_Visitante = (int)lector[ContratoDB.Partidos_DB.PARTIDOS_DB_ID_VISITANTE];
                        oPartido.Resultado_Local = (int)lector[ContratoDB.Partidos_DB.PARTIDOS_DB_RESULTADO_LOCAL];
                        oPartido.Resultado_Visitante = (int)lector[ContratoDB.Partidos_DB.PARTIDOS_DB_RESULTADO_VISITANTE];
                        oPartido.Lugar = (String)lector[ContratoDB.Partidos_DB.PARTIDOS_DB_LUGAR];
                        try
                        {
                            oPartido.Foto = (byte[])lector[ContratoDB.Partidos_DB.PARTIDOS_DB_FOTO];
                        }
                        catch (InvalidCastException)
                        {
                            oPartido.Foto = null;
                        }
                        oPartido.Notas = (String)lector[ContratoDB.Partidos_DB.PARTIDOS_DB_NOTAS];
                        oPartido.Fecha_Partido = (DateTime)lector[ContratoDB.Partidos_DB.PARTIDOS_DB_FECHA_PARTIDO];
                        oPartido.Fecha_Creacion = (DateTime)lector[ContratoDB.Partidos_DB.PARTIDOS_DB_FECHA_CREACION];

                    }
                }

            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }

            return oPartido;
        }

        /// <summary>
        /// Añade un nuevo Partido en la base de datos
        /// </summary>
        /// <param name="partido">Recibe un  tipo Partido</param>
        /// <returns>retorna el numero de filas afectadas , int</returns>
        public int insertarPartido(Partido partido)
        {
            int filasAfectadas = 0;
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();
            Partido oPartido = new Partido();

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = String.Format("");//Preguntar a javi que se inserta y que no
                miComando.Connection = conexion;

                filasAfectadas = miComando.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }

            return filasAfectadas;
        }

        /// <summary>
        /// Funcion que borra un Partido de la base de datos 
        /// </summary>
        /// <param name="id">Recibe el id del Partido a borrar</param>
        /// <returns>int , retorna el numero de filas afectadas</returns>
        public int borrarPartido(int id)
        {
            int filasafectadas = 0;
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = String.Format("Delete from {0} where {1} = {2}", ContratoDB.Partidos_DB.PARTIDOS_DB_TABLE_NAME, ContratoDB.Partidos_DB.PARTIDOS_DB_ID, id);
                miComando.Connection = conexion;

                filasafectadas = miComando.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }

            return filasafectadas;
        }
    }
}
