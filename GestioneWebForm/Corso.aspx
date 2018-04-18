<%@ Page Title="Corso" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Corso.aspx.cs" Inherits="GestioneWebForm._Corso" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%:Title %></h2>
     <div Class="text-warning">
        <%=Message%>
    </div>
    <div class="container">
       <div class="row">
            <div class="col-md-3">
               <b>Nome</b>
            </div>
            <div class="col-md-9">
                 <%=corso.Nome%>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
               <b>Descrizione</b>
            </div>
            <div class="col-md-9">
                 <%=corso.Descrizione%>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
               <b>Data Inizio</b>
            </div>
            <div class="col-md-9">
                 <%=corso.Inizio%>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
              <b>Data Fine</b>
            </div>
            <div class="col-md-9">
                 <%=corso.Fine%>
            </div>
        </div>
        <asp:Button OnClick="LezioniOn_Click" CssClass="btn btn-default" Text="Mostra lezioni" runat="server" />
         <asp:Button OnClick="AddLezione_Click" CssClass="btn btn-default" Text="Aggiungi Lezione" runat="server" />
        <hr />
        <%if(lezioni!=null){ %>
            <h3><b>Lezioni del corso <%=corso.Nome%></b></h3>
            <div class="row">
                <div class="col-md-3">
                   <h3> <b>Nome</b></h3>
                </div>
                <div class="col-md-7">
                    <h3><b>Descrizione</b></h3>
                </div>
                <div class="col-md-2">
                    <h3><b>Durata</b></h3>
                </div>
            </div>
            <%foreach(DAO.Lezione l in lezioni){%>
                <div class="row">
                    <div class="col-md-3">
                        <%=l.Nome%>
                    </div>
                    <div class="col-md-7">
                         <%=l.Descrizione%>
                    </div>
                    <div class="col-md-2">
                         <%=l.Durata%>
                    </div>
                </div>
            <%}%>
             <asp:Button OnClick="LezioniOff_Click" CssClass="btn btn-default" Text="Non mostrare" runat="server" />   
        <%}%>
    </div>
</asp:Content>
