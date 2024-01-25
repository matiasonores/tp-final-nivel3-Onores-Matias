<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="TPFinalNivel3OnoresMatias.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div class="row justify-content-center align-items-center" style="height: 80vh">
        <div class="col-6">
            <div class="card mb-3" style="max-width: 540px;">
                <div class="row g-0">
                    <div class="col-md-5 d-flex align-items-center">
                        <asp:Image CssClass="img-fluid rounded-start" ID="imgPerfil" runat="server" />
                    </div>
                    <div class="col-md-7">
                        <div class="card-body">
                            <div class="mb-3">
                                <asp:Label For="txtEmail" CssClass="form-label" ID="lblEmail" runat="server" Text="Email:"></asp:Label>
                                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" readonly="true"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <asp:Label For="txtPassword" CssClass="form-label" ID="lblPassword" runat="server" Text="Password:"></asp:Label>
                                <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <asp:Label For="txtNombre" CssClass="form-label" ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
                                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <asp:Label For="txtApellido" CssClass="form-label" ID="lblApellido" runat="server" Text="Apellido:"></asp:Label>
                                <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <asp:Label For="txtImagen" CssClass="form-label" ID="lblImagen" runat="server" Text="Imagen:"></asp:Label>
                                <asp:FileUpload ID="fuImagen" accept=".jpg" CssClass="form-control" runat="server"></asp:FileUpload>
                            </div>
                            <div class="mb-3">
                                     <asp:Button ID="btnVolver" OnClick="btnVolver_Click" CssClass="btn btn-secondary" runat="server" Text="Volver"/>
                                     <asp:Button ID="btnModificar" OnClick="btnModificar_Click" CssClass="btn btn-warning" runat="server" Text="Actualizar datos"/>
                            </div>
                        
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
        <%--Para que funcione correctamente el fileupload--%>
         <Triggers>
        <asp:PostBackTrigger ControlID="btnModificar" />
    </Triggers>
    </asp:UpdatePanel>
</asp:Content>
