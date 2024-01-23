<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Signin.aspx.cs" Inherits="TPFinalNivel3OnoresMatias.Signin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row justify-content-center">
                <div class="col-6 d-flex align-items-center" style="height: 80vh">
                    <div class="card mb-3 " style="max-width: 540px;">
                        <div class="row g-0">
                            <div class="col-md-4 d-flex align-items-center">
                                <img src="Images/signin.jpg" class="img-fluid rounded-start" alt="...">
                            </div>
                            <div class="col-md-8">
                                <div class="card-body">
                                    <h5 class="card-title">¡Bienvenido!</h5>
                                    <p class="card-text">Para generar un nuevo usuario y poder acceder a funcionalidades adicionales de la aplicación, cargue los campos correctamente.</p>

                                    <div class="mb-3">
                                        <asp:Label ID="lblEmail" CssClass="form-label" runat="server" Text="Email"></asp:Label>
                                        <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="mb-3">
                                        <asp:Label ID="lblPassword" CssClass="form-label" runat="server" Text="Password"></asp:Label>
                                        <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                                            ErrorMessage="La contraseña es requerida." Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                                    </div>

                                    <div class="mb-3">
                                        <asp:Label ID="lblNombre" CssClass="form-label" runat="server" Text="Nombre"></asp:Label>
                                        <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"
                                            ErrorMessage="El nombre es requerido." Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                                    </div>

                                    <div class="mb-3">
                                        <asp:Label ID="lblApellido" CssClass="form-label" runat="server" Text="Apellido"></asp:Label>
                                        <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido"
                                            ErrorMessage="El apellido es requerido." Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                                    </div>

                                    <div class="mb-3">
                                        <asp:Label ID="lblImagenPerfil" CssClass="form-label" runat="server" Text="Imagen de Perfil"></asp:Label>
                                        <asp:FileUpload ID="fuImagen" CssClass="form-control" runat="server" Accept=".jpg" />
                                        <asp:RequiredFieldValidator ID="rfvImagenPerfil" runat="server" ControlToValidate="fuImagen" ErrorMessage="La imagen de perfil es requerida." Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revImagenPerfil" runat="server" ControlToValidate="fuImagen" ErrorMessage="Solo se permiten archivos JPG." ValidationExpression="^.*\.(jpg|JPG)$" Display="Dynamic" CssClass="text-danger"></asp:RegularExpressionValidator>
                                    </div>

                                    <asp:Button ID="btnSignIn" runat="server" CssClass="btn btn-primary" Text="Log In" OnClick="btnSignIn_Click" />


                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="toast-container position-absolute top-50 start-50 translate-middle">
                <div class="toast" id="miToast" role="alert" aria-live="assertive" aria-atomic="true">
                    <div class="toast-header">

                        <strong class="me-auto">Sign In</strong>
                        <button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button>
                    </div>
                    <div class="toast-body">
                        <p id="txtMensaje"><%= (this.mensaje)%></p>
                    </div>
                </div>
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script type='text/javascript'>
        function mostrarModal() {
            $(document).ready(function () {
                var miToastEl = document.getElementById('miToast');
                var miToast = new bootstrap.Toast(miToastEl);

                miToast.show();
            });
        }
    </script>
</asp:Content>
