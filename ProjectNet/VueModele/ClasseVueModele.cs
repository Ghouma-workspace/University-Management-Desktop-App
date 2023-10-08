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
    internal class ClasseVueModele : ObservableObject
    {
        private string idcl;
        private string nomcl;
        private string ajoutbouton;
        private string affichebouton;
        private string idlabel;
        private string nomlabel;

        private List<Departement> depList = new List<Departement>();
        private Departement depSelected;

        public string Idcl { get => idcl; set => SetProperty(ref idcl, value); }
        public string Nomcl { get => nomcl; set => SetProperty(ref nomcl, value); }
        public string Ajoutbouton { get => ajoutbouton; set => SetProperty(ref ajoutbouton, value); }
        public string Affichebouton { get => affichebouton; set => SetProperty(ref affichebouton, value); }
        public string Idlabel { get => idlabel; set => SetProperty(ref idlabel, value); }
        public string Nomlabel { get => nomlabel; set => SetProperty(ref nomlabel, value); }

        public List<Classe> ClList { get; set; } = AfficherDB();
        public List<Departement> DepList { get => depList ; set => SetProperty(ref depList, value); }
        public Departement DepSelected { get => depSelected; set => SetProperty(ref depSelected, value); }


        public IRelayCommand AfficherCommande { set; get; }
        public static List<Classe> AfficherDB()
        {
            List<Classe> classes = new List<Classe>();
            classes = GestionBD.GetClasses();
            return classes;
        }

        private void Afficher()
        {
            ShowCl vp = new ShowCl();
            vp.Show();
        }

        
        public IRelayCommand AjouterCommande { get; set; }
        private void Ajouter()
        {
            Classe dt = new Classe { IdCl = idcl, NameCl = nomcl, DepartementIdDep = depSelected.IdDep };
            GestionBD.AjouterClasse(dt);
            MessageBox.Show("Ajout confirmé!!");
            idcl = String.Empty;
            nomcl= String.Empty;
        }

        public ClasseVueModele()
        {
            AfficherCommande = new RelayCommand(Afficher);
            AjouterCommande = new RelayCommand(Ajouter);
            Idlabel = "ID : ";
            Nomlabel = "Nom : ";
            Ajoutbouton = "Ajouter";
            Affichebouton = "Afficher";
            DepList = GestionBD.GetDepartements();
        }
    }
}
