using System;
/**************
* Restricciones
* *************
* Nombre<=20 caracteres
* 
* 
*/
namespace NervionPlayers_Ent.Modelos
{
    public class Deporte
    {
        #region Atributos

        private int id;
        private String nombre;
        #endregion

        #region Constructores
        public Deporte() { }

        public Deporte(int id, String nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        #endregion

        #region Propiedades

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }
        #endregion

        #region Métodos

        #endregion
    }
}