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

                Plat nouveauPlat = new Plat(txtNomPlat.Text, Convert.ToDouble(txtPrix.Text), lstIngredientsDuPlat);

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
                //VerifierChampQuantiteFormulaire(txtQuantite.Text);

                if (radioAliment.IsChecked == true)
                {
                    //VerifierChampDatePeremptionFormulaire(txtDatePeremption.Text);

                    typeIngredient = "aliment";
                }
                else if (radioContenant.IsChecked == true)
                {
                    typeIngredient = "contenant";
                }
                else
                {
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
    }
}
