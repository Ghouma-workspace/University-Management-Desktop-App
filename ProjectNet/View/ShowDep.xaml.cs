using ProjectNet.Modele;
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
    /// Interaction logic for ShowDep.xaml
    /// </summary>
    public partial class ShowDep : Window
    {
        public ShowDep()
        {
            InitializeComponent();

            //DG.ItemsSource = GestionBD.GetDepartements();
        }
    }
}
