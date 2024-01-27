<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoriasABM.aspx.cs" Inherits="TPFinalNivel3OnoresMatias.CategoriasABM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="form-group" style="height: 77vh">
                <h2>Categorías</h2>
                <%--                Agregar marca--%>
                <div class="mb-3">
                    <div class="input-group">
                        <label for="txtNombreCategoria" class="form-label m-2">Nombre:</label>

                        <asp:TextBox ID="txtNombreCategoria" Type="Text" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:Button ID="btnAgregarCategoria" CssClass="btn btn-success" runat="server" Text="Agregar" OnClick="btnAgregarCategoria_Click" />
                    </div>
                </div>


                <%--                DataGridView de categorias--%>
                <div class="mb-3">
                    <asp:GridView ID="dgvCategorias" DataKeyNames="Id" runat="server" CssClass="table" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnSelectedIndexChanged="dgvCategorias_SelectedIndexChanged" OnRowDeleting="dgvCategorias_RowDeleting" OnPageIndexChanging="dgvCategorias_PageIndexChanging">
                        <Columns>
                            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                            <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="Editar" />
                            <asp:CommandField HeaderText="Acción" ShowDeleteButton="true" SelectText="Eliminar" />
                        </Columns>
                    </asp:GridView>

                </div>

                <%--                DropDownList de marcas--%>
                <div class="mb-3">
                    <label for="ddlCategorias" class="form-label">Marca:</label>
                    <asp:DropDownList ID="ddlCategorias" CssClass="form-select" runat="server"></asp:DropDownList>
                </div>
            </div>
            </div>

            <%--Toast de marcas--%>
            <div class="toast-container position-absolute top-50 start-50 translate-middle">
                <div class="toast" id="miToast" role="alert" aria-live="assertive" aria-atomic="true">
                    <div class="toast-header">

                        <strong class="me-auto">Categorías</strong>
                        <button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button>
                    </div>
                    <div class="toast-body">
                        <p id="txtMensaje"><%= (this.mensaje)%></p>
                    </div>
                </div>
            </div>


            </div>
            
            <%--Modal de marcas--%>
            <div class="modal fade" id="modalCategoria" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title"><%=(this.tituloModal) %></h5>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">
                            <p><%=(this.mensajeModal) %></p>
                            <asp:TextBox ID="txtIdCategoria" Visible="false" Type="Text" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:TextBox ID="txtCategoria" Visible="false" Type="Text" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnModificar" Visible="false" CssClass="btn btn-success" runat="server" Text="Modificar" OnClick="btnModificar_Click" data-bs-dismiss="modal" />
                            <asp:Button ID="btnEliminar" Visible="false" CssClass="btn btn-danger" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" data-bs-dismiss="modal" />


                        </div>
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

        function mostrarModalCategoria() {
            $(document).ready(function () {
                $('#modalCategoria').modal('show');
            });
        }
    </script>
</asp:Content>
