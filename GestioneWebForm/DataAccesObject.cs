using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

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
		void CompilaHLavoro(DateTime data, int ore, int idCommessa, int idUtente);
		void Compila(DateTime data, int ore, HType tipoOre, int idUtente);
		Giorno VisualizzaGiorno(DateTime data, string idUtente);
		List<Giorno> GiorniCommessa(int idCommessa, int idUtente);
		Commessa CercaCommessa(string nomeCommessa);
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
        public void AddCompetenze(string MatrCv,Competenza comp) {
            throw new NotImplementedException();
        }

        public void AddCorso(Corso corso) {
            throw new NotImplementedException();
        }

        public void AddCvStudi(string MatrCv,PerStud studi) {
            throw new NotImplementedException();
        }

        public void AddEspLav(string MatrCv,EspLav esp) {
            throw new NotImplementedException();
        }

        public void AddLezione(int idCorso,Lezione lezione) {
            throw new NotImplementedException();
        }

        public void AggiungiCV(CV a) {
            throw new NotImplementedException();
        }

        public void CaricaCV(string path) {
            throw new NotImplementedException();
        }

        public Commessa CercaCommessa(string nomeCommessa) {
            throw new NotImplementedException();
        }

        public void Compila(DateTime data,int ore,HType tipoOre,int idUtente) {
            throw new NotImplementedException();
        }

        public void CompilaHLavoro(DateTime data,int ore,int idCommessa,int idUtente) {
            throw new NotImplementedException();
        }

        public void EliminaCV(CV curriculum) {
            throw new NotImplementedException();
        }

        public List<Giorno> GiorniCommessa(int idCommessa,int idUtente) {
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

        public Corso SearchCorsi(int idCorso) {
            throw new NotImplementedException();
        }

        public List<Corso> SearchCorsi(string descrizione) {
            throw new NotImplementedException();
        }

        public List<Corso> SearchCorsi(string descrizione,int idUtente) {
            throw new NotImplementedException();
        }

        public List<CV> SearchEta(int eta) {
            throw new NotImplementedException();
        }

        public List<CV> SearchRange(int etmin,int etmax) {
            throw new NotImplementedException();
        }

        public Giorno VisualizzaGiorno(DateTime data, string idUtente) {
            Giorno result = null;
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource= @"(localdb)\MSSQLLocalDB";
            scsb.InitialCatalog="GeTime";
            SqlConnection connection = new SqlConnection(scsb.ToString());
            try {
                connection.Open();
                SqlCommand command = new SqlCommand("SP_VisualizzaGiorno",connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@Data", System.Data.SqlDbType.Date).Value = data.ToString("yyyy-MM-dd");
                command.Parameters.Add("@IdUtente", System.Data.SqlDbType.NVarChar).Value = idUtente;
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read()) {
                    result = new Giorno(data);
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
                    } while(reader.Read());
                }
                reader.Close();
                command.Dispose();
            } catch (Exception e) {
                throw e;
            } finally {
                connection.Dispose();
            }
            return result;
        }
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
	
    public partial class Giorno {
		private string _id_utente;
		private DateTime data;
		private int idG;
		public DateTime Data { get { return data; } }
		private List<OreLavorative> oreLavorative = new List<OreLavorative>();
		public string ID_UTENTE { get { return _id_utente; } set { _id_utente = value; } }
		public int HPermesso{ get;set;}
		public int HMalattia{ get;set;}
		public int HFerie{ get;set;}
		public List<OreLavorative> OreLavorate { get => oreLavorative; }
		public int IdGiorno{ get;set;}

		public Giorno(DateTime data) { this.data = data; }
		public Giorno(DateTime data, int idG, int HP, int HM, int HF, string id_utente) {
			this.data = data;
			HPermesso = HP;
			HMalattia = HM;
			HFerie = HF;
			_id_utente = id_utente;
			this.idG=idG;
		}

		public void AddOreLavorative(OreLavorative com) {
			oreLavorative.Add(com);
		}
		public int TotOreLavorate() {
			int tot = 0;
			foreach (OreLavorative com in OreLavorate) {
				tot += com.Ore;
			}
			return tot;
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