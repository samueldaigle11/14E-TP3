using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TP214E.Data;

namespace TP214E
{
    public partial class FenetreAjoutPlat : Window
    {
        AccesseurBaseDeDonnees accesseurBaseDeDonnees;

        public FenetreAjoutPlat(AccesseurBaseDeDonnees accesseurBaseDeDonnees)
        {
            InitializeComponent();

            this.accesseurBaseDeDonnees = accesseurBaseDeDonnees;
        }

        private void AjouterPlat(object sender, RoutedEventArgs e)
        {

        }

        private void AnnulerEtFermer(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
