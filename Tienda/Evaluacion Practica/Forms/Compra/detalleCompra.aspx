<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="detalleCompra.aspx.cs" Inherits="Evaluacion_Practica.Forms.Compra.detalleCompra" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../../App_Themes/datatables/datatables.css" rel="stylesheet" type="text/css" />
    <link href="../../App_Themes/datatables/datatables.min.css" rel="stylesheet" type="text/css" />
    <link href="../../App_Themes/toastr/toastr.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.11.1/themes/smoothness/jquery-ui.css" />

    <script src="../../Scripts/jQuery/jQuery 3.7.1.js" type="text/javascript"></script>
    <script src="../../Scripts/toastr/toastr.js" type="text/javascript"></script>
    <script src="../../Scripts/ajax/ajax 3.7.1.js" type="text/javascript"></script>
    <script src="../../Scripts/datatables/datatables.js" type="text/javascript"></script>
    <script src="../../Scripts/datatables/datatables.js" type="text/javascript"></script>
    <script src="../../Scripts/UIBlock/UIBlock.js" type="text/javascript"></script>

    <script src="https://code.jquery.com/ui/1.11.1/jquery-ui.min.js"></script>
    <script src="https://code.jquery.com/jquery-migrate-3.0.0.min.js"></script>

    <script src="../../Scripts/Forms/Compra/detalleCompra.js" type="text/javascript"></script>
    <script>
        $(document).ready(function () {
            detalleCompra.Init();
        });
    </script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Detalle Compra</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="display: flex; justify-content: space-around;">
            <h1>Evaluación</h1>
        </div>
        <div style="display: flex; justify-content: space-around;">
            <div>
                <button type="button" id="btnAgregar">Agregar Venta</button>
            </div>
            <div>
                <label>Nombre del cliente</label>
                <asp:DropDownList ID="drlClientName" runat="server"></asp:DropDownList>
            </div>
            <div>
                <label>Clave cliente</label>
                <asp:DropDownList ID="drlClave" runat="server"></asp:DropDownList>
            </div>
            <div>
                <label>Estatus</label>
                <asp:DropDownList ID="drlStatus" runat="server"></asp:DropDownList>
            </div>
            <div>
    <button type="button" id="btnBuscar">Buscar</button>
</div>
        </div>
        <br />
        <br />
        <div style="display: flex; justify-content: space-around; width: 100%">
            <table id="tblVenta" class="display cell-border hover row-border table table-striped" style="width: 100%"></table>
        </div>

        <div id="modalAddVenta" style="display: flex; flex-direction: column; align-content: space-between; justify-content: space-around; gap: 0.5rem;">
            <div id="divInpts">
                <div>
                    <label>Clave cliente</label>
                    <asp:DropDownList ID="drlCliente" runat="server"></asp:DropDownList>
                </div>

                <div>
                    <label>Producto</label>
                    <asp:DropDownList ID="drlProducto" runat="server"></asp:DropDownList>
                </div>
                <div>
                    <label>Cantidad</label>
                    <input type="number" id="Cantidad" min="1" max="99" value="1" />
                </div>
                <div>
                    <label>Total x Producto</label>
                    <input type="text" id="iptTotal" disabled="disabled" />
                </div>
                <div>
                    <button type="button" id="btnAddProd">Agregar Producto</button>
                </div>
            </div>
            <div style="display: flex; justify-content: space-around;">
                <table id="tblCompras" class="display cell-border hover row-border table table-striped"></table>
            </div>
            <div>
                <label>Total Venta</label>
                <input type="text" id="iptTotalVenta" disabled="disabled" />
            </div>
            <div>
                <button type="button" id="btnSaveDetail">Terminar Venta</button>
            </div>
        </div>
    </form>
</body>
</html>
