<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="TPFinalNivel3OnoresMatias.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="form-group" style="height: 77vh">
                <h2>Usuarios</h2>

                <%--                DataGridView de usuarios--%>
                <div class="mb-3">
                    <asp:GridView ID="dgvUsuarios" DataKeyNames="Id" runat="server" CssClass="table" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnSelectedIndexChanged="dgvUsuarios_SelectedIndexChanged" OnRowDeleting="dgvUsuarios_RowDeleting" OnPageIndexChanging="dgvUsuarios_PageIndexChanging">
                        <Columns>
                            <asp:BoundField HeaderText="Email" DataField="email" />
                            <asp:BoundField HeaderText="Password" DataField="Password" />
                            <asp:BoundField HeaderText="Nombre" DataField="nombre" />
                            <asp:BoundField HeaderText="Apellido" DataField="apellido" />
                            <asp:BoundField HeaderText="Imagen" DataField="URLImagenPerfil" />
                            <asp:BoundField HeaderText="Admin" DataField="admin" />
                            <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="Editar" />
                            <asp:CommandField HeaderText="Acción" ShowDeleteButton="true" SelectText="Eliminar" />
                        </Columns>
                    </asp:GridView>
                </div>


                <%--Toast de marcas--%>
                <div class="toast-container position-absolute top-50 start-50 translate-middle">
                    <div class="toast" id="miToast" role="alert" aria-live="assertive" aria-atomic="true">
                        <div class="toast-header">

                            <strong class="me-auto">Usuarios</strong>
                            <button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button>
                        </div>
                        <div class="toast-body">
                            <p id="txtMensaje"><%= (this.mensaje)%></p>
                        </div>
                    </div>
                </div>


            </div>

            <%--Modal de marcas--%>
            <div class="modal fade" id="modalUsuario" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title"><%=(this.tituloModal) %></h5>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">
                            <p><%=(this.mensajeModal) %></p>
                            <asp:TextBox ID="txtIdUsuario" Visible="false" Type="Text" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:TextBox ID="txtPassword" Visible="false" Type="Text" CssClass="form-control" runat="server"></asp:TextBox>

                            <div class="form-check">
                                <asp:CheckBox ID="chkAdmin" Visible="false" CssClass="form-check-input" runat="server" />
                                <asp:Label ID="txtAdmin" CssClass="form-check-label" for="chkAdmin" Text="Admin" runat="server"></asp:Label>
                            </div>
                            <asp:TextBox ID="txtEmail" Visible="false" Type="Text" CssClass="form-control" runat="server"></asp:TextBox>
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
       
    </asp:UpdatePanel>

    <script type='text/javascript'>
        function mostrarModal() {
            $(document).ready(function () {
                var miToastEl = document.getElementById('miToast');
                var miToast = new bootstrap.Toast(miToastEl);

                miToast.show();
            });
        }

        function mostrarModalUsuario() {
            $(document).ready(function () {
                $('#modalUsuario').modal('show');
            });
        }
    </script>
</asp:Content>
