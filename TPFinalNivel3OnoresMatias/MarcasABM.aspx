<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MarcasABM.aspx.cs" Inherits="TPFinalNivel3OnoresMatias.MarcasABM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="form-group">
                    <h2>Agregar marca</h2>

                    <div class="mb-3">
                        <label for="txtNombreMarca" class="form-label">Nombre:</label>
                        <asp:TextBox ID="txtNombreMarca" Type="Text" CssClass="form-control" runat="server"></asp:TextBox>
                        
                        <label for="ddlMarca" class="form-label">Marca:</label>
                        <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
                    </div>
                    <asp:Button ID="btnAgregarMarca" CssClass="btn btn-success" runat="server" Text="Agregar" OnClick="btnAgregarMarca_Click" />
                </div>



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
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
