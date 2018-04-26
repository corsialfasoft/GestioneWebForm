<%@ Control Language="C#"
    AutoEventWireup="true"
    CodeBehind="ListaCorsi.ascx.cs"
    Inherits="GestioneWebForm.Controls._ListaCorsi" %>


<%if(Corsi != null && Corsi.Count>0){%>
<hr />
<div class="row">
    <div class="col-md-2">
        <h3><b>Codice</b></h3>
    </div>
    <div class="col-md-6">
        <h3><b>Descrizone</b></h3>
    </div>
    <div class="col-md-4">
        <h3><b>Dettagli</b></h3>
    </div>
</div>
<asp:Table id="CorsiTable"
        width="100%"
        CellPadding="10"
        GridLines="None"
        HorizontalAlign="Center"
        Runat="server"/>
<%}%>
