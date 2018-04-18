<%@ Page Language="C#" 
    AutoEventWireup="true"
    MasterPageFile="~/Site.Master"
    CodeBehind="DettagliCv.aspx.cs"
    Inherits="GestioneWebForm.DettagliCv"
    %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" id="divCVContainer">
        <label>Nome:</label>
        <asp:TextBox  ID="NomeTextBox"  runat="server"></asp:TextBox>
        <label>Cognome:</label>
        <asp:TextBox ID="CognomeTextBox" runat="server"></asp:TextBox>
        <br />
        <label>Età:</label>
        <asp:TextBox ID="EtaTextBox" runat="server"></asp:TextBox>
        <label>Residenza:</label>
        <asp:TextBox ID="ResidenzaTextBox" runat="server"></asp:TextBox>
        <br />
        <label>Email:</label>
        <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
        <label>Telefono:</label>
        <asp:TextBox ID="TelefonoTextBox" runat="server"></asp:TextBox>
    </div>
    <div class="Table">
        <asp:Table ID="TablePerStudi" CellPadding="10" Width="100%" GridLines="Both" runat="server" HorizontalAlign="Center">

        </asp:Table>
    </div>
    <div class="Table">
        <asp:Table ID="TableEspLav" CellPadding="10" Width="100%" GridLines="Both" runat="server" HorizontalAlign="Center">

        </asp:Table>
    </div>
    <div class="Table">
        <asp:Table ID="TableComp" CellPadding="10" Width="100%" GridLines="Both" runat="server" HorizontalAlign="Center">

        </asp:Table>
    </div>
</asp:Content>
