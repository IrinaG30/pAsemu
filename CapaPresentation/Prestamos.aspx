<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prestamos.aspx.cs" Inherits="CapaPresentation.Prestamos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>Registro de Prestamos</title>
	<script src="Scripts/jquery-3.5.1.js"></script>
	<script type="text/javascript" src='js/bootstrap.min.js'></script>
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
							<li><a href="CreaUsuarios.aspx">UsUsuarios</a></li>
						</ul>
					</li>
				</ul>
				<%--Boton de log out--%>
				<%--<ul class="nav navbar-nav navbar-right">
					<li>
						<span id="spanBtn" class="glyphicon glyphicon-log-in"></span>
						<asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" OnClick="btnCerrarSesion_Click" CssClass="btn btn-default" CausesValidation="false" />
					</li>
				</ul>--%>
			</div>
		</nav>


		<%--FORMULARIO DE PRESTAMOS--%>
		<div class="container" style="background-color: white;">
			<div class="row">
				<div class="col-md-12">



					<h3>ReReRegistro de Prestamos</h3>
					<br />
					<%--COLUMNA DE INFO PERSONAL--%>
					<div class="col-md-6">
						<br />

						<div class="form-group">
							<asp:Label Text="ID" runat="server" />
							<asp:TextBox ID="txtId" CssClass="form-control" runat="server" ReadOnly="true" />
						</div>

						<div class="form-group">
							<asp:Label Text="Número de Prestamo" runat="server" />
							<asp:TextBox ID="txtNumPrestamo" CssClass="form-control" runat="server" onkeypress="javascript:return solonumeros(event)" />
							<br />
							<asp:ImageButton CausesValidation="false" ID="btnBuscar" runat="server" ImageUrl="Imagenes/lupa.png" Width="30" Height="30" OnClick="btnBuscar_Click" />
							<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNumPrestamo" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar el numero de Prestamo</asp:RequiredFieldValidator>

						</div>

						<div class="form-group">
							<asp:Label Text="Cédula Asociado" runat="server" />
							<asp:TextBox ID="txtCedula" CssClass="form-control" runat="server" placeholder="Ej: 101110111" onkeypress="javascript:return solonumeros(event)" />
							<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCedula" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar la Cédula</asp:RequiredFieldValidator>
						</div>

						<div class="form-group">
							<asp:Label Text="Número de Empleado" runat="server" />
							<asp:TextBox ID="txtNumEmpleado" CssClass="form-control" runat="server" placeholder="Ej: John Doe" onkeypress="javascript:return solonumeros(event)" />
							<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNumEmpleado" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar el número de Empleado</asp:RequiredFieldValidator>
						</div>

						<div class="form-group">
							<asp:Label Text="Puesto" runat="server" />
							<asp:DropDownList ID="dpPuesto" runat="server"></asp:DropDownList>

						</div>

						<div class="form-group">
							<asp:Label Text="Número de Cuenta" runat="server" />
							<asp:TextBox ID="txtNumCuenta" CssClass="form-control" runat="server" placeholder="Ej: 123411112222" onkeypress="javascript:return solonumeros(event)" />
							<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtNumCuenta" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar el número de Cuenta</asp:RequiredFieldValidator>

						</div>

						<div class="form-group">
							<asp:Label Text="Tipo de Crédito" runat="server" />
							<br />
							<asp:DropDownList ID="dpCredito" runat="server"></asp:DropDownList>

						</div>

						<div class="form-group">
							<asp:Label Text="Plazo" runat="server" />
							<br />
							<asp:DropDownList ID="dpPlazo" runat="server"></asp:DropDownList>

						</div>

						<div class="form-group">
							<asp:Label Text="Monto Cuota" runat="server" />
							<asp:TextBox ID="txtMontoCuota" CssClass="form-control" runat="server" placeholder="Ej: 0" onkeypress="javascript:return solonumeros(event)" />
							<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtMontoCuota" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar el número de Cuenta</asp:RequiredFieldValidator>

						</div>

						<div class="form-group">
							<asp:Label Text="Fecha de Inicio" runat="server" />
							<asp:TextBox ID="txtFecha1" CssClass="form-control" runat="server" placeholder="Ej: 7-7-2020" step="any" />

						</div>

						<div class="form-group">
							<asp:Label Text="Fecha Final" runat="server" />
							<asp:TextBox ID="txtFecha2" CssClass="form-control" runat="server" placeholder="Ej: 7-7-2020" step="any" />

						</div>

					</div>

					<%--COLUMNA DE INFO EMPRESARIAL--%>
					<div class="col-md-6">

						<br />

						<div class="form-group">
							<asp:Label Text="Interes" runat="server" />
							<br />
							<asp:DropDownList ID="dpInteres" runat="server"></asp:DropDownList>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="dpInteres" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar el interes</asp:RequiredFieldValidator>


						</div>

						<div class="form-group">
							<asp:Label Text="Tipo de Fiador" runat="server" />
							<br />
							<asp:DropDownList ID="dpFiador" runat="server"></asp:DropDownList>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="dpFiador" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar el tipo de fiador</asp:RequiredFieldValidator>

						</div>

						<div class="form-group">
							<asp:Label Text="Monto Solicitado" runat="server" />
							<asp:TextBox ID="txtMontoSol" CssClass="form-control" runat="server" placeholder="Ej: 0" type="number" step="any" />
							<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtMontoSol" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar el monto solicitado</asp:RequiredFieldValidator>

						</div>

						<div class="form-group">
							<asp:Label Text="Monto a Pagar" runat="server" />
							<asp:TextBox ID="txtMontoPagar" CssClass="form-control" runat="server" placeholder="Ej: 0" type="number" step="any" />
							<asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtMontoPagar" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar el monto a pagar</asp:RequiredFieldValidator>

						</div>

						<div class="form-group">
							<asp:Label Text="Salario Bruto" runat="server" />
							<asp:TextBox ID="txtSalBruto" CssClass="form-control" runat="server" placeholder="Ej: 0" type="number" step="any" />
							<asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtSalBruto" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar el salario Bruto</asp:RequiredFieldValidator>

						</div>

						<div class="form-group">
							<asp:Label Text="Salario Neto" runat="server" />
							<asp:TextBox ID="txtSalNeto" CssClass="form-control" runat="server" placeholder="Ej: 0" type="number" step="any" />
							<asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtSalNeto" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar el salario Neto</asp:RequiredFieldValidator>

						</div>

						<div class="form-group">
							<asp:Label Text="Cuota Fianza" runat="server" />
							<asp:TextBox ID="txtCuotaFianza" CssClass="form-control" runat="server" placeholder="Ej: 0" type="number" step="any" />
							<asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtCuotaFianza" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar la cuota de Fianza</asp:RequiredFieldValidator>

						</div>

						<div class="form-group">
							<asp:Label Text="Comisión Cargos" runat="server" />
							<asp:TextBox ID="txtComision" CssClass="form-control" runat="server" placeholder="Ej: 0" type="number" step="any" />
							<asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtComision" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar la comisión por Cargos</asp:RequiredFieldValidator>

						</div>

						<div class="form-group">
							<asp:Label Text="Estado" runat="server" />
							<asp:TextBox ID="txtEstado" CssClass="form-control" runat="server" />

						</div>
						<%--Boton de Guardar--%>
						<div class="form-group">
							<asp:Button ID="btnGuardar" Text="Guardar" CssClass="btn btn-success" runat="server" OnClick="btnGuardar_Click" />
							<asp:Button ID="btnActualizar" Text="Actualizar" CssClass="btn btn-info" runat="server" OnClick="btnActualizar_Click" />
							<asp:Button CausesValidation="false" ID="btnRegistrarPago" Text="Registrar Pago" CssClass="btn btn-warning" runat="server" OnClick="btnRegistrarPago_Click"/>
							<asp:Button CausesValidation="false" ID="btnLimpiar" Text="Limpiar" CssClass="btn btn-default" runat="server" OnClick="btnLimpiar_Click"/>
						</div>

						<div class="form-group">
							<asp:Label ID="lblMensaje" runat="server" Font-Bold="true" />
						</div>



					</div>



				</div>
			</div>
		</div>

	</form>
	<script src="scripts/jquery-1.9.1.min.js"></script>
	<script src="scripts/bootstrap.min.js"></script>
	<script src="Scripts/datepicker-es.js"></script>
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
			$('#txtFecha1').datepicker({
				dateFormat: 'mm-dd-yy',
				changeMonth: true,
				changeYear: true
			});
		});

		$(document).ready(function () {
			$('#txtFecha2').datepicker({
				dateFormat: 'mm-dd-yy',
				changeMonth: true,
				changeYear: true
			});
		});
	</script>
</body>
</html>