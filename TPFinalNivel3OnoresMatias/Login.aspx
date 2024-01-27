<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPFinalNivel3OnoresMatias.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row justify-content-center">
                <div class="col-6 d-flex align-items-center">
                    <div class="card mb-3 " style="max-width: 540px;">
                        <div class="row g-0">
                            <div class="col-md-4 d-flex align-items-center">
                                <img src="Images/login.jpg" class="img-fluid rounded-start" alt="...">
                            </div>
                            <div class="col-md-8">
                                <div class="card-body">
                                    <h5 class="card-title">¡Iniciar sesión!</h5>
                                    <p class="card-text">¡Bienvenido! Ingrese su dirección de correo electrónico y contraseña para iniciar sesión o continúe como visitante para ver el catálogo.</p>

                                    <div class="mb-3">
                                        <label for="txtEmail" class="form-label">Email</label>
                                        <input type="email" class="form-control" id="txtEmail" runat="server"/>
                                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                                            ErrorMessage="El email es requerido." Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>

                                    </div>
                                    <div class="mb-3">
                                        <label for="txtPassword" class="form-label">Password</label>
                                        <input type="password" class="form-control" id="txtPassword" runat="server">
                                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                                            ErrorMessage="La contraseña es requerida." Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="mb-3">
                                        <asp:Button runat="server" ID="btnLogin" class="btn btn-success" Text="Log In" OnClick="btnLogin_Click" />
                                        <asp:LinkButton href="Signin.aspx" runat="server" ID="btnSignin" type="submit" class="btn btn-primary">Sign In</asp:LinkButton>
                                    </div>
                                    <div class="mb-3">
                                        <p class="card-text">¿Desea iniciar una sesión de prueba?</p>
                                        <asp:Button ID="btnAdmin" CssClass="btn btn-secondary" runat="server" Text="Log as Admin" OnClick="btnAdmin_Click" />
                                        <asp:Button ID="btnUser" CssClass="btn btn-warning" runat="server" Text="Log as User" OnClick="btnUser_Click" />
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <%--Para que funcione correctamente el fileupload--%>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSignIn" />
        </Triggers>
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
