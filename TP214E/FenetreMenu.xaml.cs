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
    public partial class FenetreMenu : Window
    {
        private AccesseurBaseDeDonnees accesseurBaseDeDonnees;
        private List<Plat> entrees;
        private List<Plat> platsPrincipaux;
        private List<Plat> desserts;

        public FenetreMenu(AccesseurBaseDeDonnees accesseurBaseDeDonnees)
        {
            InitializeComponent();

            this.accesseurBaseDeDonnees = accesseurBaseDeDonnees;
            RafraichirPlats();
            RafraichirTousLesStackPanelsDePlats();
        }

        private void RafraichirPlats()
        {
            entrees = accesseurBaseDeDonnees.ObtenirPlatsDuneCategorie("entrée");
            platsPrincipaux = accesseurBaseDeDonnees.ObtenirPlatsDuneCategorie("plat principal");
            desserts = accesseurBaseDeDonnees.ObtenirPlatsDuneCategorie("dessert");
        }

        private void RafraichirStackPanelEntrees()
        {
            stackPanelEntrees.Children.Clear();

            foreach (Plat plat in entrees)
            {
                Label labelDuPlat = new Label();
                labelDuPlat.Content = plat.ToString();
                labelDuPlat.Foreground = System.Windows.Media.Brushes.LightGreen;
                labelDuPlat.HorizontalAlignment = HorizontalAlignment.Center;
                labelDuPlat.FontFamily = new FontFamily("Rockwell");
                labelDuPlat.FontSize = 12;

                stackPanelEntrees.Children.Add(labelDuPlat);
            }
        }

        private void RafraichirStackPanelPlatsPrincipaux()
        {
            stackPanelPlatsPrincipaux.Children.Clear();

            foreach (Plat plat in platsPrincipaux)
            {
                Label labelDuPlat = new Label();
                labelDuPlat.Content = plat.ToString();
                labelDuPlat.Foreground = System.Windows.Media.Brushes.LightGreen;
                labelDuPlat.HorizontalAlignment = HorizontalAlignment.Center;
                labelDuPlat.FontFamily = new FontFamily("Rockwell");
                labelDuPlat.FontSize = 12;

                stackPanelPlatsPrincipaux.Children.Add(labelDuPlat);
            }
        }

        private void RafraichirStackPanelDesserts()
        {
            stackPanelDesserts.Children.Clear();

            foreach (Plat plat in desserts)
            {
                Label labelDuPlat = new Label();
                labelDuPlat.Content = plat.ToString();
                labelDuPlat.Foreground = System.Windows.Media.Brushes.LightGreen;
                labelDuPlat.HorizontalAlignment = HorizontalAlignment.Center;
                labelDuPlat.FontFamily = new FontFamily("Rockwell");
                labelDuPlat.FontSize = 12;

                stackPanelDesserts.Children.Add(labelDuPlat);
            }
        }

        private void RafraichirTousLesStackPanelsDePlats()
        {
            RafraichirStackPanelEntrees();
            RafraichirStackPanelPlatsPrincipaux();
            RafraichirStackPanelDesserts();
        }

    }
}
