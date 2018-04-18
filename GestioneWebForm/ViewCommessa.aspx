<%@ Page Title="ViewCommessa" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewCommessa.aspx.cs" Inherits="GestioneWebForm.ViewCommessa" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>In questa sezione è possibile visualizza i giorni dedicati ad una determinata Commessa</h3>
    <asp:Label runat="server">Codice</asp:Label>
    <asp:TextBox id="txt_Id" runat="server"></asp:TextBox>
    <asp:Label runat="server">Descrizione</asp:Label>
    <asp:TextBox id="txt_Descr" runat="server"></asp:TextBox>
    <asp:Button ID="Cerca" Text="CERCA" OnClick="Cerca_Click" runat="server"></asp:Button>
    <div class="table" style="margin-top:25px">
        <asp:Table ID="ListaCommesse" runat="server" width="100%" CellPadding="10" GridLines="None" HorizontalAlign="Center"></asp:Table>
    </div>
    <div class="table" style="margin-top:25px">
        <asp:Table ID="ListaOreCommessa" runat="server" width="100%" CellPadding="10" GridLines="None" HorizontalAlign="Center"></asp:Table>
    </div>
</asp:Content>
