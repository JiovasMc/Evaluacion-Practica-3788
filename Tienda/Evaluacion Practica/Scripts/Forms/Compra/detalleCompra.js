var $tblDCompra = null;

var detalleCompra = {
    Init: function(){
        console.log("funciona el js");

        detalleCompra.Tables();
        detalleCompra.getHistorial();
        toastr.info("revisando 1");
    },

    Tables: function () {
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
                    sTitle: "Clave cliente", mData: "idClient", responsivePriority: 1, sClass: "", "bSortable": true, mRender: function(d,t,r){
                    return d;
                    }
                },
                {
                    sTitle: "Cliente", mData: "idClient", responsivePriority: 1, sClass: "", "bSortable": true, mRender: function (d, t, r) {
                        return d;
                    }
                },
                {
                    sTitle: "Mail", mData: "idClient", responsivePriority: 1, sClass: "", "bSortable": true, mRender: function (d, t, r) {
                        return d;
                    }
                },
                {
                    sTitle: "Fecha de venta", mData: "idClient", responsivePriority: 1, sClass: "", "bSortable": true, mRender: function (d, t, r) {
                        return d;
                    }
                },
                {
                    sTitle: "Total de venta", mData: "idClient", responsivePriority: 1, sClass: "", "bSortable": true, mRender: function (d, t, r) {
                        return d;
                    }
                },
                {
                    sTitle: "Detalle", mData: "idClient", responsivePriority: 1, sClass: "", "bSortable": true, mRender: function (d, t, r) {
                        return d;
                    }
                },

            ]



        });
    },

    getHistorial: function () {
        toastr.info("revisando");
        $tblDCompra.clear();
        $tblDCompra.draw();
        $.blockUI();
        $.ajax({
            type: "POST",
            async: true,
            url: "detalleCompra.aspx/GetHistorial",
            data: JSON.stringify({}),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                $.unblockUI();
                switch (r.d) {
                    case "error":
                        break;
                    default:
                        break;

                }
            }
        });
    }
}