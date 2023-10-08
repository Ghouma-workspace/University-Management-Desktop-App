using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectNet.Modele;
using ProjectNet.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProjectNet.VueModele
{
    internal class EtudiantVueModele : ObservableObject
    {
        private int idet;
        private string cin;
        private string nom;
        private string prenom;
        private string boutonajout;
        private string boutonaffiche;
        private string deplabel;
        private string cllabel;
        private string nomlabel;
        private string prenomlabel;
        private string cinlabel;


        public int Idet { get => idet; set => SetProperty(ref idet, value); }
        public string Cin { get => cin; set => SetProperty(ref cin, value); }
        public string Nom { get => nom; set => SetProperty(ref nom, value); }
        public string Prenom { get => prenom; set => SetProperty(ref prenom, value); }
        public string Boutonajout { get => boutonajout; set => SetProperty(ref boutonajout, value); }
        public string BoutonAffiche { get => boutonaffiche; set => SetProperty(ref boutonaffiche, value); }
        public string Deplabel { get => deplabel; set => SetProperty(ref deplabel, value); }
        public string Cllabel { get => cllabel; set => SetProperty(ref cllabel, value); }
        public string Nomlabel { get => nomlabel; set => SetProperty(ref nomlabel, value); }
        public string Prenomlabel { get => prenomlabel; set => SetProperty(ref prenomlabel, value); }
        public string Cinlabel { get => cinlabel; set => SetProperty(ref cinlabel, value); }

        private Departement depS;
        private Classe clS;
        private List<Departement> tdep = new List<Departement>();
        private List<Classe> tcl = new List<Classe>();
        public List<Etudiant> EtList { get; set; } = AfficherDB();

        public IRelayCommand AfficherCommande { get; set; }
        public static List<Etudiant> AfficherDB()
        {
            List<Etudiant> etudiants = new List<Etudiant>();
            etudiants = GestionBD.GetEtudiants();
            return etudiants;
        }


        public IRelayCommand AjouterCommande { get; set; }
        public List<Departement> Tdep { get => tdep; set => SetProperty(ref tdep, value); }
        public List<Classe> Tcl { get => tcl; set => SetProperty(ref tcl, value); }
        public Departement DepS { get => depS; set => SetProperty(ref depS, value); }
        public Classe ClS { get => clS; set => clS = value; }

        private void Ajouter()
        {
            MessageBox.Show(ClS.IdCl.ToString());
            Etudiant dt = new Etudiant { IdEt = Idet, CIN = cin, Nom = nom, Prénom = prenom, ClasseIdCl = ClS.IdCl };
            GestionBD.AjouterEtudiant(dt);
            MessageBox.Show("Ajout confirmé!!");
            Nom = String.Empty;
            Prenom= String.Empty;
            Cin= String.Empty;
        }
        
        private void Afficher()
        {
            ShowEt vp = new ShowEt();
            vp.Show();
        }
        /*
        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string id = (e.AddedItems[0] as Departement).IdDep as string;
            Tcl = GestionBD.GetClasseByDep(DepS.IdDep);
        }
        */
        public EtudiantVueModele()
        {
            AfficherCommande = new RelayCommand(Afficher);
            AjouterCommande = new RelayCommand(Ajouter);
            DepS = GestionBD.GetDepartements()[0];
            Nomlabel = "Nom : ";
            Prenomlabel = "Prénom :";
            Cinlabel = "CIN";
            Deplabel = "Département";
            Cllabel = "Classe";
            Boutonajout = "Ajouter";
            BoutonAffiche = "Afficher";
            Tdep = GestionBD.GetDepartements();
            Tcl = GestionBD.GetClasseByDep(DepS.IdDep);
        }
    }
}