<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreaUsuarios.aspx.cs" Inherits="CapaPresentation.CreaUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>Configuraciones y Parámetros: Usuarios</title>

	<script src="Scripts/jquery-3.5.1.js"></script>
	<script type="text/javascript" src='js/bootstrap.min.js'></script>
	<link href="Content/bootstrap.css" rel="stylesheet" />

	<style type="text/css">
		* {
			margin: auto;
			padding: 0px;
		}

		body {
			background-color: #BA371A;
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
	        font-family: poppins-semibold,poppins,sans-serif;
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

		<%--CONTENEDOR DEL FORMULARIO PARA REGISTRAR USUARIOS--%>
		<div class="container" style="background-color: white;">
			<div class="row">
				<div class="col-md-12">

					<h3>Registro de Usuarios</h3>
					<br />

					<div class="form-group">
                        <asp:Label Text="Cedula Usuario" runat="server" />
                        <asp:TextBox ID="txtcedulaUsuario" CssClass="form-control" runat="server" onkeypress="javascript:return solonumeros(event)" placeholder="Ej: 101110111" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtcedulaUsuario" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar la Cedula del Usuario</asp:RequiredFieldValidator>
                    </div>

                
                    <div class="form-group">
                        <asp:Label Text="Nombre Completo" runat="server" />
                        <asp:TextBox ID="txtnombreCompleto" CssClass="form-control"  runat="server" placeholder="Ej: John Doe" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  ControlToValidate="txtnombreCompleto" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar su nombre completo</asp:RequiredFieldValidator>
                    </div>

 

                    <div class="form-group">
                        <asp:Label Text="ID Rol" runat="server" />
                        <asp:TextBox ID="txtRol" CssClass="form-control" runat="server" placeholder="Ej: 1" onkeypress="javascript:return solonumeros(event)"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRol" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar el ID de rol. Ejem: 1  </asp:RequiredFieldValidator>
                    </div>

 

                     <div class="form-group">
                        <asp:Label Text="Contraseña" runat="server" />
                        <asp:TextBox ID="txtcontrasenna" CssClass="form-control" runat="server" placeholder="111111" type="password" pattern=".{6,}" title="Debe ser de 6 o más caracteres"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtcontrasenna" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar una contraseña</asp:RequiredFieldValidator>
                
                     </div>

                    <div class="form-group">
                        <asp:CheckBox ID="cbEstado" runat="server" Text="¿Se encuentra activo?" />
                    </div>

					<div class="form-group">
						<asp:Button ID="txtGuardar" Text="Guardar" CssClass="btn btn-success" runat="server" OnClick="txtGuardar_Click" />
					</div>

				</div>
			</div>

			<%--GRID VIEW--%>
			<%--<asp:GridView ID="gvUsuarios" runat="server" CssClass="table table-hover" AutoGenerateColumns="true"></asp:GridView>--%>
			
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
