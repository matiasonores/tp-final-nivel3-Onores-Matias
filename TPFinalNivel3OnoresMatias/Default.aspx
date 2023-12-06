<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPFinalNivel3OnoresMatias._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
        <div class="container-fluid">
            
            <asp:DropDownList CssClass=" nav-item form-select" runat="server">
                <asp:ListItem>Armaduras</asp:ListItem>
                <asp:ListItem>Espadas</asp:ListItem>
                <asp:ListItem>Escudos</asp:ListItem>
            </asp:DropDownList>
            <div class="nav-item input-group">
                <input type="text" class="form-control" id="autoSizingInputGroup" placeholder="Username">
                <div class="input-group-text"><i class="bi bi-search"></i></div>
            </div>
        </div>
    </nav>
    <div class="row justify-content-center">
        <div class="col-8">

            <%--    Carrusel con repeater--%>
            <div id="carouselExampleCaptions" class="carousel slide" data-bs-ride="carousel">
                <div class="carousel-indicators">
                    <asp:Repeater ID="RepeaterCarousel" runat="server">
                        <ItemTemplate>
                            <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to='<%# Container.ItemIndex %>' class='<%# Container.ItemIndex == 0 ? "active" : "" %>' aria-current='<%# Container.ItemIndex == 0 %>' aria-label='<%# "Slide " + (Container.ItemIndex + 1) %>'></button>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="carousel-inner">
                    <asp:Repeater ID="RepeaterCarousel2" runat="server">
                        <ItemTemplate>
                            <div class='<%# "carousel-item" + (Container.ItemIndex == 0 ? " active" : "") %>'>
                                <img src='Images/<%# Eval("Imagen") %>' style="height: 300px; width: 300px" class="d-block w-100" alt="...">
                                <div class="carousel-caption d-none d-md-block">
                                    <h5><%# Eval("Nombre") %></h5>
                                    <p><%# Eval("Descripcion") %></p>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Previous</span>
                </button>
                <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Next</span>
                </button>
            </div>


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

                                    <asp:LinkButton Text="Ver" CssClass="btn btn-outline-info" runat="server" ID="btnEjemplo" CommandArgument='<%#Eval("Id")%>' CommandName="ArticuloId" OnClick="btnEjemplo_Click"><i class="bi bi-eye"></i></asp:LinkButton>
                                    <asp:LinkButton CssClass="btn btn-outline-success" runat="server" ID="btnFavorito" CommandArgument='<%#Eval("Id")%>' CommandName="ArticuloId" OnClick="btnFavorito_Click"><i class="bi bi-star"></i></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
