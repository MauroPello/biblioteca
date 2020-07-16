using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Biblioteca.Binder;
using System.Windows.Forms;

namespace Biblioteca.Interface
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
		}

        BinderBiblioteca Gestore = new BinderBiblioteca();


		/*DICHIARAZIONE VARIABILI*/

		//Panel
		Panel pnlDatabase;
		Panel pnlOpzioni;
		Panel pnlLibri;
		Panel pnlAutori;
		Panel pnlUtenti;
		Panel pnlCollocazioni;
		Panel pnlCategorie;
		Panel pnlPrestiti;
		Panel pnlRicerca;
		Panel pnlLibriAutore;
		Panel pnlLibriCollocazione;
		Panel pnlLibriCategoria;

		//Button
		Button btnDatabase;
		Button btnConferma;
		Button btnCambiaDatabase;
		//ComboBox
		ComboBox cmbDatabase;
		ComboBox cmbAzione;
		ComboBox cmbElemento;
		ComboBox cmbRicerca;
		//Label
		Label lblDatabase;
		Label lblAzione;
		Label lblElemento;
		Label lblRicerca;
		//Label Libri
		Label lblCodiceISBN;
		Label lblTitolo;
		Label lblLingua;
		Label lblEditore;
		Label lblData;
		//Label Categoria
		Label lblIdCategoria;
		Label lblCategoria;
		//Label Autori
		Label lblIdAutore;
		Label lblNomeAutore;
		Label lblCognomeAutore;
		Label lblDataNascita;
		Label lblLuogoNascita;
		//Label Utenti
		Label lblIdTessera;
		Label lblNomeUtente;
		Label lblCognomeUtente;
		Label lblDataRegistrazione;
		//Label Collocazioni
		Label lblIdCollocazioni;
		Label lblSezione;
		Label lblNumeroScaffale;
		Label lblNumeroPosto;
		Label lblQuantita;
		Label lblCollocazioniCodiceISBNLibri;
		//Label Prestiti
		Label lblIdPrestiti;
		Label lblCodiceISBNPrestiti;
		Label lblIdTesseraPrestiti;
		Label lblInizioPrestito;
		Label lblFinePrestito;
		//Label LibriAutore
		Label lblCodiceISBNLibriAutore;
		Label lblIdAutoreLibriAutore;
		//Label LibriCollocazione
		Label lblCodiceISBNLibriCollocazione;
		Label lblIdCollocazioneLibriCollocazione;
		//Label LibriCategoria
		Label lblCodiceISBNLibriCategoria;
		Label lblIdCategoriaLibriCategoria;
		//Label Ricerca
		Label lblCodiceISBNRicerca;
		Label lblNomeAutoreRicerca;
		Label lblCognomeAutoreRicerca;
		Label lblNomeCategoriaRicerca;
		Label lblIdTesseraRicerca;

		//TextBox Libri
		TextBox txtTitolo;
		TextBox txtLingua;
		TextBox txtEditore;
		//TextBox Categoria
		TextBox txtCategoria;
		//TextBox Autori
		TextBox txtNomeAutore;
		TextBox txtCognomeAutore;
		TextBox txtLuogoNascita;
		//TextBox Utenti
		TextBox txtNomeUtente;
		TextBox txtCognomeUtente;
		//TextBox Collocazioni
		TextBox txtSezione;
		//TextBox Ricerca
		TextBox txtNomeAutoreRicerca;
		TextBox txtCognomeAutoreRicerca;
		TextBox txtNomeCategoriaRicerca;

		//NumericUpDown Libri
		NumericUpDown nudCodiceISBN;
		//NumericUpDown Categorie
		NumericUpDown nudIdCategorie;
		//NumericUpDown Utenti
		NumericUpDown nudIdTessera;
		//NumericUpDown Autore
		NumericUpDown nudIdAutore;
 		//NumericUpDown Collocazioni
		NumericUpDown nudIdCollocazioni;
		NumericUpDown nudNumeroScaffale;
		NumericUpDown nudNumeroPosto;
		NumericUpDown nudQuantita;
		NumericUpDown nudCollocazioniCodiceISBNLibri;
		//NumericUpDown Prestiti
		NumericUpDown nudIdPrestiti;
		NumericUpDown nudCodiceISBNPrestiti;
		NumericUpDown nudIdTesseraPrestito;
		//NumericUpDown LibriAutore
		NumericUpDown nudCodiceISBNLibriAutore;
		NumericUpDown nudIdAutoreLibriAutore;
		//NumericUpDown LibriCollocazioni
		NumericUpDown nudCodiceISBNLibriCollocazioni;
		NumericUpDown nudIdCollocazioniLibriCollocazioni;
		//NumericUpDown LibriCategoria
		NumericUpDown nudCodiceISBNLibriCategoria;
		NumericUpDown nudIdCategoriaLibriCategoria;
		//NumericUpDown Ricerca
		NumericUpDown nudCodiceISBNRicerca;
		NumericUpDown nudIdTesseraRicerca;

		//DateTimePicker
		DateTimePicker dtpPubblicazione;
		DateTimePicker dtpDataNascitaAutore;
		DateTimePicker dtpDataRegistrazione;
		DateTimePicker dtpInizioPrestito;
		DateTimePicker dtpFinePrestito;

		//DataGridView
		DataGridView dgvElenco;
		DataGridView dgvRicerca;

		//CheckBox 
		CheckBox ckbData;

		bool controlloSeEsisteLibriCollocazioni = false;

		/*Lista per il riempimento della ComboBox azioni*/
		List<string> azioni = new List<string>
		{
			"Inserisci","Modifica","Visualizza Elenchi", "Elimina", "Ricerca"
		};
		/*Lista per il riempimento della ComboBox elementi*/
		List<string> elementi = new List<string>
		{
			"tmp"
		};
		/*Lista per il riempimento della ComboBox ricerca*/
		List<string> ricerche = new List<string>
		{
			"Collocazioni con Codice ISBN del Libro","Libri non restituti da più di 2 mesi","Libro più noleggiato per ogni utente", "Libro più noleggiato per ogni categoria", "Autori che hanno scritto libri di una categoria", "Autore preferito per ogni utente", "Libri di una categoria restituiti da un utente", "Libri scritti da un autore"
		};

		private void MainForm_Load(object sender, EventArgs e)
		{
			/*Lista dei nomi dei database*/
			List<string> nomiDatabase = Gestore.OttieniNomiDatabase();

			
			/*Size del Form*/
			Size = new Size(220, 200);

			/*Crea i Panel*/
			pnlDatabase = Crea_Panel("pnlDatabase", new Point(27, 37), new Size(150, 150), true);
			Controls.Add(pnlDatabase);
			pnlOpzioni = Crea_Panel("pnlOpzioni", new Point(12, 12), new Size(200, 110), false);
			Controls.Add(pnlOpzioni);
			pnlRicerca = Crea_Panel("pnlRicerca", new Point(214, 10), new Size(600, 500), false);
			Controls.Add(pnlRicerca);
			pnlLibri = Crea_Panel("pnlLibri", new Point(214, 10), new Size(400, 400), false);
			Controls.Add(pnlLibri);
			pnlAutori = Crea_Panel("pnlAutori", new Point(214, 10), new Size(400, 245), false);
			Controls.Add(pnlAutori);
			pnlUtenti = Crea_Panel("pnlUtenti", new Point(214, 10), new Size(400, 245), false);
			Controls.Add(pnlUtenti);
			pnlCollocazioni = Crea_Panel("pnlCollocazioni", new Point(214, 10), new Size(400, 295), false);
			Controls.Add(pnlCollocazioni);
			pnlCategorie = Crea_Panel("pnlCategorie", new Point(214, 10), new Size(400, 245), false);
			Controls.Add(pnlCategorie); 
			pnlPrestiti = Crea_Panel("pnlPrestiti", new Point(214, 10), new Size(400, 300), false);
			Controls.Add(pnlPrestiti);
			pnlLibriAutore = Crea_Panel("pnlLibriAutore", new Point(214, 10), new Size(400, 245), false);
			Controls.Add(pnlLibriAutore);
			pnlLibriCategoria = Crea_Panel("pnlLibriCategoria", new Point(214, 10), new Size(400, 245), false);
			Controls.Add(pnlLibriCategoria);
			pnlLibriCollocazione = Crea_Panel("pnlLibriCollocazione", new Point(214, 10), new Size(400, 245), false);
			Controls.Add(pnlLibriCollocazione);

			/*Crea i Bottoni*/
			btnDatabase = Crea_Bottoni("btnDatabase", new Point(25, 50), "SELEZIONA", 10, new Size(100, 30), true);
			btnDatabase.Click += new EventHandler(btnSeleziona_Click);
			pnlDatabase.Controls.Add(btnDatabase);
			btnConferma = Crea_Bottoni("btnConferma", new Point(40, 180), "CONFERMA", 10, new Size(121, 30), false);
			btnConferma.Click += new EventHandler(btnConferma_Click);
			Controls.Add(btnConferma);
			btnCambiaDatabase = Crea_Bottoni("btnCambiaDatabase", new Point(40, 130), "CAMBIA DATABASE", 10, new Size(121, 45), false);
			btnCambiaDatabase.Click += new EventHandler(btnCambiaDatabase_Click);
			Controls.Add(btnCambiaDatabase);

			/*Crea le ComboBox*/
			cmbDatabase = Crea_Combo("cmbDatabase", new Point(0, 20), 10, new Size(147,80), nomiDatabase);
			pnlDatabase.Controls.Add(cmbDatabase);
			cmbAzione = Crea_Combo("cmbAzione", new Point(15, 85), 10, new Size(147, 80), azioni);
			cmbAzione.SelectedIndexChanged += new EventHandler(CambiamentoIndiceComboBox);
			pnlOpzioni.Controls.Add(cmbAzione);
			cmbElemento = Crea_Combo("cmbElemento", new Point(15, 25), 10, new Size(147, 80), elementi);
			cmbElemento.SelectedIndexChanged += new EventHandler(CambiamentoIndiceComboBox);
			pnlOpzioni.Controls.Add(cmbElemento);
			cmbRicerca = Crea_Combo("cmbRicerca", new Point(38, 30), 10, new Size(300, 80), ricerche);
			cmbRicerca.SelectedIndexChanged += new EventHandler(CambiamentoIndiceComboBox);
			pnlRicerca.Controls.Add(cmbRicerca);

			/*Crea le Label*/
			lblDatabase = Crea_Label("lblDatabase", new Point(0, 0), 10,"Selezionare Database", new Size(150,20), true);
			pnlDatabase.Controls.Add(lblDatabase);
			lblAzione = Crea_Label("lblAzione", new Point(12, 65), 10, "Selezionare Azione:", new Size(150, 20), true);
			pnlOpzioni.Controls.Add(lblAzione);
			lblElemento = Crea_Label("lblElemento", new Point(12, 6), 10, "Selezionare Elemento:", new Size(150, 20), true);
			pnlOpzioni.Controls.Add(lblElemento);
			lblRicerca = Crea_Label("lblRicerca", new Point(125, 6), 10, "Selezionare Ricerca:", new Size(150, 20), true);
			pnlRicerca.Controls.Add(lblRicerca);
			//Label Libri
			lblCodiceISBN = Crea_Label("lblCodiceISBN", new Point(20, 20), 10, "Codice ISBN:", new Size(150, 20), true);
			pnlLibri.Controls.Add(lblCodiceISBN);
			lblTitolo = Crea_Label("lblTitolo", new Point(20, 70), 10, "Titolo:", new Size(150, 20), true);
			pnlLibri.Controls.Add(lblTitolo);
			lblLingua = Crea_Label("lblLingua", new Point(20, 120), 10, "Lingua:", new Size(150, 20), true);
			pnlLibri.Controls.Add(lblLingua);
			lblEditore = Crea_Label("lblEditore", new Point(20, 170), 10, "Editore:", new Size(150, 20), true);
			pnlLibri.Controls.Add(lblEditore);
			lblData = Crea_Label("lblData", new Point(20, 220), 10, "Data di pubblicazione:", new Size(150, 20), true);
			pnlLibri.Controls.Add(lblData);
			//Label Categoria
			lblIdCategoria = Crea_Label("lblIdCategoria", new Point(20, 20), 10, "Id Categoria:", new Size(150, 20), true);
			pnlCategorie.Controls.Add(lblIdCategoria);
			lblCategoria = Crea_Label("lblCategoria", new Point(20, 70), 10, "Nome Categoria:", new Size(150, 20), true);
			pnlCategorie.Controls.Add(lblCategoria);
			//Label Autori
			lblIdAutore = Crea_Label("lblIdAutore", new Point(20, 20), 10, "Id Autore:", new Size(150, 20), true);
			pnlAutori.Controls.Add(lblIdAutore);
			lblNomeAutore = Crea_Label("lblNomeAutore", new Point(20, 70), 10, "Nome Autore:", new Size(150, 20), true);
			pnlAutori.Controls.Add(lblNomeAutore);
			lblCognomeAutore = Crea_Label("lblCognomeAutore", new Point(20, 120), 10, "Cognome Autore:", new Size(150, 20), true);
			pnlAutori.Controls.Add(lblCognomeAutore);
			lblDataNascita = Crea_Label("lblDataNascita", new Point(20, 170), 10, "Data di Nascita:", new Size(150, 20), true);
			pnlAutori.Controls.Add(lblDataNascita);
			lblLuogoNascita = Crea_Label("lblLuogoNascita", new Point(20, 220), 10, "Luogo di Nascita:", new Size(150, 20), true);
			pnlAutori.Controls.Add(lblLuogoNascita);
			//Label Utenti
			lblIdTessera = Crea_Label("lblIdTessera", new Point(20, 20), 10, "Id Tessera:", new Size(150, 20), true);
			pnlUtenti.Controls.Add(lblIdTessera);
			lblNomeUtente = Crea_Label("lblNomeUtente", new Point(20, 70), 10, "Nome Utente:", new Size(150, 20), true);
			pnlUtenti.Controls.Add(lblNomeUtente);
			lblCognomeUtente = Crea_Label("lblCognomeUtente", new Point(20, 120), 10, "Cognome Utente:", new Size(150, 20), true);
			pnlUtenti.Controls.Add(lblCognomeUtente);
			lblDataRegistrazione = Crea_Label("lblDataRegistrazione", new Point(20, 165), 10, "Data di Registrazione:", new Size(150, 20), true);
			pnlUtenti.Controls.Add(lblDataRegistrazione);
			//Label Collocazioni
			lblIdCollocazioni = Crea_Label("lblIdCollocazioni", new Point(20, 20), 10, "Id Collocazione:", new Size(150, 20), true);
			pnlCollocazioni.Controls.Add(lblIdCollocazioni);
			lblSezione = Crea_Label("lblSezione", new Point(20, 70), 10, "Sezione:", new Size(150, 20), true);
			pnlCollocazioni.Controls.Add(lblSezione);
			lblNumeroScaffale = Crea_Label("lblNumeroScaffale", new Point(20, 120), 10, "Numero Scaffale:", new Size(150, 20), true);
			pnlCollocazioni.Controls.Add(lblNumeroScaffale);
			lblNumeroPosto = Crea_Label("lblNumeroPosto", new Point(20, 170), 10, "Numero Posto:", new Size(150, 20), true);
			pnlCollocazioni.Controls.Add(lblNumeroPosto);
			lblQuantita = Crea_Label("lblQuantita", new Point(20, 220), 10, "N° Libri:", new Size(150, 20), true);
			pnlCollocazioni.Controls.Add(lblQuantita);
			lblCollocazioniCodiceISBNLibri = Crea_Label("lblCollocazioniCodiceISBNLibri", new Point(20, 270), 10, "CodiceISBN:", new Size(150, 20), true);
			//Label Prestiti
			lblIdPrestiti = Crea_Label("lblIdPrestiti", new Point(20, 20), 10, "Id Prestito:", new Size(150, 20), true);
			pnlPrestiti.Controls.Add(lblIdPrestiti);
			lblCodiceISBNPrestiti = Crea_Label("lblCodiceISBNPrestiti", new Point(20, 70), 10, "Codice ISBN:", new Size(150, 20), true);
			pnlPrestiti.Controls.Add(lblCodiceISBNPrestiti);
			lblIdTesseraPrestiti = Crea_Label("lblIdTesseraPrestiti", new Point(20, 120), 10, "ID Tessera:", new Size(150, 20), true);
			pnlPrestiti.Controls.Add(lblIdTesseraPrestiti);
			lblInizioPrestito = Crea_Label("lblInizioPrestito", new Point(20, 165), 10, "Inizio Prestito:", new Size(150, 20), true);
			pnlPrestiti.Controls.Add(lblInizioPrestito);
			lblFinePrestito = Crea_Label("lblFinePrestito", new Point(20, 250), 10, "Fine Prestito:", new Size(150, 20), false);
			pnlPrestiti.Controls.Add(lblFinePrestito);
			//Label LibriAutori
			lblCodiceISBNLibriAutore = Crea_Label("lblCodiceISBNLibriAutore", new Point(20, 20), 10, "Codice ISBN:", new Size(150, 20), true);
			pnlLibriAutore.Controls.Add(lblCodiceISBNLibriAutore);
			lblIdAutoreLibriAutore = Crea_Label("lblIdAutoreLibriAutore", new Point(20, 70), 10, "Id Autore:", new Size(150, 20), true);
			pnlLibriAutore.Controls.Add(lblIdAutoreLibriAutore);
			//Label LibriCollocazione
			lblCodiceISBNLibriCollocazione = Crea_Label("lblCodiceISBNLibriCollocazione", new Point(20, 20), 10, "Codice ISBN:", new Size(150, 20), true);
			pnlLibriCollocazione.Controls.Add(lblCodiceISBNLibriCollocazione);
			lblIdCollocazioneLibriCollocazione = Crea_Label("lblIdCollocazioneLibriCollocazione", new Point(20, 70), 10, "Id Collocazione:", new Size(150, 20), true);
			pnlLibriCollocazione.Controls.Add(lblIdCollocazioneLibriCollocazione);
			//Label LibriCategoria
			lblCodiceISBNLibriCategoria = Crea_Label("lblCodiceISBNLibriCategoria", new Point(20, 20), 10, "Codice ISBN:", new Size(150, 20), true);
			pnlLibriCategoria.Controls.Add(lblCodiceISBNLibriCategoria);
			lblIdCategoriaLibriCategoria = Crea_Label("lblIdCategoriaLibriCategoria", new Point(20, 70), 10, "Id Categoria:", new Size(150, 20), true);
			pnlLibriCategoria.Controls.Add(lblIdCategoriaLibriCategoria);
			//Label Ricerca
			lblCodiceISBNRicerca = Crea_Label("lblCodiceISBNRicerca", new Point(20, 80), 10, "Codice ISBN:", new Size(150, 20), true);
			pnlRicerca.Controls.Add(lblCodiceISBNRicerca);
			lblNomeAutoreRicerca = Crea_Label("lblNomeAutoreRicerca", new Point(20, 80), 10, "Nome Autore:", new Size(150, 20), true);
			pnlRicerca.Controls.Add(lblNomeAutoreRicerca);
			lblNomeCategoriaRicerca = Crea_Label("lblNomeCategoriaRicerca", new Point(20, 80), 10, "Nome Categoria:", new Size(150, 20), true);
			pnlRicerca.Controls.Add(lblNomeCategoriaRicerca);
			lblIdTesseraRicerca = Crea_Label("lblIdTesseraRicerca", new Point(20, 110), 10, "Id Tessera:", new Size(150, 20), true);
			pnlRicerca.Controls.Add(lblIdTesseraRicerca);
			lblCognomeAutoreRicerca = Crea_Label("lblCognomeAutoreRicerca", new Point(20, 110), 10, "Cognome Autore:", new Size(150, 20), true);
			pnlRicerca.Controls.Add(lblCognomeAutoreRicerca);

			/*Crea le TextBox*/
			//TextBox Libri
			txtTitolo = Crea_Textbox("txtTitolo", new Point(230, 65), 10, new Size(121, 23), true);
			pnlLibri.Controls.Add(txtTitolo);
			txtLingua = Crea_Textbox("txtLingua", new Point(230, 115), 10, new Size(121, 23), true);
			pnlLibri.Controls.Add(txtLingua);
			txtEditore = Crea_Textbox("txtEditore", new Point(230, 165), 10, new Size(121, 23), true);
			pnlLibri.Controls.Add(txtEditore);
			//TextBox Categoria
			txtCategoria = Crea_Textbox("txtCategoria", new Point(230, 65), 10, new Size(121, 23), true);
			pnlCategorie.Controls.Add(txtCategoria);
			//TextBox Autori
			txtNomeAutore = Crea_Textbox("txtNomeAutore", new Point(230, 65), 10, new Size(121, 23), true);
			pnlAutori.Controls.Add(txtNomeAutore);
			txtCognomeAutore = Crea_Textbox("txtCognomeAutore", new Point(230, 115), 10, new Size(121, 23), true);
			pnlAutori.Controls.Add(txtCognomeAutore);
			txtLuogoNascita = Crea_Textbox("txtLuogoNascita", new Point(230, 215), 10, new Size(121, 23), true);
			pnlAutori.Controls.Add(txtLuogoNascita);
			//TextBox Utenti
			txtNomeUtente = Crea_Textbox("txtNomeUtente", new Point(230, 65), 10, new Size(121, 23), true);
			pnlUtenti.Controls.Add(txtNomeUtente);
			txtCognomeUtente = Crea_Textbox("txtCognomeUtente", new Point(230, 115), 10, new Size(121, 23), true);
			pnlUtenti.Controls.Add(txtCognomeUtente);
			//TextBox Collocazioni
			txtSezione = Crea_Textbox("txtSezione", new Point(230, 65), 10, new Size(121, 23), true);
			pnlCollocazioni.Controls.Add(txtSezione);
			//TextBox Ricerca
			txtNomeAutoreRicerca = Crea_Textbox("txtNomeAutoreRicerca", new Point(230, 75), 10, new Size(121, 23), true);
			pnlRicerca.Controls.Add(txtNomeAutoreRicerca);
			txtNomeCategoriaRicerca = Crea_Textbox("txtNomeCategoriaRicerca", new Point(230, 75), 10, new Size(121, 23), true);
			pnlRicerca.Controls.Add(txtNomeCategoriaRicerca);
			txtCognomeAutoreRicerca = Crea_Textbox("txtCognomeAutoreRicerca", new Point(230, 105), 10, new Size(121, 23), true);
			pnlRicerca.Controls.Add(txtCognomeAutoreRicerca);

			/*Crea i DataTimePicker*/
			//DataTimePicker Libri
			dtpPubblicazione = Crea_DataTimePicker("dtpPubblicazione", new Point(230, 215), new Size(121, 23), true);
			pnlLibri.Controls.Add(dtpPubblicazione);
			//DataTimePicker Autori
			dtpDataNascitaAutore = Crea_DataTimePicker("dtpDataNascitaAutore", new Point(230, 165), new Size(121, 23), true);
			pnlAutori.Controls.Add(dtpDataNascitaAutore);
			//DataTimePicker Utenti
			dtpDataRegistrazione = Crea_DataTimePicker("dtpDataRegistrazione", new Point(230, 165), new Size(121, 23), true);
			pnlUtenti.Controls.Add(dtpDataRegistrazione);
			//DataTimePicker Prestito
			dtpInizioPrestito = Crea_DataTimePicker("dtpInizioPrestito", new Point(230, 165), new Size(121, 23), true);
			pnlPrestiti.Controls.Add(dtpInizioPrestito);
			dtpFinePrestito = Crea_DataTimePicker("dtpFinePrestito", new Point(230, 250), new Size(121, 23), false);
			pnlPrestiti.Controls.Add(dtpFinePrestito);

			/*Crea i NumericUpDown*/
			//NumericUpDown Libri
			nudCodiceISBN = Crea_NumericUpDown("nudCodiceISBN", new Point(230, 15), 10, true);
			pnlLibri.Controls.Add(nudCodiceISBN);
			//NumericUpDown Categoria
			nudIdCategorie = Crea_NumericUpDown("nudIdCategorie", new Point(230, 15), 10, true);
			pnlCategorie.Controls.Add(nudIdCategorie);
			//NumericUpDown Autori
			nudIdAutore = Crea_NumericUpDown("nudIdAutore", new Point(230, 15), 10, true);
			pnlAutori.Controls.Add(nudIdAutore);
			//NumericUpDown Utenti
			nudIdTessera = Crea_NumericUpDown("nudIdTessera", new Point(230, 15), 10, true);
			pnlUtenti.Controls.Add(nudIdTessera);
			//NumericUpDown Collocazioni
			nudIdCollocazioni = Crea_NumericUpDown("nudIdCollocazioni", new Point(230, 15), 10, true);
			pnlCollocazioni.Controls.Add(nudIdCollocazioni);
			nudNumeroScaffale = Crea_NumericUpDown("nudNumeroScaffale", new Point(230, 115), 10, true);
			pnlCollocazioni.Controls.Add(nudNumeroScaffale);
			nudNumeroPosto = Crea_NumericUpDown("nudNumeroPosto", new Point(230, 165), 10, true);
			pnlCollocazioni.Controls.Add(nudNumeroPosto);
			nudQuantita = Crea_NumericUpDown("nudQuantita", new Point(230, 215), 10, true);
			pnlCollocazioni.Controls.Add(nudQuantita);
			nudCollocazioniCodiceISBNLibri = Crea_NumericUpDown("nudCollocazioniCodiceISBNLibri", new Point(230, 265), 10, true);
			//NumericUpDown Prestito
			nudIdPrestiti = Crea_NumericUpDown("nudIdPrestiti", new Point(230, 15), 10, true);
			pnlPrestiti.Controls.Add(nudIdPrestiti);
			nudCodiceISBNPrestiti = Crea_NumericUpDown("nudCodiceISBNPrestito", new Point(230, 65), 10, true);
			pnlPrestiti.Controls.Add(nudCodiceISBNPrestiti);
			nudIdTesseraPrestito = Crea_NumericUpDown("nudIdTesseraPrestito", new Point(230, 115), 10, true);
			pnlPrestiti.Controls.Add(nudIdTesseraPrestito);
			//NumericUpDown LibroAutore
			nudCodiceISBNLibriAutore = Crea_NumericUpDown("nudCodiceISBNLibriAutore", new Point(230, 15), 10, true);
			pnlLibriAutore.Controls.Add(nudCodiceISBNLibriAutore);
			nudIdAutoreLibriAutore = Crea_NumericUpDown("nudIdAutoreLibriAutore", new Point(230, 65), 10, true);
			pnlLibriAutore.Controls.Add(nudIdAutoreLibriAutore);
			//NumericUpDown LibroCollocazione
			nudCodiceISBNLibriCollocazioni = Crea_NumericUpDown("nudCodiceISBNLibriCollocazioni", new Point(230, 15), 10, true);
			pnlLibriCollocazione.Controls.Add(nudCodiceISBNLibriCollocazioni);
			nudIdCollocazioniLibriCollocazioni = Crea_NumericUpDown("nudIdCollocazioniLibriCollocazioni", new Point(230, 65), 10, true);
			pnlLibriCollocazione.Controls.Add(nudIdCollocazioniLibriCollocazioni);
			//NumericUpDown LibroCategoria
			nudCodiceISBNLibriCategoria = Crea_NumericUpDown("nudCodiceISBNLibriCategoria", new Point(230, 15), 10, true);
			pnlLibriCategoria.Controls.Add(nudCodiceISBNLibriCategoria);
			nudIdCategoriaLibriCategoria = Crea_NumericUpDown("nudIdCategoriaLibriCategoria", new Point(230, 65), 10, true);
			pnlLibriCategoria.Controls.Add(nudIdCategoriaLibriCategoria);
			//NumericUpDown Ricerca
			nudCodiceISBNRicerca = Crea_NumericUpDown("nudCodiceISBNRicerca", new Point(230, 75), 10, true);
			pnlRicerca.Controls.Add(nudCodiceISBNRicerca);
			nudIdTesseraRicerca = Crea_NumericUpDown("nudIdTesseraRicerca", new Point(230, 105), 10, true);
			pnlRicerca.Controls.Add(nudIdTesseraRicerca);

			/*Crea i DataGridView*/
			//DataGridView Libri
			dgvElenco = Crea_DataGridView("dgvElenco", new Point(220, 12), new Size(503, 220), false);
			dgvElenco.RowHeadersVisible = false;
			dgvElenco.ReadOnly = true;
			Controls.Add(dgvElenco);
			//DataGridView Ricerca
			dgvRicerca = Crea_DataGridView("dgvRicerca", new Point(0,110), new Size(503, 220), true);
			dgvRicerca.RowHeadersVisible = false;
			dgvRicerca.ReadOnly = true;
			pnlRicerca.Controls.Add(dgvRicerca);

			/*Crea le CheckBox*/
			//CheckBox Prestito
			ckbData = Crea_CheckBox("ckbData", "Consegnato", new Point(230, 150), 10, true);
			ckbData.CheckedChanged += ckbPrestito_CheckedChanged;
			pnlPrestiti.Controls.Add(ckbData);
		}

		/*Metodo per la creazione dei DataTimePicker*/
		private DateTimePicker Crea_DataTimePicker(string name, Point punto, Size dimensioni, bool visibile)
		{
			DateTimePicker dtp = new DateTimePicker
			{
				Name = name,
				Location = punto,
				Size = dimensioni,
				Format = DateTimePickerFormat.Short,
				Visible = visibile,
			};
			return dtp;
		}

		/*Metodo per la creazione dei Panel*/
		private Panel Crea_Panel(string name, Point punto, Size dimensioni, bool visibile)
		{
			Panel pnl = new Panel
			{
				Name = name,
				Location = punto,
				Size = dimensioni,
				Visible = visibile,
			};
			return pnl;
		}

		/*Metodo per la creazione dei Bottoni*/
		private Button Crea_Bottoni(string name, Point punto, string text, int fontSize, Size dimensioni, bool visibile)
		{
			Button btn = new Button
			{
				Name = name,
				Location = punto,
				Text = text,
				Font = new Font(Font.FontFamily, fontSize),
				Size = dimensioni,
				Visible = visibile,
			};
			return btn;
		}

		/*Metodo per la creazione dei Combo*/
		private ComboBox Crea_Combo(string name, Point punto, int fontSize, Size dimensioni, List<string> nomi)
		{
			ComboBox cmb = new ComboBox
			{
				Name = name,
				Location = punto,
				Font = new Font(Font.FontFamily, fontSize),
				Size = dimensioni,
				DropDownStyle = ComboBoxStyle.DropDownList,
			};
			for (int i = 0; i < nomi.Count; i++)
			{
				cmb.Items.Add(nomi.ElementAt(i));
			}
			cmb.SelectedIndex = 0;
			return cmb;
		}

		/*Metodo per la creazione dei Label*/
		private Label Crea_Label(string name, Point punto, int fontSize, string text, Size dimensione, bool visibile)
		{
			Label lbl = new Label
			{
				Name = name,
				Location = punto,
				Font = new Font(Font.FontFamily, fontSize),
				Text = text,
				Size = dimensione,
				Visible = visibile,
			};
			return lbl;
		}

		/*Metodo per la creazione dei TextBox*/
		private TextBox Crea_Textbox(string name, Point punto, int fontSize, Size dimensione, bool visibile)
		{
			TextBox txt = new TextBox()
			{
				Name = name,
				Location = punto,
				Font = new Font(Font.FontFamily, fontSize),
				Size = dimensione,
				Visible = visibile,
			};
			return txt;
		}

		/*Metodo per la creazione dei NumericUpDown*/
		private NumericUpDown Crea_NumericUpDown(string name, Point punto, int fontSize, bool visibile)
		{
			NumericUpDown nud = new NumericUpDown()
			{
				Name = name,
				Location = punto,
				Font = new Font(Font.FontFamily, fontSize),
				Visible = visibile,
			};
			return nud;
		}

		/*Metodo per la creazione dei DataGridView*/
		private DataGridView Crea_DataGridView(string name, Point punto, Size dimensioni, bool visibile)
		{
			DataGridView dgv = new DataGridView()
			{
				Name = name,
				Location = punto,
				Visible = visibile,
				Size = dimensioni,
			};
			return dgv;
		}

		/*Metodo per la creazione dei CheckBox*/
		private CheckBox Crea_CheckBox(string nome, string testo, Point punto, int fontSize, bool visibile)
		{
			CheckBox ckb = new CheckBox()
			{
				Name = nome,
				Text = testo,
				Location = punto,
				Font = new Font(Font.FontFamily, fontSize),
				Visible = visibile,
			};
			return ckb;
		}

		/*Metodo che controlla il CheckedChange*/
		private void ckbPrestito_CheckedChanged(object sender, EventArgs e)
		{
			if (ckbData.Checked)
			{
				lblFinePrestito.Visible = true;
				dtpFinePrestito.Visible = true;
			}
			else
			{
				lblFinePrestito.Visible = false;
				dtpFinePrestito.Visible = false;
			}
		}

		private void btnSeleziona_Click(object sender, EventArgs e)
		{
			Gestore.CollegaDatabase(cmbDatabase.Text); //Collega il database selezionato dall'utente
			elementi = Gestore.OttieniNomiTabelle(); //Prende gli elementi da aggiungere alla ComboBox

			controlloSeEsisteLibriCollocazioni = ControlloEsistenzaRelazione("libricollocazioni");
			if (controlloSeEsisteLibriCollocazioni)
			{
				pnlCollocazioni.Controls.Remove(lblCollocazioniCodiceISBNLibri);
				pnlCollocazioni.Controls.Remove(nudCollocazioniCodiceISBNLibri);
			}
			else
			{
				pnlCollocazioni.Controls.Add(lblCollocazioniCodiceISBNLibri);
				pnlCollocazioni.Controls.Add(nudCollocazioniCodiceISBNLibri);
			}

			cmbElemento.Items.Clear(); 
			cmbElemento.Items.AddRange(elementi.ToArray()); //Aggiunge gli elementi alla ComboBox
			cmbElemento.SelectedIndex = 0;

			pnlDatabase.Visible = false;

			pnlOpzioni.Visible = true;
			btnCambiaDatabase.Visible = true;
			btnConferma.Visible = true;
		}

		private void btnCambiaDatabase_Click(object sender, EventArgs e)
		{
			Gestore.ChiudiDatabase();

			Size = new Size(220, 200);

			pnlDatabase.Visible = true;

			pnlOpzioni.Visible = false;
			btnCambiaDatabase.Visible = false;
			btnConferma.Visible = false;
		}
			
		private bool ControlloEsistenzaRelazione (string relazione)
		{
			bool result = false;
			for (int i = 0; i < elementi.Count; i++)
				result = result || elementi.ElementAt(i).ToLower().Replace(" ", string.Empty).Contains(relazione);
			return result;
		}

		/*Metodo per aggiornare la parte visuale quando si cambia gli indici delle ComboBox*/
		private void CambiamentoIndiceComboBox(object sender, EventArgs e)
		{
			AggiornaVista(cmbElemento.Text, cmbAzione.Text, cmbRicerca.SelectedIndex);
		}

		private void btnConferma_Click(object sender, EventArgs e)
		{
			switch (cmbAzione.Text)
			{
				case "Inserisci":
					switch (cmbElemento.Text.ToLower().Replace(" ", string.Empty))
					{
						case "libri": //Inserisce il libro
							MessageBox.Show(Gestore.Inserimento_Libro(Convert.ToInt32(nudCodiceISBN.Value), txtTitolo.Text, txtLingua.Text, txtEditore.Text, dtpPubblicazione.Value.ToString("yyyyMMdd")));
							break;
						case "categorie": //Inserisce la categoria
							MessageBox.Show(Gestore.Inserimento_Categoria(txtCategoria.Text));
							break;
						case "collocazioni": //Inserisce la collocazione
							if (controlloSeEsisteLibriCollocazioni) //Controllo per verificare se nel database è presente la tabella libri-collocazione
								MessageBox.Show(Gestore.Inserimento_Collocazione(txtSezione.Text, Convert.ToInt32(nudNumeroScaffale.Value), Convert.ToInt32(nudNumeroPosto.Value), Convert.ToInt32(nudQuantita.Value), 0));
							else
								MessageBox.Show(Gestore.Inserimento_Collocazione(txtSezione.Text, Convert.ToInt32(nudNumeroScaffale.Value), Convert.ToInt32(nudNumeroPosto.Value), Convert.ToInt32(nudQuantita.Value), Convert.ToInt32(nudCollocazioniCodiceISBNLibri.Value)));
							break;
						case "autori": //Inserisce autore
							MessageBox.Show(Gestore.Inserimento_Autore(txtNomeAutore.Text, txtCognomeAutore.Text, dtpDataNascitaAutore.Value.ToString("yyyyMMdd"), txtLuogoNascita.Text));
							break;
						case "utenti": //Inserisce utente
							MessageBox.Show(Gestore.Inserimento_Utente(txtNomeUtente.Text, txtCognomeUtente.Text, dtpDataRegistrazione.Value.ToString("yyyyMMdd")));
							break;
						case "prestiti": //Inserisce prestito
							if (ckbData.Checked) //Verifica il Checked della CheckBox
								if (dtpInizioPrestito.Value < dtpFinePrestito.Value) //Verifica la coerenza della data
									MessageBox.Show(Gestore.Inserimento_Prestito(Convert.ToInt32(nudCodiceISBNPrestiti.Value), Convert.ToInt32(nudIdTesseraPrestito.Value), dtpInizioPrestito.Value.ToString("yyyyMMdd"), dtpFinePrestito.Value.ToString("yyyyMMdd")));
								else
									MessageBox.Show("La data di fine del prestito deve essere dopo quella dell'inizio");
							else
								MessageBox.Show(Gestore.Inserimento_Prestito(Convert.ToInt32(nudCodiceISBNPrestiti.Value), Convert.ToInt32(nudIdTesseraPrestito.Value), dtpInizioPrestito.Value.ToString("yyyyMMdd"), "NULL"));

							break;
						case "libriautori": //Inserisce la combinazione libri-autori
							MessageBox.Show(Gestore.Inserimento_LibriAutori(Convert.ToInt32(nudCodiceISBNLibriAutore.Value), Convert.ToInt32(nudIdAutoreLibriAutore.Value)));
							break;
						case "libricategorie": //Inserisce la combinazione libri-categorie
							MessageBox.Show(Gestore.Inserimento_LibriCategorie(Convert.ToInt32(nudCodiceISBNLibriCategoria.Value), Convert.ToInt32(nudIdCategoriaLibriCategoria.Value)));
							break;
						case "libricollocazioni": //Inserisce la combinazione libri-collocazioni
							if (controlloSeEsisteLibriCollocazioni) //Controllo per verificare se nel database è presente la tabella libri-collocazione
								MessageBox.Show(Gestore.Inserimento_LibriCollocazioni(Convert.ToInt32(nudCodiceISBNLibriCollocazioni.Value), Convert.ToInt32(nudIdCollocazioniLibriCollocazioni.Value)));
							break;
						default:
							break;
					}
					break;
				case "Modifica": //Modifica
					switch (cmbElemento.Text.ToLower().Replace(" ", string.Empty))
					{
						case "libri": //Modifica i libri
							MessageBox.Show(Gestore.Modifica_Libro(Convert.ToInt32(nudCodiceISBN.Value), txtTitolo.Text, txtLingua.Text, txtEditore.Text, dtpPubblicazione.Value.ToString("yyyyMMdd")));
							break;
						case "categorie": //Modifica le categorie
							MessageBox.Show(Gestore.Modifica_Categoria(Convert.ToInt32(nudIdCategorie.Value), txtCategoria.Text));
							break;
						case "collocazioni": //Modifica le collocazioni
							if (controlloSeEsisteLibriCollocazioni) //Controllo per verificare se nel database è presente la tabella libri-collocazione
								MessageBox.Show(Gestore.Modifica_Collocazione(Convert.ToInt32(nudIdCollocazioni.Value), txtSezione.Text, Convert.ToInt32(nudNumeroScaffale.Value), Convert.ToInt32(nudNumeroPosto.Value), Convert.ToInt32(nudQuantita.Value), 0));
							else
								MessageBox.Show(Gestore.Modifica_Collocazione(Convert.ToInt32(nudIdCollocazioni.Value), txtSezione.Text, Convert.ToInt32(nudNumeroScaffale.Value), Convert.ToInt32(nudNumeroPosto.Value), Convert.ToInt32(nudQuantita.Value), Convert.ToInt32(nudCollocazioniCodiceISBNLibri.Value)));
							break;
						case "autori": //Modifica gli autori
							MessageBox.Show(Gestore.Modifica_Autore(Convert.ToInt32(nudIdAutore.Value), txtNomeAutore.Text, txtCognomeAutore.Text, dtpDataNascitaAutore.Value.ToString("yyyyMMdd"), txtLuogoNascita.Text));
							break;
						case "utenti": //Modifica gli utenti
							MessageBox.Show(Gestore.Modifica_Utente(Convert.ToInt32(nudIdTessera.Value), txtNomeUtente.Text, txtCognomeUtente.Text, dtpDataRegistrazione.Value.ToString("yyyyMMdd")));
							break;
						case "prestiti": //Modifica i prestiti
							if (ckbData.Checked) //Verifica il Checked della CheckBox
								if (dtpInizioPrestito.Value < dtpFinePrestito.Value) //Verifica la coerenza della data
									MessageBox.Show(Gestore.Modifica_Prestito(Convert.ToInt32(nudIdPrestiti.Value), Convert.ToInt32(nudCodiceISBNPrestiti.Value), Convert.ToInt32(nudIdTesseraPrestito.Value), dtpInizioPrestito.Value.ToString("yyyyMMdd"), dtpFinePrestito.Value.ToString("yyyyMMdd")));
								else
									MessageBox.Show("La data di fine del prestito deve essere dopo quella dell'inizio");
							else
								MessageBox.Show(Gestore.Modifica_Prestito(Convert.ToInt32(nudIdPrestiti.Value), Convert.ToInt32(nudCodiceISBNPrestiti.Value), Convert.ToInt32(nudIdTesseraPrestito.Value), dtpInizioPrestito.Value.ToString("yyyyMMdd"), "NULL"));
							break;
						default:
							break;
					}
					break;
				case "Visualizza Elenchi": //Visualizza Elenchi
					switch (cmbElemento.Text.ToLower().Replace(" ", string.Empty))
					{
						case "libri": //Visualizza Elenchi dei libri
							dgvElenco.DataSource = Gestore.VisualizzaElenco_Libri().DefaultView;
							break;
						case "categorie": //Visualizza Elenchi delle categorie
							dgvElenco.DataSource = Gestore.VisualizzaElenco_Categorie().DefaultView;
							break;
						case "collocazioni": //Visualizza Elenchi delle collocazioni
							dgvElenco.DataSource = Gestore.VisualizzaElenco_Collocazioni().DefaultView;
							break;
						case "autori": //Visualizza Elenchi degli autori
							dgvElenco.DataSource = Gestore.VisualizzaElenco_Autori().DefaultView;
							break;
						case "utenti": //Visualizza Elenchi degli utenti
							dgvElenco.DataSource = Gestore.VisualizzaElenco_Utenti().DefaultView;
							break;
						case "prestiti": //Visualizza Elenchi dei prestiti
							dgvElenco.DataSource = Gestore.VisualizzaElenco_Prestiti().DefaultView;
							break;
						case "libriautori": //Visualizza Elenchi dei libri-autori
							dgvElenco.DataSource = Gestore.VisualizzaElenco_LibriAutori().DefaultView;
							break;
						case "libricategorie": //Visualizza Elenchi dei libri-categorie
							dgvElenco.DataSource = Gestore.VisualizzaElenco_LibriCategorie().DefaultView;
							break;
						case "libricollocazioni": //Visualizza Elenchi dei libri-collocazinoni
							if (controlloSeEsisteLibriCollocazioni) //Controllo per verificare se nel database è presente la tabella libri-collocazione
								dgvElenco.DataSource = Gestore.VisualizzaElenco_LibriCollocazioni().DefaultView;
							break;
						default:
							break;
					}
					break;
				case "Elimina": //Elimina
					switch (cmbElemento.Text.ToLower().Replace(" ", string.Empty))
					{
						case "libri": //Elimina i libri
							MessageBox.Show(Gestore.Elimina_Libro(Convert.ToInt32(nudCodiceISBN.Value)));
							break;
						case "categorie": //Elimina le categorie
							MessageBox.Show(Gestore.Elimina_Categoria(Convert.ToInt32(nudIdCategorie.Value)));
							break;
						case "collocazioni": //Elimina le collocazioni
							MessageBox.Show(Gestore.Elimina_Collocazione(Convert.ToInt32(nudIdCollocazioni.Value)));
							break;
						case "autori": //Elimina gli autori
							MessageBox.Show(Gestore.Elimina_Autore(Convert.ToInt32(nudIdAutore.Value)));
							break; 
						case "utenti": //Elimina gli utenti
							MessageBox.Show(Gestore.Elimina_Utente(Convert.ToInt32(nudIdTessera.Value)));
							break;
						case "prestiti": //Elimina i prestiti
							MessageBox.Show(Gestore.Elimina_Prestito(Convert.ToInt32(nudIdPrestiti.Value)));
							break;
						case "libriautori": //Elimina i libri-autori
							MessageBox.Show(Gestore.Elimina_LibriAutori(Convert.ToInt32(nudCodiceISBNLibriAutore.Value), Convert.ToInt32(nudIdAutoreLibriAutore.Value)));
							break;
						case "libricategorie": //Elimina i libri-categorie
							MessageBox.Show(Gestore.Elimina_LibriCategorie(Convert.ToInt32(nudCodiceISBNLibriCategoria.Value), Convert.ToInt32(nudIdCategoriaLibriCategoria.Value)));
							break;
						case "libricollocazioni": //Elimina i libri-collocazioni
							if (controlloSeEsisteLibriCollocazioni) //Controllo per verificare se nel database è presente la tabella libri-collocazione
								MessageBox.Show(Gestore.Elimina_LibriCollocazioni(Convert.ToInt32(nudCodiceISBNLibriCollocazioni.Value), Convert.ToInt32(nudIdCollocazioniLibriCollocazioni.Value)));
							break;
						default:
							break;
					}
					break;
				case "Ricerca": //Ricerca
					switch (cmbRicerca.SelectedIndex)
					{
						//"Collocazioni con Codice ISBN del Libro","Libri non restituti da più di 2 mesi","Libro più noleggiato per ogni utente", "Libro più noleggiato per ogni categoria", "Autori che hanno scritto libri di una categoria", "Autore preferito per ogni utente", "Libri di una categoria restituiti da un utente", "Libri scritti da un autore"
						case 0: //Ricerca Collocazioni con Codice ISBN del Libro
							dgvRicerca.DataSource = Gestore.Ricerca_Collocazioni_LibroCodice_ISBN(Convert.ToInt32(nudCodiceISBNRicerca.Text)).DefaultView;
							break;
						case 1: //Ricerca Libri non restituti da più di 2 mesi
							dgvRicerca.DataSource = Gestore.Ricerca_LibriNonRestituitiPiù2Mesi().DefaultView;
							break;
						case 2: //Ricerca Libro più noleggiato per ogni utente
							dgvRicerca.DataSource = Gestore.Ricerca_LibroPiùNoleggiatoOgniUtente().DefaultView;
							break;
						case 3: //Ricerca Libro più noleggiato per ogni categoria
							dgvRicerca.DataSource = Gestore.Ricerca_LibroPiùNoleggiatoOgniCategoria().DefaultView;
							break;
						case 4: //Ricerca Autori che hanno scritto libri di una categoria
							dgvRicerca.DataSource = Gestore.Ricerca_Autori_Categoria(txtNomeCategoriaRicerca.Text).DefaultView;
							break;
						case 5: //Ricerca Autore preferito per ogni utente
							dgvRicerca.DataSource = Gestore.Ricerca_AutorePreferitoOgniUtente().DefaultView;
							break;
						case 6: //Ricerca Libri di una categoria restituiti da un utente
							dgvRicerca.DataSource = Gestore.Ricerca_Libri_Categoria_PrestitoConcluso_Utente(txtNomeCategoriaRicerca.Text, Convert.ToInt32(nudIdTesseraRicerca.Value)).DefaultView;
							break;
						case 7: //Ricerca Libri scritti da un autore
							dgvRicerca.DataSource = Gestore.Ricerca_Libri_Autore(txtNomeAutoreRicerca.Text, txtCognomeAutoreRicerca.Text).DefaultView;
							break;
						default:
							break;
					}
					break;
				default:
					break;
			}
		}

		/*Metodo variadico per lo spostamento degli oggetti*/

		private void SpostaOggetti(int posizione, params Control[] oggetti)
        {
			foreach (Control oggetto in oggetti)
				oggetto.Location = new Point(oggetto.Location.X, oggetto.Location.Y + posizione);
        }

		/*Metodi per cambiare la visibilità degli oggetti*/

		private void CambiaVisibilità(bool[] visibilità, params Control[] oggetti)
        {
			for (int i = 0; i < visibilità.Count(); i++)
				oggetti[i].Visible = visibilità[i];
        }

		private void CambiaVisibilità(Control oggetto1, bool visibilità1, Control oggetto2, bool visibilità2)
		{
			oggetto1.Visible = visibilità1;
			oggetto2.Visible = visibilità2;
		}

		private void CambiaVisibilità (Control oggetto1, bool visibilità1, Control oggetto2, bool visibilità2, Control oggetto3, bool visibilità3, Control oggetto4, bool visibilità4)
		{
			oggetto1.Visible = visibilità1;
			oggetto2.Visible = visibilità2;
			oggetto3.Visible = visibilità3;
			oggetto4.Visible = visibilità4;
		}

		private void CambiaVisibilità (Control oggetto1, bool visibilità1, Control oggetto2, bool visibilità2, Control oggetto3, bool visibilità3, Control oggetto4, bool visibilità4, Control oggetto5, bool visibilità5, Control oggetto6, bool visibilità6, Control oggetto7, bool visibilità7, Control oggetto8, bool visibilità8, Control oggetto9, bool visibilità9)
		{
			oggetto1.Visible = visibilità1;
			oggetto2.Visible = visibilità2;
			oggetto3.Visible = visibilità3;
			oggetto4.Visible = visibilità4;
			oggetto5.Visible = visibilità5;
			oggetto6.Visible = visibilità6;
			oggetto7.Visible = visibilità7;
			oggetto8.Visible = visibilità8;
			oggetto9.Visible = visibilità9;
		}

		private void CambiaVisibilità(Control oggetto1, bool visibilità1, Control oggetto2, bool visibilità2, Control oggetto3, bool visibilità3, Control oggetto4, bool visibilità4, Control oggetto5, bool visibilità5, Control oggetto6, bool visibilità6, Control oggetto7, bool visibilità7, Control oggetto8, bool visibilità8)
		{
			oggetto1.Visible = visibilità1;
			oggetto2.Visible = visibilità2;
			oggetto3.Visible = visibilità3;
			oggetto4.Visible = visibilità4;
			oggetto5.Visible = visibilità5;
			oggetto6.Visible = visibilità6;
			oggetto7.Visible = visibilità7;
			oggetto8.Visible = visibilità8;
		}

		private void CambiaVisibilità(Control oggetto1, bool visibilità1, Control oggetto2, bool visibilità2, Control oggetto3, bool visibilità3, Control oggetto4, bool visibilità4, Control oggetto5, bool visibilità5, Control oggetto6, bool visibilità6, Control oggetto7, bool visibilità7, Control oggetto8, bool visibilità8, Control oggetto9, bool visibilità9, Control oggetto10, bool visibilità10)
		{
			oggetto1.Visible = visibilità1;
			oggetto2.Visible = visibilità2;
			oggetto3.Visible = visibilità3;
			oggetto4.Visible = visibilità4;
			oggetto5.Visible = visibilità5;
			oggetto6.Visible = visibilità6;
			oggetto7.Visible = visibilità7;
			oggetto8.Visible = visibilità8;
			oggetto9.Visible = visibilità9;
			oggetto10.Visible = visibilità10;
		}

		private void CambiaVisibilità(Control oggetto1, bool visibilità1, Control oggetto2, bool visibilità2, Control oggetto3, bool visibilità3, Control oggetto4, bool visibilità4, Control oggetto5, bool visibilità5, Control oggetto6, bool visibilità6, Control oggetto7, bool visibilità7, Control oggetto8, bool visibilità8, Control oggetto9, bool visibilità9, Control oggetto10, bool visibilità10, Control oggetto11, bool visibilità11)
		{
			oggetto1.Visible = visibilità1;
			oggetto2.Visible = visibilità2;
			oggetto3.Visible = visibilità3;
			oggetto4.Visible = visibilità4;
			oggetto5.Visible = visibilità5;
			oggetto6.Visible = visibilità6;
			oggetto7.Visible = visibilità7;
			oggetto8.Visible = visibilità8;
			oggetto9.Visible = visibilità9;
			oggetto10.Visible = visibilità10;
			oggetto11.Visible = visibilità11;
		}

		//Imposta la posizione de default degli oggetti
		private void ImpostaVistaDefault ()
		{
			Size = new Size(600, 300);
			btnConferma.Visible = true;
			btnCambiaDatabase.Visible = true;
			pnlRicerca.Visible = false;
			cmbElemento.Visible = true;
			lblElemento.Visible = true;
			cmbAzione.Location = new Point(15, 85);
			lblAzione.Location = new Point(15, 65);
			//Posizione Label Libri
			lblCodiceISBN.Location = new Point(20, 20);
			lblTitolo.Location = new Point(20, 70);
			lblLingua.Location = new Point(20, 120);
			lblEditore.Location = new Point(20, 170);
			lblData.Location = new Point(20, 215);
			//Posizione Label Categoria
			lblIdCategoria.Location = new Point(20, 20);
			lblCategoria.Location = new Point(20, 70);
			//Posizione Label Autore
			lblIdAutore.Location = new Point(20, 20);
			lblNomeAutore.Location = new Point(20, 70);
			lblCognomeAutore.Location = new Point(20, 120);
			lblDataNascita.Location = new Point(20, 165);
			lblLuogoNascita.Location = new Point(20, 220);
			//Posizione Label Utente
			lblIdTessera.Location = new Point(20, 20);
			lblNomeUtente.Location = new Point(20, 70);
			lblCognomeUtente.Location = new Point(20, 120);
			lblDataRegistrazione.Location = new Point(20, 165);
			//Posizione Label Collocazioni
			lblIdCollocazioni.Location = new Point(20, 20);
			lblSezione.Location = new Point(20, 70);
			lblNumeroScaffale.Location = new Point(20, 120);
			lblNumeroPosto.Location = new Point(20, 170);
			lblQuantita.Location = new Point(20, 220);
			if (!controlloSeEsisteLibriCollocazioni)
				lblCollocazioniCodiceISBNLibri.Location = new Point(20, 270);
			//Posizione Label Prestiti
			lblIdPrestiti.Location = new Point(20, 20);
			lblCodiceISBNPrestiti.Location = new Point(20, 70);
			lblIdTesseraPrestiti.Location = new Point(20, 120);
			lblInizioPrestito.Location = new Point(20, 165);
			lblFinePrestito.Location = new Point(20, 265);
			//Posizione TextBox Libri
			txtTitolo.Location = new Point(230, 65);
			txtLingua.Location = new Point(230, 115);
			txtEditore.Location = new Point(230, 165);
			//Posizione TextBox Categoria
			txtCategoria.Location = new Point(230, 65);
			//Posizione TextBox Autore
			txtNomeAutore.Location = new Point(230, 65);
			txtCognomeAutore.Location = new Point(230, 115);
			txtLuogoNascita.Location = new Point(230, 215);
			//Posizione TextBox Utente
			txtNomeUtente.Location = new Point(230, 65);
			txtCognomeUtente.Location = new Point(230, 115);
			//Posizione TextBox Collocazioni
			txtSezione.Location = new Point(230, 65);
			//Posizione DataTimePicker Libri
			dtpPubblicazione.Location = new Point(230, 215);
			//Posizione DataTimePicker Autore
			dtpDataNascitaAutore.Location = new Point(230, 165);
			//Posizione DataTimePicker Utente
			dtpDataRegistrazione.Location = new Point(230, 165);
			//Posizione DataTimePicker Prestito
			dtpInizioPrestito.Location = new Point(230, 165);
			dtpFinePrestito.Location = new Point(230, 265);
			//Posizione NumericUpDown Libri
			nudCodiceISBN.Location = new Point(230, 15);
			//Posizione NumericUpDown Categorie
			nudIdCategorie.Location = new Point(230, 15);
			//Posizione NumericUpDown Autore
			nudIdAutore.Location = new Point(230, 15);
			//Posizione NumericUpDown Utente
			nudIdTessera.Location = new Point(230, 15);
			//Posizione NumericUpDown Collocazioni
			nudIdCollocazioni.Location = new Point(230, 15);
			nudNumeroScaffale.Location = new Point(230, 115);
			nudNumeroPosto.Location = new Point(230, 165);
			nudQuantita.Location = new Point(230, 215);
			if (!controlloSeEsisteLibriCollocazioni)
				nudCollocazioniCodiceISBNLibri.Location = new Point(230, 265);
			//Posizione NumericUpDown Prestiti
			nudIdPrestiti.Location = new Point(230, 15);
			nudCodiceISBNPrestiti.Location = new Point(230, 65);
			nudIdTesseraPrestito.Location = new Point(230, 115);

			dgvRicerca.Location = new Point(0, 110);
			ckbData.Location = new Point(230, 215);
		}

		//Svuota tutti gli oggetti
		private void SvuotaTutto ()
		{
			txtCategoria.Text = string.Empty;
			txtCognomeAutore.Text = string.Empty;
			txtCognomeUtente.Text = string.Empty;
			txtEditore.Text = string.Empty;
			txtLingua.Text = string.Empty;
			txtLuogoNascita.Text = string.Empty;
			txtNomeAutore.Text = string.Empty;
			txtNomeUtente.Text = string.Empty;
			txtSezione.Text = string.Empty;
			txtTitolo.Text = string.Empty;
			txtNomeAutoreRicerca.Text = string.Empty;
			txtNomeCategoriaRicerca.Text = string.Empty;
			txtCognomeAutoreRicerca.Text = string.Empty;


			nudCodiceISBN.Value = 0;
			nudCodiceISBNLibriAutore.Value = 0;
			nudCodiceISBNLibriCategoria.Value = 0;
			nudCodiceISBNLibriCollocazioni.Value = 0;
			nudCodiceISBNPrestiti.Value = 0;
			nudCollocazioniCodiceISBNLibri.Value = 0;
			nudIdAutore.Value = 0;
			nudIdAutoreLibriAutore.Value = 0;
			nudIdCategoriaLibriCategoria.Value = 0;
			nudIdCategorie.Value = 0;
			nudIdCollocazioni.Value = 0;
			nudIdCollocazioniLibriCollocazioni.Value = 0;
			nudIdPrestiti.Value = 0;
			nudIdTessera.Value = 0;
			nudIdTesseraPrestito.Value = 0;
			nudNumeroPosto.Value = 0;
			nudNumeroScaffale.Value = 0;
			nudQuantita.Value = 0;
			nudCodiceISBNRicerca.Value = 0;
			nudIdTesseraRicerca.Value = 0;

			dtpDataNascitaAutore.Value = DateTime.Today;
			dtpPubblicazione.Value = DateTime.Today;
			dtpInizioPrestito.Value = DateTime.Today;
			dtpFinePrestito.Value = DateTime.Today;
			dtpDataRegistrazione.Value = DateTime.Today;

			dgvElenco.Columns.Clear();
			dgvRicerca.Columns.Clear();

			ckbData.Checked = false;
		}

		//Aggiorna la parte visuale
		private void AggiornaVista (string elemento, string azione, int indiceRicerca)
		{
			ImpostaVistaDefault();
			SvuotaTutto();

			elemento = elemento.ToLower();
			elemento = elemento.Replace(" ", String.Empty);

			if (!cmbAzione.Items.Contains("Modifica"))
				cmbAzione.Items.Insert(1, "Modifica");

			if (elemento.Equals("libriautori") ||
				elemento.Equals("libricategorie") ||
				elemento.Equals("libricollocazioni"))
				cmbAzione.Items.Remove("Modifica");

			for (int i = 0; i < cmbElemento.Items.Count; i++)
			{
				if (!cmbElemento.Items[i].ToString().Equals(elementi.ElementAt(i)))
					cmbElemento.Items.Insert(i, elementi.ElementAt(i));
			}

			switch (azione)
			{
				case "Inserisci": //Inserisci
					pnlRicerca.Visible = false;

					switch (elemento)
					{
						case "libri": //Aggiorna la visibilità dei Libri
							CambiaVisibilità( new bool[]{ true, true, true, true, true, true, true, true}, lblTitolo, txtTitolo, lblLingua, txtLingua, lblEditore, txtEditore, lblData, dtpPubblicazione);
							CambiaVisibilità(pnlRicerca, false, dgvElenco, false, pnlLibri, true, pnlCategorie, false, pnlAutori, false, pnlUtenti, false, pnlCollocazioni, false, pnlPrestiti, false, pnlLibriAutore, false, pnlLibriCategoria, false, pnlLibriCollocazione, false);
							break;
						case "categorie": //Aggiorna la visibilità delle Categorie
							SpostaOggetti(-50, lblCategoria, txtCategoria);
							CambiaVisibilità(lblIdCategoria, false, nudIdCategorie, false, lblCategoria, true, txtCategoria, true);
							CambiaVisibilità(pnlRicerca, false, dgvElenco, false, pnlLibri, false, pnlCategorie, true, pnlAutori, false, pnlUtenti, false, pnlCollocazioni, false, pnlPrestiti, false, pnlLibriAutore, false, pnlLibriCategoria, false, pnlLibriCollocazione, false);
							break;
						case "collocazioni": //Aggiorna la visibilità delle Collocazioni
							SpostaOggetti(-50, lblSezione, txtSezione, lblNumeroPosto, nudNumeroPosto, lblNumeroScaffale, nudNumeroScaffale, lblQuantita, nudQuantita);
							CambiaVisibilità(lblIdCollocazioni, false, nudIdCollocazioni, false, lblSezione, true, txtSezione, true, lblNumeroPosto, true, nudNumeroPosto, true, lblNumeroScaffale, true, nudNumeroScaffale, true, lblQuantita, true, nudQuantita, true);
							CambiaVisibilità(pnlRicerca, false, dgvElenco, false, pnlLibri, false, pnlCategorie, false, pnlAutori, false, pnlUtenti, false, pnlCollocazioni, true, pnlPrestiti, false, pnlLibriAutore, false, pnlLibriCategoria, false, pnlLibriCollocazione, false);
							if (!controlloSeEsisteLibriCollocazioni)
							{
								SpostaOggetti(-50, lblCollocazioniCodiceISBNLibri, nudCollocazioniCodiceISBNLibri);
								CambiaVisibilità(lblCollocazioniCodiceISBNLibri, true, nudCollocazioniCodiceISBNLibri, true);
							}
							break;
						case "autori": //Aggiorna la visibilità degli Autori
							SpostaOggetti(-50, lblNomeAutore, txtNomeAutore, lblCognomeAutore, txtCognomeAutore, lblDataNascita, dtpDataNascitaAutore, lblLuogoNascita, txtLuogoNascita);
							CambiaVisibilità(lblIdAutore, false, nudIdAutore, false, lblNomeAutore, true, txtNomeAutore, true, lblCognomeAutore, true, txtCognomeAutore, true, lblLuogoNascita, true, txtLuogoNascita, true, lblDataNascita, true, dtpDataNascitaAutore, true);
							CambiaVisibilità(pnlRicerca, false, dgvElenco, false, pnlLibri, false, pnlCategorie, false, pnlAutori, true, pnlUtenti, false, pnlCollocazioni, false, pnlPrestiti, false, pnlLibriAutore, false, pnlLibriCategoria, false, pnlLibriCollocazione, false);
							break;
						case "utenti": //Aggiorna la visibilità degli Utenti
							SpostaOggetti(-50, lblNomeUtente, txtNomeUtente, lblCognomeUtente, txtCognomeUtente, lblDataRegistrazione, dtpDataRegistrazione);
							CambiaVisibilità(lblIdTessera, false, nudIdTessera, false, lblNomeUtente, true, txtNomeUtente, true, lblCognomeUtente, true, txtCognomeUtente, true, lblDataRegistrazione, true, dtpDataRegistrazione, true);
							CambiaVisibilità(pnlRicerca, false, dgvElenco, false, pnlLibri, false, pnlCategorie, false, pnlAutori, false, pnlUtenti, true, pnlCollocazioni, false, pnlPrestiti, false, pnlLibriAutore, false, pnlLibriCategoria, false, pnlLibriCollocazione, false);
							break;
						case "prestiti"://Aggiorna la visibilità dei Prestiti
							SpostaOggetti(-50, ckbData, lblCodiceISBNPrestiti, nudCodiceISBNPrestiti, lblIdTesseraPrestiti, nudIdTesseraPrestito, lblInizioPrestito, dtpInizioPrestito, lblFinePrestito, dtpFinePrestito);
							CambiaVisibilità(ckbData, true, lblIdPrestiti, false, nudIdPrestiti, false, lblCodiceISBNPrestiti, true, nudCodiceISBNPrestiti, true, lblIdTesseraPrestiti, true, nudIdTesseraPrestito, true, lblInizioPrestito, true, dtpInizioPrestito, true, lblFinePrestito, false, dtpFinePrestito, false);
							CambiaVisibilità(pnlRicerca, false, dgvElenco, false, pnlLibri, false, pnlCategorie, false, pnlAutori, false, pnlUtenti, false, pnlCollocazioni, false, pnlPrestiti, true, pnlLibriAutore, false, pnlLibriCategoria, false, pnlLibriCollocazione, false);
							break;
						case "libriautori": //Aggiorna la visibilità dei libri-autore
							CambiaVisibilità(pnlRicerca, false, dgvElenco, false, pnlLibri, false, pnlCategorie, false, pnlAutori, false, pnlUtenti, false, pnlCollocazioni, false, pnlPrestiti, false, pnlLibriAutore, true, pnlLibriCategoria, false, pnlLibriCollocazione, false);
							break;
						case "libricategorie": //Aggiorna la visibilità dei libri-categorie
							CambiaVisibilità(pnlRicerca, false, dgvElenco, false, pnlLibri, false, pnlCategorie, false, pnlAutori, false, pnlUtenti, false, pnlCollocazioni, false, pnlPrestiti, false, pnlLibriAutore, false, pnlLibriCategoria, true, pnlLibriCollocazione, false);
							break;
						case "libricollocazioni": //Aggiorna la visibilità dei libri-collocazioni
							CambiaVisibilità(pnlRicerca, false, dgvElenco, false, pnlLibri, false, pnlCategorie, false, pnlAutori, false, pnlUtenti, false, pnlCollocazioni, false, pnlPrestiti, false, pnlLibriAutore, false, pnlLibriCategoria, false, pnlLibriCollocazione, true);
							break;
						default:
							break;
					}
					break;
				case "Modifica": //Modifica
					pnlRicerca.Visible = false;

					for (int i = 0; i < cmbElemento.Items.Count; i++)
						if (cmbElemento.Items[i].ToString().ToLower().Replace(" ", string.Empty).Equals("libriautori"))
							cmbElemento.Items.RemoveAt(i);

					for (int i = 0; i < cmbElemento.Items.Count; i++)
						if (cmbElemento.Items[i].ToString().ToLower().Replace(" ", string.Empty).Equals("libricategorie"))
							cmbElemento.Items.RemoveAt(i);

					for (int i = 0; i < cmbElemento.Items.Count; i++)
						if (cmbElemento.Items[i].ToString().ToLower().Replace(" ", string.Empty).Equals("libricollocazioni"))
							cmbElemento.Items.RemoveAt(i);

					switch (elemento)
					{
						case "libri": //Libri
							CambiaVisibilità(lblTitolo, true, txtTitolo, true, lblLingua, true, txtLingua, true, lblEditore, true, txtEditore, true, lblData, true, dtpPubblicazione, true);
							CambiaVisibilità(dgvElenco, false, pnlLibri, true, pnlCategorie, false, pnlAutori, false, pnlUtenti, false, pnlCollocazioni, false, pnlPrestiti, false, pnlLibriAutore, false, pnlLibriCategoria, false, pnlLibriCollocazione, false);
							break;
						case "categorie": //Categorie
							CambiaVisibilità(lblIdCategoria, true, nudIdCategorie, true, lblCategoria, true, txtCategoria, true);
							CambiaVisibilità(dgvElenco, false, pnlLibri, false, pnlCategorie, true, pnlAutori, false, pnlUtenti, false, pnlCollocazioni, false, pnlPrestiti, false, pnlLibriAutore, false, pnlLibriCategoria, false, pnlLibriCollocazione, false);
							break;
						case "collocazioni": //Collocazioni
							CambiaVisibilità(lblIdCollocazioni, true, nudIdCollocazioni, true, lblSezione, true, txtSezione, true, lblNumeroPosto, true, nudNumeroPosto, true, lblNumeroScaffale, true, nudNumeroScaffale, true, lblQuantita, true, nudQuantita, true);
							CambiaVisibilità(dgvElenco, false, pnlLibri, false, pnlCategorie, false, pnlAutori, false, pnlUtenti, false, pnlCollocazioni, true, pnlPrestiti, false, pnlLibriAutore, false, pnlLibriCategoria, false, pnlLibriCollocazione, false);
							if (!controlloSeEsisteLibriCollocazioni)
							{
									Size = new Size(600, 350);
									CambiaVisibilità(lblCollocazioniCodiceISBNLibri, true, nudCollocazioniCodiceISBNLibri, true);
							}
							break;
						case "autori": //Autori
							CambiaVisibilità(lblIdAutore, true, nudIdAutore, true, lblNomeAutore, true, txtNomeAutore, true, lblCognomeAutore, true, txtCognomeAutore, true, lblLuogoNascita, true, txtLuogoNascita, true, lblDataNascita, true, dtpDataNascitaAutore, true);
							CambiaVisibilità(dgvElenco, false, pnlLibri, false, pnlCategorie, false, pnlAutori, true, pnlUtenti, false, pnlCollocazioni, false, pnlPrestiti, false, pnlLibriAutore, false, pnlLibriCategoria, false, pnlLibriCollocazione, false);
							break;
						case "utenti": //Utenti
							CambiaVisibilità(lblIdTessera, true, nudIdTessera, true, lblNomeUtente, true, txtNomeUtente, true, lblCognomeUtente, true, txtCognomeUtente, true, lblDataRegistrazione, true, dtpDataRegistrazione, true);
							CambiaVisibilità(dgvElenco, false, pnlLibri, false, pnlCategorie, false, pnlAutori, false, pnlUtenti, true, pnlCollocazioni, false, pnlPrestiti, false, pnlLibriAutore, false, pnlLibriCategoria, false, pnlLibriCollocazione, false);
							break;
						case "prestiti": //Prestiti
							Size = new Size(600, 350);
							CambiaVisibilità(ckbData, true, lblIdPrestiti, true, nudIdPrestiti, true, lblCodiceISBNPrestiti, true, nudCodiceISBNPrestiti, true, lblIdTesseraPrestiti, true, nudIdTesseraPrestito, true, lblInizioPrestito, true, dtpInizioPrestito, true, lblFinePrestito, false, dtpFinePrestito, false);
							CambiaVisibilità(dgvElenco, false, pnlLibri, false, pnlCategorie, false, pnlAutori, false, pnlUtenti, false, pnlCollocazioni, false, pnlPrestiti, true, pnlLibriAutore, false, pnlLibriCategoria, false, pnlLibriCollocazione, false);
							break;
						case "libriautori": //Libri-Autori
							CambiaVisibilità(dgvElenco, false, pnlLibri, false, pnlCategorie, false, pnlAutori, false, pnlUtenti, false, pnlCollocazioni, false, pnlPrestiti, false, pnlLibriAutore, true, pnlLibriCategoria, false, pnlLibriCollocazione, false);
							break;
						case "libricategorie": //Libri-Categorie
							CambiaVisibilità(dgvElenco, false, pnlLibri, false, pnlCategorie, false, pnlAutori, false, pnlUtenti, false, pnlCollocazioni, false, pnlPrestiti, false, pnlLibriAutore, false, pnlLibriCategoria, true, pnlLibriCollocazione, false);
							break;
						case "libricollocazioni": //Libri-Collocazioni
							CambiaVisibilità(dgvElenco, false, pnlLibri, false, pnlCategorie, false, pnlAutori, false, pnlUtenti, false, pnlCollocazioni, false, pnlPrestiti, false, pnlLibriAutore, false, pnlLibriCategoria, false, pnlLibriCollocazione, true);
							break;
						default:
							break;
					}
					break;
				case "Visualizza Elenchi": //Visualizza Elenchi
					pnlRicerca.Visible = false;
					pnlRicerca.Visible = false;
					dgvElenco.Visible = true;
					Size = new Size(750, 300);
					switch (elemento)
					{
						case "libri": //Libro
							SvuotaTutto();
							CambiaVisibilità(pnlLibri, false, pnlCategorie, false, pnlAutori, false, pnlUtenti, false, pnlCollocazioni, false, pnlPrestiti, false, pnlLibriAutore, false, pnlLibriCategoria, false, pnlLibriCollocazione, false);
							break;
						case "categorie": //Categoria
							SvuotaTutto();
							CambiaVisibilità(pnlLibri, false, pnlCategorie, false, pnlAutori, false, pnlUtenti, false, pnlCollocazioni, false, pnlPrestiti, false, pnlLibriAutore, false, pnlLibriCategoria, false, pnlLibriCollocazione, false);
							break;
						case "collocazioni": //Collocazione
							SvuotaTutto();
							CambiaVisibilità(pnlLibri, false, pnlCategorie, false, pnlAutori, false, pnlUtenti, false, pnlCollocazioni, false, pnlPrestiti, false, pnlLibriAutore, false, pnlLibriCategoria, false, pnlLibriCollocazione, false);
							break;
						case "autori": //Autore
							SvuotaTutto();
							CambiaVisibilità(pnlLibri, false, pnlCategorie, false, pnlAutori, false, pnlUtenti, false, pnlCollocazioni, false, pnlPrestiti, false, pnlLibriAutore, false, pnlLibriCategoria, false, pnlLibriCollocazione, false);
							break;
						case "utenti": //Utente
							SvuotaTutto();
							CambiaVisibilità(pnlLibri, false, pnlCategorie, false, pnlAutori, false, pnlUtenti, false, pnlCollocazioni, false, pnlPrestiti, false, pnlLibriAutore, false, pnlLibriCategoria, false, pnlLibriCollocazione, false);
							break;
						case "prestiti": //Prestito
							SvuotaTutto();
							CambiaVisibilità(pnlLibri, false, pnlCategorie, false, pnlAutori, false, pnlUtenti, false, pnlCollocazioni, false, pnlPrestiti, false, pnlLibriAutore, false, pnlLibriCategoria, false, pnlLibriCollocazione, false);
							break;
						case "libriautori": //Libri-Autori
							SvuotaTutto();
							CambiaVisibilità(pnlLibri, false, pnlCategorie, false, pnlAutori, false, pnlUtenti, false, pnlCollocazioni, false, pnlPrestiti, false, pnlLibriAutore, false, pnlLibriCategoria, false, pnlLibriCollocazione, false);
							break;
						case "libricategorie": //Libri-Categorie
							SvuotaTutto();
							CambiaVisibilità(pnlLibri, false, pnlCategorie, false, pnlAutori, false, pnlUtenti, false, pnlCollocazioni, false, pnlPrestiti, false, pnlLibriAutore, false, pnlLibriCategoria, false, pnlLibriCollocazione, false);
							break;
						case "libricollocazioni": //Libri-Collocazioni
							SvuotaTutto();
							CambiaVisibilità(pnlLibri, false, pnlCategorie, false, pnlAutori, false, pnlUtenti, false, pnlCollocazioni, false, pnlPrestiti, false, pnlLibriAutore, false, pnlLibriCategoria, false, pnlLibriCollocazione, false);
							break;
						default:
							break;
					}
					break;
				case "Elimina": //Elimina
					pnlRicerca.Visible = false;
					switch (elemento)
					{
						case "libri": //Libro
							CambiaVisibilità(lblTitolo, false, txtTitolo, false, lblLingua, false, txtLingua, false, lblEditore, false, txtEditore, false, lblData, false, dtpPubblicazione, false);
							CambiaVisibilità(dgvElenco, false, pnlLibri, true, pnlCategorie, false, pnlAutori, false, pnlUtenti, false, pnlCollocazioni, false, pnlPrestiti, false, pnlLibriAutore, false, pnlLibriCategoria, false, pnlLibriCollocazione, false);
							break;
						case "categorie": //Categoria
							CambiaVisibilità(lblIdCategoria, true, nudIdCategorie, true, lblCategoria, false, txtCategoria, false);
							CambiaVisibilità(dgvElenco, false, pnlLibri, false, pnlCategorie, true, pnlAutori, false, pnlUtenti, false, pnlCollocazioni, false, pnlPrestiti, false, pnlLibriAutore, false, pnlLibriCategoria, false, pnlLibriCollocazione, false);
							break;
						case "collocazioni": //Collocazione
							CambiaVisibilità(lblIdCollocazioni, true, nudIdCollocazioni, true, lblSezione, false, txtSezione, false, lblNumeroPosto, false, nudNumeroPosto, false, lblNumeroScaffale, false, nudNumeroScaffale, false, lblQuantita, false, nudQuantita, false);
							CambiaVisibilità(dgvElenco, false, pnlLibri, false, pnlCategorie, false, pnlAutori, false, pnlUtenti, false, pnlCollocazioni, true, pnlPrestiti, false, pnlLibriAutore, false, pnlLibriCategoria, false, pnlLibriCollocazione, false);
							if (!controlloSeEsisteLibriCollocazioni)
								CambiaVisibilità(lblCollocazioniCodiceISBNLibri, false, nudCollocazioniCodiceISBNLibri, false);
							break;
						case "autori": //Autore
							CambiaVisibilità(lblIdAutore, true, nudIdAutore, true, lblNomeAutore, false, txtNomeAutore, false, lblCognomeAutore, false, txtCognomeAutore, false, lblLuogoNascita, false, txtLuogoNascita, false, lblDataNascita, false, dtpDataNascitaAutore, false);
							CambiaVisibilità(dgvElenco, false, pnlLibri, false, pnlCategorie, false, pnlAutori, true, pnlUtenti, false, pnlCollocazioni, false, pnlPrestiti, false, pnlLibriAutore, false, pnlLibriCategoria, false, pnlLibriCollocazione, false);
							break;
						case "utenti": //Utente
							CambiaVisibilità(lblIdTessera, true, nudIdTessera, true, lblNomeUtente, false, txtNomeUtente, false, lblCognomeUtente, false, txtCognomeUtente, false, lblDataRegistrazione, false, dtpDataRegistrazione, false);
							CambiaVisibilità(dgvElenco, false, pnlLibri, false, pnlCategorie, false, pnlAutori, false, pnlUtenti, true, pnlCollocazioni, false, pnlPrestiti, false, pnlLibriAutore, false, pnlLibriCategoria, false, pnlLibriCollocazione, false);
							break;
						case "prestiti": //Prestito
							CambiaVisibilità(ckbData, false, lblIdPrestiti, true, nudIdPrestiti, true, lblCodiceISBNPrestiti, false, nudCodiceISBNPrestiti, false, lblIdTesseraPrestiti, false, nudIdTesseraPrestito, false, lblInizioPrestito, false, dtpInizioPrestito, false, lblFinePrestito, false, dtpFinePrestito, false);
							CambiaVisibilità(dgvElenco, false, pnlLibri, false, pnlCategorie, false, pnlAutori, false, pnlUtenti, false, pnlCollocazioni, false, pnlPrestiti, true, pnlLibriAutore, false, pnlLibriCategoria, false, pnlLibriCollocazione, false);
							break;
						case "libriautori": //Libri-Autori
							CambiaVisibilità(dgvElenco, false, pnlLibri, false, pnlCategorie, false, pnlAutori, false, pnlUtenti, false, pnlCollocazioni, false, pnlPrestiti, false, pnlLibriAutore, true, pnlLibriCategoria, false, pnlLibriCollocazione, false);
							break;
						case "libricategorie": //Libri-Categorie
							CambiaVisibilità(dgvElenco, false, pnlLibri, false, pnlCategorie, false, pnlAutori, false, pnlUtenti, false, pnlCollocazioni, false, pnlPrestiti, false, pnlLibriAutore, false, pnlLibriCategoria, true, pnlLibriCollocazione, false);
							break;
						case "libricollocazioni": //Libri-Collocazioni
							CambiaVisibilità(dgvElenco, false, pnlLibri, false, pnlCategorie, false, pnlAutori, false, pnlUtenti, false, pnlCollocazioni, false, pnlPrestiti, false, pnlLibriAutore, false, pnlLibriCategoria, false, pnlLibriCollocazione, true);
							break;
						default:
							break;
					}
					break;
				case "Ricerca": //Ricerca
					CambiaVisibilità(dgvElenco, false, pnlLibri, false, pnlCategorie, false, pnlAutori, false, pnlUtenti, false, pnlCollocazioni, false, pnlPrestiti, false, pnlLibriAutore, false, pnlLibriCategoria, false, pnlLibriCollocazione, false);
					pnlRicerca.Visible = true;
					
					cmbElemento.Visible = false;
					lblElemento.Visible = false;
					cmbElemento.SelectedIndex = 0;
					cmbAzione.Location = cmbElemento.Location;
					lblAzione.Location = lblElemento.Location;
					dgvRicerca.Location = new Point(0, 110);
					Size = new Size(780, 400);
					switch (indiceRicerca)
					{
						case 0://Ricerca Collocazioni con Codice ISBN del Libro
							pnlRicerca.Visible = true;
							CambiaVisibilità(lblCognomeAutoreRicerca, false, txtCognomeAutoreRicerca, false, lblNomeCategoriaRicerca, false, txtNomeCategoriaRicerca, false, lblIdTesseraRicerca, false, nudIdTesseraRicerca, false, lblCodiceISBNRicerca, true, nudCodiceISBNRicerca, true, lblNomeAutoreRicerca, false, txtNomeAutoreRicerca, false);
							CambiaVisibilità(dgvElenco, false, pnlLibri, false, pnlCategorie, false, pnlAutori, false, pnlUtenti, false, pnlCollocazioni, false, pnlPrestiti, false, pnlLibriAutore, false, pnlLibriCategoria, false, pnlLibriCollocazione, false);
							break;
						case 1: //Ricerca Libri non restituti da più di 2 mesi
						case 2: //Ricerca Libro più noleggiato per ogni utente
						case 3: //Ricerca Libro più noleggiato per ogni categoria
						case 5: //Ricerca Autore preferito per ogni utente
							pnlRicerca.Visible = true;
							SpostaOggetti(-30, dgvRicerca);
							CambiaVisibilità(lblCognomeAutoreRicerca, false, txtCognomeAutoreRicerca, false, lblNomeCategoriaRicerca, false, txtNomeCategoriaRicerca, false, lblIdTesseraRicerca, false, nudIdTesseraRicerca, false, lblCodiceISBNRicerca, false, nudCodiceISBNRicerca, false, lblNomeAutoreRicerca, false, txtNomeAutoreRicerca, false);
							break;
						case 4: //Ricerca Autori che hanno scritto libri di una categoria
							pnlRicerca.Visible = true;
							CambiaVisibilità(lblCognomeAutoreRicerca, false, txtCognomeAutoreRicerca, false, lblNomeCategoriaRicerca, true, txtNomeCategoriaRicerca, true, lblIdTesseraRicerca, false, nudIdTesseraRicerca, false, lblCodiceISBNRicerca, false, nudCodiceISBNRicerca, false, lblNomeAutoreRicerca, false, txtNomeAutoreRicerca, false);
							CambiaVisibilità(dgvElenco, false, pnlLibri, false, pnlCategorie, false, pnlAutori, false, pnlUtenti, false, pnlCollocazioni, false, pnlPrestiti, false, pnlLibriAutore, false, pnlLibriCategoria, false, pnlLibriCollocazione, false);
							break;
						case 6: //Ricerca Libri di una categoria restituiti da un utente
							Size = new Size(780, 450);
							pnlRicerca.Visible = true;
							SpostaOggetti(+40, dgvRicerca);
							CambiaVisibilità(lblCognomeAutoreRicerca, false, txtCognomeAutoreRicerca, false, lblNomeCategoriaRicerca, true, txtNomeCategoriaRicerca, true, lblIdTesseraRicerca, true, nudIdTesseraRicerca, true, lblCodiceISBNRicerca, false, nudCodiceISBNRicerca, false, lblNomeAutoreRicerca, false, txtNomeAutoreRicerca, false);
							CambiaVisibilità(dgvElenco, false, pnlLibri, false, pnlCategorie, false, pnlAutori, false, pnlUtenti, false, pnlCollocazioni, false, pnlPrestiti, false, pnlLibriAutore, false, pnlLibriCategoria, false, pnlLibriCollocazione, false);
							break;
						case 7: //Ricerca Libri scritti da un autore
							Size = new Size(780, 450);
							pnlRicerca.Visible = true;
							SpostaOggetti(+40, dgvRicerca);
							CambiaVisibilità(lblCognomeAutoreRicerca, true, txtCognomeAutoreRicerca, true, lblNomeCategoriaRicerca, false, txtNomeCategoriaRicerca, false, lblIdTesseraRicerca, false, nudIdTesseraRicerca, false, lblCodiceISBNRicerca, false, nudCodiceISBNRicerca, false, lblNomeAutoreRicerca, true, txtNomeAutoreRicerca, true);
							CambiaVisibilità(dgvElenco, false, pnlLibri, false, pnlCategorie, false, pnlAutori, false, pnlUtenti, false, pnlCollocazioni, false, pnlPrestiti, false, pnlLibriAutore, false, pnlLibriCategoria, false, pnlLibriCollocazione, false);
							break;
						default:
							break;
					}
					break;
				default:
					break;
			}
		}
	}
}
