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
                <asp:TextBox  ID="NomeTextBox"  runat="server"></asp:TextBox>
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
                    <asp:TextBox ID="EtaTextBox" runat="server"></asp:TextBox>
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
    <br />
    <br />

    <label>Tabella Studi</label> <br />
    <div class="row">
        <asp:Table ID="TablePerStudi"  CellPadding="10" Width="100%"  runat="server" >

        </asp:Table>
    </div>
    <br />
    <label>Tabella Esperienze lavorative</label> <br />
    <div class="row">
        <asp:Table ID="TableEspLav"  CellPadding="10" Width="100%"  runat="server" >

        </asp:Table>
    </div>
    <br />

    <label>Tabella Competenze</label> <br />
    <div class="row">
        <asp:Table ID="TableComp" CellPadding="10" Width="100%"  runat="server" >
         
        </asp:Table>
    </div>
    <br />
</asp:Content>


