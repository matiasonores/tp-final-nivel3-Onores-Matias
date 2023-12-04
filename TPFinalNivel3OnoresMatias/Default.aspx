<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPFinalNivel3OnoresMatias._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%--<div id="carouselExampleCaptions" class="carousel slide" data-bs-ride="carousel">
  <div class="carousel-indicators">
    <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
    <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="1" aria-label="Slide 2"></button>
    <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="2" aria-label="Slide 3"></button>
  </div>
  <div class="carousel-inner">
    <div class="carousel-item active">
      <img src="Images/20231203141509.jpg" class="d-block w-100" alt="...">
      <div class="carousel-caption d-none d-md-block">
        <h5>First slide label</h5>
        <p>Some representative placeholder content for the first slide.</p>
      </div>
    </div>
    <div class="carousel-item">
      <img src="Images/20231203125032.jpg" class="d-block w-100" alt="...">
      <div class="carousel-caption d-none d-md-block">
        <h5>Second slide label</h5>
        <p>Some representative placeholder content for the second slide.</p>
      </div>
    </div>
    <div class="carousel-item">
      <img src="Images/imagePlaceholder.jpg" class="d-block w-100" alt="...">
      <div class="carousel-caption d-none d-md-block">
        <h5>Third slide label</h5>
        <p>Some representative placeholder content for the third slide.</p>
      </div>
    </div>
  </div>
  <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="prev">
    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
    <span class="visually-hidden">Previous</span>
  </button>
  <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="next">
    <span class="carousel-control-next-icon" aria-hidden="true"></span>
    <span class="visually-hidden">Next</span>
  </button>
</div>--%>
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
                            <img src='Images/<%# Eval("Imagen") %>' style="height:300px; width:300px" class="d-block w-100" alt="...">
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
                        <p class="card-text"><%#Eval("Descripcion") %></p>
                        <a href="ArticuloABM.aspx?id=<%#Eval("Id") %>">Ver detalle</a>
                        <asp:Button Text="Ejemplo" CssClass="btn btn-primary" runat="server" ID="btnEjemplo" CommandArgument='<%#Eval("Id")%>' CommandName="ArticuloId" OnClick="btnEjemplo_Click"/>
                    </div>
                </div>
            </div>
            </ItemTemplate>
        </asp:Repeater>
        </div>
</asp:Content>
