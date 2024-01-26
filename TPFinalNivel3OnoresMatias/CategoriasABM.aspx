<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoriasABM.aspx.cs" Inherits="TPFinalNivel3OnoresMatias.CategoriasABM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="form-group">
                <h2>Agregar categoría</h2>
                <div class="mb-3">
                    <label for="txtNombreCategoria" class="form-label">Nombre:</label>
                    <asp:TextBox ID="txtNombreCategoria" Type="Text" CssClass="form-control" runat="server"></asp:TextBox>


                    <label for="ddlMarca" class="form-label">Categoría:</label>
                    <asp:DropDownList ID="ddlCategoria" CssClass="form-select" runat="server"></asp:DropDownList>
                </div>
                <asp:Button ID="btnAgregarCategoria" CssClass="btn btn-success" runat="server" Text="Agregar" OnClick="btnAgregarCategoria_Click" />
            </div>

           <div class="toast-container position-absolute top-50 start-50 translate-middle">
                <div class="toast" id="miToast" role="alert" aria-live="assertive" aria-atomic="true">
                    <div class="toast-header">

                        <strong class="me-auto">Categorias</strong>
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
        <asp:PostBackTrigger ControlID="btnAgregarCategoria" />
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
