<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPFinalNivel3OnoresMatias.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row justify-content-center">
        <div class="col-6 d-flex align-items-center" style="height: 80vh">
            <div class="card mb-3 " style="max-width: 540px;">
                <div class="row g-0">
                    <div class="col-md-4 d-flex align-items-center">
                        <img src="Images/login.jpg" class="img-fluid rounded-start" alt="...">
                    </div>
                    <div class="col-md-8">
                        <div class="card-body">
                            <h5 class="card-title">¡Bienvenido!</h5>
                            <p class="card-text">Ingrese su dirección de correo electrónico y contraseña para iniciar sesión o continúe como visitante para ver el catálogo.</p>

                            <div class="mb-3">
                                <label for="exampleInputEmail1" class="form-label">Email</label>
                                <input type="email" class="form-control" id="exampleInputEmail1" />

                            </div>
                            <div class="mb-3">
                                <label for="exampleInputPassword1" class="form-label">Password</label>
                                <input type="password" class="form-control" id="exampleInputPassword1">
                            </div>
                            <div class="mb-3">
                                <asp:Button runat="server" ID="btnLogin" class="btn btn-success" Text="Log In" />
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

    
</asp:Content>
