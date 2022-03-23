$(document).ready(function () {
    GetAll();
    EstadoGetAll();
    DepartamentoGetAll();
});

function GetAll() {
    $.ajax({
        type: 'GET',
        datetype: 'json',
        url: 'https://localhost:44368/api/Empleado/GetAll',

        success: function (result) {
            $('#Empleados tbody').empty();
            $.each(result.Objects, function (i, empleado) {
                var filas =
                    '<tr>'
                    + '<td class="text-center"> '
                    + '<a href="#" onclick="GetById(' + empleado.IdEmpleado + ')">'
                    + '<img  style="height: 25px; width: 25px;" src="../img/edit.ico" />'
                    + '</a> '
                    + '</td>'
                    + "<td  id='id' class='hidden'>" + empleado.IdEmpleado + "</td>"
                    + "<td class='text-center'>" + empleado.Nombre + " " + empleado.ApellidoPaterno + " " + empleado.ApellidoMaterno + "</ td>"
                    + "<td class='hidden'>" + empleado.Departamento.IdDepartamento + "</td>"
                    + "<td class='text-center'>" + empleado.Departamento.Nombre + "</td>"
                    + "<td class='text-center'>" + empleado.Email + "</td>"
                    + "<td class='text-center'>" + empleado.Sexo + "</td>"
                    + "<td class='text-center'>" + empleado.Telefono + "</td>"
                    + "<td class='text-center'>" + empleado.Celular + "</td>"
                    + "<td class='text-center'>" + empleado.FechaNacimiento + "</td>"
                    + "<td class='hidden'>" + empleado.Estado.IdEstado + "</td>"
                    + "<td class='text-center'>" + empleado.Estado.Nombre + "</td>"
                    + "<td class='text-center'>" + empleado.CodigoPostal + "</td>"
                    + "<td class='text-center'>" + empleado.Direccion + "</td>"
                    + "<td class='text-center'>" + empleado.PagoNomina + "</td>"
                    + '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar(' + empleado.IdEmpleado + ')"><span class="glyphicon glyphicon-trash" style="color:#FFFFFF"></span></button></td>'

                    + "</tr>";
                $("#Empleados tbody").append(filas);
            });
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};

function EstadoGetAll() {
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44368/api/Estado/GetAll',
        success: function (result) {
            $("#ddlEstados").append('<option value="' + 0 + '">' + 'Seleccione una opcion' + '</option>')
            $.each(result.Objects, function (i, estado) {
                $("#ddlEstados").append('<option value="'
                    + estado.IdEstado + '">'
                    + estado.Nombre + '</option>');
            });
        }
    });
}

function DepartamentoGetAll() {
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44368/api/Departamento/GetAll',
        success: function (result) {
            $("#ddlDepartamentos").append('<option value="' + 0 + '">' + 'Seleccione una opcion' + '</option>')
            $.each(result.Objects, function (i, departamento) {
                $("#ddlDepartamentos").append('<option value="'
                    + departamento.IdDepartamento + '">'
                    + departamento.Nombre + '</option>');
            });
        }
    });
}

function ModalForm() {
    document.getElementById('btnUpdate').onclick = Add;
    document.getElementById('Formulario').reset();
    document.getElementById('myModalLabel').innerText = "Agregar Usuario";
    document.getElementById('btnUpdate').innerText = "Agregar";
    $('#ModalUpdate').modal('show');

}

