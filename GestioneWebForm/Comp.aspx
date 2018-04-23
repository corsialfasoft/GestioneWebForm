<%@ Page 
    Title="Esperienze Lavorative" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Comp.aspx.cs"
    Inherits="GestioneWebForm._Comp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%:Title %></h2>
    <div class="container">
    <%if(compe !=null){%>
        <div class ="row">
            <div class="col-md-3">
               Titolo
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="titolo" runat="server" Text=""></asp:TextBox>
            </div>
            <div class="col-md-3">
                Livello
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="livello" runat="server"></asp:TextBox>
            </div>
        </div> 

        <asp:Button runat="server" OnClick="Modifica_Click" Text="Modifica"/>
    <%}%>
    </div>
    <br />
</asp:Content>
