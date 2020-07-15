using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System;
using System.Data;

namespace Biblioteca.Data
{
    //creazione classe DatabaseBiblioteca che si interfaccia direttamente con i database

    public class DatabaseBiblioteca
    {
        SqlConnection CONNESSIONE;                                                            //connessione al database
        string nome;                                                                          //nome del database collegato


        //metodo costruttore che prende in input il nome del database scelto e il suo indice equivalente nel file guida "NomiDatabase.txt"
        public DatabaseBiblioteca(string nomeDatabase)
        {
            nome = nomeDatabase;
            string percorso = Directory.GetCurrentDirectory() + @"\Databases\";                //prende percorso corrente e aggiunge Databases (cartella in cui sono presenti i database)
            string stringaConn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""" + percorso + nome + @".mdf"";Integrated Security=True;Connect Timeout=30";  //costruzione della stringa di connessione
            CONNESSIONE = new SqlConnection(stringaConn);
            CONNESSIONE.Open();                                                                //apertura connessione
        }

        //metodo che ottiene tutte le query del database scelto dal file che le lista tutte
        public List<string> OttieniQuery()
        {
            string path = Directory.GetCurrentDirectory() + @"\Config\Queries\" + nome + ".txt";//prende percorso corrente e aggiunge Config\QueryDatabase.txt (file con tutte le query di tutti i database)
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);       //apertura del filestream
            StreamReader streamReader = new StreamReader(fileStream);                           //apertura dello streamreader
            List<string> tmp = new List<string>();                                              //lista che verrà riempita con tutte le query del file
            while (!streamReader.EndOfStream)
                tmp.Add(streamReader.ReadLine());                                               //riempe lista con le query del file
            return tmp;
        }

        public List<string> OttieniNomiTabelle()
        {
            List<string> tmp = new List<string>();                                              //lista che conterrà i nomi dei campi del database scelto
            DataTable dt = CONNESSIONE.GetSchema("Tables");                                     //creazione di datatable che contiene lo schema del database scelto
            foreach (DataRow row in dt.Rows)                                                    //estrazione dei nomi delle tabelle dallo schema del database scelto
            {
                string tablename = (string)row[2];
                tmp.Add(tablename);
            }
            return tmp;
        }

        public string InserisciElemento (string query)
        {
            string messaggio = "Elemento Inserito!";                                            //messaggio di output default per l'inserimento di un elemento
            string esito = EseguiQuery(query);
            if (esito == "")
                esito = messaggio;
            return esito;
        }

        public string ModificaElemento (string query)
        {
            string messaggio = "Elemento Modificato!";                                          //messaggio di output default per la modifica di un elemento
            string esito = EseguiQuery(query);                                                  //esegue query e salva l'esito nella stringa
            if (esito == "")                                                                    //se l'esito è nullo
                esito = messaggio;                                                              //allora l'operazione è andata a buon fine quindi viene dato in output il messaggio default
            return esito;
        }

        public DataTable VisualizzaElenco (string query)
        {
            DataTable output = new DataTable();                                                 //creazione datatable per l'output
            SqlDataAdapter adapter = new SqlDataAdapter(query, CONNESSIONE);                    //creazione sql data adapter per l'esecuzione della query
            adapter.Fill(output);                                                               //riempimento della datatable con i risultati della query
            return output;
        }

        public string EliminaElemento (string query)
        {
            string messaggio = "Elemento Eliminato!";                                            //messaggio di output default per l'eliminazione di un elemento
            string esito = EseguiQuery(query);                                                   //esegue query e salva l'esito nella stringa
            if (esito == "")                                                                     //se l'esito è nullo
                esito = messaggio;                                                               //allora l'operazione è andata a buon fine quindi viene dato in output il messaggio default
            return esito;
        }

        public DataTable Ricerca (string query)
        {
            DataTable output = new DataTable();                                                 //creazione datatable per l'output
            SqlDataAdapter adapter = new SqlDataAdapter(query, CONNESSIONE);                    //creazione sql data adapter per l'esecuzione della query
            adapter.Fill(output);                                                               //riempimento della datatable con i risultati della query
            return output;
        }

        private string EseguiQuery(string query)
        {
            string result = "";                                                                //stringa di risultato della query
            SqlDataAdapter adapter = new SqlDataAdapter();                                     //creazione sql data adapter per l'esecuzione della query
            try
            {
                adapter.InsertCommand = new SqlCommand(query, CONNESSIONE);                    //inserimento del comando richiesto
                adapter.InsertCommand.ExecuteNonQuery();                                       //esecuzione del comando richiesto
            }
            catch (Exception ex)                                                               //nel caso di errore
            {
                result = ex.ToString();                                                        //il metodo restituisce tale errore (utile per debugging, ecc....)
            }
            return result;
        }

        public void Chiudi()
        {
            CONNESSIONE.Close();                                                                //chiusura della connessione al database
        }
    }
}
