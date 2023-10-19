// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function MostrarInfoSerie(IdSerie) 
{
    $.ajax(
        {
            type:'POST',
            dataType:'JSON',
            url:'/Home/VerDetalleSerie',
            data:{IdSerie: IdSerie},
            success:
            function(response){
                $("#NombreSerie").html(response.nombre);
                $("#FotoSerie").attr("src",response.imagenSerie);
                $("#AñoInicio").html(response.añoInicio);
                $("#Sinopsis").html(response.sinopsis);
                vaciarHTMLActores();
                vaciarHTMLTemporadas();
            }
        }
    )
}


function MostrarTemporadasSerie(IdSerie) 
{
    $.ajax(
        {
            type:'POST',
            dataType:'JSON',
            url:'/Home/VerTemporadasSerie',
            data:{IdSerie: IdSerie},
            success:
            function(response){
                console.log(response)
                 let sumaTemporadas=[];
                response.forEach(element => {
                    sumaTemporadas.push(element + "<br></br>")
                });
                $("#TituloTemporada").html(sumaTemporadas);
                vaciarHTMLActores();
                vaciarHTMLInfo();
            }

        }
    )
}



function MostrarActoresSerie(IdSerie) 
{
    $.ajax(
        {
            type:'POST',
            dataType:'JSON',
            url:'/Home/VerActoresSerie',
            data:{IdSerie: IdSerie},
            success:
            function(response){
                console.log(response)
                 let sumaActores=[];
                response.forEach(element => {
                    sumaActores.push(element + "<br></br>")
                });
                $("#NombreActores").html(sumaActores);
                vaciarHTMLInfo();
                vaciarHTMLTemporadas();
            }
        }
    )
}




function vaciarHTMLInfo(){
    $("#NombreSerie").html("");
    $("#FotoSerie").attr("src","");
    $("#AñoInicio").html("");
    $("#Sinopsis").html("");
}

function vaciarHTMLTemporadas(){
    $("#TituloTemporada").html("");

}



function vaciarHTMLActores(){
    $("#NombreActores").html("");
}