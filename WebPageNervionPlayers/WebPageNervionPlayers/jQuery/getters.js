$(function(){
  //  $("#tabla").tablesorter( {sortList: [[0,0], [1,0]]} );
	//$("#call").click(getClientes);
	//$("#callId").click(getClientesId);
    //modificar por id de botones reales
});

/*a espera de api funcionando,
de nombres de tablas y de botones, de estilos, de jwt, y de controlar la session y guardar el token
*/

//a espera de url final
var URL_BASE = "";
var TOKEN = "";
function getAlumnos(){
    var arraypersonas;
	$.ajax({
		url:URL_BASE+"alumnos",
		type:"GET",
		beforeSend: function (xhr) {
		    xhr.setRequestHeader ("Authorization", "Bearer " + TOKEN);
		},
		success: function (data) {

		    arraypersonas = JSON.parse(data);
		   /* $('#tabla tr').remove();
		    var primeraFila = $("<tr>");
		    
		        primeraFila.append($("<th>").text("Nombre"));
		        primeraFila.append($("<th>").text("Apellidos"));
		        primeraFila.append($("<th>").text("Alias"));
		        primeraFila.append($("<th>").text("Correo"));		        
		        primeraFila.append($("<th>").text("Curso"));
		        primeraFila.append($("<th>").text("Letra"));
		        primeraFila.append($("<th>").text("Observaciones"));
		        primeraFila.append($("<th>").text("Confirmado"));
		    
		    $('#tabla').append(primeraFila);
		    $.each(data,function(index,value){
		        var row = $("<tr>");
		            row.append($("<td>").text(data[index].nombre));
		            row.append($("<td>").text(data[index].apellidos));
		            row.append($("<td>").text(data[index].alias));
		            row.append($("<td>").text(data[index].correo));
		            row.append($("<td>").text(data[index].curso));
		            row.append($("<td>").text(data[index].letra));
		            row.append($("<td>").text(data[index].observaciones));
		            if (data[index].confirmado == true) {
		                row.append($("<td>").text("SI"));
		            }else{
		                if (data[index].confirmado == false) {
		                    row.append($("<td>").text("NO"));
		                }
		            }		                     
		        $('#tabla').append(row);
		    })*/
		    
		}
	});

	return arraypersonas;
}

function getAlumnosId(id){
    //a falta del id verdadero, coger el campo de texto que manda el index bueno, igual en todos los métodos que usan 
    alumno: Persona;
	$.ajax({
		url:URL_BASE+"alumnos/"+id,
		type:"GET",
		beforeSend: function (xhr) {
		    xhr.setRequestHeader ("Authorization", "Bearer " + TOKEN);
		},
		success: function (data) {


		    alumno:Persona = JSON.parse(data);
		  /*  $('#tabla tr').remove();
		    var primeraFila = $("<tr>");		   
		        primeraFila.append($("<th>").text("Nombre"));
		        primeraFila.append($("<th>").text("Apellidos"));
		        primeraFila.append($("<th>").text("Alias"));
		        primeraFila.append($("<th>").text("Correo"));		        
		        primeraFila.append($("<th>").text("Curso"));
		        primeraFila.append($("<th>").text("Letra"));
		        primeraFila.append($("<th>").text("Observaciones"));
		        primeraFila.append($("<th>").text("Confirmado"));
		    $('#tabla').append(primeraFila);
		    
		        var row = $("<tr>");
		        row.append($("<td>").text(data[0].nombre));
		        row.append($("<td>").text(data[0].apellidos));
		        row.append($("<td>").text(data[0].alias));
		        row.append($("<td>").text(data[0].correo));
		        row.append($("<td>").text(data[0].apellidos));
		        row.append($("<td>").text(data[0].curso));
		        row.append($("<td>").text(data[0].letra));
		        row.append($("<td>").text(data[0].observaciones));
		        if (data[index].confirmado == true) {
		            row.append($("<td>").text("SI"));
		        } else {
		            if (data[index].confirmado == false) {
		                row.append($("<td>").text("NO"));
		            }
		        }
		        $('#tabla').append(row);*/
		    
		}
	});
	return alumno;
}

