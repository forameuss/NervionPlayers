using System;
/**
 * #region Atributos

    #endregion

    #region Constructores
    #endregion

    #region Propiedades

    #endregion

    #region Métodos

    #endregion
 * 
 */
/**************
* Restricciones
* *************
* Nombre<=20 caracteres
* 
* 
*/
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
