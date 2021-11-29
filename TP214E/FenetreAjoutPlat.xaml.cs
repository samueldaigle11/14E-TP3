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
        List<Ingredient> lstIngredientsDuPlat;

        public FenetreAjoutPlat(AccesseurBaseDeDonnees accesseurBaseDeDonnees)
        {
            InitializeComponent();

            this.accesseurBaseDeDonnees = accesseurBaseDeDonnees;
            lstIngredientsDuPlat = new List<Ingredient>();
        }

        private void AjouterPlat(object sender, RoutedEventArgs e)
        {
            try
            {
                // TODO Vérifier les champs
                //VerifierChampQuantiteFormulaire(txtQuantite.Text);

                foreach (Ingredient ingredient in lstIngredients.Items)
                {
                    lstIngredientsDuPlat.Add(ingredient);
                }

                Plat nouveauPlat = new Plat(txtNomPlat.Text, Convert.ToDouble(txtPrix.Text), txtCategorie.Text, lstIngredientsDuPlat);

                accesseurBaseDeDonnees.AjouterPlat(nouveauPlat);
                DialogResult = true;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Erreur",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AnnulerEtFermer(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void AjouterIngredient(object sender, RoutedEventArgs e)
        {
            try
            {
                string typeIngredient;

                VerifierChampQuantiteIngredient(txtQuantiteIngredient.Text);

                if (radioAliment.IsChecked == true)
                {
                    VerifierChampUniteIngredient(txtUniteIngredient.Text);

                    typeIngredient = "aliment";
                }
                else if (radioContenant.IsChecked == true)
                {
                    txtUniteIngredient.Clear();
                    typeIngredient = "contenant";
                }
                else
                {
                    txtUniteIngredient.Clear();
                    typeIngredient = "ustensile";
                }

                Ingredient ingredientAAjouter = new Ingredient(txtNomIngredient.Text,
                    Convert.ToInt32(txtQuantiteIngredient.Text), txtUniteIngredient.Text, typeIngredient);
                lstIngredients.Items.Add(ingredientAAjouter);

                ViderChampsIngredient();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Erreur",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ViderChampsIngredient()
        {
            txtNomIngredient.Clear();
            txtQuantiteIngredient.Clear();
            txtUniteIngredient.Clear();
        }

        private bool ChaineContientSeulementChiffres(string chaine)
        {
            foreach (char charactere in chaine)
            {
                if (charactere < '0' || charactere > '9')
                    return false;
            }

            return true;
        }

        private void VerifierChampQuantiteIngredient(string quantite)
        {
            if (quantite == "")
            {
                throw new ArgumentException("La quantité doit être entrée.");
            }
            if (!ChaineContientSeulementChiffres(quantite))
            {
                throw new ArgumentException("La quantité doit être plus grande que 0.");
            }
        }

        private void VerifierChampUniteIngredient(string unite)
        {
            if (unite != "")
            {
                if (unite.Length > 12)
                {
                    throw new ArgumentException("L'unité doit être de 12 caractères et moins.");
                }
            }
            else
            {
                throw new ArgumentException("L'unité doit être entrée.");
            }
        }
    }
}
