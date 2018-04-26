<%@ Page Title="Aggiungi un giorno" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddGiorno.aspx.cs" Inherits="GestioneWebForm._AddGiorno" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <h2><%: Title %></h2>
    <br />
<script type="text/javascript">
    function changeHTyp(value) {
        if (value == 'Ore di permesso' || value == 'Ore di malattia') {
            // document.getElementById('commesse').hidden = true;
            document.getElementById('MainContent_commesse').disabled = true;
            document.getElementById('MainContent_ore').value = "";
            document.getElementById('MainContent_ore').disabled = false;
        }
        if (value == 'Ore di ferie') {
            document.getElementById('MainContent_ore').value = 8;
            document.getElementById('MainContent_ore').disabled = true;
            document.getElementById('MainContent_commesse').disabled = true;
        }
        if (value == 'Ore di lavoro' || value == '') {
            document.getElementById('MainContent_commesse').disabled = false;
            document.getElementById('MainContent_ore').value = "";
            document.getElementById('MainContent_ore').disabled = false;
        }
    }
</script>
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
            <asp:Calendar runat="server" ID="oggi"    ></asp:Calendar>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-2">
            Tipo di orario
        </div>
        <div class="col-md-1">
                  <asp:DropDownList ID="tipoOre" runat="server">
                  <asp:ListItem Selected="True" Value="White"> White </asp:ListItem>
                  <asp:ListItem Value="Ore di lavoro"> Lavoro </asp:ListItem>
                  <asp:ListItem Value="Ore di permesso" > Permesso </asp:ListItem>
                  <asp:ListItem Value="Ore di ferie"> Ferie </asp:ListItem>
                  <asp:ListItem Value="Ore di malattia"> Malattia </asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-2">
            Commessa
        </div>
        <div class="col-md-1">
            <asp:TextBox runat="server" id="commesse" ></asp:TextBox>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-2">
            Ore
        </div>
        <div class="col-md-1">
            <asp:TextBox runat="server" id="ore" TextMode="Number" ></asp:TextBox>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-2">
            <asp:Button  runat="server" ID="Aggiungi" OnClick="Aggiungi_Click" Text="Aggiungi"  ></asp:Button>
        </div>
    </div>
    
    
</asp:Content>