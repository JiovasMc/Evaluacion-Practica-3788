var $tblDCompra = null;
var glbProdN = "";

var detalleCompra = {
    Init: function () {
        $("#modalAddVenta").dialog({
            autoOpen: false,
            modal: true,
            width: "auto%"
        });


        detalleCompra.getDrls("drlProducto", 1, "TT:02:01", "descripcion", "producto_id", "costo");
        detalleCompra.getDrls("drlCliente", 2, "TT:01:01", "nombre", "cliente_id", "");
        detalleCompra.getDrls("drlClave", 2, "0", "clave", "cliente_id", "");
        detalleCompra.getDrls("drlClientName", 2, "0", "nombre", "cliente_id", "");
        detalleCompra.getDrls("drlStatus", 3, "TT:01", "descripcion", "catalogo_id", "");
        detalleCompra.Tables();

        $("#btnBuscar").on("click", function () {
            detalleCompra.getHistorial();
        });
        $("#btnAgregar").on("click", function () {
            detalleCompra.cleanFrm();
            glbProdN = "";
            $("#iptTotal").val("");
            $("#divInpts").css("display", "inline");
            $("#btnSaveDetail").css("display", "inline");
            $("#modalAddVenta").dialog("open");
            //$('#tblCompras').dataTable().clear();
            $tblDCompra.clear();
            $tblDCompra.draw();
        });

        $("#drlProducto").on("change", function () {
            var cs = $(this).val().split("-");
            //toastr.warning(cs[1]);
            glbProdN = $(this).find('option:selected').text().split("$")[0];
            //toastr.warning(glbProdN);
            $("#iptTotal").val(parseFloat(cs[1]) * ($("#Cantidad").val()));
        });

        $("#Cantidad").on("change", function () {
            var cs = $(drlProducto).val().split("-");
            //toastr.warning(cs[1]);

            $("#iptTotal").val(parseFloat(cs[1]) * ($("#Cantidad").val()));
        });

        $("#btnAddProd").on("click", function () {
            detalleCompra.addProducto();
        });
        $("#btnSaveDetail").on("click", function () {
            detalleCompra.saveVenta();
        });
        
    },

    Tables: function () {
        $tblVenta = $("#tblVenta").DataTable({
            "paging": true,
            "ordering": true,
            "info": false,
            "responsive": true,
            "scrollY": "400",
            "language": {
                "search": "Buscar",
                "lengthMenu": "_MENU_ Registros por página",
                "zeroRecords": "No información",
                "info": "Página _PAGE_ de _PAGES_",
                "infoEmpty": "Información no disponible",
                "emptyTable": "Información no disponible"

            },
            'columnDefs': [{
                "targets": 0,
                "orderable": false,
                'checkboxes': {
                    'selectRow': true,
                }
            }],
            'select': {
                'style': "multi"
            },
            "aoColumns": [
                {
                    sTitle: "Clave cliente", mData: "clave", responsivePriority: 1, sClass: "", "bSortable": true, mRender: function (d, t, r) {
                        return d;
                    }
                },
                {
                    sTitle: "Cliente", mData: "nombre", responsivePriority: 1, sClass: "", "bSortable": true, mRender: function (d, t, r) {
                        return d;
                    }
                },
                {
                    sTitle: "Mail", mData: "mail", responsivePriority: 1, sClass: "", "bSortable": true, mRender: function (d, t, r) {
                        return d;
                    }
                },
                {
                    sTitle: "Fecha de venta", mData: "fecha", responsivePriority: 1, sClass: "", "bSortable": true, mRender: function (d, t, r) {
                        return d;
                    }
                },
                {
                    sTitle: "Total de venta", mData: "total", responsivePriority: 1, sClass: "", "bSortable": true, mRender: function (d, t, r) {
                        return d;
                    }
                },
                {
                    sTitle: "Detalle", mData: "venta_id", responsivePriority: 1, sClass: "", "bSortable": true, mRender: function (d, t, r) {
                        return '<button style="float: right" type="button" class="btnDetalle" value"' + d.venta_id + '">Detalle</button>';
                    }
                },

            ]



        });


        $tblDCompra = $("#tblCompras").DataTable({
            "paging": true,
            "ordering": true,
            "info": false,
            "responsive": true,
            "scrollY": "400",
            "language": {
                "search": "Buscar",
                "lengthMenu": "_MENU_ Registros por página",
                "zeroRecords": "No información",
                "info": "Página _PAGE_ de _PAGES_",
                "infoEmpty": "Información no disponible",
                "emptyTable": "Información no disponible"

            },
            'columnDefs': [{
                "targets": 0,
                "orderable": false,
                'checkboxes': {
                    'selectRow': true,
                }
            }],
            'select': {
                'style': "multi"
            },
            "aoColumns": [
                {
                    sTitle: "Producto_id", mData: "producto_id", responsivePriority: 1, sClass: "", bVisible: false, "bSortable": true, mRender: function (d, t, r) {
                        return d;
                    }
                },
                {
                    sTitle: "Producto", mData: "descripcion", responsivePriority: 1, sClass: "", "bSortable": true, mRender: function (d, t, r) {
                        return d;
                    }
                },
                {
                    sTitle: "Cantidad", mData: "cantidad", responsivePriority: 1, sClass: "", "bSortable": true, mRender: function (d, t, r) {
                        return d;
                    }
                },
                {
                    sTitle: "Costo Unitario", mData: "costo_unitario", responsivePriority: 1, sClass: "", "bSortable": true, mRender: function (d, t, r) {
                        return d;
                    }
                },
                {
                    sTitle: "Totral", mData: "total", responsivePriority: 1, sClass: "", "bSortable": true, mRender: function (d, t, r) {
                        return d;
                    }
                },

            ]



        });
    },

    actionDetail: function () {

        $(".btnDetalle").on("click", function (d) {
            $("#divInpts").css("display", "none");
            $("#btnSaveDetail").css("display", "none");
            var tbl = $("#tblVenta").DataTable();
            var d = tbl.rows(this.closest('tr')).data();
            $("#modalAddVenta").dialog("open");
            var venta = d[0].venta_id;
            $tblDCompra.clear();
            $tblDCompra.draw();
            detalleCompra.cleanFrm();
            detalleCompra.getDetalleCompra(venta);
        });
    },
    
    getHistorial: function () {
        $tblVenta.clear();
        $tblVenta.draw();
        $.blockUI();
        $.ajax({
            type: "POST",
            async: true,
            url: "detalleCompra.aspx/GetHistorial",
            data: JSON.stringify({ nombre: parseInt($("#drlClientName").val()), clave: parseInt($("#drlClave").val()),  estatus: $("#drlStatus").val() }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                $.unblockUI();
                switch (r.d) {
                    case "error":
                        toastr.success("Ocurrio un error");
                        break;
                    default:
                        var $res = JSON.parse(r.d);
                        $.each($res, function (index, value) {
                            $tblVenta.row.add(value).draw();
                        });
                        $tblVenta.columns.adjust().draw();
                        detalleCompra.actionDetail();
                        break;

                }
            }
        });
    },

    getDetalleCompra: function (venta_id) {
        $tblDCompra.clear();
        $tblDCompra.draw();
        $.blockUI();
        $.ajax({
            type: "POST",
            async: true,
            url: "detalleCompra.aspx/getDetalleCompra",
            data: JSON.stringify({ venta_id: venta_id }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                $.unblockUI();
                switch (r.d) {
                    case "error":
                        toastr.success("Ocurrio un error");
                        break;
                    default:
                        var $res = JSON.parse(r.d);
                        $.each($res, function (index, value) {
                            $tblDCompra.row.add(value).draw();
                            $("#iptTotalVenta").val($res[index]["total"] + parseFloat($("#iptTotalVenta").val()));
                        });
                        $tblDCompra.columns.adjust().draw();
                        break;

                }
            }
        });
    },

    getDrls: function (drlOpt, opt, estatus, text, value, text2) {
        $.blockUI();
        $.ajax({
            type: "POST",
            async: true,
            url: "detalleCompra.aspx/getDrls",
            data: JSON.stringify({ opt: opt, estatus: estatus }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                $.unblockUI();
                switch (r.d) {
                    case "error":
                        toastr.success("Ocurrio un error");
                        break;
                    default:
                        var $res = JSON.parse(r.d);
                        $('#' + drlOpt).append($('<option />', {
                            text: "-- Seleccione una opción --",
                            value: 0,
                        }));
                        for (var i = 0; i < $res.length; i++) {
                            $('#' + drlOpt).append($('<option />', {
                                text: $res[i][text] + (text2 == "" ? "" : " $" + $res[i][text2]),
                                value: $res[i][value] + (text2 == "" ? "" : "-" + $res[i][text2]),
                            }));
                        }
                        break;

                }
            }
        });
    },

    addProducto: function () {
        if ($("#iptTotal").val() == "" || $("#drlCliente").val() == "0" || $("#drlProducto").val() == "0") {
            toastr.warning("Faltan datos necesarios");
            return;
        }
        $('#drlCliente').prop('disabled', true);
        var prd = $("#drlProducto").val().split("-");
        var detalle_compra = {
            producto_id: prd[0],
            descripcion: glbProdN,
            cantidad: $("#Cantidad").val(),
            costo_unitario: prd[1],
            //Descuento:"",
            total: $("#iptTotal").val(),

        }
        var tot = parseFloat($("#iptTotalVenta").val()) + parseFloat($("#iptTotal").val());
        $("#iptTotalVenta").val(tot);
        //$tblDCompra.fnAddData(detalle_compra);
        $tblDCompra.row.add(detalle_compra).draw();
        $tblDCompra.columns.adjust().draw();

    },

    saveVenta: function () {
        var tbl = $("#tblCompras").DataTable().rows().data();

        if (tbl.length <= 0) {
            toastr.warning("No tiene productos");
            return;
        }
        var detalle_compras = [];
        for (var i = 0; i < tbl.length; i++) {
            var Detalle_comprasVO = {
                producto_id: parseInt(tbl[i]["producto_id"]),
                cantidad: parseInt(tbl[i]["cantidad"]),
                descuento: 0.0,
                total: parseFloat(tbl[i]["total"])
            };

            detalle_compras.push(Detalle_comprasVO);   
        }

        $.blockUI();
        $.ajax({
            type: "POST",
            async: true,
            url: "detalleCompra.aspx/saveVenta",
            data: JSON.stringify({ cliente_id: parseInt($("#drlCliente").val()), detalle_compras: detalle_compras }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                $.unblockUI();
                switch (r.d) {
                    case "error":
                        toastr.success("Ocurrio un error");
                        break;
                    case "exito":
                        toastr.success("Se guardo correctamente");
                        $("#modalAddVenta").dialog("close");
                        detalleCompra.getHistorial();
                    default:
   
                        break;

                }
            }
        });
    },

    cleanFrm: function () {
        $('#drlCliente').prop('disabled', false);
        $("#drlCliente").val("0");
        $("#drlProducto").val("0");
        $("#Cantidad").val(1);
        $("#iptTotal").val("");
        $("#iptTotalVenta").val(0.0);
        
       
    }

    //getDrlCliente: function () {
    //    $.blockUI();
    //    $.ajax({
    //        type: "POST",
    //        async: true,
    //        url: "detalleCompra.aspx/getClientes",
    //        data: JSON.stringify({}),
    //        contentType: "application/json; charset=utf-8",
    //        dataType: "json",
    //        success: function (r) {
    //            $.unblockUI();
    //            switch (r.d) {
    //                case "error":
    //                    break;
    //                default:
    //                    var $res = JSON.parse(r.d);
    //                    for (var i = 0; i < $res.length; i++) {
    //                        $('#drlProducto').append($('<option />', {
    //                            text: $res[i]["descripcion"],
    //                            value: $res[i]["producto_id"],
    //                        }));
    //                    }
    //                    break;

    //            }
    //        }
    //    });
    //}
}