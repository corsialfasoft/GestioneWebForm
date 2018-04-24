<%@ Control Language="C#"
    AutoEventWireup="true"
    CodeBehind="ListaLezioni.ascx.cs"
    Inherits="GestioneWebForm.Controls.ListaLezioni" %>

<%if(Lezioni != null && Lezioni.Count > 0) {%>
<div class="Table" style="margin-top: 40px;margin-bottom:40px">
    <asp:Table
        ID="LezioniList"
        runat="server"
        Width="100%"
        CellPadding="10"
        GridLines="None"
        HorizontalAlign="Center">
    </asp:Table>
</div>
<%} %>
