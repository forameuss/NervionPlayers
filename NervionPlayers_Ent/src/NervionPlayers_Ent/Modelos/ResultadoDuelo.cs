using System;
/**************
* Restricciones
* *************
* ganados,empatados y perdidos>=0
* 
*/
public class ResultadoDuelo
{
    #region Atributos
    private int id;
    private int id_Alumno;
    private int ganados;
    private int empatados;
    private int perdidos;

    #endregion

    #region Constructores
    public ResultadoDuelo(int id, int id_Alumno, int ganados, int empatados, int perdidos)
    {
        this.id = id;
        this.id_Alumno = id_Alumno;
        this.ganados = ganados;
        this.empatados = empatados;
        this.perdidos = perdidos;
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

    public int Id_Alumno
    {
        get
        {
            return id_Alumno;
        }

        set
        {
            id_Alumno = value;
        }
    }

    public int Ganados
    {
        get
        {
            return ganados;
        }

        set
        {
            ganados = value;
        }
    }

    public int Empatados
    {
        get
        {
            return empatados;
        }

        set
        {
            empatados = value;
        }
    }

    public int Perdidos
    {
        get
        {
            return perdidos;
        }

        set
        {
            perdidos = value;
        }
    }
    #endregion

    #region Métodos

    #endregion


}
