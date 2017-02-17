using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

//FIXME Cambiar el namespace!
namespace DALClassLibrary
{
    /// <summary>
    /// Clase conexion. Generador de conexiones
    /// </summary>
    public class Connection
    {
        #region Privates Attributes

        private String _host;
        private String _dataBase;
        private String _user;
        private String _password;
        public SqlConnection _connection;

        #endregion

        #region Constructores

        /// <summary>
        /// Metodo por defecto, obtendra solamente la cadena de conexion, y la base de datos.
        /// host = localhost
        /// dataBase = NervionPlayers
        /// </summary>
        public Connection()
        {
            //TODO Insertar url;
            this._host = "nervionplayers.database.windows.net";
            this._dataBase = "NervionPlayers";
        }


        /// <summary>
        /// Parametros con conxion.
        /// </summary>
        /// <param name="user">String nombre del usuario</param>
        /// <param name="pass">String password del usuario</param>
        public Connection(String user, String pass) : this()
        {
            this._user =user;
            this._password = pass;
        }

        #endregion

        #region Acciones

        /// <summary>
        /// Abre una conexion. devuelve una SqlException
        /// </summary>
        public SqlConnection openConnection()
        {
            ConnectionSql = new SqlConnection();
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = string.Format("server={0};database={1};uid={2};pwd={3};", _host, _dataBase, _user, _password);
                con.Open();
            }
            catch (SqlException)
            {
                throw;
            }

            return con;
        }

        /// <summary>
        /// Cierra la conexion generada anteriormente. Devuelve una SqlException
        /// </summary>
        public void CloseConnection()
        {
            try
            {
                ConnectionSql.Close();
            }
            catch (SqlException)
            {
                throw;
            }
        }

        #endregion


        #region Attributes

        public SqlConnection ConnectionSql
        {
            get
            {
                return this._connection;
            }
            set
            {
                this._connection = value;
            }
        }


        public String Host
        {
            get
            {
                return this._host;
            }
            set
            {
                this._host = value;
            }
        }

        public string DataBase
        {
            get
            {
                return this._dataBase;
            }
            set
            {
                this._dataBase = value;
            }
        }

        public String User
        {
            get
            {
                return this._user;
            }
            set
            {
                this._user = value;
            }
        }

        public String Password
        {
            get
            {
                return this._password;
            }
            set
            {
                this._password = value;
            }
        }

        #endregion
    }
}