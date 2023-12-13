<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="TPFinalNivel3OnoresMatias.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
                                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
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
                                <asp:FileUpload ID="txtImagen" accept=".jpg" CssClass="form-control" runat="server"></asp:FileUpload>
                            </div>
                            <div class="mb-3">
                                     <asp:Button ID="btnVolver" OnClick="btnVolver_Click" CssClass="btn btn-secondary" runat="server" Text="Volver"/>
                                     <asp:Button ID="btnModificar" OnClick="btnModificar_Click" CssClass="btn btn-warning" runat="server" Text="Actualizar datos"/>
                            </div>
                            <%--<div class="mb-3">
                                <asp:Label For="txtPassword" CssClass="form-label" ID="txtImagen" runat="server" Text="Cargar imagen:"></asp:Label>
                                <asp:Image ID="imgNueva" CssClass="d-flex img-thumbnail" Style="width: 150px; height: 150px;" ImageUrl="https://elpopular.cronosmedia.glr.pe/original/2023/07/06/64a74b82017b6f32c5340134.jpg" runat="server" />
                                <asp:LinkButton ID="btnImagen" OnClick="btnImagen_Click" CssClass="btn btn-outline-success" runat="server">Actualizar</asp:LinkButton>
                                <asp:FileUpload ID="fileImagen" Type="File" CssClass="form-control form-control-sm" runat="server"></asp:FileUpload>
                            </div>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
