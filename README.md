# biblioteca
C# WindowsForms Application for Library Management (SQL database)
Al codice non sono state apportate modifiche in quanto è stato sviluppato in modo tale che potesse supportare le due principali varianti del database (relazione 1 a N o N a N per Libri e Collocazioni) e la differente formattazione dei nomi.

Per aggiungere un database al programma, copiare il proprio database (.mdf) nella cartella "Databases". Successivamente aggiungere il nome del database aggiunto nel file "NomiDatabase.txt", creare un nuovo file .txt nella cartella "\Config\Queries" con nome uguale a quello del database che si sta inserendo, infine aggiungere le query necessarie al file appena creato. Il programma adotta il seguente ordine/indice per le query:
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
Questo indice dovrà essere rispettato mentre si inseriscono le query del nuovo database in modo da garantire il corretto funzionamento. 
Infine, il programma per riconoscere i campi da inserire nella query da eseguire cerca il nome del campo diviso da trattini bassi ("_"), contornato da asterischi ("*") e con tutte le iniziali maiuscole, ad eccezione delle sigle e della parola id che invece è in maiuscolo per intero (ID). 

N.B.: per il nome dei campi non vengono scritte le preposizioni in quanto superflue, e nel caso di ID, nomi e cognomi vengono ignorate la tabella in cui appartengono (ad eccezione delle tabelle di relazione, per evitare conflitti).

Tabella di traduzione
Nome Campo		| Codice capito dal nostro programma
------------------------|------------------------------------
id (no tabellerelazioni)| *ID*
id codice ISBN		| *ID_CodiceISBN*
titolo			| *Titolo*
lingua			| *Lingua*
editore			| *Editore*
data di pubblicazione	| *Data_Pubblicazione*
id categorie		| *ID_Categorie*
nome categoria		| *Nome*
id collocazioni		| *ID_Collocazioni*
id codice ISBN libri	| *ID_CodiceISBN_Libri*
sezione			| *Sezione*
numero scaffale		| *Numero_Scaffale*
numero posto		| *Numero_Posto*
quantità		| *Quantita*
id autori		| *ID_Autori*
nome autore		| *Nome*
cognome autore		| *Cognome*
data di nascita		| *Data_Nascita*
luogo di nascita	| *Luogo_Nascita*
id tessera 		| *ID_Tessera*
nome utente		| *Nome*
cognome utente		| *Cognome*
data di registrazione	| *Data_Registrazione*
id tessera utenti	| *ID_Tessera_Utenti*
data di inizio		| *Data_Inizio*
data fine		| *Data_Fine*