function getProfesor(){
    $.ajax({
        url:URL_BASE+"profesor",
        type:"GET",
        beforeSend: function (xhr) {
            xhr.setRequestHeader ("Authorization", "Bearer " + TOKEN);
        },
        success: function(data){
            $('#tabla tr').remove();
            var primeraFila = $("<tr>");
           
                primeraFila.append($("<th>").text("Nombre"));
                primeraFila.append($("<th>").text("Apellidos"));              
                primeraFila.append($("<th>").text("Correo"));                    
                primeraFila.append($("<th>").text("Observaciones"));

            
            $('#tabla').append(primeraFila);
            $.each(data,function(index,value){
                var row = $("<tr>");
                row.append($("<td>").text(data[index].nombre));
                row.append($("<td>").text(data[index].apellidos));                
                row.append($("<td>").text(data[index].correo));            
                row.append($("<td>").text(data[index].observaciones));

                $('#tabla').append(row);
            })		
        }
    });
}
function getProfesorId(){
    $.ajax({
        url:URL_BASE+"profesor/"+id,
        type:"GET",
        beforeSend: function (xhr) {
            xhr.setRequestHeader ("Authorization", "Bearer " + TOKEN);
        },
        success: function(data){
            $('#tabla tr').remove();
            var primeraFila = $("<tr>");
            
                primeraFila.append($("<th>").text("Nombre"));
                primeraFila.append($("<th>").text("Apellidos"));              
                primeraFila.append($("<th>").text("Correo"));                    
                primeraFila.append($("<th>").text("Observaciones"));

            
            $('#tabla').append(primeraFila);
            
                var row = $("<tr>");
                row.append($("<td>").text(data[0].nombre));
                row.append($("<td>").text(data[0].apellidos));                
                row.append($("<td>").text(data[0].correo));            
                row.append($("<td>").text(data[0].observaciones));         
                $('#tabla').append(row);
           		
        }
    });
}

function getDeportes(){

	$.ajax({
		url:URL_BASE+"deportes",
		type:"GET",
		beforeSend: function (xhr) {
		    xhr.setRequestHeader ("Authorization", "Bearer " + TOKEN);
		},
		success: function(data){
		    $('#tabla tr').remove();
		    var primeraFila = $("<tr>");    
		        primeraFila.append($("<th>").text("Nombre"));		    
		    $('#tabla').append(primeraFila);
		    $.each(data,function(index,value){
		        var row = $("<tr>");
		        row.append($("<td>").text(data[index].nombre));		              
		        $('#tabla').append(row);
		    })			
		}		
	});
}

function getDeportesId(id){

	$.ajax({
		url:URL_BASE+"deportes/"+id,
		type:"GET",
		beforeSend: function (xhr) {
		    xhr.setRequestHeader ("Authorization", "Bearer " + TOKEN);
		},
		success: function(data){
		    $('#tabla tr').remove();
		    var primeraFila = $("<tr>");		    
		    primeraFila.append($("<th>").text("Nombre"));		    
		    $('#tabla').append(primeraFila);    
		    var row = $("<tr>");
		    row.append($("<td>").text(data[0].nombre));		              
		    $('#tabla').append(row);		    
		}		
	});
}
function getProfesores() {

    $.ajax({
        url: URL_BASE + "profesor",
        type: "GET",
        beforeSend: function (xhr) {
            xhr.setRequestHeader("Authorization", "Bearer " + TOKEN);
        },
        success: function (data) {
            $('#tabla tr').remove();
            var primeraFila = $("<tr>");

            primeraFila.append($("<th>").text("Nombre creador"));
            primeraFila.append($("<th>").text("Categoria"));
            primeraFila.append($("<th>").text("Nombre"));
            primeraFila.append($("<th>").text("Confirmado"));


            $('#tabla').append(primeraFila);
            $.each(data, function (index, value) {
                var row = $("<tr>");
                row.append($("<td>").text(data[index].nombre_creador));
                row.append($("<td>").text(data[index].categoria));
                row.append($("<td>").text(data[index].nombre));
                if (data[index].confirmado == true) {
                    row.append($("<td>").text("SI"));
                } else {
                    if (data[index].confirmado == false) {
                        row.append($("<td>").text("NO"));
                    }
                }

                $('#tabla').append(row);
            })
        }
    });
}

