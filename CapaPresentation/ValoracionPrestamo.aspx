<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ValoracionPrestamo.aspx.cs" Inherits="CapaPresentation.ValoracionPrestamo" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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



		<%--DATOS DEL SOLICITANTE--%>
		<div class="container" style="background-color: white;">
			<div class="row">
				<div class="col-md-12">
					<h3>Datos del Solicitante</h3>
					<br />

					<div class="row">
						<%--COLUMNA 1--%>
						<div class="col-md-6">
							<br />

							<div class="form-group">
								<asp:Label Text="Nombre del Asociado" runat="server" />
								<asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" type="text" />
								<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar el nombre del Asociado</asp:RequiredFieldValidator>

							</div>

							<div class="form-group">
								<asp:Label Text="Cédula Asociado" runat="server" />
								<asp:TextBox ID="txtCedula" CssClass="form-control" runat="server" onkeypress="javascript:return solonumeros(event)" />
								<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCedula" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar cédula del Usuario</asp:RequiredFieldValidator>

							</div>

							<div class="form-group">
								<asp:Label Text="Número de Empleado" runat="server" />
								<asp:TextBox ID="txtNumEmpleado" CssClass="form-control" runat="server" onkeypress="javascript:return solonumeros(event)" />
								<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNumEmpleado" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar el número de Empleado</asp:RequiredFieldValidator>

							</div>

							<div class="form-group">
								<asp:Label Text="Tipo de Credito" runat="server" />
								<br />
								<asp:DropDownList ID="dpTipoCredito" runat="server" Height="35px" Width="400px">
									<asp:ListItem Value="1">Clásico</asp:ListItem>
									<asp:ListItem Value="2">Preferencial</asp:ListItem>
									<asp:ListItem Value="3">Hipotecario</asp:ListItem>
									<asp:ListItem Value="4">Marchamo</asp:ListItem>
									<asp:ListItem Value="5">Prendario</asp:ListItem>
									<asp:ListItem Value="6">Redecaución</asp:ListItem>
									<asp:ListItem Value="7">Refundición</asp:ListItem>
									<asp:ListItem Value="8">Gastos Médicos</asp:ListItem>
									<asp:ListItem Value="9">Educación</asp:ListItem>
									<asp:ListItem Value="10">Aguinaldo</asp:ListItem>
								</asp:DropDownList>
							</div>

							<div class="form-group">
								<asp:Label Text="Condición Laboral" runat="server" />
								<br />
								<asp:DropDownList ID="dpCondicion" runat="server" Height="35px" Width="400px">
									<asp:ListItem Value="1">Interino</asp:ListItem>
									<asp:ListItem Value="2">Propiedad</asp:ListItem>
								</asp:DropDownList>
							</div>

							<br />

							<div class="form-group">
								<asp:Label Text="Monto Solicitado" runat="server" />
								<asp:TextBox ID="txtMontoSolic" CssClass="form-control" runat="server" type="number" step="any" />
								<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtMontoSolic" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar el monto Solicitado</asp:RequiredFieldValidator>

							</div>

							<div class="form-group">
								<asp:Label Text="Plazo" runat="server" />
								<asp:TextBox ID="txtPlazo" CssClass="form-control" runat="server"/>
								<asp:TextBox ID="txtPlazoValor" CssClass="form-control" runat="server" ReadOnly="true"/>
								<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPlazo" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar el plazo del Préstamo</asp:RequiredFieldValidator>

							</div>

							<div class="form-group">
								<asp:Label Text="Intereses Anuales" runat="server" type="number" step="any" />
								<asp:TextBox ID="txtInteres" CssClass="form-control" runat="server" ReadOnly="true" />

							</div>

							<div class="form-group">
								<asp:Label Text="Comisión por Cargos" runat="server" />
								<asp:TextBox ID="txtComision" CssClass="form-control" runat="server" ReadOnly="true" />

							</div>

							<div class="form-group">
								<asp:Label Text="Monto Aprobado" runat="server" />
								<asp:TextBox ID="txtMontoAprobado" CssClass="form-control" runat="server" ReadOnly="true" />

							</div>

							<div class="form-group">
								<asp:Label Text="Poliza del INS" runat="server" />
								<asp:TextBox ID="txtPoliza" CssClass="form-control" runat="server" ReadOnly="true" />

							</div>

							<div class="form-group">
								<asp:Label Text="Cuota aprox. por mes" runat="server" />
								<asp:TextBox ID="txtCuotaMes" CssClass="form-control" runat="server" ReadOnly="true" />
							</div>

						</div>

						<%--COLUMNA DE INFO EMPRESARIAL--%>
						<div class="col-md-6">

							<br />

							<div class="form-group">
								<asp:Label Text="Salario Bruto" runat="server" />
								<asp:TextBox ID="txtSalBruto" CssClass="form-control" runat="server"  type="number" step="any" />
								<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtSalBruto" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar el numero de Prestamo</asp:RequiredFieldValidator>

							</div>

							<div class="form-group">
								<asp:Label Text="Deducciones Actuales" runat="server" />
								<asp:TextBox ID="txtDeducciones" CssClass="form-control" runat="server" type="number" step="any" />
								<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtDeducciones" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar el numero de Prestamo</asp:RequiredFieldValidator>

							</div>

							<div class="form-group">
								<asp:Label Text="Cuota de Fianzas" runat="server" />
								<asp:TextBox ID="txtCuotaFianzas" CssClass="form-control" runat="server" type="number" step="any" />
								<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtCuotaFianzas" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar el numero de Prestamo</asp:RequiredFieldValidator>

							</div>

							<div class="form-group">
								<asp:Label Text="Posible Cuota" runat="server" />
								<asp:TextBox ID="txtCuotaPosible" CssClass="form-control" runat="server" ReadOnly="true" />

							</div>

							<div class="form-group">
								<asp:Label Text="Salario Neto" runat="server" />
								<asp:TextBox ID="txtSalNeto" CssClass="form-control" runat="server" ReadOnly="true" />

							</div>

							<div class="form-group">
								<asp:Label Text="Porcentaje de Salario Libre" runat="server" />
								<asp:TextBox ID="txtSalLibre" CssClass="form-control" runat="server" ReadOnly="true" />

							</div>

							<div class="form-group">
								<asp:Label Text="Porcentaje de Salario Comprometido" runat="server" />
								<asp:TextBox ID="txtSalCompr" CssClass="form-control" runat="server" ReadOnly="true" />

							</div>

							<div class="form-group">
								<asp:Label Text="Banco a Utilizar" runat="server" />
								<br />
								<asp:DropDownList ID="dpBanco" runat="server" Height="35px" Width="400px">
									<asp:ListItem Value="1">BCAC</asp:ListItem>
									<asp:ListItem Value="2">BCO.POP</asp:ListItem>
								</asp:DropDownList>
							</div>

							<%--Boton de Calcular--%>
							<div class="form-group">
								<asp:Button CausesValidation="false" ID="btnCalcular" Text="Calcular" CssClass="btn btn-success" runat="server" OnClick="btnCalcular_Click" />
								<asp:Button CausesValidation="false" ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-info" OnClick="btnLimpiar_Click" />
							</div>

                            <div class="form-group">
                                <asp:Label ID="lblMensajeExito" runat="server" ForeColor="Green"  Font-Bold="true"></asp:Label>
                            </div>

							<div class="form-group">
								<asp:Label ID="lblMensajeFracaso" runat="server" ForeColor="Red"  Font-Bold="true"></asp:Label>
							</div>
                        </div>
                    </div>
				</div>
			</div>
		</div>

		<br />

		<%--CAPACIDAD DE PAGO DEL FIADOR--%>
		<div class="container" style="background-color: white;">
			<div class="row">
				<div class="col-md-12">
					<h3>Capacidad de Pago del Fiador</h3>
					<br />

					<div class="row">
						<%--COLUMNA 1--%>
						<div class="col-md-6">
							<br />

							<div class="form-group">
								<asp:Label Text="Nombre del Fiador" runat="server" />
								<asp:TextBox ID="txtNombreFia" CssClass="form-control" runat="server" type="text" />
								<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtNombreFia" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar el nombre del Asociado</asp:RequiredFieldValidator>

							</div>

							<div class="form-group">
								<asp:Label Text="Cédula Fiador" runat="server" />
								<asp:TextBox ID="txtCedulaFia" CssClass="form-control" runat="server" onkeypress="javascript:return solonumeros(event)" />
								<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtCedulaFia" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar cédula del Usuario</asp:RequiredFieldValidator>

							</div>

							<div class="form-group">
								<asp:Label Text="Número de Empleado" runat="server" />
								<asp:TextBox ID="txtNumEmpleadoFia" CssClass="form-control" runat="server" onkeypress="javascript:return solonumeros(event)" />
								<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtNumEmpleadoFia" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar el número de Empleado</asp:RequiredFieldValidator>

							</div>

							<div class="form-group">
								<asp:Label Text="Tipo de Credito" runat="server" />
								<asp:TextBox ID="txtCreditoFia" CssClass="form-control" runat="server" type="text" ReadOnly="true" />
							</div>

							<div class="form-group">
								<asp:Label Text="Condición Laboral" runat="server" />
								<br />
								<asp:DropDownList ID="dpCondicionFia" runat="server" Height="35px" Width="400px">
									<asp:ListItem Value="1">Interino</asp:ListItem>
									<asp:ListItem Value="2">Propiedad</asp:ListItem>
								</asp:DropDownList>
							</div>

							<br />

							<div class="form-group">
								<asp:Label Text="Monto Solicitado" runat="server" />
								<asp:TextBox ID="txtMontoSolFia" CssClass="form-control" runat="server" type="number" step="any" ReadOnly="true"/>

							</div>

							<div class="form-group">
								<asp:Label Text="Plazo" runat="server" />
								<asp:TextBox ID="txtPlazoFia" CssClass="form-control" runat="server" ReadOnly="true"/>
							</div>

							<div class="form-group">
								<asp:Label Text="Intereses Anuales" runat="server" type="number" step="any" />
								<asp:TextBox ID="txtInteresFia" CssClass="form-control" runat="server" ReadOnly="true" onkeypress="javascript:return solonumeros(event)" />

							</div>

							<div class="form-group">
								<asp:Label Text="Comisión por Cargos" runat="server" />
								<asp:TextBox ID="txtComisionFia" CssClass="form-control" runat="server" ReadOnly="true" />

							</div>

							<div class="form-group">
								<asp:Label Text="Monto Aprobado" runat="server" />
								<asp:TextBox ID="txtMontoAprobFia" CssClass="form-control" runat="server" ReadOnly="true" />

							</div>

							<div class="form-group">
								<asp:Label Text="Cuota aprox. por mes" runat="server" />
								<asp:TextBox ID="txtCuotaMesFia" CssClass="form-control" runat="server" ReadOnly="true" />

							</div>

						</div>

						<%--COLUMNA DE INFO EMPRESARIAL--%>
						<div class="col-md-6">

							<br />

							<div class="form-group">
								<asp:Label Text="Salario Bruto" runat="server" />
								<asp:TextBox ID="txtSalBrutoFia" CssClass="form-control" runat="server" type="number" step="any" />
								<asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtSalBrutoFia" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar el numero de Prestamo</asp:RequiredFieldValidator>

							</div>

							<div class="form-group">
								<asp:Label Text="Deducciones Actuales" runat="server" />
								<asp:TextBox ID="txtDeduccionesFia" CssClass="form-control" runat="server" type="number" step="any" />
								<asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtDeduccionesFia" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar el numero de Prestamo</asp:RequiredFieldValidator>

							</div>

							<div class="form-group">
								<asp:Label Text="Cuota de Fianzas" runat="server" />
								<asp:TextBox ID="txtCuotaFianzasFia" CssClass="form-control" runat="server" type="number" step="any" />
								<asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtCuotaFianzasFia" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Debe ingresar el numero de Prestamo</asp:RequiredFieldValidator>

							</div>

							<div class="form-group">
								<asp:Label Text="Posible Cuota" runat="server" />
								<asp:TextBox ID="txtPosibleCuotaFia" CssClass="form-control" runat="server" ReadOnly="true" />

							</div>

							<div class="form-group">
								<asp:Label Text="Salario Neto Proyectado" runat="server" />
								<asp:TextBox ID="txtSalNetoFia" CssClass="form-control" runat="server" ReadOnly="true" />

							</div>

							<div class="form-group">
								<asp:Label Text="Porcentaje de Salario Libre" runat="server" />
								<asp:TextBox ID="txtSalLibreFia" CssClass="form-control" runat="server" ReadOnly="true" />

							</div>

							<div class="form-group">
								<asp:Label Text="Porcentaje de Salario Comprometido" runat="server" />
								<asp:TextBox ID="txtSalCompromFia" CssClass="form-control" runat="server" ReadOnly="true" />

							</div>

							<%--Boton de Calcular--%>
							<div class="form-group">
								<asp:Button ID="btnCalcularFia" Text="Calcular" CssClass="btn btn-success" runat="server" OnClick="btnCalcularFia_Click" />
								<asp:Button CausesValidation="false" ID="btnLimpiarFiador" runat="server" Text="Limpiar" CssClass="btn btn-info" OnClick="btnLimpiarFiador_Click" />
							</div>

							<div class="form-group">
                                <asp:Label ID="lblMensajeExitoFiador" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
                            </div>

							<div class="form-group">
								<asp:Label ID="lblMensajeFracasoFiador" runat="server" ForeColor="Red"  Font-Bold="true"></asp:Label>
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
						 </script>

</body>
</html>
