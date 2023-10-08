using ProjectNet.Modele;
using ProjectNet.VueModele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjectNet.View
{
    /// <summary>
    /// Interaction logic for Etudianta.xaml
    /// </summary>
    public partial class Etudianta : Window
    {
        public Etudianta()
        {
            InitializeComponent();

            this.DataContext = new EtudiantVueModele();
        }

        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CLBOX.ItemsSource = GestionBD.GetClasseByDep(((Departement)CBBOX.SelectedItem).IdDep);
        }
    }
}
