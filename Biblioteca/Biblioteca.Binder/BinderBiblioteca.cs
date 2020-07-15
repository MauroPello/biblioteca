using Biblioteca.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace Biblioteca.Binder
{
    //creazione classe BinderBiblioteca che collega l'interfaccia grafica al gestore dei Dati/database

    public class BinderBiblioteca
    {
        //creazione istanza della classe DatabaseBiblioteca con la quale si interfaccia BinderBiblioteca per poter accedere al database
        DatabaseBiblioteca db;

        //metodo costruttore che prende in input il nome del database scelto e il suo indice equivalente nel file guida "NomiDatabase.txt"
        public void CollegaDatabase(string nomeDatabase)
        {
            db = new DatabaseBiblioteca(nomeDatabase);
        }

        //chiusura della connessione al database
        public void ChiudiDatabase()
        {
            db.Chiudi();
        }

        //metodo che estrae dal file NomiDatabase.txt i nomi dei database disponibili e li mette in una Lista di stringhe
        public List<string> OttieniNomiDatabase()
        {
            string path = Directory.GetCurrentDirectory() + @"\Config\NomiDatabase.txt";            //prende percorso corrente e aggiunge Config\NomiDatabase.txt (file con tutti i nomi dei database)
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);           //apertura del filestream
            StreamReader streamReader = new StreamReader(fileStream);                               //apertura dello streamreader
            List<string> nomiDatabase = new List<string>();                                         //lista che conterrà i nomi dei database
            while (!streamReader.EndOfStream)
                nomiDatabase.Add(streamReader.ReadLine());                                          //riempe lista con i nomi
            return nomiDatabase;
        }

        public List<string> OttieniNomiTabelle()
        {
            return db.OttieniNomiTabelle();                                                         //returna la lista dei nomi dei campi del database scelto
        }

        /*
        Qualunque sia il database deve poter rispondere alle stesse richieste
        queste richieste sono raggiungibili attraverso il metodo DatabaseBiblioteca.OttieniQuery()
        esiste quindi un indice fisso stabilito da noi sviluppatori e comune a tutti i database
        0 - Inserimento_Libro
        1 - Inserimento_Categoria
        2 - Inserimento_Collocazione
        3 - Inserimento_Autore
        4 - Inserimento_Utente
        5 - Inserimento_Prestito
        6 - Inserimento_LibriAutori
        7 - Inserimento_LibriCategorie
        8 - Inserimento_LibriCollocazioni
        9 - Modifica_Libro
        10 - Modifica_Categoria
        11 - Modifica_Collocazione
        12 - Modifica_Autore
        13 - Modifica_Utente
        14 - Modifica_Prestito
        15 - VisualizzaElenco_Libri
        16 - VisualizzaElenco_Categorie
        17 - VisualizzaElenco_Collocazioni
        18 - VisualizzaElenco_Autori
        19 - VisualizzaElenco_Utenti
        20 - VisualizzaElenco_Prestiti
        21 - VisualizzaElenco_LibriAutori
        22 - VisualizzaElenco_LibriCategorie
        23 - VisualizzaElenco_LibriCollocazioni
        24 - Elimina_Libro
        25 - Elimina_Categoria
        26 - Elimina_Collocazione
        27 - Elimina_Autore
        28 - Elimina_Utente
        29 - Elimina_Prestito
        30 - Elimina_LibriAutori
        31 - Elimina_LibriCategorie
        32 - Elimina_LibriCollocazioni
        33 - Ricerca_Collocazioni_LibroCodice_ISBN
        34 - Ricerca_LibriNonRestituitiPiù2Mesi
        35 - Ricerca_LibroPiùNoleggiatoOgniUtente
        36 - Ricerca_LibroPiùNoleggiatoOgniCategoria
        37 - Ricerca_Autori_Categoria
        38 - Ricerca_AutorePreferitoOgniUtente
        39 - Ricerca_Libri_Categoria_PrestitoConcluso_Utente
        40 - Ricerca_Libri_Autore
        */

        //In ogni metodo che costruisce le query il funzionamento è lo stesso:
        //si ottiene la query necessaria (secondo l'indice) dalla lista delle query
        //si sostituisce il codice contemporaneo del campo con il dato da inserire (preso dall'interfaccia grafica)
        //nel caso di inserimento di stringhe ogni apostrofo viene sostituito con un doppio apostrofo per evitare errori
        //e proteggere il programma da vulnerabilità come SQL Injection (es. 1=1).
        //la query oramai costruita nel modo corretto e contenente tutti i dati viene poi eseguita con il metodo 
        //a lei associato (es. InserisciElemento(string query) per l'inserimento di un elemento)
        //tutti i metodi restituiscono l'esito della query attraverso stringhe, nel caso della visualizzazione di elenchi/liste 
        //i metodi restituiscono la DataTable da inserire nella DataGridView di visualizzazione

        public string Inserimento_Libro(int ID_CodiceISBN, string Titolo, string Lingua, string Editore, string Data_Pubblicazione)
        {
            string tmp = db.OttieniQuery().ElementAt(0);
            
            tmp = tmp.Replace("*ID_CodiceISBN*", ID_CodiceISBN.ToString());
            tmp = tmp.Replace("*Titolo*", Titolo.Replace("'", "''"));
            tmp = tmp.Replace("*Lingua*", Lingua.Replace("'", "''"));
            tmp = tmp.Replace("*Editore*", Editore.Replace("'", "''"));
            tmp = tmp.Replace("*Data_Pubblicazione*", Data_Pubblicazione);
            
            return db.InserisciElemento(tmp);
        }

        public string Inserimento_Categoria(string Nome)
        {
            string tmp = db.OttieniQuery().ElementAt(1);
            
            tmp = tmp.Replace("*Nome*", Nome.Replace("'", "''"));
            
            return db.InserisciElemento(tmp);
        }

        public string Inserimento_Collocazione(string Sezione, int Numero_Scaffale, int Numero_Posto, int Quantità, int ID_CodiceISBN_Libri)
        {
            string tmp = db.OttieniQuery().ElementAt(2);
            
            tmp = tmp.Replace("*Sezione*", Sezione.Replace("'", "''"));
            tmp = tmp.Replace("*Numero_Scaffale*", Numero_Scaffale.ToString());
            tmp = tmp.Replace("*Numero_Posto*", Numero_Posto.ToString());
            tmp = tmp.Replace("*Quantità*", Quantità.ToString());
            tmp = tmp.Replace("*ID_CodiceISBN_Libri*", ID_CodiceISBN_Libri.ToString());

            return db.InserisciElemento(tmp);
        }

        public string Inserimento_Autore(string Nome, string Cognome, string Data_Nascita, string Luogo_Nascita)
        {
            string tmp = db.OttieniQuery().ElementAt(3);
            
            tmp = tmp.Replace("*Nome*", Nome.Replace("'", "''"));
            tmp = tmp.Replace("*Cognome*", Cognome.Replace("'", "''"));
            tmp = tmp.Replace("*Data_Nascita*", Data_Nascita);
            tmp = tmp.Replace("*Luogo_Nascita*", Luogo_Nascita.Replace("'", "''"));

            return db.InserisciElemento(tmp);
        }

        public string Inserimento_Utente(string Nome, string Cognome, string Data_Registrazione)
        {
            string tmp = db.OttieniQuery().ElementAt(4);
            
            tmp = tmp.Replace("*Nome*", Nome.Replace("'", "''"));
            tmp = tmp.Replace("*Cognome*", Cognome.Replace("'", "''"));
            tmp = tmp.Replace("*Data_Registrazione*", Data_Registrazione);

            return db.InserisciElemento(tmp);
        }

        public string Inserimento_Prestito(int ID_CodiceISBN_Libri, int ID_Tessera_Utenti, string Data_Inizio, string Data_Fine)
        {
            string tmp = db.OttieniQuery().ElementAt(5);
            
            tmp = tmp.Replace("*ID_CodiceISBN_Libri*", ID_CodiceISBN_Libri.ToString());
            tmp = tmp.Replace("*ID_Tessera_Utenti*", ID_Tessera_Utenti.ToString());
            tmp = tmp.Replace("*Data_Inizio*", Data_Inizio);
            if (Data_Fine == "NULL")
                tmp = tmp.Replace("'*Data_Fine*'", Data_Fine);
            else
                tmp = tmp.Replace("*Data_Fine*", Data_Fine);

            return db.InserisciElemento(tmp);
        }

        public string Inserimento_LibriAutori(int ID_CodiceISBN_Libri, int ID_Autori)
        {
            string tmp = db.OttieniQuery().ElementAt(6);

            tmp = tmp.Replace("*ID_CodiceISBN_Libri*", ID_CodiceISBN_Libri.ToString());
            tmp = tmp.Replace("*ID_Autori*", ID_Autori.ToString());

            return db.InserisciElemento(tmp);
        }

        public string Inserimento_LibriCategorie(int ID_CodiceISBN_Libri, int ID_Categorie)
        {
            string tmp = db.OttieniQuery().ElementAt(7);

            tmp = tmp.Replace("*ID_CodiceISBN_Libri*", ID_CodiceISBN_Libri.ToString());
            tmp = tmp.Replace("*ID_Categorie*", ID_Categorie.ToString());

            return db.InserisciElemento(tmp);
        }

        public string Inserimento_LibriCollocazioni(int ID_CodiceISBN_Libri, int ID_Collocazioni)
        {
            string tmp = db.OttieniQuery().ElementAt(8);

            tmp = tmp.Replace("*ID_CodiceISBN_Libri*", ID_CodiceISBN_Libri.ToString());
            tmp = tmp.Replace("*ID_Collocazioni*", ID_Collocazioni.ToString());

            return db.InserisciElemento(tmp);
        }

        public string Modifica_Libro(int ID_CodiceISBN, string Titolo, string Lingua, string Editore, string Data_Pubblicazione)
        {
            string tmp = db.OttieniQuery().ElementAt(9);
            
            tmp = tmp.Replace("*ID_CodiceISBN*", ID_CodiceISBN.ToString());
            tmp = tmp.Replace("*Titolo*", Titolo.Replace("'", "''"));
            tmp = tmp.Replace("*Lingua*", Lingua.Replace("'", "''"));
            tmp = tmp.Replace("*Editore*", Editore.Replace("'", "''"));
            tmp = tmp.Replace("*Data_Pubblicazione*", Data_Pubblicazione);

            return db.ModificaElemento(tmp);
        }

        public string Modifica_Categoria(int ID, string Nome)
        {
            string tmp = db.OttieniQuery().ElementAt(10);
            
            tmp = tmp.Replace("*ID*", ID.ToString());
            tmp = tmp.Replace("*Nome*", Nome.Replace("'", "''"));
            
            return db.ModificaElemento(tmp);
        }

        public string Modifica_Collocazione(int ID, string Sezione, int Numero_Scaffale, int Numero_Posto, int Quantità, int ID_CodiceISBN_Libri)
        {
            string tmp = db.OttieniQuery().ElementAt(11);
            
            tmp = tmp.Replace("*ID*", ID.ToString());
            tmp = tmp.Replace("*Sezione*", Sezione.Replace("'", "''"));
            tmp = tmp.Replace("*Numero_Scaffale*", Numero_Scaffale.ToString());
            tmp = tmp.Replace("*Numero_Posto*", Numero_Posto.ToString());
            tmp = tmp.Replace("*Quantità*", Quantità.ToString());
            tmp = tmp.Replace("*ID_CodiceISBN_Libri*", ID_CodiceISBN_Libri.ToString());

            return db.ModificaElemento(tmp);
        }

        public string Modifica_Autore(int ID, string Nome, string Cognome, string Data_Nascita, string Luogo_Nascita)
        {
            string tmp = db.OttieniQuery().ElementAt(12);
            
            tmp = tmp.Replace("*ID*", ID.ToString());
            tmp = tmp.Replace("*Nome*", Nome.Replace("'", "''"));
            tmp = tmp.Replace("*Cognome*", Cognome.Replace("'", "''"));
            tmp = tmp.Replace("*Data_Nascita*", Data_Nascita);
            tmp = tmp.Replace("*Luogo_Nascita*", Luogo_Nascita.Replace("'", "''"));

            return db.ModificaElemento(tmp);
        }

        public string Modifica_Utente(int ID_Tessera, string Nome, string Cognome, string Data_Registrazione)
        {
            string tmp = db.OttieniQuery().ElementAt(13);
            
            tmp = tmp.Replace("*ID_Tessera*", ID_Tessera.ToString());
            tmp = tmp.Replace("*Nome*", Nome.Replace("'", "''"));
            tmp = tmp.Replace("*Cognome*", Cognome.Replace("'", "''"));
            tmp = tmp.Replace("*Data_Registrazione*", Data_Registrazione);
            
            return db.ModificaElemento(tmp);
        }

        public string Modifica_Prestito(int ID, int ID_CodiceISBN_Libri, int ID_Tessera_Utenti, string Data_Inizio, string Data_Fine)
        {
            string tmp = db.OttieniQuery().ElementAt(14);

            tmp = tmp.Replace("*ID*", ID.ToString());
            tmp = tmp.Replace("*ID_CodiceISBN_Libri*", ID_CodiceISBN_Libri.ToString());
            tmp = tmp.Replace("*ID_Tessera_Utenti*", ID_Tessera_Utenti.ToString());
            tmp = tmp.Replace("*Data_Inizio*", Data_Inizio);
            if (Data_Fine == "NULL")
                tmp = tmp.Replace("'*Data_Fine*'", Data_Fine);
            else
                tmp = tmp.Replace("*Data_Fine*", Data_Fine);

            return db.ModificaElemento(tmp);
        }
        public DataTable VisualizzaElenco_Libri()
        {
            string tmp = db.OttieniQuery().ElementAt(15);
            
            DataTable table = db.VisualizzaElenco(tmp);
            
            return table;
        }
        public DataTable VisualizzaElenco_Categorie()
        {
            string tmp = db.OttieniQuery().ElementAt(16);
            
            return db.VisualizzaElenco(tmp);
        }
        public DataTable VisualizzaElenco_Collocazioni()
        {
            string tmp = db.OttieniQuery().ElementAt(17);
            
            return db.VisualizzaElenco(tmp);
        }
        public DataTable VisualizzaElenco_Autori()
        {
            string tmp = db.OttieniQuery().ElementAt(18);
            
            return db.VisualizzaElenco(tmp);
        }
        public DataTable VisualizzaElenco_Utenti()
        {
            string tmp = db.OttieniQuery().ElementAt(19);
            
            return db.VisualizzaElenco(tmp);
        }
        public DataTable VisualizzaElenco_Prestiti()
        {
            string tmp = db.OttieniQuery().ElementAt(20);
            
            return db.VisualizzaElenco(tmp);
        }

        public DataTable VisualizzaElenco_LibriAutori()
        {
            string tmp = db.OttieniQuery().ElementAt(21);

            return db.VisualizzaElenco(tmp);
        }

        public DataTable VisualizzaElenco_LibriCategorie()
        {
            string tmp = db.OttieniQuery().ElementAt(22);

            return db.VisualizzaElenco(tmp);
        }

        public DataTable VisualizzaElenco_LibriCollocazioni()
        {
            string tmp = db.OttieniQuery().ElementAt(23);

            return db.VisualizzaElenco(tmp); 
        }

        public string Elimina_Libro(int ID_CodiceISBN)
        {
            string tmp = db.OttieniQuery().ElementAt(24);
            
            tmp = tmp.Replace("*ID_CodiceISBN*", ID_CodiceISBN.ToString());

            return db.EliminaElemento(tmp);
        }

        public string Elimina_Categoria(int ID)
        {
            string tmp = db.OttieniQuery().ElementAt(25);
            
            tmp = tmp.Replace("*ID*", ID.ToString());
            
            return db.EliminaElemento(tmp);
        }

        public string Elimina_Collocazione(int ID)
        {
            string tmp = db.OttieniQuery().ElementAt(26);
            
            tmp = tmp.Replace("*ID*", ID.ToString());
            
            return db.EliminaElemento(tmp);
        }
        public string Elimina_Autore(int ID)
        {
            string tmp = db.OttieniQuery().ElementAt(27);
            
            tmp = tmp.Replace("*ID*", ID.ToString());
            
            return db.EliminaElemento(tmp);
        }
        public string Elimina_Utente(int ID_Tessera)
        {
            string tmp = db.OttieniQuery().ElementAt(28);
            
            tmp = tmp.Replace("*ID_Tessera*", ID_Tessera.ToString());
            
            return db.EliminaElemento(tmp);
        }
        public string Elimina_Prestito(int ID)
        {
            string tmp = db.OttieniQuery().ElementAt(29);
            
            tmp = tmp.Replace("*ID*", ID.ToString());
            
            return db.EliminaElemento(tmp);
        }

        public string Elimina_LibriAutori(int ID_CodiceISBN_Libri, int ID_Autori)
        {
            string tmp = db.OttieniQuery().ElementAt(30);

            tmp = tmp.Replace("*ID_CodiceISBN_Libri*", ID_CodiceISBN_Libri.ToString());
            tmp = tmp.Replace("*ID_Autori*", ID_Autori.ToString());

            return db.EliminaElemento(tmp);
        }

        public string Elimina_LibriCategorie(int ID_CodiceISBN_Libri, int ID_Categorie)
        {
            string tmp = db.OttieniQuery().ElementAt(31);

            tmp = tmp.Replace("*ID_CodiceISBN_Libri*", ID_CodiceISBN_Libri.ToString());
            tmp = tmp.Replace("*ID_Categorie*", ID_Categorie.ToString());

            return db.EliminaElemento(tmp);
        }

        public string Elimina_LibriCollocazioni(int ID_CodiceISBN_Libri, int ID_Collocazioni)
        {
            string tmp = db.OttieniQuery().ElementAt(32);

            tmp = tmp.Replace("*ID_CodiceISBN_Libri*", ID_CodiceISBN_Libri.ToString());
            tmp = tmp.Replace("*ID_Collocazioni*", ID_Collocazioni.ToString());

            return db.EliminaElemento(tmp);
        }

        public DataTable Ricerca_Collocazioni_LibroCodice_ISBN(int ID_CodiceISBN)
        {
            string tmp = db.OttieniQuery().ElementAt(33);

            tmp = tmp.Replace("*ID_CodiceISBN*", ID_CodiceISBN.ToString());

            return db.Ricerca(tmp);
        }

        public DataTable Ricerca_LibriNonRestituitiPiù2Mesi()
        {
            string tmp = db.OttieniQuery().ElementAt(34);
            string dataTMP = DateTime.Today.AddMonths(-2).ToString("yyyyMMdd");

            tmp = tmp.Replace("*Data Attuale Meno Due Mesi*", dataTMP);

            return db.Ricerca(tmp);
        }

        public DataTable Ricerca_LibroPiùNoleggiatoOgniUtente()
        {
            string tmp = db.OttieniQuery().ElementAt(35);

            return db.Ricerca(tmp);
        }

        public DataTable Ricerca_LibroPiùNoleggiatoOgniCategoria()
        {
            string tmp = db.OttieniQuery().ElementAt(36);

            return db.Ricerca(tmp);
        }

        public DataTable Ricerca_Autori_Categoria(string Nome)
        {
            string tmp = db.OttieniQuery().ElementAt(37);

            tmp = tmp.Replace("*Nome*", Nome.Replace("'", "''"));

            return db.Ricerca(tmp);
        }

        public DataTable Ricerca_AutorePreferitoOgniUtente()
        {
            string tmp = db.OttieniQuery().ElementAt(38);

            return db.Ricerca(tmp);
        }

        public DataTable Ricerca_Libri_Categoria_PrestitoConcluso_Utente(string Nome, int ID_Tessera)
        {
            string tmp = db.OttieniQuery().ElementAt(39);

            tmp = tmp.Replace("*Nome*", Nome.Replace("'", "''"));
            tmp = tmp.Replace("*ID_Tessera*", ID_Tessera.ToString());

            return db.Ricerca(tmp);
        }

        public DataTable Ricerca_Libri_Autore(string Nome, string Cognome)
        {
            string tmp = db.OttieniQuery().ElementAt(40);

            tmp = tmp.Replace("*Nome*", Nome.Replace("'", "''"));
            tmp = tmp.Replace("*Cognome*", Cognome.Replace("'", "''"));

            return db.Ricerca(tmp);
        }
    }
}
