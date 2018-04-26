using GestioneWebForm;
using DAO;
using LibreriaDB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace DAO{
	public interface ITrasformer {
        Commessa TrasformInCommessa(SqlDataReader data);
        List<Commessa> TrasformInListaCommesse(SqlDataReader data);
        Giorno TrasformInGiorno(SqlDataReader reader);
        List<Giorno> TransfInGiorni(SqlDataReader data);
        List<Giorno> TrasformInGiorni(SqlDataReader data);
        DTGiornoDMese ConvertGiornoInDTGDMese(Giorno giorno);
    }
	public class Trasformator :ITrasformer{
        public Giorno TrasformInGiorno(SqlDataReader reader) {
            Giorno result = null;
            if (reader.Read()) {
                result = new Giorno(DateTime.Today);
                do {
                    switch (reader.GetInt32(0)) {
                        case 1:
                            result.HMalattia = reader.GetInt32(1);
                            break;
                        case 2:
                            result.HPermesso = reader.GetInt32(1);
                            break;
                        case 3:
                            result.HFerie = reader.GetInt32(1);
                            break;
                        case 4:
                            result.AddOreLavorative(new OreLavorative(reader.GetInt32(4), reader.GetInt32(1), reader.GetString(2), reader.GetString(3)));
                            break;
                    }
                } while (reader.Read());
            }
            return result; 
        }

        public List<Giorno> TrasformInGiorni(SqlDataReader data) {
           return DB.TrasformInList(data,TrasformInGiornoOreLavorative);
        }
        public Giorno TrasformInGiornoOreLavorative(SqlDataReader data) {
            Giorno giorno = null;
            if (data.Read()) {
                giorno = new Giorno(data.GetDateTime(1)) {
                    IdGiorno = data.GetInt32(0)
                };
                giorno.AddOreLavorative(new OreLavorative(data.GetInt32(3), data.GetInt32(2), data.GetString(4), data.GetString(5)));
            }
            return giorno;
        }

        public Commessa TrasformInCommessa(SqlDataReader data) {
            Commessa commessa = null;
            if (data.Read()) {
                commessa = new Commessa(data.GetInt32(0), data.GetString(1), data.GetString(2), data.GetValue(3)==DBNull.Value?0:data.GetInt32(3), data.GetInt32(4));
            }
            return commessa;
        }
        public List<Commessa> TrasformInListaCommesse(SqlDataReader data) {
            return DB.TrasformInList(data, TrasformInCommessa);
        }
        public List<Giorno> TransfInGiorni(SqlDataReader reader) {
            List<Giorno> giorni = new List<Giorno>();
            DateTime oldData = default(DateTime);
            Giorno result =null;
            while (reader.Read()) {
                DateTime data= reader.GetDateTime(2);//data indice
                if (data != oldData) {
                    result = new Giorno(data);
                    oldData= data;
                    giorni.Add(result);
                }
                switch (reader.GetInt32(0)) {
                    case 1:
                        result.HMalattia = reader.GetInt32(1);
                        break;
                    case 2:
                        result.HPermesso = reader.GetInt32(1);
                        break;
                    case 3:
                        result.HFerie = reader.GetInt32(1);
                        break;
                    case 4:
                        result.TotOreLavorate = reader.GetInt32(1);
                        break;
                }
            }
            return giorni;
        }
        public DTGiornoDMese ConvertGiornoInDTGDMese(Giorno giorno) {
            return new DTGiornoDMese {
                data = giorno.Data, OreFerie = giorno.HFerie, OreMalattia = giorno.HMalattia,
                OrePermesso = giorno.HPermesso, TotOreLavorate = giorno.TotOreLavorate
            };
        }
    }
    public class DTGiorno {
        public DateTime Data { get; set; }
        public int OreLavorate { get; set; }
    }
    public class DTCommessa {
        public int Id { get; set; }
        public string Descrizione { get; set; }
        public string Nome { get; set; }
        public int Capienza { get; set; }
        public int OreLavorate { get; set; }
        public DTCommessa(int id, string nome, string descrizione, int capienza, int oreLavorate) {
            Id = id;
            OreLavorate = oreLavorate;
            Nome = nome;
            Descrizione = descrizione;
            Capienza = capienza;
        }
    }
    public class DTGGiorno {
        public DateTime data { get; set; }
        public int TotOreLavorate { get; set; }
        public int OrePermesso { get; set; }
        public int OreMalattia { get; set; }
        public int OreFerie { get; set; }
        public DTGGiorno() { }
        private List<OreLavorate> OreLavorates = new List<OreLavorate>();
        public List<OreLavorate> OreLavorate { get { return OreLavorates; } }
    }
    public class OreLavorate {
        public string nome { get; set; }
        public int oreGiorno { get; set; }
        public string descrizione { get; set; }
    }
    public class DTGiornoDMese {
        public DateTime data { get; set; }
        public int TotOreLavorate { get; set; }
        public int OrePermesso { get; set; }
        public int OreMalattia { get; set; }
        public int OreFerie { get; set; }
        public override bool Equals(object obj) {
            return data.Equals(((DTGiornoDMese)obj).data);
        }
    }
}	