function Add() {

    var Empleado = {
        Nombre: $('#txtNombre').val(),
        ApellidoPaterno: $('#txtApellidoPaterno').val(),
        ApellidoMaterno: $('#txtApellidoMaterno').val(),
        Departamento: {
            IdDepartamento: $('#ddlDepartamentos').val()
        },
        Email: $('#txtEmail').val(),
        Sexo: $('#txtSexo').val(),
        Telefono: $('#txtTelefono').val(),
        Celular: $('#txtCelular').val(),
        FechaNacimiento: $('#txtFechaNacimiento').val(),
        Estado: {
            IdEstado: $('#ddlEstados').val()
        },
        CodigoPostal: $('#txtCodigoPostal').val(),
        Direccion: $('#txtDireccion').val(),
        PagoNomina: $('#txtPagoNomina').val()
    }

    $.ajax({
        type: 'POST',
        url: 'https://localhost:44368/api/Empleado/Add',
        dataType: 'json',
        data: Empleado,
        success: function (result) {
            $('#myModal').modal();
            $('#ModalUpdate').modal('hide');
            GetAll();
            Console(respond);
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};


   

function GetById(IdEmpleado) {
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44368/api/Empleado/GetById/' + IdEmpleado,
        success: function (result) {
            document.getElementById('btnUpdate').onclick = Update;
            document.getElementById('myModalLabel').innerText = "Actualizar Empleado";
            document.getElementById('btnUpdate').innerText = "Actualizar";
            $('#txtIdEmpleado').val(result.Object.IdEmpleado);
            $('#txtNombre').val(result.Object.Nombre);
            $('#txtApellidoPaterno').val(result.Object.ApellidoPaterno);
            $('#txtApellidoMaterno').val(result.Object.ApellidoMaterno);
            $('#ddlDepartamentos').val(result.Object.Departamento.IdDepartamento);
            $('#txtEmail').val(result.Object.Email);
            $('#txtSexo').val(result.Object.Sexo);
            $('#txtTelefono').val(result.Object.Telefono);
            $('#txtCelular').val(result.Object.Celular);
            $('#txtFechaNacimiento').val(result.Object.FechaNacimiento);
            $('#ddlEstados').val(result.Object.Estado.IdEstado);
            $('#txtCodigoPostal').val(result.Object.CodigoPostal);
            $('#txtDireccion').val(result.Object.Direccion);
            $('#txtPagoNomina').val(result.Object.PagoNomina);
            $('#ModalUpdate').modal('show');
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }


    });

}


function Update() {

    var Empleado = {
        IdEmpleado: $('#txtIdEmpleado').val(),
        Nombre: $('#txtNombre').val(),
        ApellidoPaterno: $('#txtApellidoPaterno').val(),
        ApellidoMaterno: $('#txtApellidoMaterno').val(),
        Departamento: {
            IdDepartamento: $('#ddlDepartamentos').val()
        },
        Email: $('#txtEmail').val(),
        Sexo: $('#txtSexo').val(),
        Telefono: $('#txtTelefono').val(),
        Celular: $('#txtCelular').val(),
        FechaNacimiento: $('#txtFechaNacimiento').val(),
        Estado: {
            IdEstado: $('#ddlEstados').val()
        },
        CodigoPostal: $('#txtCodigoPostal').val(),
        Direccion: $('#txtDireccion').val(),
        PagoNomina: $('#txtPagoNomina').val()
    }

    $.ajax({
        type: 'POST',
        url: 'https://localhost:44368/api/Empleado/Update/',
        datatype: 'json',
        data: Empleado,
        success: function (result) {
            $('#myModal').modal();
            $('#ModalUpdate').modal('hide');
            GetAll();
            Console(respond);
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });

};



function Eliminar(IdEmpleado) {

    if (confirm("¿Estas seguro de eliminar El Empleado seleccionada?")) {
        $.ajax({
            type: 'GET',
            url: 'https://localhost:44368/api/Empleado/Delete/' + IdEmpleado,
            success: function (result) {
                $('#myModal').modal();
                GetAll();
            },
            error: function (result) {
                alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
            }
        });

    };
};

$(document).ready(function () {

    (function ($) {

        $('#search').keyup(function () {

            var rex = new RegExp($(this).val(), 'i');

            $('.buscar tr').hide();

            $('.buscar tr').filter(function () {
                return rex.test($(this).text());
            }).show();

        })

    }(jQuery));

});


