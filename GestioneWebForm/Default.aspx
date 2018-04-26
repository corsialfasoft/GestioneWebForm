<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GestioneWebForm._Default" %>

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
    
body {
	width: 100%;
	height: 90vh;
	color: #fff;
	background: linear-gradient(-45deg, #6dedbe, #295c84, #d87b1e, #f27b04);
	background-size: 400% 400%;
	-webkit-animation: Gradient 12s ease infinite;
	-moz-animation: Gradient 12s ease infinite;
	animation: Gradient 12s ease infinite;
}

@-webkit-keyframes Gradient {
	0% {
		background-position: 0% 50%
	}
	50% {
		background-position: 100% 50%
	}
	100% {
		background-position: 0% 50%
	}
}

@-moz-keyframes Gradient {
	0% {
		background-position: 0% 50%
	}
	50% {
		background-position: 100% 50%
	}
	100% {
		background-position: 0% 50%
	}
}

@keyframes Gradient {
	0% {
		background-position: 0% 50%
	}
	50% {
		background-position: 100% 50%
	}
	100% {
		background-position: 0% 50%
	}
}


        
    </style>
    
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Open+Sans:300" type="text/css" />

    <div class="jumbotron" style="background:url(Content/Image/Corso.jpg); background-repeat: no-repeat;background-attachment: fixed;border-radius:10px 10px;">
        <h1 style="color: black;">Corsi</h1>
        
        <p ><a href="/Home/ElencoCorsi" class="btn btn-primary btn-lg">Vai a corsi &raquo;</a></p>
    </div>

    <div class="row">
        <div class="jumbotron" style="width:45%;float:left;background:none;background-attachment: fixed;margin-right:5px;">
            <h1 style="color:black;">GeTime</h1>
            <p class="lead">GeTime si occupa della gestione delle ore lavorative</p>
            <p><a href="/Home/GeTimeHome" class="btn btn-primary btn-lg">Vai a GeTime &raquo;</a></p>
        </div>
        <div class="jumbotron" style="width:45%;float:left;background:none;background-attachment: fixed;">
            <h1 style="color: black;">GeCv</h1>
            <p class="lead">GeCv si occupa della gestione e modifica del proprio curriculum.</p>
            <p><a href="/Home/MyPage" class="btn btn-primary btn-lg">Vai a GeCv &raquo;</a></p>            

        </div>
    </div>





</asp:Content>
