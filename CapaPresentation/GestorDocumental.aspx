<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestorDocumental.aspx.cs" Inherits="CapaPresentation.GestorDocumental" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<title>Control de Expedientes de Afiliados ASEMU</title>
	
	<script src="Scripts/jquery-3.5.1.js"></script>
	<script type="text/javascript" src='js/bootstrap.min.js'></script>
	<link href="Content/bootstrap.css" rel="stylesheet" />

		<style type="text/css">
			
			* {
				margin:auto;
				padding:0px;
			}
			
			.navbar-nav.navbar-center {
				position: absolute;
				left: 50%;
				transform: translatex(-50%);
			}
			
			#btnCerrarSesion {
				background-color:transparent;
				border-color:transparent;
				color:GrayText;
				padding:15px 5px;
				font-family:poppins-semibold, poppins, sans-serif";
			}

			#spanBtn {
				color:GrayText
			}

			</style>
	</head>

<body style="background-color:#BA371A;">
		<form id="form1" runat="server">
			<%--BARRA DE NAVEGACIÓN--%>
			<nav class="navbar navbar-default" style="position:relative;z-index:99; font-family:poppins-semibold,poppins,sans-serif">
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
							<asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" OnClick="btnCerrarSesion_Click" CssClass="btn btn-default" CausesValidation="false" />
						</li>
					</ul>--%>
				</div>
			</nav>


			<%--CONTENIDO DEL GESTOR DOCUMENTAL--%>
			<div class="container" style="background-color: white">
			<div class="row">
				<div class="col-md-12">

					<h3>Gestor Documental</h3>

						<div class="form-group">
							<asp:Label Text="Numero Empleado:" runat="server" />
							<br />
							<asp:DropDownList ID="dlNumEm" runat="server" CssClass="form-control" Width="142px" >
								<asp:ListItem></asp:ListItem>
							</asp:DropDownList>
							<asp:Panel ID="Panel1" runat="server">
							</asp:Panel>
							<br />
							<br />
							<br />

							<br />
							<asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
							<br />
							<asp:Button ID="btnUpload" runat="server" OnClick="Upload" Text="Carga" CssClass="btn btn-success" />
							&nbsp;&nbsp;&nbsp;
						</div>


						<div class="form-group">

							
							<asp:GridView ID="GridView1" runat="server"   AutoGenerateColumns="False" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" RowStyle-BackColor="#A1DCF2" PageSize="5" Width="645px" > 
								<AlternatingRowStyle BackColor="White" />
								<Columns>
									<asp:BoundField DataField="numeroEmpleado" HeaderText="# Empleado" />
									<asp:BoundField DataField="documento" HeaderText="Documento" />
									<asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Descarga Doc">
										<ItemTemplate>
											<asp:ImageButton  ID="lnkDownload" runat="server" CommandArgument='<%# Eval("idDocExpedientes") %>' OnClick="DownloadFile" Text="Download" ImageUrl="~/Imagenes/down.png">

							</asp:ImageButton>
										</ItemTemplate>
										<ItemStyle HorizontalAlign="Center" />
									</asp:TemplateField>
								</Columns>
								<FooterStyle BackColor="Gray" Font-Bold="True" ForeColor="White" />
								<HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" />
								<PagerStyle BackColor="Gray" ForeColor="White" HorizontalAlign="Center" />
								<AlternatingRowStyle BackColor="Lightgray" />

								<RowStyle BackColor="white"></RowStyle>
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