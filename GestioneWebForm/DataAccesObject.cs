using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using LibreriaDB;
using DAO;

namespace DAO{
	public interface IDao{
		void ModificaCV(CV a, CV b); //modifica un curriculum nel db
		void AggiungiCV(CV a); //quando sei loggato, puoi aggiungere un curriculum nel db
		void CaricaCV(string path); //quando non sei loggato, puoi spedire un curriuculum
		CV Search(string id); //search di un curriculum per id di un curriculum
		List<CV> SearchChiava(string chiava); //search generale per parole chiava 
		List<CV> SearchEta(int eta); //search solo per quella precisa età
		List<CV> SearchRange(int etmin, int etmax); //search per un range di età minimo e massimo
		void EliminaCV(CV curriculum); //Elimina un CV dal db
		List<CV> SearchCognome(string cognome); //Ricerca solo per cognome
        void AddCvStudi(string MatrCv,PerStud studi);
        void AddEspLav(string MatrCv, EspLav esp );
        void AddCompetenze(string MatrCv, Competenza comp);
        void CompilaHLavoro(DateTime data, int ore, int idCommessa, string idUtente);
        void Compila(DateTime data, int ore, HType tipoOre, string idUtente);
        Giorno VisualizzaGiorno(DateTime data, string idUtente);
        List<Giorno> GiorniCommessa(int idCommessa, string idUtente);
        List<Commessa> CercaCommesse(string nomeCommessa);
        Commessa CercaCommessa(string nomeCommessa);


         List<GiornoMese> VisualizzaMese(int anno, int mese, string idUtente);
		
        //Aggiungi nuovo corso. Lo puo fare solo l'admin
        void AddCorso(Corso corso);
        //Aggiungi una lezione a un determinato corso. Lo puo fare solo il prof
        void AddLezione(int idCorso, Lezione lezione);
        //Iscrizione di uno studente a un determinato corso. Lo puo fare solo lo studente specifico
        void Iscriviti (int idCorso, int idStudente);

        //Cerca un determinato corso 
        Corso SearchCorsi(int idCorso);
        //Cerca tutti i corsi che contine la "descrizione" nei suoi attributi(nome,descrizione)
        List<Corso> SearchCorsi(string descrizione);
        //Cerca tutti i corsi che contiene la "descrizione" di un determinato studente(idStudente)
        List<Corso>SearchCorsi(string descrizione, int idUtente);
        //Mostra tutti i corsi presenti nel db
        List<Corso>ListaCorsi();
        //Mostra tutti i corsi a cui è iscritto un determinato studente(idStudente)
        List<Corso>ListaCorsi(int idUtente);
    }
	public enum HType { HMalattia = 1, HPermesso, HFerie }
    public partial class DataAccesObject : IDao {
        //GeCv
        public void AddCompetenze(string MatrCv,Competenza comp) {
            throw new NotImplementedException();
        }
        public void AddCvStudi(string MatrCv,PerStud studi) {
            throw new NotImplementedException();
        }
        public void AddEspLav(string MatrCv,EspLav esp) {
            throw new NotImplementedException();
        }
        public void AggiungiCV(CV a) {
            throw new NotImplementedException();
        }
        public void CaricaCV(string path) {
            throw new NotImplementedException();
        }
        public void EliminaCV(CV curriculum) {
            throw new NotImplementedException();
        }
        public void ModificaCV(CV a,CV b) {
            throw new NotImplementedException();
        }
        public CV Search(string id) {
            List<EspLav> esplav = new List<EspLav>{new EspLav{ AnnoInizio=2012, AnnoFine=2016, Descrizione="Binzinaro",Qualifica="Ciavevo le pompe di benzina"} };
			List<Competenza> competenzas = new List<Competenza> {new Competenza{Livello=2,Titolo="Alto Mago"} };
			List<PerStud> perStuds=new List<PerStud> {new PerStud{AnnoInizio=2000,AnnoFine=2005,Descrizione="Media",Titolo="Licenza media" } };
			return new CV {Nome="Pino",Cognome="Panino",Eta=78,Email="paxxerellotunztunz@netlog.com",Matricola="E9412E",Residenza="Sotto il ponte della tangenziale",Telefono="800900313",Esperienze=esplav,Competenze=competenzas,Percorsostudi=perStuds };
			;
        }
        public List<CV> SearchChiava(string chiava) {
            throw new NotImplementedException();
        }
        public List<CV> SearchCognome(string cognome) {
            throw new NotImplementedException();
        }
        public List<CV> SearchEta(int eta) {
            throw new NotImplementedException();
        }
        public List<CV> SearchRange(int etmin,int etmax) {
            throw new NotImplementedException();
        }
        
