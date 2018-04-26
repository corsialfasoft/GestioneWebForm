<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GestioneWebForm._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
       body{
  background: url(https://goo.gl/NL6f0b) ;
  background-size: cover;
  background-position: top;
  font-family: 'Roboto'!important;
}
#content{
  text-align: center;
  padding: 25% 0 2% 0;
  margin: 1% 0;
  border-radius: 4px;
  background: rgba(255, 255, 255, .6);
  box-shadow: 0 2px 4px rgba(0,0,0, .2);
}

       .btn {   
           background-color:black;
            
           }

/*Responsive*/
@media (max-width: 840px) {
  a{margin-top: 10px;}
}
    </style>

    <div class="jumbotron">
        <h1>Corsi</h1>
        <p class="lead">Ricerca il corso più adatto alle tue esigenze all'interno del nostro elenco</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Vai a corsi &raquo;</a></p>
    </div>

    <div class="row">
        <div class="jumbotron" style="width:40%;float:left;border">
        <h1>GeTime</h1>
        <p class="lead">Ricerca il corso più adatto alle tue esigenze all'interno del nostro elenco</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Vai a GeTime &raquo;</a></p>
        </div>
        <div class="jumbotron" style="width:40%;float:left;">
        <h1>GeCv</h1>
        <p class="lead">Ricerca il corso più adatto alle tue esigenze all'interno del nostro elenco</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Vai a GeCv &raquo;</a></p>
    </div>

    </div>



</asp:Content>
