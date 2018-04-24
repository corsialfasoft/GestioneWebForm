<%@ Control Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="ListaLezioni.ascx.cs" 
    Inherits="GestioneWebForm.Controls.ListaLezioni" %>

<%if(Lezioni!=null && Lezioni.Count>0) {%>
<asp:Table
    id="LezioniList"
    runat="server"
    width="100%"
    CellPadding="10"
    GridLines="None"
    HorizontalAlign="Center"
    >

</asp:Table>
<%} %>
