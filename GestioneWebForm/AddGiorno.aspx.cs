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
			DataAccess.CompilaHLavoro(DateTime.Parse(data.Text),Int32.Parse(numeroore.Text),Int32.Parse(nomecommmessa.Text),Int32.Parse(Request["idUtente"]));
			switch(listaore.SelectedIndex) {
			case 1: 
			
			
			break;
			case 2:

			break;
			case 3:

			break;
			case 4:

			break;
			}


		}
    }
}