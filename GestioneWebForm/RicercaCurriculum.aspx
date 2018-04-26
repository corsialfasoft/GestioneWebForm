<%@ Page 
    Title="Ricerca Curriculum" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="RicercaCurriculum.aspx.cs"
    Inherits="GestioneWebForm._RicercaCurriculum" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <%if(Message!=null){ %>
    <h4><%=Message %></h4>
    <%} %>
    <div class="row">
        <div class="col-md-4">
            <asp:Label runat="server">Parola chiava </asp:Label>
        </div>
        <div class="col-md-4">
            <asp:TextBox runat="server" placeholder="Inserisci la parola chiava" ID="Chiava"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <asp:Label runat="server">Eta</asp:Label>
        </div>
        <div class="col-md-4">
            <asp:TextBox runat="server" placeholder="Inserisci l'età" ID="Eta"></asp:TextBox>
        </div>         
    </div>
    <div class="row">
        <div class="col-md-4">
            <asp:Label runat="server">Eta Minima</asp:Label>
        </div>
         <div class="col-md-4">
            <asp:textbox runat="server" placeholder="Inserisci l'età minima" ID="EtaMin"></asp:textbox>
        </div>
        <div class="col-md-2">
            <asp:Label runat="server">Eta Massima</asp:Label>
        </div>
         <div class="col-md-2">
            <asp:textbox runat="server" placeholder="Inserisci l'età massima" ID="EtaMax"></asp:textbox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <asp:Label runat="server">Cognome</asp:Label>
        </div>
        <div class="col-md-4">
            <asp:TextBox runat="server" placeholder="Inserisci il cognome" ID="Cognome"></asp:TextBox>
        </div>
    </div>
    <asp:Button runat="server" OnClick="Cerca_Click" Text="Cerca"/>
</asp:Content>
