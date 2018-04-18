<%@ Page Title="Corso" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Corso.aspx.cs" Inherits="GestioneWebForm._Corso" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%:Title %></h2>
     <div Class="text-warning">
        <%=Message%>
    </div>
    <div class="container">
       <div class="row">
            <div class="col-md-3">
               Nome   
            </div>
            <div class="col-md-9">
                 <%=corso.Nome%>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
               Descrizione  
            </div>
            <div class="col-md-9">
                 <%=corso.Descrizione%>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
               Data Inizio  
            </div>
            <div class="col-md-9">
                 <%=corso.Inizio%>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
               Data Fine  
            </div>
            <div class="col-md-9">
                 <%=corso.Fine%>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
               <asp:Button OnClick="Lezioni_Click" CssClass="btn btn-default" Text="Lezioni" runat="server" />
            </div>
        </div>
        <hr />
        <%foreach(DAO.Lezione l in corso.Lezioni){%>
            
        <%}%>
    </div>
</asp:Content>
