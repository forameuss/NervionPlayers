var Persona = (function () {
    function Persona(id, nombre, alias, correo, fecha_Creacion, curso, letra, observaciones, confirmado, contraseña, apellidos, foto) {
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
    Persona.prototype.getID = function () {
        return this.id;
    };
    Persona.prototype.getNombre = function () {
        return this.nombre;
    };
    Persona.prototype.getContraseña = function () {
        return this.contraseña;
    };
    Persona.prototype.getAlias = function () {
        return this.alias;
    };
    Persona.prototype.getConfirmado = function () {
        return this.confirmado;
    };
    Persona.prototype.toString = function () {
        return this.nombre + ", " + this.apellidos;
    };
    return Persona;
}());
