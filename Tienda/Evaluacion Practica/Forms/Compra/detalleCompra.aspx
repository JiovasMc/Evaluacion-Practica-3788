<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detalleCompra.aspx.cs" Inherits="Evaluacion_Practica.Forms.Compra.detalleCompra" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../../App_Themes/datatables/datatables.css" rel="stylesheet" type="text/css" />
    <link href="../../App_Themes/datatables/datatables.min.css" rel="stylesheet" type="text/css" />
    <link href="../../App_Themes/toastr/toastr.css" rel="stylesheet" type="text/css" />

    <script src="../../Scripts/jQuery/jQuery 3.7.1.js" type="text/javascript"></script>


    <script src="../../Scripts/toastr/toastr.js" type="text/javascript"></script>
    <script src="../../Scripts/ajax/ajax 3.7.1.js" type="text/javascript"></script>


    <script src="../../Scripts/datatables/datatables.js" type="text/javascript"></script>
    <script src="../../Scripts/datatables/datatables.js" type="text/javascript"></script>
    <script src="../../Scripts/UIBlock/UIBlock.js" type="text/javascript"></script>


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
        <div style="display:flex; justify-content: space-around;">
            <h1>Evaluación</h1>
        </div>
        <div style="display:flex; justify-content: space-around;">
            <div>
                <label>Nombre del cliente</label>
                <asp:DropDownList ID="drlClientName" runat="server"></asp:DropDownList>
            </div>
            <div>
                <label>Clave cliente</label>
                <asp:DropDownList ID="drlIdClient" runat="server"></asp:DropDownList>
            </div>
            <div>
                <label>Estatus</label>
                <asp:DropDownList ID="drlStatus" runat="server"></asp:DropDownList>
            </div>
        </div>
        <br /><br />
        <div style="display:flex; justify-content: space-around;" width: 100%">
            <table id="tblCompras" class="display cell-border hover row-border table table-striped" style="width: 100%"></table>
        </div>
    </form>
</body>
</html>
