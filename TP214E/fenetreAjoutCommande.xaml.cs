using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using TP214E.Data;

namespace TP214E
{
    /// <summary>
    /// Logique d'interaction pour fenetreAjoutCommande.xaml
    /// </summary>
    public partial class fenetreAjoutCommande : Window
    {
        private List<Plat> plats;
        private List<ObjetInventaire> objetInventaires;
        private Dictionary<string, int> ingredientsNecessaires;
        private AccesseurBaseDeDonnees accesseurBaseDeDonnees;
        private Commande commande;

        public fenetreAjoutCommande(AccesseurBaseDeDonnees accesseurBaseDeDonnees)
        {
            InitializeComponent();

            this.accesseurBaseDeDonnees = accesseurBaseDeDonnees;
            objetInventaires = accesseurBaseDeDonnees.ObtenirObjetsInventaire();
            commande = new Commande();

            RafraichirLstPlatsDisponibles();
        }

        private void AnnulerEtFermerLaFenetre(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void CreerCommande(object sender, RoutedEventArgs e)
        {
            if (commande.Plats.Count > 0)
            {
                // valider disponibilité des ObjetInventaire ici***
                if (VerifierSiCommandeEstPossible())
                {
                    accesseurBaseDeDonnees.AjouterCommande(commande);
                    DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Vous n'avez pas les quantités requises en inventaire pour au moins " +
                        "un ingrédient pour pouvoir prendre cette commande.", "Impossible de compléter la commande",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Vous devez ajouter des plats à la commande.", "Erreur: Commande vide",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AjouterPlatALaCommande(object sender, RoutedEventArgs e)
        {
            int indicePlatAAjouter = lstPlatsDisponibles.SelectedIndex;

            if (indicePlatAAjouter != -1)
            {
                Plat platAAjouterACommande = plats[indicePlatAAjouter];
                commande.AjouterPlat(platAAjouterACommande);
                commande.CalculerPrixTotal();
            }

            RafraichirLstContenuCommande();
        }

        private void RafraichirLstPlatsDisponibles()
        {
            plats = accesseurBaseDeDonnees.ObtenirPlats();
            lstPlatsDisponibles.Items.Clear();

            foreach (Plat plat in plats)
            {
                lstPlatsDisponibles.Items.Add(plat);
            }
        }

        private void RafraichirLstContenuCommande()
        {
            lstContenuCommande.Items.Clear();

            foreach (Plat plat in commande.Plats)
            {
                lstContenuCommande.Items.Add(plat);
            }
        }

        private void EnleverPlatDeLaCommande(object sender, RoutedEventArgs e)
        {
            Plat platAEnlever = (Plat)lstContenuCommande.SelectedItem;

            if (platAEnlever != null)
            {
                commande.SupprimerPlat(platAEnlever);
                commande.CalculerPrixTotal();
            }

            RafraichirLstContenuCommande();
        }

        private void CalculerIngredientsNecessaires()
        {
            ingredientsNecessaires = new Dictionary<string, int>();

            foreach (Plat plat in commande.Plats)
            {
                foreach (Ingredient ingredient in plat.Ingredients)
                {
                    if (ingredientsNecessaires.ContainsKey(ingredient.Nom))
                    {
                        ingredientsNecessaires[ingredient.Nom] += ingredient.Quantite; 
                    }
                    else
                    {
                        ingredientsNecessaires[ingredient.Nom] = ingredient.Quantite;
                    }
                }
            }
        }

        private bool VerifierSiCommandeEstPossible()
        {
            CalculerIngredientsNecessaires();

            foreach (string nomIngredient in ingredientsNecessaires.Keys)
            {
                int quantiteEnInventaire = 0;
                List<ObjetInventaire> objetsInventaireSelonNomParticulier = accesseurBaseDeDonnees.ObtenirObjetsInventaireSelonNom(nomIngredient);

                foreach (ObjetInventaire objet in objetsInventaireSelonNomParticulier)
                {
                    quantiteEnInventaire += objet.Quantite;
                }

                if (ingredientsNecessaires[nomIngredient] > quantiteEnInventaire)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
