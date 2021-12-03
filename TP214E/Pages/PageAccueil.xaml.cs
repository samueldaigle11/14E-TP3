using System.Windows;
using System.Windows.Controls;
using TP214E.Data;
using TP214E.Pages;

namespace TP214E
{
    public partial class PageAccueil : Page
    {
        private AccesseurBaseDeDonnees accesseurBaseDeDonnees;

        public PageAccueil()
        {
            InitializeComponent();
            accesseurBaseDeDonnees = new AccesseurBaseDeDonnees();
        }

        private void NaviguerAPageInventaire(object sender, RoutedEventArgs e)
        {
            PageInventaire frmInventaire = new PageInventaire(accesseurBaseDeDonnees);
            NavigationService.Navigate(frmInventaire);
        }

        private void NaviguerAPageCommande(object sender, RoutedEventArgs e)
        {
            PageCommandes frmCommandes = new PageCommandes(accesseurBaseDeDonnees);
            NavigationService.Navigate(frmCommandes);
        }

        private void NaviguerAPagePlats(object sender, RoutedEventArgs e)
        {
            PagePlats frmPlats = new PagePlats(accesseurBaseDeDonnees);
            NavigationService.Navigate(frmPlats);
        }

        private void AfficherFenetreMenu(object sender, RoutedEventArgs e)
        {
            FenetreMenu fenetreMenu = new FenetreMenu(accesseurBaseDeDonnees);
            fenetreMenu.Show();
        }
    }
}