function getProfesoresId(id) {
    $.ajax({
        url: URL_BASE + "profesor/" + id,
        type: "GET",
        beforeSend: function (xhr) {
            xhr.setRequestHeader("Authorization", "Bearer " + TOKEN);
        },
        success: function (data) {
            $('#tabla tr').remove();
            var primeraFila = $("<tr>");

            primeraFila.append($("<th>").text("Nombre creador"));
            primeraFila.append($("<th>").text("Categoria"));
            primeraFila.append($("<th>").text("Nombre"));
            primeraFila.append($("<th>").text("Confirmado"));

            $('#tabla').append(primeraFila);

            var row = $("<tr>");
            row.append($("<td>").text(data[0].nombre_creador));
            row.append($("<td>").text(data[0].categoria));
            row.append($("<td>").text(data[0].nombre));
            if (data[index].confirmado == true) {
                row.append($("<td>").text("SI"));
            } else {
                if (data[index].confirmado == false) {
                    row.append($("<td>").text("NO"));
                }
            }
            $('#tabla').append(row);

        }
    });
}
function getPartidos(){

	$.ajax({
		url:URL_BASE+"partidos",
		type: "GET",
		beforeSend: function (xhr) {
		    xhr.setRequestHeader("Authorization", "Bearer " + TOKEN);
		},
		success: function (data) {
		    $('#tabla tr').remove();
		    var primeraFila = $("<tr>");

		    primeraFila.append($("<th>").text("Local"));
		    primeraFila.append($("<th>").text("Visitante"));
		    primeraFila.append($("<th>").text("Deporte"));
		    primeraFila.append($("<th>").text("Fecha"));
		    primeraFila.append($("<th>").text("Resultado local"));
		    primeraFila.append($("<th>").text("Resultado visitante"));
		    primeraFila.append($("<th>").text("Lugar"));
		    primeraFila.append($("<th>").text("Notas"));


		    $('#tabla').append(primeraFila);
		    $.each(data, function (index, value) {
		        var row = $("<tr>");
		        row.append($("<td>").text(data[index].nombre_creador));
		        row.append($("<td>").text(data[index].categoria));
		        row.append($("<td>").text(data[index].nombre));
		        if (data[index].confirmado == true) {
		            row.append($("<td>").text("SI"));
		        } else {
		            if (data[index].confirmado == false) {
		                row.append($("<td>").text("NO"));
		            }
		        }

		        $('#tabla').append(row);
		    })
		}
	});
}

function getPartidosId(id){

	//id = 0;
	$.ajax({
		url:URL_BASE+"partidos/"+id,
		type:"GET",
		beforeSend: function (xhr) {
		    xhr.setRequestHeader ("Authorization", "Bearer " + TOKEN);
		},
		success: function(data){
		    pintar(data)
		}
		
	});
}
function getDuelos(){

	$.ajax({
		url:URL_BASE+"duelos",
		type:"GET",
		beforeSend: function (xhr) {
		    xhr.setRequestHeader ("Authorization", "Bearer " + TOKEN);
		},
		success: function(data){


		    //pintar(data)
			
		}
		
	});
}

function getDuelosId(){

	id = $("#txtId").val();
	//id = 0;
	$.ajax({
		url:URL_BASE+"duelos/"+id,
		type:"GET",
		beforeSend: function (xhr) {
		    xhr.setRequestHeader ("Authorization", "Bearer " + TOKEN);
		},
		success: function(data){
		    pintar(data)
		}
		
	});
}
function getAlumnosEquipo(){

	id = $("#txtId").val();
	//id = 0;
	$.ajax({
		url:URL_BASE+"Equipos/"+id+"/Alumno",
		type:"GET",
		beforeSend: function (xhr) {
		    xhr.setRequestHeader ("Authorization", "Bearer " + TOKEN);
		},
		success: function(data){
		    pintar(data)
			
		}
		
	});
}

function getEquiposAlumno(){

	id = $("#txtId").val();
	//id = 0;
	$.ajax({
		url:URL_BASE+"Alumnos/"+id+"/Equipo",
		type:"GET",
		beforeSend: function (xhr) {
		    xhr.setRequestHeader ("Authorization", "Bearer " + TOKEN);
		},
		success: function(data){
		    pintar(data)
			}
		});
	}
function pintar(data){
	$('#tabla tr').remove();
	var primeraFila = $("<tr>");
	$.each(data[0],function(index,value){
		primeraFila.append($("<th>").text(index));
	})
	$('#tabla').append(primeraFila);
        $.each(data,function(index,value){
		var row = $("<tr/>");                

                $.each(value,function(value,celda)
                {
                   row.append($('<td>').text(celda));
                });                      
        $('#tabla').append(row);
        })
 }

function getToken(nombre, pass) {
    //
$.ajax({
    url:URL_BASE+"Token",
    type:"GET",
    beforeSend: function (xhr) {
        xhr.setRequestHeader ("Authorization", "Basic " + btoa(nombre + ":" + pass));
    },
    function(data, textStatus, request) {

        TOKEN = request.getResponseHeader('Authorization');
    }
    });     
}	
