<%@ Page Title="Aggiungi un giorno" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddGiorno.aspx.cs" Inherits="GestioneWebForm._AddGiorno" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <script type="text/javascript">
        function changeHTyp(value) {
        if (value == 'Ore di permesso' || value == 'Ore di malattia') {
            // document.getElementById('commesse').hidden = true;
            document.getElementById('commesse').disabled = true;
            document.getElementById('ore').value = "";
            document.getElementById('ore').disabled = false;
        }
        if (value == 'Ore di ferie') {
            document.getElementById('ore').value = 8;
            document.getElementById('ore').disabled = true;
            document.getElementById('commesse').disabled = true;
        }
        if (value == 'Ore di lavoro') {
            document.getElementById('commesse').disabled = false;
            document.getElementById('ore').value = "";
            document.getElementById('ore').disabled = false;
        }
    }</script>
    <h2><%: Title %></h2>
    <br />
    <div class="text-warning" style="font-size:large">
        <%=Message %>
        <br />
    </div>
    <br />
    <div class="row">
        <div class="col-md-2">
            Seleziona una data
        </div>
        <div class="col-md-1">
            <asp:Calendar runat="server" ID="data" OnSelectionChanged="SelezionaGiorno" OnLoad="SelezionaGiorno"></asp:Calendar>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-2">
            Tipo di orario
        </div>
        <div class="col-md-1">
            <select id="HType" name="tipoOre" onChange = "javascript:changeHTyp(this.value);">
                        <option value="Seleziona tipo Ore" />Seleziona tipo Ore
                        <option value="Ore di lavoro" />Ore di lavoro
                        <option value="Ore di permesso" />Ore di permesso
                        <option value="Ore di ferie" />Ore di ferie
                        <option value="Ore di malattia" />Ore di malattia
             </select>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-2">
            Commessa
        </div>
        <div class="col-md-1">
            <asp:TextBox runat="server" ID="commessa" ></asp:TextBox>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-2">
            Ore
        </div>
        <div class="col-md-1">
            <asp:TextBox runat="server" ID="ore" TextMode="Number" ></asp:TextBox>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-2">
            <asp:Button  runat="server" ID="Aggiungi" OnClick="Aggiungi_Click" Text="Aggiungi"  ></asp:Button>
        </div>
    </div>
    
    
</asp:Content>