        //GeCorso
        public void AddCorso(Corso corso) {
            throw new NotImplementedException();
        }
        public void AddLezione(int idCorso,Lezione lezione) {
            throw new NotImplementedException();
        }
        public void Iscriviti(int idCorso,int idStudente) {
            throw new NotImplementedException();
        }
        public List<Corso> ListaCorsi() {
            throw new NotImplementedException();
        }
        public List<Corso> ListaCorsi(int idUtente) {
            throw new NotImplementedException();
        }
        public Corso SearchCorsi(int idCorso) {
            throw new NotImplementedException();
        }
        public List<Corso> SearchCorsi(string descrizione) {
            throw new NotImplementedException();
        }
        public List<Corso> SearchCorsi(string descrizione,int idUtente) {
            throw new NotImplementedException();
        }

        //GeTime
        ITrasformer transf = new Trasformator();
        //GeTime 
        public List<Commessa> CercaCommesse(string nomeCommessa) {
            try {
                SqlParameter[] parameter = {
                    new SqlParameter("@nomeCommessa", nomeCommessa)
                };
                return DB.ExecQProcedureReader("SP_CercaCommesse", transf.TrasformInListaCommesse, parameter, "GeTime");
            } catch (SqlException) {
                throw new Exception("Errore server!");
            } catch (Exception e) {
                throw e;
            }
        }
        public void Compila(DateTime data, int ore, HType tipoOre, string idUtente) {
            try {
                SqlParameter[] parameters = {
                    new SqlParameter("@giorno",data.ToString("yyyy-MM-dd")),
                    new SqlParameter("@idUtente",idUtente),
                    new SqlParameter("@ore", ore),
                    new SqlParameter("@TipoOre", (int)tipoOre)
                    };
                DB.ExecNonQProcedure("SP_Compila", parameters, "GeTime");
            } catch (SqlException) {
                throw new Exception("Errore server!");
            } catch (Exception e) {
                throw e;
            }
        }
        public void CompilaHLavoro(DateTime data, int ore, int idCommessa, string idUtente) {
            try {
                SqlParameter[] parameters = {
                    new SqlParameter("@data",data.ToString("yyyy-MM-dd")),
                    new SqlParameter("@ore", ore),
                    new SqlParameter("@idCommessa",idCommessa),
                    new SqlParameter("@idUtente", idUtente)
                    };
                DB.ExecNonQProcedure("SP_AddHLavoro", parameters, "GeTime");
            } catch (SqlException) {
                throw new Exception("Errore server!");
            } catch (Exception e) {
                throw e;
            }
        }
        public Giorno VisualizzaGiorno(DateTime data, string idUtente) {
            try {
                SqlParameter[] parameter = {
                    new SqlParameter("@Data", data.ToString("yyyy-MM-dd")),
                    new SqlParameter("@IdUtente", idUtente)
                };
                Giorno result = DB.ExecQProcedureReader("SP_VisualizzaGiorno", transf.TrasformInGiorno, parameter, "GeTime");
                if (result != null)
                    result.Data = data;
                return result;
            } catch (SqlException) {
                throw new Exception("Errore server!");
            } catch (Exception e) {
                throw e;
            }
        }
        public List<Giorno> GiorniCommessa(int idCommessa, string idUtente) {
            try {
                SqlParameter[] parameter = {
                    new SqlParameter("@idC", idCommessa),
                    new SqlParameter("@idU",idUtente)
                };
                return DB.ExecQProcedureReader("SP_VisualizzaCommessa", transf.TrasformInGiorni, parameter, "GeTime");
            } catch (SqlException) {
                throw new Exception("Errore server!");
            } catch (Exception e) {
                throw e;
            }
        }
        public List<DTGiornoDMese> DettaglioMese(int anno, int mese, string idutente) {
            try {
                SqlParameter[] param = { new SqlParameter("@anno", anno), new SqlParameter("@mese", mese), new SqlParameter("@idutente", idutente) };
                List<Giorno> output = DB.ExecQProcedureReader("SP_VisualizzaMese", transf.TransfInGiorni, param, "GeTime");
                List<DTGiornoDMese> result = null;
                if (output.Count > 0) {
                    result = output.ConvertAll(new Converter<Giorno, DTGiornoDMese>(transf.ConvertGiornoInDTGDMese));
                } else
                    result = new List<DTGiornoDMese>();
                return result;
            } catch (SqlException e) {
                throw new Exception(e.Message);
            } catch (Exception e) {
                throw e;
            }
        }
        public Commessa CercaCommessa(string nomeCommessa) {
            try {
                SqlParameter[] param = { new SqlParameter("@nomeCommessa", nomeCommessa) };
                return DB.ExecQProcedureReader("SP_CercaCommessa", transf.TrasformInCommessa, param, "GeTime");
            } catch (SqlException) {
                throw new Exception("Errore server!");
            } catch (Exception e) {
                throw e;
            }
        }
        public List<GiornoMese> VisualizzaMese(int anno, int mese, string idUtente){ 
            List<GiornoMese> result = null;
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource= @"(localdb)\MSSQLLocalDB";
            scsb.InitialCatalog="GeTime";
            SqlConnection connection = new SqlConnection(scsb.ToString());
            try {
                connection.Open();
                SqlCommand command = new SqlCommand("SP_VisualizzaMese",connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@anno", System.Data.SqlDbType.Date).Value = anno;
                command.Parameters.Add("@mese", System.Data.SqlDbType.Date).Value = mese;
                command.Parameters.Add("@IdUtente", System.Data.SqlDbType.NVarChar).Value = idUtente;
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read()){
                    result.Add(new GiornoMese{data=reader.GetDateTime(2), Tipo =reader.GetInt32(0), Ore= reader.GetInt32(1)});
                }
                reader.Close();
                command.Dispose();
                return result;
            } catch (Exception e) {
                throw e;
            } finally {
                connection.Dispose();
            }
            
        }
    }
    public class Profilo{ 
        public string Matrincola{get;set;}
        public string Nome{get;set;}
        public string Cognome{get;set;}
        public string Ruolo{get;set;}
        public string Username{get;set;}
        public string Password{get;set;}
    }

