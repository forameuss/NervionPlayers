$(function(){
    $("#tabla").tablesorter( {sortList: [[0,0], [1,0]]} );
	$("#call").click(getClientes);
	$("#callId").click(getClientesId);
    //modificar por id de botones reales
});

/*a espera de api funcionando,
de nombres de tablas y de botones, de estilos, de jwt, y de controlar la session y guardar el token
*/

//a espera de url final
var URL_BASE = "";
var TOKEN = "";
function getAlumnos(){

	$.ajax({
		url:URL_BASE+"alumnos",
		type:"GET",
		beforeSend: function (xhr) {
		    xhr.setRequestHeader ("Authorization", "Bearer " + TOKEN);
		},
		success: function(data){
		    pintar(data)
			
		}
	});
}

function getAlumnosId(){
    //a falta del id verdadero, coger el campo de texto que manda el index bueno, igual en todos los métodos que usan 
	id = $("#txtId").val();
	$.ajax({
		url:URL_BASE+"alumnos/"+id,
		type:"GET",
		beforeSend: function (xhr) {
		    xhr.setRequestHeader ("Authorization", "Bearer " + TOKEN);
		},
		success: function(data){
		    pintar(data)
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
		    pintar(data)
			
		}
		
	});
}

function getDeportesId(){

	id = $("#txtId").val();
	//id = 0;
	$.ajax({
		url:URL_BASE+"deportes/"+id,
		type:"GET",
		beforeSend: function (xhr) {
		    xhr.setRequestHeader ("Authorization", "Bearer " + TOKEN);
		},
		success: function(data){
		    pintar(data)
		}
		
	});
}
function getEquipos(){

	$.ajax({
		url:URL_BASE+"equipos",
		type:"GET",
		beforeSend: function (xhr) {
		    xhr.setRequestHeader ("Authorization", "Bearer " + TOKEN);
		},
		success: function(data){
		    pintar(data)
			
		}
		
	});
}

function getEquiposId(){

	id = $("#txtId").val();
	//id = 0;
	$.ajax({
		url:URL_BASE+"equipos/"+id,
		type:"GET",
		beforeSend: function (xhr) {
		    xhr.setRequestHeader ("Authorization", "Bearer " + TOKEN);
		},
		success: function(data){
		    pintar(data)
		}
		
	});
}
function getPartidos(){

	$.ajax({
		url:URL_BASE+"partidos",
		type:"GET",
		beforeSend: function (xhr) {
		    xhr.setRequestHeader ("Authorization", "Bearer " + TOKEN);
		},
		success: function(data){
		    pintar(data)
			
		}
		
	});
}

function getPartidosId(){

	id = $("#txtId").val();
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
		    pintar(data)
			
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

function getToken() {
    var nombre = ;
    var pass = ;
    //a falta de recibir nombre y pass de campos de texto
$.ajax({
    url:URL_BASE+"Token",
    type:"GET",
    beforeSend: function (xhr) {
        xhr.setRequestHeader ("Authorization", "Basic " + btoa(nombre + ":" + pass));
    },
    function(data, textStatus, request){
        TOKEN = request.getResponseHeader('Authorization');
    }
    });     
}	
