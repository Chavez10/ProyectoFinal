// Document javascript

$(document).ready(function() {
    $('#btn1').on('click', function(){
        $.ajax({
            type: "POST",
            url: "Registro.html",
            success: function(response) {
                $('#completo').html(response);
            }
        });
    });
 
});

$(document).ready(function () {
    $('#mostrar_contrasena').click(function () {
      if ($('#mostrar_contrasena').is(':checked')) {
        $('#contrasena').attr('type', 'text');
      } else {
        $('#contrasena').attr('type', 'PASSWORD');
      }
    });
  });


  function mostrarContrasena(){
    var tipo = document.getElementById("PASSWORD");
    if(tipo.type == "password"){
        tipo.type = "text";
    }else{
        tipo.type = "password";
    }
}