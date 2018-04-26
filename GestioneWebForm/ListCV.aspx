<%@ Page Title="LISTA CV" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="ListCV.aspx.cs"
    Inherits="GestioneWebForm.listaCV" %>

    <%@ Register TagPrefix="CVL" TagName="Cur" Src="~/Controll/ListCurriculum.ascx" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Title %>.</h2>

    <CVL:Cur ID="ListaCVPg" runat="server" ></CVL:Cur>
</asp:Content>
