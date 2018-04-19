using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestioneWebForm {
    public partial class listaCV : Page {
        List<CV> curriculums {get; set;}
        protected void Page_Load(object sender,EventArgs e) { 
            curriculums = (List<CV>)Session["listaCV"] ?? null;
            ListaCVPg.CV  = curriculums;
            ListaCVPg.Update();
        }
        protected void Monk_Click(object sender, EventArgs e) {
            IDomainModel model = new MockDomainModel();
            List<CV> monk = model.SearchByDescription("sa");
            Session["listaCV"] = monk;
        }

        public partial interface IDomainModel {
            List<CV> SearchByDescription(string description);
        }
        public partial class MockDomainModel : IDomainModel {
            public List<CV> SearchByDescription(string description) {
                return new List<CV>(){
                new CV(){Matricola="1",Nome="Goofy",Cognome="Pippo"},
                new CV(){Matricola="2",Nome="Donald",Cognome="Paperino"},
                new CV(){Matricola="3",Nome="Mickey",Cognome="Topolino"}
            };
            }
        }

    }
}