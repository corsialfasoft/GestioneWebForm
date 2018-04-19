<%@ Page Title="Aggiungi Corso"
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="AggiungiCorso.aspx.cs" 
    Inherits="GestioneWebForm._AggiungiCorso" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="text-warning">
        <%=Message %>
    </div>
<div class="container">
    <br />
    <div class="row">
        <div class="col-sm-4">
            <asp:Label runat="server">Nome</asp:Label>
        </div>
        <div class="col-sm-8">
            <asp:TextBox runat="server" ID="nome"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="text-danger h4" ControlToValidate ="nome" ErrorMessage=" * " runat="server"/>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-sm-4">
            <asp:Label runat="server">Data inizio</asp:Label>
        </div>
        <div class="col-sm-8">
            <asp:TextBox runat="server" ID="inizio"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="text-danger h4" ControlToValidate ="inizio" ErrorMessage=" * " runat="server"/>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-sm-4">
            <asp:Label runat="server">Data fine</asp:Label>
        </div>
        <div class="col-sm-8">
            <asp:TextBox runat="server" ID="fine"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="text-danger h4" ControlToValidate ="fine" ErrorMessage=" * " runat="server"/>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-sm-4">
            <asp:Label runat="server">Descrizione</asp:Label>
        </div>
        <div class="col-sm-8">
            <asp:TextBox runat="server" ID="descrizione"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="text-danger h4" ControlToValidate ="descrizione" ErrorMessage=" * " runat="server"/>
        </div>
    </div>
</div>
    <br />
    <div class="row">
        <asp:Button runat="server" OnClick="Crea_Click" class="btn btn-primary" Text="Crea" />
        <asp:Button runat="server" PostBackUrl="~/AggiungiCorso.aspx" class="btn btn-default" Text="ANNULLA" />
    </div>
</asp:Content>