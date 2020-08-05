<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditorPuestos.aspx.cs" Inherits="CapaPresentation.EditorPuestos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    
    <script src="Scripts/jquery-3.5.1.js"></script>
    <script type="text/javascript" src='js/bootstrap.min.js'></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <title>Configuración de Plazos</title>

     <style type="text/css">
        * {
            margin: auto;
            padding: 0px;
        }

        body {
            background-color: #BA371A;
        }

    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container" style="background-color: white">
            <div class="row">

                <div class="col-md-12">

                    <h3>Puestos</h3>

                    <div class="form-group">
                        <asp:Label Text="ID" runat="server" />
                        <asp:TextBox ID="txtIdPuesto" CssClass="form-control" runat="server" ReadOnly="true" />
                    </div>

                    <div class="form-group">
                        <asp:Label Text="Puesto" runat="server" />
                        <asp:TextBox ID="txtPuesto" CssClass="form-control" runat="server"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPuesto" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Campo Requerido</asp:RequiredFieldValidator>
                    </div>

                    <div class="form-group">
                        <asp:Button ID="btnGrabar" runat="server" Text="Grabar" OnClick="btnGrabar_Click" Width="100px" />
                        <asp:Button ID="btnActualizar" runat="server" OnClick="btnActualizar_Click" Text="Actualizar" Enabled="False" Width="100px" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Enabled="False" OnClick="btnCancelar_Click" Width="100px" />
                        <asp:Button ID="btnSalir" runat="server" Text="Salir" OnClick="btnSalir_Click" Width="100px" CausesValidation="false"/>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                    </div>

                </div>
            </div>
        </div>
    </form>
</body>
</html>