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
        <asp:Button OnClick="LezioniOn_Click" CssClass="btn btn-default" Text="Mostra lezioni" runat="server" />
         <asp:Button OnClick="AddLezione_Click" CssClass="btn btn-default" Text="Aggiungi Lezione" runat="server" />
        <hr />
        <%if(lezioni!=null){ %>
            <h3><b>Lezioni del corso <%=corso.Nome%></b></h3>
            <div class="row">
                <div class="col-md-3">
                    Nome
                </div>
                <div class="col-md-7">
                    Descrizione
                </div>
                <div class="col-md-2">
                    Durata
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
