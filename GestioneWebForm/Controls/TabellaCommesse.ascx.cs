﻿using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestioneWebForm {
    public partial class TabellaCommesse : System.Web.UI.UserControl {
        public List<Commessa> ListaCommesse { get;set; }
        public bool VisualissaCommessa { set;get; }
        public bool AddGiorno { get;set; }
        protected void Page_Load(object sender, EventArgs e) {

        }
        public void Update() {
            TableRow row = new TableRow();
            row.Cells.Add(CreateCellLebel("#", 2));
            row.Cells.Add(CreateCellLebel("Nome Commessa", 5));
            TabCommesse.Rows.Add(row);
            int index = 1;
            foreach (Commessa com in ListaCommesse) {
                row = new TableRow();
                row.Cells.Add(CreateCellLebel($"{index++}", 2));
                row.Cells.Add(CreateCellLebel($"{com.Nome}", 5));
                TableCell col = new TableCell();
                if (VisualissaCommessa) {
                    col.Controls.Add(new Button() { Text ="Seleziona", CssClass = "col-xs-3 col-sm-3 col-md-3 col-lg-3",PostBackUrl= $"~/ViewCommessa?nome={com.Nome}"});
                }
                if (AddGiorno) {
                    col.Controls.Add(new Button() {
                        Text = "Seleziona", CssClass = "col-xs-3 col-sm-3 col-md-3 col-lg-3", PostBackUrl = $"~/AddCommessa?nome={com.Nome}"});
                }
                row.Cells.Add(col);
                TabCommesse.Rows.Add(row);
            }
        }
        private TableCell CreateCellLebel(string text, int lunghezza) {
            TableCell col = new TableCell();
            col.Controls.Add(new Label() { Text = text, CssClass = $"col-xs-{lunghezza} col-sm-{lunghezza} col-md-{lunghezza} col-lg-{lunghezza}" });
            return col;
        }
    }
}