    public class Studente{ 
        public int Id{get;set;}
        public string Nome{get;set;}
        public string Cognome{get;set;}
    }
    public class Corso{ 
        public int Id{get;set;}
        public string Nome{get;set;}
        public string Descrizione{get;set;}
        public DateTime Inizio{get;set;}
        public DateTime Fine {get;set;}
        public List<Studente> Studenti{get;set;}
        public List<Lezione> Lezioni{get;set;}
    }
    public class Lezione{ 
        public int Id{get;set;}
        public string Nome {get;set;}
        public string Descrizione{get;set;}
        public int Durata{get;set;}
    }
	public class GiornoMese{ 
        public DateTime data{ get;set;}
        public int Tipo {get;set;}
        public int Ore{get;set;}
    }
    public partial class Giorno {
        public DateTime data;
        private int idG;
        public DateTime Data { get { return data; } set { data = value; } }
        private List<OreLavorative> oreLavorative = new List<OreLavorative>();
        public string ID_UTENTE { get;set;}
        public int HPermesso { get; set; }
        public int HMalattia { get; set; }
        public int HFerie { get; set; }
        public List<OreLavorative> OreLavorate { get;set; }
        public int IdGiorno { get; set; }
        public int TotOreLavorate { get; set; }

        public Giorno(DateTime data) { this.data = data; }
        public Giorno(DateTime data, int idG, int HP, int HM, int HF, int oreLavorate, string id_utente):this(data,idG,HP,HM,HF,id_utente) {
            TotOreLavorate = oreLavorate;
        }
        public Giorno(DateTime data, int idG, int HP, int HM, int HF, string id_utente) {
            this.data = data;
            HPermesso = HP;
            HMalattia = HM;
            HFerie = HF;
           ID_UTENTE = id_utente;
            this.idG = idG;
        } 
        public void AddOreLavorative(OreLavorative com) {
            oreLavorative.Add(com);
            this.TotOreLavorate += com.Ore;
        }
        public override bool Equals(object obj) {
            return data.Equals(((Giorno)obj).data);
        }
        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }
	public partial class OreLavorative {
		public int IdC{ get;set;}
		public string Descrizione { get => _descrizione; set => _descrizione = value; }
		public string Nome { get => _nome; set => _nome = value; }
		public int Ore{ get; set; }
		private string _nome;
		private string _descrizione;

		public OreLavorative(int idC, int oreLavorate, string nome, string descrizione) {
			this.IdC = idC;
			Ore = oreLavorate;
			_nome = nome;
			_descrizione = descrizione;
		}
    }
	public class Commessa {
		public int Id { get; set; }
		public string Descrizione { get; set; }
		public string Nome { get; set; }
		public int Capienza { get; set; }
		public int OreLavorate { get; set; }

		public Commessa(int id, string nome, string descrizione, int capienza, int oreLavorate) {
			Id = id;
			OreLavorate = oreLavorate;
			Nome = nome;
			Descrizione = descrizione;
			Capienza = capienza;
		}
	}

    public class CV {
        public string Matricola {get; set;}
        public string Nome {get; set;}
        public string Cognome {get; set;}
        public int Eta {get; set;}
        public string Email { get; set;}
        public string Residenza {get; set;}
        public string Telefono {get; set;}
        public List<EspLav> Esperienze {get; set;}
        public List<PerStud> Percorsostudi {get; set;}
        public List<Competenza> Competenze {get; set;}
    }
    public class EspLav {
        public int AnnoInizio {get; set;}
        public int AnnoFine {get; set;}
        public string Qualifica {get; set;}
        public string Descrizione {get; set;}
    }
    public class PerStud {
        public int AnnoInizio {get; set;}
        public int AnnoFine {get; set;}
        public string Titolo {get; set;}
        public string Descrizione {get; set;}
    }
    public class Competenza {
        public string Titolo {get; set;}
        public int Livello {get; set;}
    }

}