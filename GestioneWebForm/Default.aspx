﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GestioneWebForm._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
       body{
  background: url(https://goo.gl/NL6f0b) ;
  background-size: cover;
  background-position: top;
  font-family: 'Roboto'!important;
}

       .btn-primary,
.btn-primary:hover,
.btn-primary:active,
.btn-primary:visited,
.btn-primary:focus {
    background-color: black;
    border-color: black;
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

@media (max-width: 840px) {
  a{margin-top: 10px;}
}

        
    </style>
    


    <div class="jumbotron" style="background:url(Content/Image/Corso.jpg); background-repeat: no-repeat;background-attachment: fixed;border-radius:10px;">
        <h1 style="color: #f7ca43;">Corsi</h1>
        <p class="lead">Ricerca il corso più adatto alle tue esigenze all'interno del nostro elenco</p>
        <p ><a href="http://www.asp.net" class="btn btn-primary btn-lg">Vai a corsi &raquo;</a></p>
    </div>

    <div class="row">
        <div class="jumbotron" style="width:45%;float:left;background:none;background-attachment: fixed;margin-right:5px;">
            <h1 style="color: #f7ca43;">GeTime</h1>
            <p class="lead">GeTime si occupa della gestione delle ore lavorative</p>
            <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Vai a GeTime &raquo;</a></p>
        </div>
        <div class="jumbotron" style="width:45%;float:left;background:none;background-attachment: fixed;">
            <h1 style="color: #f7ca43;">GeCv</h1>
            <p class="lead">GeCv si occupa della gestione e modifica del proprio curriculum.</p>
            <p><a href="/Home/GeTimeHome" class="btn btn-primary btn-lg">Vai a GeCv &raquo;</a></p>            

        </div>



    </div>





</asp:Content>
