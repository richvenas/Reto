

var tablaDisponible;
var data;
function addRowDT(data) {
    tablaDisponible = $('#tbl_Empresas').DataTable();

    $('#tbl_Empresas').dataTable().fnClearTable();
    for (var i = 0; i < data.length; i++) {
        $('#tbl_Empresas').dataTable().fnAddData([
            data[i].Nombre,
            
            moment(data[i].FechaConstitucion).format('L'),
            data[i].TipoEmpresa.NombreTipoEmpresa,

            `<div style="white-space: nowrap; text-overflow:ellipsis; overflow:hidden;">
                 <a data-toggle="modal" data-target="#EditEmpresaModal" class="primary edit mr-1 btn-edit"><i class="la la-pencil"></i></a>
                 <a class="danger delete mr-1 btn-delete"><i class="la la-trash-o"></i></a>
            </div>`,
            data[i].Identificador            
        ]);
    }
}




$(document).on('click', '.btn-edit', function (e) {
    e.preventDefault();
    var row = $(this).parent().parent().parent()[0];
    var table1 = $('#tbl_Empresas').dataTable();
    var dataRow = table1.fnGetData(row);

    console.log(dataRow[4]);
    $("[id*='HiddenFieldId']").val(dataRow[4])

    var obj = JSON.stringify({ id: dataRow[4] });
    $.ajax({
        type: "POST",
        url: "Empresas.aspx/EditEmpresa",
        data: obj,
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (data) {
            
            
            var arrayDat = moment(data.d.fechaConstitucion).format('L').split('/')
            var anio = arrayDat[2]
            var dia = arrayDat[1]
            var mes = arrayDat[0]

            var fecha = (anio+'-'+mes+'-'+dia)
            

            document.getElementById('txt_NombreEmpresamod').value = data.d.Nombre;
            document.getElementById('txt_FechaConstitucionmod').value =  fecha,
                document.getElementById('select_TipoEmpresamod').value=data.d.TipoEmpresa.Identificador,
                document.getElementById('txt_Comentariosmod').value = data.d.Comentarios
        }

    });


});



$(document).on('click', '.btn-modificar', function (e) {

    let valor = true;
    if (document.getElementById('txt_NombreEmpresamod').value == false) {
        alert('Nombre de la empresa es un campo obligatorio')
        return
    }
    if (document.getElementById('txt_FechaConstitucionmod').value == false) {
        alert('Fecha de constitución es un campo obligatorio')
        return
    }
    if (document.getElementById('select_TipoEmpresamod').value == 0) {
        alert('Tipo de empresa es un campo obligatorio')
        return
    }



    var obj = JSON.stringify({
        id:$("[id*='HiddenFieldId']").val(),
        nombre: document.getElementById('txt_NombreEmpresamod').value,
        fechaConstitucion: document.getElementById('txt_FechaConstitucionmod').value,
        tipoEmpresaId: document.getElementById('select_TipoEmpresamod').value,
        comentarios: document.getElementById('txt_Comentariosmod').value
    });


    $.ajax({
        type: "POST",
        url: "Empresas.aspx/modEmpresa",
        data: obj,
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (data) {
            if (data.d == false) {

                alert("La empresa no se ha modificado");

            } else {

                alert("La empresa se modificó corectamente");
            }
            sendDataAjax();
        }

    });


    sendDataAjax();

});

$(document).on('click', '.btn-save', function (e) {

    let valor = true;
    if (document.getElementById('txt_NombreEmpresa').value==false) {
        alert('Nombre de la empresa es un campo obligatorio')
        return
    }
    if (document.getElementById('txt_FechaConstitucion').value == false) {
        alert('Fecha de constitución es un campo obligatorio')
        return
    }
    if (document.getElementById('select_TipoEmpresa').value == 0) {
        alert('Tipo de empresa es un campo obligatorio')
        return
    }

    

    var obj = JSON.stringify({
        nombre: document.getElementById('txt_NombreEmpresa').value,
        fechaConstitucion: document.getElementById('txt_FechaConstitucion').value,
        tipoEmpresaId: document.getElementById('select_TipoEmpresa').value,
        comentarios: document.getElementById('txt_Comentarios').value
    });

    
    $.ajax({
        type: "POST",
        url: "Empresas.aspx/RegistrarEmpresa",
        data: obj,
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (data) {
            if (data.d == false) {
                
                alert("La empresa no se ha registrado");
                
            } else {
                
                alert("La empresa se registro corectamente");
            }
            sendDataAjax();
        }

    });


    sendDataAjax();

});

$(document).on('click', '.btn-delete', function (e) {
    
    e.preventDefault();
    var row = $(this).parent().parent().parent()[0];
    var table1 = $('#tbl_Empresas').dataTable();
    var dataRow = table1.fnGetData(row);
    //alert(dataRow[4]);
    console.log(dataRow[4]);

    var mensaje;
    var opcion = confirm("Esta seguro?");
    if (opcion == true) {


        var obj = JSON.stringify({ id: dataRow[4] });
        $.ajax({
            type: "POST",
            url: "Empresas.aspx/EliminarEmpresa",
            data: obj,
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                if (data.d == false) {
                  
                    alert("La empresa no se ha eliminado");
                    
                } else {
                    alert("La empresa se elimino corectamente");
                }
                sendDataAjax();
            }

        });


      
    } else {
        alert("La campaña No se ha eliminado : )");
    }

});

function sendDataAjax() {

    

    $.ajax({
        type: "POST",
        url: "Empresas.aspx/Empresas",
        data: {},
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + " \n" + xhr.responseText, " \n" + thrownError);
        },
        success: function (data) {
            console.log(data.d);
            addRowDT(data.d)
        }
    });
}
sendDataAjax();