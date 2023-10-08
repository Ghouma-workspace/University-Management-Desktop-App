using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectNet.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNet
{
    internal class Main : ObservableObject
    {
        private string boutondep;
        private string boutoncl;
        private string boutonet;

        public string Boutondep { get => boutondep; set => SetProperty(ref boutondep, value); }
        public string Boutoncl { get => boutoncl; set => SetProperty(ref boutoncl, value); }
        public string Boutonet { get => boutonet; set => SetProperty(ref boutonet, value); }

        public IRelayCommand DepCommande { set; get; }
        private void OuvrirDep()
        {
            Département vp = new Département();
            vp.Show();
        }

        public IRelayCommand ClCommande { set; get; }
        private void OuvrirCl()
        {
            Classi vp = new Classi();
            vp.Show();
        }

        public IRelayCommand EtCommande { set; get; }
        private void OuvrirEt()
        {
            Etudianta vp = new Etudianta();
            vp.Show();
        }

        public Main()
        {
            EtCommande = new RelayCommand(OuvrirEt);
            DepCommande = new RelayCommand(OuvrirDep);
            ClCommande = new RelayCommand(OuvrirCl);
            Boutondep = "Départements";
            Boutoncl = "Classes";
            Boutonet = "Etudiants";
        }
    }
}