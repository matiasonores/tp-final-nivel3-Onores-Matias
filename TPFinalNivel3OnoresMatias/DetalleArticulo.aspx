<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="TPFinalNivel3OnoresMatias.DetalleArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row justify-content-center">
        <div class="col-6 d-flex align-items-center" style="height: 80vh">
            <div class="card mb-3 " style="max-width: 600px;">
                <div class="row g-0">
                    <%--<div class="col-md-4 d-flex align-items-center">--%>
                    <div class="col-md-6 d-flex align-items-center">
                        <asp:Image ID="imgArticulo" class="img-fluid rounded-start" runat="server" />
                    </div>
                    <div class="col-md-6">
                        <div class="card-body">
                            <h5 id="txtNombre" runat="server" class="card-title fw-bold"></h5>
                            <div class="mb-3" style="display: none">
                                <label for="txtId" id="lblId" class="form-label fw-bold">ID: </label>
                                <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <label for="txtCodigo" id="lblCodigo" class="form-label fw-bold" style="display: hidden">Codigo: </label>
                                <%--<asp:TextBox ID="txtCodigo" CssClass="form-control" runat="server"></asp:TextBox>--%>
                                <p id="txtCodigo" cssclass="fst-italic" runat="server"></p>
                            </div>
                            <div class="mb-3">
                                <label for="txtDescripcion" id="lblDescripcion" class="form-label fw-bold" style="display: hidden">Descripcion: </label>
                                <%--<asp:TextBox ID="txtDescripcion" CssClass="form-control" runat="server"></asp:TextBox>--%>
                                <p id="txtDescripcion" cssclass="fst-italic" runat="server"></p>
                            </div>

                            <div class="mb-3">
                                <label for="txtMarca" id="lblMarca" class="form-label fw-bold" style="display: hidden">Marca: </label>
                                <%--<asp:TextBox ID="txtMarca" CssClass="form-control" runat="server"></asp:TextBox>--%>
                                <p id="txtMarca" cssclass="fst-italic" runat="server"></p>
                            </div>
                            <div class="mb-3">
                                <label for="txtCategoria" id="lblCategoria" class="form-label fw-bold" style="display: hidden">Categoria: </label>
                                <%--<asp:TextBox ID="txtCategoria" CssClass="form-control" runat="server"></asp:TextBox>--%>
                                <p id="txtCategoria" cssclass="fst-italic" runat="server"></p>
                            </div>

                            <div class="mb-3">
                                <label for="txtPrecio" id="lblPrecio" class="form-label fw-bold" style="display: hidden">Precio: </label>
                                <%--<asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server"></asp:TextBox>--%>
                                <p id="txtPrecio" cssclass="fst-italic" runat="server"></p>
                            </div>
                            <div class="mb-3">
                                <%if (esFavorito)
                                    {%>
                                <asp:Button ID="btnBorrarFavorito" CssClass="btn btn-danger" runat="server" Text="Quitar" OnClick="btnBorrarFavorito_Click" />
                                <% }
                                    else
                                    {%>
                                <asp:Button ID="btnFavorito" CssClass="btn btn-success" runat="server" Text="Favorito" OnClick="btnFavorito_Click" />
                                <%  }%>
                                <asp:LinkButton ID="btnCancelar" CssClass="btn btn-secondary" href="/" runat="server">Volver</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
