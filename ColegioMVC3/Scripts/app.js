$(function () {
    $(".btnDeleteAlumno").click(function () {
        
        if (confirm("¿Desea eliminar este elemento?")) {
            var idAlumno = $(this).val();
            $.ajax({
                method: "post",
                url: "/Alumnos/Delete",
                datatype: "text/json",
                data: { id: idAlumno },
                success: function(){ location.href='/Alumnos/Index'},
                error: function () { alert("error!"); }
            });
        }  
    });

});