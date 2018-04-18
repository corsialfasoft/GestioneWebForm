<%@ Page 
    Title="Ricerca il curriculum" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="RicercaCurriculum.aspx.cs"
    Inherits="GestioneWebForm._RicercaCurriculum" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
   <div class="row">
       <div class="col md 4"></div>
       <asp:Label runat="server">Codice</asp:Label>
       <div class="col md 4">
           <asp:TextBox runat="server" placeholder="inserisci il codice" ID="Codice">

           </asp:TextBox>
       </div>
   </div>
    <div class="row">
       <div class="col md 4"></div>
       <div class="col md 4"></div>
   </div>
    <div class="row">
       <div class="col md 3"></div>
       <div class="col md 3"></div>
       <div class="col md 3"></div>
       <div class="col md 3"></div>
   </div>
</asp:Content>
