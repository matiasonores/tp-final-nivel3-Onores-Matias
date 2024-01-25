<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPFinalNivel3OnoresMatias._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


            <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
                <div class="container-fluid">


                    <div class="row nav-item m-1">
                        <div class="col-4 col-form-label">
                            <asp:Label ID="lblCategorias" For="ddlCategorias" runat="server" CssClass="nav-item form-label text-white" Text="Categorias"></asp:Label>

                        </div>
                        <div class="col-8">
                            <asp:DropDownList ID="ddlCategorias" CssClass="nav-item form-select" runat="server" OnSelectedIndexChanged="ddlCategorias_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

                        </div>

                    </div>
                    <div class="row nav-item m-1">
                        <div class="input-group">
                            <asp:TextBox ID="txtBuscar" AutoPostBack="true" runat="server" CssClass="form-control" placeholder="Buscar articulo" OnTextChanged="txtBuscar_TextChanged"></asp:TextBox>
                            <div class="input-group-text"><i class="bi bi-search"></i></div>
                        </div>

                    </div>

                    <div class="row nav-item m-1">
                        <div class="col col-form-label">
                            <asp:Label ID="lblORdenar" For="ddlOrdenar" runat="server" CssClass="nav-item form-label text-white ml-auto" Text="Ordenar por:"></asp:Label>
                        </div>
                        <div class="col">
                            <asp:DropDownList ID="ddlOrdenar" CssClass="nav-item form-select" runat="server" OnSelectedIndexChanged="ddlOrdenar_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                        <div class="col">
                            <asp:DropDownList ID="ddlCriterio" CssClass="nav-item form-select" runat="server" OnSelectedIndexChanged="ddlCriterio_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>


                </div>
            </nav>
            <div class="row justify-content-center">
                <div class="col-8">

                    <div class="mb-3 text-center" style="display: none">
                        <asp:Label ID="lblTop" runat="server" CssClass="display-3 " Text="Top 3 favoritos"></asp:Label>
                    </div>
                    <%--    Carrusel con repeater Top 3--%>
                    <div id="carouselExampleCaptions" class="carousel slide" data-bs-ride="carousel" style="display: none">
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
                                    <div class='<%# "carousel-item" + (Container.ItemIndex == 0 ? " active" : "")%>'>
                                        <img src='Images/<%# Eval("Imagen") %>' class="d-block w-50 mx-auto" alt="...">
                                        <div class="carousel-caption d-none d-md-block">
                                            <h5 class="text-dark"><%# Eval("Nombre") %></h5>
                                            <%--<p class="text-dark"><%# Eval("Descripcion") %></p>--%>
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
                    <%--Fin del carrusel Top 3--%>

                    <div class="mb-3 text-center">
                        <asp:Label ID="lblArticulos" runat="server" CssClass="display-4" Text="Todos los articulos"></asp:Label>

                    </div>

                    <div class="row row-cols-5 row-cols-md-5 g-4">
                        <asp:Repeater ID="repRepetidor" runat="server">

                            <ItemTemplate>
                                <div class="col">
                                    <div class="card h-100">
                                        <asp:LinkButton runat="server" ID="btnDetalles" CommandArgument='<%#Eval("Id")%>' CommandName="ArticuloId" OnClick="btnDetalles_Click">

                                            <img src="Images/<%#Eval("Imagen") %>" class="card-img-top" alt="...">
                                            <div class="card-body">
                                                <h6 class="card-title text-center"><%#Eval("Nombre")%></h6>
                                            </div>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>


                </div>

                <%--Inicio del toast--%>
                <div class="toast-container position-absolute top-50 start-50 translate-middle">
                    <div class="toast" id="miToast" role="alert" aria-live="assertive" aria-atomic="true">
                        <div class="toast-body">
                            <p id="txtMensaje"><%= (this.toast)%></p>
                        </div>
                    </div>
                </div>
                <%--Fin del toast--%>
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
    </script>
</asp:Content>
