<%@ Page Title="Aggiungi Giorno"
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="AddGiorno.aspx.cs" 
    Inherits="GestioneWebForm._AddGiorno" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <br><br>
    <h4>Aggiorna i tuoi dati...</h4>
    <br><br>
    <div class="Conteiner">
        Data (*)          <input type="date" name="dateTime" required/>
        <br><br>
<%--        <form method="get">--%>
            Tipologia Ore (*)
            <input list="HType" name="tipoOre">
            <select id="HType">
                <option value="">Seòeziona tipo di ore
                <option value="Ore di lavoro">Ore di lavoro
                <option value="Ore di permesso">Ore di lavoro
                <option value="Ore di ferie">Ore di ferie
                <option value="Ore di malattia">Ore di malattia
            </select>
<%--        </form>--%>
        <br><br>
        Nome Commessa <input type="text" name="Commessa" placeholder=" - - - " /> (Solo per ore di lavoro)
        <br><br>
        Numero Ore:  (*)  <input type="number" name="ore" min=1 max=8>
        <br><br>
        <input type="submit" name="caricaOre" value="Carica Ore" />
        <br><br>
    </div>
</asp:Content>


<%--<h2>@ViewBag.Title:</h2>
<br><br>
<div>
    @using (Html.BeginForm("AddGiorno", "Home", FormMethod.Post)) {
    <div class="Conteiner">
        Data (*)          <input type="date" name="dateTime" />
        <br><br>
        <form method="get">
            Tipologia Ore (*)
            <input list="HType" name="tipoOre">
            <datalist id="HType">
                <option value="Ore di lavoro">
                <option value="Ore di permesso">
                <option value="Ore di ferie">
                <option value="Ore di malattia">
            </datalist>
        </form>
        <br><br>
        Nome Commessa <input type="text" name="Commessa" placeholder=" - - - " /> (Solo per ore di lavoro)
        <br><br>
        Numero Ore:  (*)  <input type="number" name="ore" min=1 max=8>
        <br><br>
        <input type="submit" name="caricaOre" value="Carica Ore" />
        <br><br>
    </div>
    }
</div>
<p>(*) Campi obligatori</p>
<br><br>
@if(ViewBag.GeCoDataTime != null){
    <p>@ViewBag.GeCoDataTime.ToString("yyyy-MM-dd")</p>}
    <p>@ViewBag.EsitoAddGiorno</p>
<br><br>--%>
