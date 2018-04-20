using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;

namespace GestioneWebForm {
    public partial class _PerStud : Page{ 
        DataAccesObject dao = new DataAccesObject();
        public List<PerStud> percorsi{get;set;}
        protected void Page_Load(object sender,EventArgs e) {
            percorsi = dao.Listpercorsi
        }

		protected void Go_Click(object sender,EventArgs e)
		{
		}
	}
}