<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroPagos.aspx.cs" Inherits="CapaPresentation.RegistroPagos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Registro de Pagos</title>

    <script src="Scripts/jquery-3.5.1.js"></script>
    <script type="text/javascript" src='js/bootstrap.min.js'></script>
    <script src="scripts/jquery-1.9.1.min.js"></script>

    <script src="scripts/bootstrap.min.js"></script>

    <script src="Scripts/datepicker-es.js"></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />

    <script src="Scripts/jquery-ui-1.12.1.js"></script>
    <link href="Content/themes/base/jquery-ui.css" rel="stylesheet" />

    <style type="text/css">
        * {
            margin: auto;
            padding: 0px;
        }

        .navbar-nav.navbar-center {
            position: absolute;
            left: 50%;
            transform: translatex(-50%);
        }

        #btnCerrarSesion {
            background-color: transparent;
            border-color: transparent;
            color: GrayText;
            padding: 15px 5px;
            font-family: poppins-semibold,poppins,sans-serif";
        }

        #spanBtn {
            color: GrayText
        }
    </style>
</head>

<body style="background-color: #BA371A;">

    <form id="form1" runat="server">
        
        <%--FORMULARIO DE REGISTRO DE PAGOS--%>

        <div class="container" style="background-color: white;">
            <div class="row">

                <h3>Registro de Pagos</h3>

                <br />

                <div class="form-group">
                    <asp:Label Text="ID Registro" runat="server" />
                    <asp:TextBox ID="txtId" CssClass="form-control" runat="server" ReadOnly="true" />
                </div>

                <div class="form-group">
                    <asp:Label Text="ID del Prestamo" runat="server" />
                    <asp:TextBox ID="txtIdPrestamo" CssClass="form-control" runat="server" ReadOnly="true" />
                </div>

                <div class="form-group">
                    <asp:Label Text="Número de Prestamo" runat="server" />
                    <asp:TextBox ID="txtNumPrestamo" CssClass="form-control" runat="server" ReadOnly="true" />
                </div>

                <div class="form-group">
                    <asp:Label Text="Número de Empleado" runat="server" />
                    <asp:TextBox ID="txtNumEmpleado" CssClass="form-control" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNumEmpleado" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Campo requerido</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <asp:Label Text="Fecha de Pago" runat="server" />
                    <asp:TextBox ID="txtFechaPago" CssClass="form-control" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFechaPago" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Campo requerido</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <asp:Label Text="Plazo" runat="server" />
                    <br />
                    <asp:DropDownList ID="dpPlazo" runat="server"></asp:DropDownList>
                </div>

                <div class="form-group">
                    <asp:Label Text="Fecha de Próximo Pago" runat="server" />
                    <asp:TextBox ID="txtFechaProxPago" CssClass="form-control" runat="server" />
                </div>

                <div class="form-group">
                    <asp:Label Text="Estado" runat="server" />
                    <br />
                    <asp:DropDownList ID="dpEstado" runat="server"></asp:DropDownList>
                </div>

                <div class="form-group">
                    <asp:Label Text="Monto a Pagar" runat="server" />
                    <asp:TextBox ID="txtMonto" CssClass="form-control" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtMonto" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Campo requerido</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <asp:Label Text="Total Pagado" runat="server" />
                    <asp:TextBox ID="txtTotal" CssClass="form-control" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtTotal" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Campo requerido</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <asp:Button ID="btnAgregar" Text="Agregar" CssClass="btn btn-success" runat="server" OnClick="btnAgregar_Click" />
                    <asp:Button CausesValidation="false" ID="btnSalir" Text="Salir" CssClass="btn btn-warning" runat="server" OnClick="btnSalir_Click" />
                </div>

                <div class="form-group">
                    <asp:Label ID="lblMensaje" runat="server" Font-Bold="true" />
                </div>

            </div>
        </div>

        <br />

        <div class="container" style="background-color: white; text-align:center">
            <div class="row">

                <h4>Pagos Registrados según Préstamo</h4>

                <div class="form-group">

                    <asp:GridView ID="GridViewDatos" runat="server" OnRowCommand="GridViewDatos_RowCommand" AutoGenerateColumns="False" CellPadding="5" AllowPaging="True" OnPageIndexChanging="GridViewDatos_PageIndexChanging" PageSize="5">
                        <AlternatingRowStyle BackColor="White" />

                        <Columns>
                            <asp:ButtonField ButtonType="Image" CommandName="Revisar" HeaderText="Revisar" ImageUrl="~/Imagenes/check.png" Text="Botón" />

                            <asp:BoundField DataField="idRegistroPago" HeaderText="ID" />
                            <asp:BoundField DataField="numeroPrestamo" HeaderText="Prestamo" />
                            <asp:BoundField DataField="numeroEmpleado" HeaderText="Empleado" />
                            <asp:BoundField DataField="fechaPago" HeaderText="Fecha de Pago" />
                            <asp:BoundField DataField="idPlazo" HeaderText="Plazo" />
                            <asp:BoundField DataField="fechaProxPago" HeaderText="Prox. Pago" />
                            <asp:BoundField DataField="idEstado" HeaderText="Estado" />
                            <asp:BoundField DataField="montoAPagar" HeaderText="Monto a Pagar" />
                            <asp:BoundField DataField="totalPagado" HeaderText="Total Pagado" />
                        </Columns>

                        <FooterStyle BackColor="Gray" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="Gray" ForeColor="White" HorizontalAlign="Center" />
                        <AlternatingRowStyle BackColor="Lightgray" />
                    </asp:GridView>
                </div>

            </div>
        </div>

    </form>

    <%--Metodo para validar solo numeros, se llama en los textbox como onkeypress--%>
    <script>
        function solonumeros(e) {



            var key;



            if (window.event) {
                key = e.keyCode;
            }
            else if (e.which) {
                key = e.which;
            }



            if (key < 48 || key > 57) {
                return false;
            }



            return true;
        }

        $(document).ready(function () {
            $('#txtFechaPago').datepicker({
                dateFormat: 'mm-dd-yy',
                changeMonth: true,
                changeYear: true
            });
        });

        $(document).ready(function () {
            $('#txtFechaProxPago').datepicker({
                dateFormat: 'mm-dd-yy',
                changeMonth: true,
                changeYear: true
            });
        });
    </script>

</body>
</html>

