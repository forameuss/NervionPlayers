class clsProfesor{

	var id;
    var nombre;
    var apellidos;
    var contraseña;
    var correo;
    var fecha_Creacion;
    var observaciones;
    var foto;

        constructor(id,nombre,apellidos,contraseña,correo,fecha_Creacion,observaciones,foto){
    	this.id= id;
    	this.nombre= nombre;
    	this.apellidos = apellidos;
    	this.contraseña = contraseña;
    	this.correo = correo;
    	this.fecha_Creacion = fecha_Creacion;
    	this.observaciones = observaciones;
    	this.foto = foto;
    }
}