<%@ Page Title="Aggiungi Giorno" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddGiorno.aspx.cs" Inherits="GestioneWebForm.AddGiorno" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>Aggiungi Giorno</h3>
   
    <b>Data (*)</b> <br />
    <asp:TextBox runat="server" Text="gg/mm/aaaa" ID="data"></asp:TextBox> <br />
    <br />
    <b> Tipologia Ore</b> <br />
     <asp:ListBox id="listaore" 
           Rows="4"
           Width="200px"
           SelectionMode="Single" 
           runat="server">

         <asp:ListItem Selected="True">Ore di lavoro </asp:ListItem>
         <asp:ListItem>Ore di permesso </asp:ListItem>
         <asp:ListItem>Ore di ferie </asp:ListItem>
         <asp:ListItem>Ore di malattia </asp:ListItem>         
         </asp:ListBox> <br /> <br />

    <b>Nome Commessa</b> <br /> 
     <asp:TextBox runat="server" Placeholder="-- -- -- --" ID="nomecommmessa"></asp:TextBox>  <b> (Solo per ore di lavoro)</b>
    <br /> <br />
    <b>Numero Ore (*)</b> <br /> 
     <asp:TextBox runat="server" ID="numeroore"></asp:TextBox>
    <br /> <br />
    <asp:Button runat="server" OnClick="AggiungiGiorno_Click" Text="CaricaOre" />  <br />

    <i>(*) Campi obbligatori</i>



</asp:Content>
