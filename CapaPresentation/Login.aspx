<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CapaPresentation.Login1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <style>

        .login{
            margin-top:150px;
        }
        div{
            text-align: center;
        }
    </style>
</head>
<body style="background-color:#BA371A;">

    <form id="form1" runat="server" >
        <div class="container">

            <div class="row">

                <div class="col-md-offset-4 col-md-4">

                    <div class="panel panel-default login">
                        <div class="panel-heading"><span style="font-family:poppins-semibold,poppins,sans-serif"><span style="font-size:22px"><span style="font-weight:bold"><span style="color:#373B4D">Iniciar Sesión</span></span></span></span></div>
                        <div class="panel-body">

                            <div class="form-group">

                                <asp:Label Text="Usuario" runat="server" />
                                <asp:TextBox runat="server" ID="txtUsuario" CssClass="form-control" onkeypress="javascript:return solonumeros(event)"/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsuario" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar la cedula del usuario</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:Label Text="Contraseña" runat="server" />
                                <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" TextMode="Password" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar la contraseña del usuario</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:Button Text="INGRESAR" ID="btnIniciar" CssClass="btn btn-success" BorderColor="#E36C53" BackColor="#E36C53"  runat="server" ForeColor="White" Font-Bold="True" OnClick="btnIniciar_Click1"/> <%--OnClientClick="Iniciar"--%>
                            </div>


                        </div>
                    </div>

                </div>

            </div>

        </div>
    </form>
    <script src="scripts/jquery-1.9.1.min.js"></script>
    <script src="scripts/bootstrap.min.js"></script>
    <%--Metodo para validar solo numeros, se llama en los textbox como onkeypress--%>
    <script>
        function solonumeros(e) {



            var key;



            if (window.event) // IE
            {
                key = e.keyCode;
            }
            else if (e.which) // Netscape/Firefox/Opera
            {
                key = e.which;
            }



            if (key < 48 || key > 57) {
                return false;
            }



            return true;
        }

    </script>
</body>
</html>
