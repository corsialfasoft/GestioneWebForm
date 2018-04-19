using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
namespace GestioneWebForm {
    public partial class AddGiorno : Page {
        protected void Page_Load(object sender,EventArgs e) {

        }

		protected void AggiungiGiorno_Click(object sender,EventArgs e)
		{
			DataAccesObject DataAccess = new DataAccesObject();
			switch(listaore.SelectedIndex) {
			case 1: 
						
				DataAccess.Compila(DateTime.Parse(data.Text),Int32.Parse(numeroore.Text),(HType)1,Int32.Parse(Request["idUtente"]));	
			break;
			case 2:
			     DataAccess.Compila(DateTime.Parse(data.Text),Int32.Parse(numeroore.Text),(HType)2,Int32.Parse(Request["idUtente"]));		
			break;
			case 3:
				DataAccess.Compila(DateTime.Parse(data.Text),Int32.Parse(numeroore.Text),(HType)3,Int32.Parse(Request["idUtente"]));	
			
			break;
			case 4:
				DataAccess.CompilaHLavoro(DateTime.Parse(data.Text),Int32.Parse(numeroore.Text),Int32.Parse(nomecommmessa.Text),Int32.Parse(Request["idUtente"]));		
			
			break;
			}


		}
    }
}