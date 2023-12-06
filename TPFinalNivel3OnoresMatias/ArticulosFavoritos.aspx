<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArticulosFavoritos.aspx.cs" Inherits="TPFinalNivel3OnoresMatias.ArticulosFavoritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row row-cols-1 row-cols-md-3 g-4">
                <asp:Repeater ID="repRepetidor" runat="server">

                    <ItemTemplate>
                        <div class="col">
                            <div class="card h-100">
                                <img src="Images/<%#Eval("Imagen") %>" class="card-img-top" alt="...">
                                <div class="card-body">
                                    <h5 class="card-title"><%#Eval("Nombre")%></h5>
                                    <%--<p class="card-text"><%#Eval("Descripcion") %></p>--%>
                                    <p class="card-text text-warning"><i class="bi bi-coin"></i><%#Eval("Precio") %></p>

                                    <asp:LinkButton Text="Ver" CssClass="btn btn-outline-info" runat="server" ID="btnDetalles" CommandArgument='<%#Eval("Id")%>' CommandName="ArticuloId" OnClick="btnDetalles_Click"><i class="bi bi-eye"></i></asp:LinkButton>
                                    <asp:LinkButton CssClass="btn btn-outline-danger" runat="server" ID="btnQuitar" CommandArgument='<%#Eval("Id")%>' CommandName="ArticuloId" OnClick="btnQuitar_Click"><i class="bi bi-star"></i></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
</asp:Content>
