using System;
using System.Collections.Generic;

namespace GestioneWebForm
{
    public class Corso
    {
        int _idCorso;
        string _nome;
        DateTime _DataInizio;
        DateTime _DataFine;
        string _descrizione;
        List<Studente> _studenti = new List<Studente>();
        List<Lezione> _lezioni = new List<Lezione>();

        public int IdCorso => _idCorso;
        public string Nome {
            get => _nome;
            set => this._nome = value;
        }
        public string Descrizione {
            get => _descrizione;
            set => this._descrizione = value;
        }
        public DateTime DataInizio => _DataInizio;
        public DateTime DataFine => _DataFine;
        public List<Studente> Studenti => _studenti;
        public List<Lezione> Lezioni => _lezioni;
        //usiamo nome come identificatore univoco!
        public Corso(int id, string nome)
        {
            this._idCorso = id;
            this._nome = nome;
        }
        public Corso(int id, string nome, DateTime dataInizio)
        {
            this._idCorso = id;
            this._nome = nome;
            this._DataInizio = dataInizio;
        }
        public Corso(int id, string nome, DateTime dataInizio, DateTime dataFine)
        {
            this._idCorso = id;
            this._nome = nome;
            this._DataInizio = dataInizio;
            this._DataFine = dataFine;
        }
        public Corso(string nome, DateTime dataInizio, DateTime dataFine, string descrizione)
        {
            this._nome = nome;
            this._DataInizio = dataInizio;
            this._DataFine = dataFine;
            this._descrizione = descrizione;
        }
        public Corso(int id, string nome, string descrizione)
        {
            this._idCorso = id;
            this._nome = nome;
            this._descrizione = descrizione;
        }

        public void Iscriviti(Studente s) => this._studenti.Add(s);
        public void AddLezione(Lezione l) => this._lezioni.Add(l);
        public void ModDurLez(Lezione l, int ore) => l.Durata = ore;
    }
}