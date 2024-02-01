<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArticulosABM.aspx.cs" Inherits="TPFinalNivel3OnoresMatias.ArticulosABM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2 id="itemArticulo">Nuevo artículo</h2>

    <div class="row">

        <div class="col-4">
            <div class="row d-none">
                <label for="txtId" class="form-label">Id:</label>
                <asp:TextBox ID="txtId" Type="Text" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Código:</label>
                <asp:TextBox ID="txtCodigo" Type="Text" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre:</label>
                <asp:TextBox ID="txtNombre" Type="Text" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción:</label>
                <asp:TextBox ID="txtDescripcion" Type="Text" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

        </div>
        <div class="col-4">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="ddlMarca" class="form-label">Marca:</label>
                        <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
                    </div>
                    <div class="mb-3">
                        <label for="ddlMarca" class="form-label">Categoría:</label>
                        <asp:DropDownList ID="ddlCategoria" CssClass="form-select" runat="server"></asp:DropDownList>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio:</label>
                <div class="input-group mb-6">
                    <span class="input-group-text">$</span>
                    <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-4">
            <div class="mb-3">
                <label for="txtImagen" class="form-label">Cargar imagen:</label>
                <asp:Image ID="imagen" CssClass="d-flex img-thumbnail" Style="width: 150px; height: 150px;" ImageUrl="https://elpopular.cronosmedia.glr.pe/original/2023/07/06/64a74b82017b6f32c5340134.jpg" runat="server" />
                <asp:LinkButton ID="btnImagen" OnClick="btnImagen_Click" CssClass="btn btn-outline-success" runat="server">Actualizar</asp:LinkButton>
                <asp:FileUpload ID="fileImagen" OnChange="fileImagen_Load" Type="File" CssClass="form-control form-control-sm" runat="server"></asp:FileUpload>
            </div>
        </div>
    </div>
    <asp:Button ID="btnAceptar" CssClass="btn btn-success" runat="server" Text="Agregar" OnClick="btnAceptar_Click" />
    <asp:Button ID="btnEliminar" Visible="false" CssClass="btn btn-danger" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
    <asp:Button ID="btnCancelar" CssClass="btn btn-primary" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
</asp:Content>
