using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectNet.Modele;
using ProjectNet.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectNet.VueModele
{
    internal class DepartementVueModele : ObservableObject 
    {
        private string iddep;
        private string nomdep;
        private string ajoutbouton;
        private string affichebouton;
        private string idlabel;
        private string nomlabel;

        public string Iddep { get => iddep; set => SetProperty(ref iddep, value); }
        public string Nomdep { get => nomdep; set => SetProperty(ref nomdep, value); }
        public string Ajoutbouton { get => ajoutbouton; set => SetProperty(ref ajoutbouton, value); }
        public string Affichebouton { get => affichebouton; set => SetProperty(ref affichebouton, value); }
        public string Idlabel { get => idlabel; set => SetProperty(ref idlabel, value); }
        public string Nomlabel { get => nomlabel; set => SetProperty(ref nomlabel, value); }
        public List<Departement> DepList { get; set; } = AfficherDB();


        public IRelayCommand AfficherCommande { set; get; }
        public static List<Departement> AfficherDB()
        {
            List<Departement> departements = new List<Departement>();
            departements = GestionBD.GetDepartements();
            return departements;
        }
        
        private void Afficher()
        {
            ShowDep vp = new ShowDep();
            vp.Show();
        }


        public IRelayCommand AjouterCommande { get; set; }
        private void Ajouter()
        {
            Departement dt = new Departement { IdDep = iddep, NameDep = nomdep };
            GestionBD.AjouterDepartement(dt);
            MessageBox.Show("Ajout confirmé!!");
            Iddep = String.Empty;
            Nomdep = String.Empty;
        }

        public DepartementVueModele()
        {
            AfficherCommande = new RelayCommand(Afficher);
            AjouterCommande = new RelayCommand(Ajouter);
            Idlabel = "ID : ";
            Nomlabel = "Nom : ";
            Ajoutbouton = "Ajouter";
            Affichebouton = "Afficher";
        }
    }
}
