<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="TPFinalNivel3OnoresMatias.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row justify-content-center">
        <div class="col-8 d-flex align-items-center" style="height: 80vh">
            <div class="card mb-3 col">
                <div class="row">
                    <div class="col">
                        <div class="card-body">
                            <h5 class="card-title text-center">¡Ocurrió un error!</h5>
                            <p id="txtError" runat="server" class="card-text"></p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
