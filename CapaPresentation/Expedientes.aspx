<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Expedientes.aspx.cs" Inherits="CapaPresentation.Expedientes" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>Control de Expedientes de Afiliados ASEMU</title>
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

		#btnCerrarSesion {
			background-color: transparent;
			border-color: transparent;
			color: GrayText;
			padding: 15px 5px;
		}

		#spanBtn {
			color: GrayText
		}
	</style>
</head>
<body style="background-color: #BA371A;">
	<form id="form1" runat="server">


		<%--BARRA DE NAVEGACIÓN--%>
		<nav class="navbar navbar-default" style="position: relative; z-index: 99; font-family: poppins-semibold,poppins,sans-serif">
			<div class="container-fluid">
				<%--<div class="navbar-header">
						<a class="navbar-brand" href="#">Inicio</a>
					</div>--%>
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
						<asp:Button CausesValidation="false" ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" OnClick="btnCerrarSesion_Click" CssClass="btn btn-default" />
					</li>
				</ul>--%>
			</div>
		</nav>


		<%--FORMULARIO DE EXPEDIENTE--%>
		<div class="container" style="background-color: white;">
			<div class="row">
				<div class="col-md-12">

					<h3>Formulario de Expedientes</h3>
					<br />

					<div class="row">
						<%--COLUMNA DE INFO PERSONAL--%>
						<div class="col-md-6">
							<h4>Información Personal</h4>

							<div class="form-group">
								<asp:Label Text="ID" runat="server" ID="Label1" />
								<asp:TextBox ID="txtId" CssClass="form-control" runat="server" ReadOnly="true" />
							</div>

							<br />

							<div class="form-group">
								<asp:Label Text="Cedula Asociado" runat="server" />
								<asp:TextBox ID="txtCedula" CssClass="form-control" runat="server" placeholder="Ej: 101110111" onkeypress="javascript:return solonumeros(event)" />
								<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCedula" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar la Cedula del asociado</asp:RequiredFieldValidator>
							</div>

							<div class="form-group">
								<asp:Label Text="Número de Empleado" runat="server" />
								<asp:TextBox ID="txtNumEmpleado" CssClass="form-control" runat="server" placeholder="Ej: 10" onkeypress="javascript:return solonumeros(event)" />
								<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNumEmpleado" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar el numero de empleado</asp:RequiredFieldValidator>
								<br />
								<asp:ImageButton CausesValidation="false" ID="btnBuscar" runat="server" ImageUrl="Imagenes/lupa.png" Width="30" Height="30" OnClick="btnBuscar_Click" />
							</div>

							<div class="form-group">
								<asp:Label Text="Nombre" runat="server" />
								<asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" placeholder="Ej: John" />
								<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNombre" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar el nombre del asociado</asp:RequiredFieldValidator>
							</div>

							<div class="form-group">
								<asp:Label Text="Apellido Paterno" runat="server" />
								<asp:TextBox ID="txtApellido1" CssClass="form-control" runat="server" placeholder="Ej: Doe" />
								<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtApellido1" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar el apelido paterno del asociado</asp:RequiredFieldValidator>
							</div>

							<div class="form-group">
								<asp:Label Text="Apellido Materno" runat="server" />
								<asp:TextBox ID="txtApellido2" CssClass="form-control" runat="server" placeholder="Ej: Diaz" />
								<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtApellido2" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar el apellido materno del asociado</asp:RequiredFieldValidator>
							</div>

							<div class="form-group">
								<asp:Label Text="Telefono" runat="server" />
								<asp:TextBox ID="txtTel" CssClass="form-control" runat="server" placeholder="Ejm: 88997766" onkeypress="javascript:return solonumeros(event)" />
								<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtTel" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar numero telefonico</asp:RequiredFieldValidator>
							</div>

							<div class="form-group">
								<asp:Label Text="Direccion" runat="server" />
								<asp:TextBox ID="txtDireccion" CssClass="form-control" runat="server" placeholder="Ej: La Union, Cartago" />
								<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtDireccion" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar la direccion del asociado</asp:RequiredFieldValidator>
							</div>

							<div class="form-group">
								<asp:Label Text="Correo Electronico" runat="server" />
								<asp:TextBox ID="txtCorreo" CssClass="form-control" runat="server" placeholder="Ej: JohnDoe@mail.com" type="email" />
								<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtCorreo" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar el correo electronico del asociado</asp:RequiredFieldValidator>
							</div>

							<div class="form-group">
								<asp:Label Text="Numero de Cuenta" runat="server" />
								<asp:TextBox ID="txtNumCuenta" CssClass="form-control" runat="server" placeholder="Ej: 11110203040506" onkeypress="javascript:return solonumeros(event)" />
								<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtNumCuenta" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar el numero de cuenta del asociado</asp:RequiredFieldValidator>
							</div>

						</div>

						<%--COLUMNA DE INFO EMPRESARIAL--%>
						<div class="col-md-6">

							<h4>Información Empresarial</h4>
							<br />

							<div class="form-group">
								<asp:Label Text="Puesto" runat="server" />
								&nbsp;<asp:DropDownList ID="dlPuesto" runat="server">
								</asp:DropDownList>
								<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="dlPuesto" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar el puesto de trabajo del asociado</asp:RequiredFieldValidator>
							</div>

							<div class="form-group">
								<asp:Label Text="Departamento" runat="server" />
								&nbsp;<asp:DropDownList ID="dlDepa" runat="server">
									<asp:ListItem></asp:ListItem>
								</asp:DropDownList>
								<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="dlDepa" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar el departamento del asociado</asp:RequiredFieldValidator>
							</div>


							<div class="form-group">
								<asp:Label Text="Fecha de Ingreso" runat="server" />
								<div>
									<asp:Calendar ID="CalendarI" runat="server" OnSelectionChanged="CalendarI_SelectionChanged" Visible="True"></asp:Calendar>
								</div>
								<asp:TextBox ID="txtFechaI" CssClass="form-control" runat="server" placeholder="Ejm: DD-MM-AAAA" Width="147px" ReadOnly="true" />
								<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtFechaI" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar la fecha de ingreso del asociado</asp:RequiredFieldValidator>
							</div>


							<div class="form-group">
								<asp:Label Text="Fecha de Salida" runat="server" />
								<div>
									<asp:Calendar ID="CalendarS" runat="server" OnSelectionChanged="CalendarS_SelectionChanged" Visible="True"></asp:Calendar>
								</div>
								<asp:TextBox ID="txtFechaS" CssClass="form-control" runat="server" placeholder="Ejm: DD-MM-AAAA" Width="145px" ReadOnly="true" />
							</div>



							<div class="form-group">
								<asp:Label Text="Condicion Laboral" runat="server" />
								&nbsp;<asp:DropDownList ID="dlCon" runat="server">
									<asp:ListItem></asp:ListItem>
								</asp:DropDownList>
								<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="dlCon" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar la condicion laboral del asociado</asp:RequiredFieldValidator>
							</div>

							<div class="form-group">
								<asp:Label Text="Tiempo Afiliado" runat="server" />
								<asp:TextBox ID="txtTiempo" CssClass="form-control" runat="server" placeholder="Ej: 1 mes" />
								<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtTiempo" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar el tiempo de afiliacion del asociado</asp:RequiredFieldValidator>
							</div>

							<div class="form-group">
								<asp:Label Text="Estado" runat="server" ID="Label2" />
								<br />
								<asp:DropDownList ID="dlEstado" runat="server">
									<asp:ListItem></asp:ListItem>
									<asp:ListItem>1</asp:ListItem>
								</asp:DropDownList>

							</div>


							<%--BOTON DE GUARDAR--%>
							<div class="form-group">
								<asp:Button ID="btnGuardar" Text="Guardar" CssClass="btn btn-success" runat="server" OnClick="btnGuardar_Click" />
								<asp:Button ID="btnActualizar" Text="Actualizar" CssClass="btn btn-info" runat="server" OnClick="btnActualizar_Click" />
								<asp:Label ID="lblMensaje" runat="server"></asp:Label>
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
