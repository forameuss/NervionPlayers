$(function(){

$("input[type='text']").on("keyup",noEmpty);
$("input[type='password']").on("keyup",noEmpty);
$("input[type='email']").on("keyup",noEmpty);
$("input[type='submit']").click(validate);

$("form").validate({

        highlight: function (element, errorClass) {
           $(element).removeClass("campoTexto");
            $(element).addClass("txtInvalido");
        },

        unhighlight: function (element, errorClass) {
            $(element).removeClass("txtInvalido");
            $(element).addClass("campoTexto");
        },

        errorElement: "label",
        errorClass: "error",

        rules: {
            txtNombre:{required: true},
            txtApellidos:{required: true},
            txtContraseña:{
                required: true,
                minlength: 3
            },
            txtCorreo:{required: true},
            txtFecha_Creacion:{required: true},
            txtObservaciones:{required: true}        
        }
});

});

var bCorrecto = false;

function validate(e){

    e.preventDefault();

    var nombre;
    var apellidos;
    var contraseña;
    var correo;
    var fecha_Creacion;
    var observaciones;
    var foto;

    var requireds = $(".required").length;
    if(requireds == 0){
        

        nombre = $("input[name='txtNombre']").val();
        apellidos = $("input[name='txtApellidos']").val();
        contraseña = $("input[name='txtContraseña']").val();
        correo = $("input[name='txtCorreo']").val();
        fecha_Creacion = $("input[name='txtFecha_Creacion']").val();
        observaciones = $("input[name='txtObservaciones']").val();
        foto = $("input[name='txtFoto']").val();

        

        //crear objeto Profesor
        //Profesor p = new Profesor(nombre, apellidos, contraseña, correo, fecha_Creacion, observaciones, foto);
        //profesorPost(p.nombre, p.apellidos, p.contraseña, p.correo, p.fecha_Creacion, p.observaciones, p.foto);

    }
}

function noEmpty(e){

    var value = $(this).val();
    if(value == ""){        
        $(this).addClass("required");
    }else{        
        $(this).removeClass("required");
    }
}