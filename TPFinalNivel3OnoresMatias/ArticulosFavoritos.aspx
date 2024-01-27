<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArticulosFavoritos.aspx.cs" Inherits="TPFinalNivel3OnoresMatias.ArticulosFavoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">




    <%--<div class="row row-cols-1 row-cols-md-3 g-4">--%>
    <div class="row text-center justify-content-center">
        <asp:Label ID="lblFavoritos" runat="server" CssClass="display-4" Text="Mis articulos favoritos"></asp:Label>
        <div class="col-9">
                    <div class="row d-flex justify-content-center">

            <asp:Repeater ID="repRepetidor" runat="server">

                <ItemTemplate>


                    <%--<div class="card mb-3">
                    <div class="row d-flex justify-content-center">
                        <div class="col-md-6">
                            <img src="Images/<%#Eval("Imagen") %>" class="card-img" alt="...">
                        </div>
                        <div class="col-md-6">
                            <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre")%></h5>
                                 <asp:LinkButton Text="Ver" CssClass="btn btn-outline-info" runat="server" ID="btnDetalles" CommandArgument='<%#Eval("Id")%>' CommandName="ArticuloId" OnClick="btnDetalles_Click"><i class="bi bi-eye"></i></asp:LinkButton>
                            <asp:LinkButton CssClass="btn btn-outline-danger" runat="server" ID="btnQuitar" CommandArgument='<%#Eval("Id")%>' CommandName="ArticuloId" OnClick="btnQuitar_Click"><i class="bi bi-star"></i></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>--%>
                    <div class="col-4">
                    <div class="card mb-3">
                        
                                <div class="card-body">
                                    <h5 class="card-title"><%#Eval("Nombre")%></h5>
                                    <img src="Images/<%#Eval("Imagen") %>" class="card-img" alt="...">
                                    <asp:LinkButton Text="Ver" CssClass="btn btn-outline-info" runat="server" ID="btnDetalles" CommandArgument='<%#Eval("Id")%>' CommandName="ArticuloId" OnClick="btnDetalles_Click"><i class="bi bi-eye"></i></asp:LinkButton>
                                    <asp:LinkButton CssClass="btn btn-outline-danger" runat="server" ID="btnQuitar" CommandArgument='<%#Eval("Id")%>' CommandName="ArticuloId" OnClick="btnQuitar_Click"><i class="bi bi-star"></i></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    
                </ItemTemplate>
            </asp:Repeater>
                </div>

        </div>
    </div>

</asp:Content>
