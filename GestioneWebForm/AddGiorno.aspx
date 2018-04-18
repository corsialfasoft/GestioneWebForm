<%@ Page Title="Aggiungi Giorno" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddGiorno.aspx.cs" Inherits="GestioneWebForm.AddGiorno" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>Aggiungi Giorno</h3>
   
     <asp:ListBox id="ListBox1" 
           Rows="4"
           Width="100px"
           SelectionMode="Single" 
           runat="server">

         <asp:ListItem Selected="True">Ore di lavoro</asp:ListItem>
         <asp:ListItem>Ore di permesso</asp:ListItem>
         <asp:ListItem>Ore di ferie</asp:ListItem>
         <asp:ListItem>Ore di malattia</asp:ListItem>
         

      </asp:ListBox>

</asp:Content>
