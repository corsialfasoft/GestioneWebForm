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
    <div>
        <%=Message%>
    </div>
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
    <%if(HaveCv) {%>
        <asp:Button ID="modAnag" OnClick="modAnag_Click" Text="Modifica" runat="server"/>
    <%}else{ %>
        <asp:Button ID="AddCV" OnClick="AddCV_Click" Text="Aggiungi Curriculum" runat="server" />
    <%} %>
    <hr  style="color:black; border-width:3px;"/>
    <br />
    <div class="row">
        <div class="col-md-2">
            <label>Percorso Studi</label> <br />
        </div>
        <div class="col-md-2">
            <asp:Button runat="server" ID="btn_AddPerStudi" OnClick="btn_AddPerStudi_Click"  Text="Aggiungi" />
        </div>
    </div>
    <hr style="color:black; border-width:3px;" >
    <div class="row"  >
        <asp:Table ID="TablePerStudi" class="table" CellPadding="10"  Width="100%" runat="server">

        </asp:Table>
    </div>
    <hr style="color:black; border-width:5px;" />
    
     <div class="row">
        <div class="col-md-2">
            <label>Esperienze Lavorative</label> <br />
        </div>
        <div class="col-md-2">
            <asp:Button runat="server" ID="btn_AddEspLav" OnClick="btn_AddEspLav_Click" Text="Aggiungi" />
        </div>
    </div>
     <hr style="color:black; border-width:5px;">
    <div class="row">
        <asp:Table ID="TableEspLav"  class="table" CellPadding="10" GridLines="None" Width="100%"  runat="server" ></asp:Table>
    </div>
    <hr  style="color:black; border-width:5px;"/>
    <div class="row">
        <div class="col-md-2">
            <label>Tabella Competenze</label> <br />
        </div>
        <div class="col-md-2">
            <asp:Button ID="btn_AddComp" Text="Aggiungi"  OnClick="btn_AddComp_Click" runat="server" />
        </div>
    </div>
    <hr style="color:black; border-width:5px;">
    <div class="row">
        <asp:Table ID="TableComp"  class="table" CellPadding="10" Width="100%" GridLines="None"  runat="server" ></asp:Table>
    </div>
    <br />
</asp:Content>


