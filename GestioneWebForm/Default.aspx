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

.fa{color: #03a9f4;}

hr{
  border: 2px dashed #03a9f4;
  border-bottom: 1px dashed rgba(3, 169, 244, 0.4);
}

h1{
  text-shadow: 0 4px 3px rgba(0,0,0, .4), 0 8px 13px rgba(0,0,0, .1), 0 18px 23px rgba(0,0,0, .1);
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



</asp:Content>
