<%@ Page 
    Title="Pagina Iniziale" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="MyPage.aspx.cs"
    Inherits="GestioneWebForm._MyPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <div class="container">
  <div class="jumbotron" style="background-image:url(http://static1.gamespot.com/uploads/screen_kubrick/1572/15725770/3125635-battlefield1_top_5_scout_tips_9616site.jpg);background-size: auto">
    <h1 style="color:white">Benvenuto </h1>      
    <p style="color:white">Clicca sul bottone per inserire,visualizzare o modificare il tuo curriculum</p>
  </div>    
</div>
    <div class="col md-4">
        <asp:Button runat="server" OnClick="Go_Click" Text="Clicca"/>
    </div>
</asp:Content>
