using DALClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NervionPlayers_DAL.Manejadoras
{
    public class ManejadoraResultadoDueloDAL
    {
        private Connection con;

        public ManejadoraResultadoDueloDAL()
        {
            con = new Connection("ProfesorNervion", "1iNu#L0par7€T0");
        }

        /// <summary>
        /// Busca en la base de datos y devuelve un ResultadoDuelo con el id recibido
        /// </summary>
        /// <param name="id">Recibe la id del ResultadoDuelo a buscar</param>
        /// <returns>retorna el ResultadoDuelo</returns>
        public ResultadoDuelo obtenerResultadoDuelo(int id)
        {
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();
            ResultadoDuelo oResultadoDuelo = new ResultadoDuelo();
            SqlDataReader lector;

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = String.Format("Select * From {0} Where {1} = {2}", ContratoDB.ResultadosDuelos_DB.RESULTADOSDUELOS_DB_TABLE_NAME, ContratoDB.ResultadosDuelos_DB.RESULTADOSDUELOS_DB_ID, id);
                miComando.Connection = conexion;
                lector = miComando.ExecuteReader();

                if (lector.HasRows)
                {
                    if (lector.Read())
                    {
                        oResultadoDuelo.Id = Convert.ToInt32(lector[ContratoDB.ResultadosDuelos_DB.RESULTADOSDUELOS_DB_ID]);
                        oResultadoDuelo.Id_Alumno = Convert.ToInt32(lector[ContratoDB.ResultadosDuelos_DB.RESULTADOSDUELOS_DB_ID_ALUMNO]);
                        oResultadoDuelo.Ganados = Convert.ToInt32(lector[ContratoDB.ResultadosDuelos_DB.RESULTADOSDUELOS_DB_GANADOS]);
                        oResultadoDuelo.Empatados = Convert.ToInt32(lector[ContratoDB.ResultadosDuelos_DB.RESULTADOSDUELOS_DB_EMPATADOS]);
                        oResultadoDuelo.Perdidos = Convert.ToInt32(lector[ContratoDB.ResultadosDuelos_DB.RESULTADOSDUELOS_DB_PERDIDOS]);
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

            return oResultadoDuelo;
        }

        /// <summary>
        /// Añade un nuevo resultadoDuelo en la base de datos
        /// </summary>
        /// <param name="ResultadoDuelo">Recibe un  tipo ResultadoDuelo</param>
        /// <returns>retorna el numero de filas afectadas , int</returns>
        public int insertarResultadoDuelo(ResultadoDuelo resultadoDuelo)
        {
            int filasAfectadas = 0;
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = String.Format("");
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
        /// Funcion que borra un ResultadoDuelo de la base de datos 
        /// </summary>
        /// <param name="id">Recibe el id del ResultadoDuelo a borrar</param>
        /// <returns>int , retorna el numero de filas afectadas</returns>
        public int borrarResultadoDuelo(int id)
        {
            int filasafectadas = 0;
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = String.Format("Delete from {0} where {1} = {2}", ContratoDB.ResultadosDuelos_DB.RESULTADOSDUELOS_DB_TABLE_NAME, ContratoDB.ResultadosDuelos_DB.RESULTADOSDUELOS_DB_ID, id);
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
