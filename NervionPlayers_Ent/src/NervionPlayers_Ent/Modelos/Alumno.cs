using System;
/***************
 * Restricciones
 * *************
 * Nombre<=30
 * Apellidos<=50
 * Contraseña<=255 contendrá mínimo un caracter en mayúscula, un número y un carácter especial
 * Alias<=20
 * Correo<=50 será *@*.* donde * es cualquiera cadena
 * Letra<=10
 * No se insertará en BBDD las fecha de Creación
 */
public class Alumno
{
    #region Atributos
    private int id;
    private String nombre;
    private String apellidos;
    private String contraseña;
    private String alias;
    private String correo;
    private DateTime fecha_Creacion;
    private Byte curso;
    private String letra;
    private String observaciones;
    private bool confirmado;
    private Byte[] foto;

    #endregion

    #region Constructores
    public Alumno()
    {
    }

    public Alumno(int id, String nombre,String apellidos,String contraseña, String alias, String correo,
        DateTime fecha_Creacion, Byte curso,String letra, String observaciones, bool confirmado,Byte[] foto)
    {
        this.id = id;
        this.nombre = nombre;
        this.apellidos = apellidos;
        this.contraseña = contraseña;
        this.alias = alias;
        this.correo = correo;
        this.fecha_Creacion = fecha_Creacion;
        this.curso = curso;
        this.letra = letra;
        this.observaciones = observaciones;
        this.confirmado = confirmado;
        this.foto = foto;
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

    public string Alias
    {
        get
        {
            return alias;
        }

        set
        {
            alias = value;
        }
    }

    public string Correo
    {
        get
        {
            return correo;
        }

        set
        {
            correo = value;
        }
    }

    public DateTime Fecha_Creacion
    {
        get
        {
            return fecha_Creacion;
        }
    }

    public byte Curso
    {
        get
        {
            return curso;
        }

        set
        {
            curso = value;
        }
    }

    public string Letra
    {
        get
        {
            return letra;
        }

        set
        {
            letra = value;
        }
    }

    public string Observaciones
    {
        get
        {
            return observaciones;
        }

        set
        {
            observaciones = value;
        }
    }

    public bool Confirmado
    {
        get
        {
            return confirmado;
        }

        set
        {
            confirmado = value;
        }
    }

    public string Contraseña
    {
        get
        {
            return contraseña;
        }

        set
        {
            contraseña = value;
        }
    }

    public string Apellidos
    {
        get
        {
            return apellidos;
        }

        set
        {
            apellidos = value;
        }
    }

    public byte[] Foto
    {
        get
        {
            return foto;
        }

        set
        {
            foto = value;
        }
    }

    #endregion

    #region Métodos

    #endregion

}
