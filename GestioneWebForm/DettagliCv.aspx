<%@ Page Language="C#" 
    AutoEventWireup="true"
    MasterPageFile="~/Site.Master"
    CodeBehind="DettagliCv.aspx.cs"
    Inherits="GestioneWebForm.DettagliCv"
    %>






<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<style>
    .btnM{
       text-align:center;
    }

    .row {
      border-style:none
    
    }

</style>
    <div class="container" id="divCVContainer">
         <div class="row">
             <br />
            <div class="col-md-1">
                <label>Nome:</label>
            </div>
            <div class="col-md-3">
                <asp:TextBox  ID="NomeTextBox"   runat="server"></asp:TextBox>
            </div>
             <div class="col-md-1">
                 <label>Cognome:</label>
             </div> 
             <div class="col-md-3">
                 <asp:TextBox ID="CognomeTextBox" runat="server"></asp:TextBox>
            </div> 
         </div> <br />
         <div class="row">
             <div class="col-md-1">
                 <label>Età:</label>
              </div>
              <div class="col-md-3">
                    <asp:TextBox ID="EtaTextBox" TextMode="Number" runat="server"></asp:TextBox>
                </div>
             <div class="col-md-1">
                 <label>Residenza:</label>
             </div> 
              <div class="col-md-3">
                 <asp:TextBox ID="ResidenzaTextBox" runat="server"></asp:TextBox>
              </div>
         </div> <br />
          
         <div class="row">
              <div class="col-md-1">
                 <label>Email:</label>
              </div>
              <div class="col-md-3">
                <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
                </div>
             <div class="col-md-1">
                 <label>Telefono:</label>
             </div>
              <div class="col-md-3">
                <asp:TextBox ID="TelefonoTextBox" runat="server"></asp:TextBox>
              </div>
         </div>
    </div>
    <asp:Button ID="modAnag" OnClick="modAnag_Click" Text="Modifica" runat="server"/>

    <br />
    <br />
    <div>
        <label>Tabella Studi</label> <br />
        <asp:Button runat="server" ID="btn_AddPerStudi" OnClick="btn_AddPerStudi_Click"  Text="Aggiungi Percorso" />
    </div>
    <div class="row">
       <%-- <Asp:Button ID="btnPerStud" OnClick="btnPerStud_Click" runat="server" Text="Percorso Studi" />
        <Asp:Button ID="btnEspLav" OnClick="btnEspLav_Click" runat="server" Text="Esperienze Lvaorative" />
        <Asp:Button ID="btnComp" OnClick="btnComp_Click" runat="server" Text="Competenze" />--%>
        <asp:Table ID="TablePerStudi" CellPadding="10" Width="100%"  runat="server" >

        </asp:Table>
    </div>
    <br />
     <div>
        <label>Tabella Esperienze lavorative</label> <br />
         <asp:Button runat="server" ID="btn_AddEspLav" OnClick="btn_AddEspLav_Click" Text="Aggiungi EspLav" />
     </div>
    <div class="row">
        <asp:Table ID="TableEspLav"  CellPadding="10" Width="100%"  runat="server" >

        </asp:Table>
    </div>
    <br />
    <div>
        <label>Tabella Competenze</label> <br />
        <asp:Button ID="btn_AddComp" OnClick="btn_AddComp_Click" runat="server" />
    </div>
    <div class="row">
        <asp:Table ID="TableComp" CellPadding="10" Width="100%"  runat="server" >
         
        </asp:Table>
    </div>
    <br />
</asp:Content>


