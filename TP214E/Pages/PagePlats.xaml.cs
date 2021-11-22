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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TP214E.Data;

namespace TP214E.Pages
{
    public partial class PagePlats : Page
    {
        private AccesseurBaseDeDonnees accesseurBaseDeDonnees;
        private List<Plat> plats;

        public PagePlats(AccesseurBaseDeDonnees accesseurBaseDeDonnees)
        {
            InitializeComponent();

            this.accesseurBaseDeDonnees = accesseurBaseDeDonnees;
            RafraichirLstPlats();
        }

        private void RafraichirLstPlats()
        {
            plats = accesseurBaseDeDonnees.ObtenirPlats();
            lstPlats.Items.Clear();

            foreach (Plat plat in plats)
            {
                lstPlats.Items.Add(plat);
            }
        }

        private void RetournerAAccueil(object sender, RoutedEventArgs e)
        {
            PageAccueil frmAccueil = new PageAccueil();

            NavigationService.Navigate(frmAccueil);
        }

        private void OuvrirFenetreAjoutPlat(object sender, RoutedEventArgs e)
        {
            FenetreAjoutPlat fenetreAjoutPlat = new FenetreAjoutPlat(accesseurBaseDeDonnees);
            fenetreAjoutPlat.Title = "Ajout d'un plat";

            if (fenetreAjoutPlat.ShowDialog() == true)
            {
                RafraichirLstPlats();
            }
        }

        private void SupprimerObjetInventaire(object sender, RoutedEventArgs e)
        {
            if (lstPlats.SelectedIndex != -1)
            {
                int indicePlatASupprimer = lstPlats.SelectedIndex;
                Plat platASupprimer = plats[indicePlatASupprimer];

                accesseurBaseDeDonnees.SupprimerPlat(platASupprimer);
                RafraichirLstPlats();
            }
        }

    }
}
