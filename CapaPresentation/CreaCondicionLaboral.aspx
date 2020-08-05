<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreaCondicionLaboral.aspx.cs" Inherits="CapaPresentation.CreaCondicionLaboral" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Configuración y Parámetros: Plazos</title>

    <script src="Scripts/jquery-3.5.1.js"></script>
    <script type="text/javascript" src='js/bootstrap.min.js'></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />

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

        body {
            background-color: #BA371A;
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
<body>
    <form id="form1" runat="server">
        <%--BARRA DE NAVEGACIÓN--%>
        <nav class="navbar navbar-default" style="position: relative; z-index: 99; font-family: poppins-semibold,poppins,sans-serif">
            <div class="container-fluid">
                <ul class="nav navbar-nav navbar-center">
                    <%--Boton para Inicio--%>
                    <li><a href="Inicio.aspx">Inicio</a></li>
                    <%--Dropdown para Expedientes--%>
                    <li class="nav-item dropdown">
                        <a class="dropdown-toggle" data-toggle="dropdown" href="#">Expedientes
								<span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li><a href="Expedientes.aspx">Control de Expedientes</a></li>
                            <li><a href="GestorDocumental.aspx">Gestor Documental</a></li>
                        </ul>
                    </li>
                    <%--Dropdown para Prestamos--%>
                    <li class="dropdown">
                        <a class="dropdown-toggle" data-toggle="dropdown" href="#">Préstamos<span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li><a href="ValoracionPrestamo.aspx">Valoración de Préstamos</a></li>
                            <li><a href="Prestamos.aspx">Registro de Préstamos</a></li>
                        </ul>
                    </li>
                    <%--Boton para Reporteria--%>
                    <li><a href="Reporteria.aspx">Reportería</a></li>
                    <%--Dropdown para Configuración y Parametros--%>
                    <li class="dropdown">
                        <a class="nav-link dropdown-toggle" data-toggle="dropdown" href="ConfigParametros.aspx">Configuraciones y Parámetros<span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li><a href="CreaRoles.aspx">Roles</a></li>
                            <li><a href="CreaPuestos.aspx">Puestos</a></li>
                            <li><a href="CreaDepartamentos.aspx">Departamentos</a></li>
                            <li><a href="CreaFiadores">Fiadores</a></li>
                            <li><a href="CreaTipoCredito.aspx">Tipo de Credito</a></li>
                            <li><a href="CreaEstadoRegPrestamos.aspx">Estado de Préstamos</a></li>
                            <li><a href="CreaInteres.aspx">Interes</a></li>
                            <li><a href="CreaCondicionLaboral.aspx">Condición Laboral</a></li>
                            <li><a href="CreaPlazos.aspx">Plazos</a></li>
                            <li><a href="CreaUsuarios.aspx">Usuarios</a></li>
                        </ul>
                    </li>
                </ul>
                <%--Boton de log out--%>
                <%--<ul class="nav navbar-nav navbar-right">
                    <li>
                        <span id="spanBtn" class="glyphicon glyphicon-log-in"></span>
                        <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" OnClick="btnCerrarSesion_Click" CssClass="btn btn-default" CausesValidation="false"/>
                    </li>
                </ul>--%>
            </div>
        </nav>

        <%--CONTENEDOR DEL FORMULARIO PARA CREAR CONDICION LABORAL--%>
        <div class="container" style="background-color: white">
            <div class="row">
                <div class="col-md-12">

                    <h3>Condición Laboral</h3>

                        <div class="form-group">
                            <asp:Label Text="Nombre: " runat="server" />
                            <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"/>

                            <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
                            <asp:Button ID="btnNuevo" runat="server" OnClick="btnNuevoRol_Click" Text="Nuevo" Width="60px" />
                        </div>


                        <div class="form-group">

                            <asp:GridView ID="GridViewCL" runat="server" AutoGenerateColumns="False" CellPadding="2" OnRowDeleting="GridViewDatos_RowDeleting" OnRowCommand="GridViewDatos_RowCommand" AllowPaging="True" OnPageIndexChanging="GridViewDatos_PageIndexChanging" PageSize="5" Width="900px">
                                <AlternatingRowStyle BackColor="White" />
                                
                                <Columns>

                                    <asp:TemplateField HeaderText="Eliminar" ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False"
                                                CommandName="Delete" ImageUrl="~/Imagenes/delete.gif"
                                                OnClientClick="return confirm('Esta seguro que desea eliminar el registro?');"
                                                Text="Eliminar" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:ButtonField ButtonType="Image" CommandName="Actualizar" HeaderText="Editar" ImageUrl="~/Imagenes/edit.gif" Text="Botón" />
                                    <asp:BoundField DataField="idCondicionLaboral" HeaderText="ID" />
                                    <asp:BoundField DataField="nombre" HeaderText="Nombre" /> 

                                </Columns>

                                <FooterStyle BackColor="Gray" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="Gray" ForeColor="White" HorizontalAlign="Center" />
                                <AlternatingRowStyle BackColor="Lightgray" />
                            </asp:GridView>
                        </div>



                    </div>
                </div>
            </div>
    </form>

    <script src="scripts/jquery-1.9.1.min.js"></script>
    <script src="scripts/bootstrap.min.js"></script>

</body>
</html>