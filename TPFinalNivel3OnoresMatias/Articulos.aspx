<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Articulos.aspx.cs" Inherits="TPFinalNivel3OnoresMatias.Articulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-6">
                    <div class="mb-3">
                        <asp:Label Text="Filtrar" runat="server" />
                        <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" />
                    </div>
                </div>
                <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
                    <div class="mb-3">
                        <asp:CheckBox Text="Filtro Avanzado" CssClass="" ID="chkAvanzado" runat="server" AutoPostBack="true" OnCheckedChanged="chkAvanzado_CheckedChanged" />
                    </div>
                </div>

                <%if (chkAvanzado.Checked)
                    { %>
                <div class="row">
                    <div class="col-4">
                        <div class="mb-3">
                            <asp:Label Text="Campo" ID="lblCampo" runat="server" />
                            <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-select" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                                <asp:ListItem Text="Código"/>
                                <asp:ListItem Text="Nombre"/>
                                <asp:ListItem Text="Precio"/>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-4">
                        <div class="mb-3">
                            <asp:Label Text="Criterio" runat="server" />
                            <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-select"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-4">
                        <div class="mb-3">
                            <asp:Label Text="Filtro" runat="server" />
                            <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
                        </div>
                    </div>
                    
                </div>
                <div class="row">
                    <div class="col-3">
                        <div class="mb-3">
                            <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" ID="btnBuscar" OnClick="btnBuscar_Click" />
                        </div>
                    </div>
                </div>
                <%} %>
            </div>
            <asp:GridView ID="dgvArticulos" DataKeyNames="Id" runat="server" CssClass="table" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="Código" DataField="Codigo" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                    <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" />
                    <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="Ver" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Button ID="btnAgregar" CssClass="btn btn-primary" runat="server" Text="Agregar" OnClick="btnAgregar_Click"/>
</asp:Content>
