let lstProductosAgregados = [];

$(() => {
    $.get(`api/productoapi`, ({ data, message }) => {
        if (data != null) {
            PintarTablaDetalleFactura();
            PintarTablaProducto(data);
        } else {
            alert(message);
        }
    })
})

const PintarTablaProducto = (data) => {
    let content = `<table class="table" id="tablaProducto">
                   <thead>
                       <tr>
                           <th>AUTO</th>
                           <th>MARCA</th>
                           <th>PRECIO</th>
                            <th>EXISTENCIA</th>
                           <th>OPCIÓN</th>
                       </tr>
                   </thead>
                   <tbody id="tbodyProducto">`;
    for (let i = 0; i < data.length; i++) {
        const { id, nombreAuto, nombreMarca, precio, existencia} = data[i];
        content += ` <tr>
                           <td>${nombreAuto}</td>
                           <td>${nombreMarca}</td>
                           <td>${precio}</td>
                            <td>${existencia}</td>
                           <td>
                               <span class="badge badge-primary" style="color:green; cursor:pointer" onclick="SeleccionarProducto(${id},'${nombreAuto}',${precio}, ${existencia})">add</span>
                           </td>
                       </tr>`;
    }
    content += `</tbody></table>`;
    document.querySelector(`#divtablaProducto`).innerHTML = content;
    $('#tablaProducto').DataTable();
}

const SeleccionarProducto = (id, nombre, precio, existencia = 0) => {
    if (existencia > 0) {
        LimpiarFormularioCalculo();
        $('#txtIdProducto').val(id);
        $('#txtNombreProducto').val(nombre);
        $('#txtPrecioProducto').val(precio);
        $('#txtSubTotal').val(precio);
        document.getElementById('btnCerrarModal').click();
    } else {
        alert("No hay existencia de este item");
    }
}

const CalcularPrecioAntesDeListar = () => {
    let precioUnitario = $('#txtPrecioProducto').val(),
        porcentajeDescuento = $('#txtPorcentaje').val(),
        cantidadProducto = $('#txtCantidad').val();

    let totalSinDescuento = precioUnitario * cantidadProducto;
    let totalDescuento = (totalSinDescuento / 100) * porcentajeDescuento;
    let subTotal = totalSinDescuento - totalDescuento;
    $('#txtTotalDescuento').val(totalDescuento.toFixed(2));
    $('#txtSubTotal').val(subTotal.toFixed(2));
}

const AgregarProductoAlista = () => {
    if (($('#txtIdProducto').val() != '' || $('#txtIdProducto').val() != 0) && $('#txtNombreProducto').val() != '') {
        let objeto = new Object();
        objeto.txtIdProducto = $('#txtIdProducto').val();
        objeto.txtNombreProducto = $('#txtNombreProducto').val();
        objeto.txtPrecioProducto = $('#txtPrecioProducto').val();
        objeto.txtCantidad = $('#txtCantidad').val();
        objeto.txtPorcentaje = $('#txtPorcentaje').val();
        objeto.txtTotalDescuento = $('#txtTotalDescuento').val();
        objeto.txtSubTotal = $('#txtSubTotal').val();
        lstProductosAgregados.push(objeto);
        PintarTablaDetalleFactura();
        LimpiarFormularioCalculo();
    }
}

const CancelarTodo = () => {
    LimpiarFormularioCalculo();
    lstProductosAgregados = [];
    PintarTablaDetalleFactura();
}

const LimpiarFormularioCalculo = () => {
    $('#txtIdProducto').val(0);
    $('#txtNombreProducto').val('');
    $('#txtPrecioProducto').val(0);
    $('#txtCantidad').val(1);
    $('#txtPorcentaje').val(0);
    $('#txtTotalDescuento').val(0);
    $('#txtSubTotal').val(0);
}

const PintarTablaDetalleFactura = () => {
    let totalDescuento = 0, total = 0, subtotal = 0;
    let content = `
            <table class="table table-hover" id="detalleFactura">
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>PRODUCTO</th>
                                <th>P. UNITARIO</th>
                                <th>CANTIDAD</th>
                                <th>% DESC.</th>
                                <th>TOTAL DESC</th>
                                <th>SUB TOTAL</th>
                            </tr>
                        </thead>
                        <tbody>`;
    for (let i = 0; i < lstProductosAgregados.length; i++) {
        const { txtIdProducto, txtNombreProducto, txtPrecioProducto, txtCantidad, txtPorcentaje, txtTotalDescuento, txtSubTotal } = lstProductosAgregados[i];
        // txtTotalDescuento = txtTotalDescuento == '' || txtTotalDescuento == null ? 0 : txtTotalDescuento;
        content += `<tr>
                                <td>${txtIdProducto}</td>
                                <td>${txtNombreProducto}</td>
                                <td>${txtPrecioProducto}</td>
                                <td>${txtCantidad}</td>
                                <td>${txtPorcentaje}</td>
                                <td>${txtTotalDescuento}</td>
                                <td>${txtSubTotal}</td>
                            </tr>`;
        totalDescuento += (txtTotalDescuento * 1);
        total += (txtPrecioProducto * txtCantidad);
        subtotal += (txtSubTotal * 1);
    }
    content += `</tbody></table>`;
    document.getElementById('divTablaDetalle').innerHTML = content;
    $('#detalleFactura').DataTable();
    //pintado datos generales
    $('#tdTotal').html(`$ ${total.toFixed(2)}`);
    $('#tdDescuento').html(`$ ${totalDescuento.toFixed(2)}`);
    $('#tdSubtotal').html(`$ ${subtotal.toFixed(2)}`);

    $('#btnAbrirFacturar').attr('disabled', lstProductosAgregados.length > 0 ? false : true);
}

const Facturar = () => {
    if ($('#txtNombreCliente').val() != '') {
        let lista = JSON.stringify(lstProductosAgregados);
        let frm = {
            'nombreCliente': $('#txtNombreCliente').val(),
            'lstSerializadaDetalleVenta': lista
        }
        $.ajax({
            url: "/api/VentaControllerAPI",
            type: "POST",
            contentType: 'application/json;charset=utf-8',
            dataType: 'json',
            data: JSON.stringify(frm),
            success: function ({ data, message }) {
                if (data > 0) {
                    DespuesDeFacturar();
                } else {
                    alert(message);
                }
            },
            error: (err) => {
                console.table(err);
                alert('Ocurrio un error al procesar la petición');
            }
        })
    } else {
        alert('Debes ingresar el nombre del cliente');
    }
}

const DespuesDeFacturar = () => {
    document.getElementById('cerrarModalFacturar').click();
    $('#txtNombreCliente').val('');
    CancelarTodo();
    alert('Se guardo correctamente');
}