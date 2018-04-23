<%@ Page 
    Title="Esperienze Lavorative" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="EspLav.aspx.cs"
    Inherits="GestioneWebForm._EspLav" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%:Title %></h2>
    <div class="container">
    <%if(esperienza !=null){%>
        <div class ="row">
            <div class="col-md-3">
                Qualifica
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="qualifica" runat="server" Text=""></asp:TextBox>
            </div>
            <div class="col-md-3">
                Descrizione
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="descrizioneEl" runat="server"></asp:TextBox>
            </div>
        </div> 
        <div class ="row">
            <div class="col-md-3">
                Anno Inizio
            </div>
            <div class="col-md-3">
                <asp:TextBox TextMode="Number" ID="annoIEl" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-3">
                Anno Fine
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="annoFEl" TextMode="Number" runat="server"></asp:TextBox>
            </div>
        </div> 

        <asp:Button runat="server" OnClick="Modifica_Click" Text="Modifica"/>
    <%}%>
    </div>
    <br />
</asp:Content>
