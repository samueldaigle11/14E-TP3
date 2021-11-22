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

        }

        private void AnnulerEtFermer(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void AjouterIngredient(object sender, RoutedEventArgs e)
        {
            try
            {
                ObjetInventaire objetInventairePourIngredientAAjouter;
                //VerifierChampQuantiteFormulaire(txtQuantite.Text);

                if (radioAliment.IsChecked == true)
                {
                    //VerifierChampDatePeremptionFormulaire(txtDatePeremption.Text);

                    objetInventairePourIngredientAAjouter = new Aliment(txtNomIngredient.Text,
                        Convert.ToInt32(txtQuantiteIngredient.Text), txtUniteIngredient.Text, DateTime.Now);
                }
                else if (radioContenant.IsChecked == true)
                {
                    objetInventairePourIngredientAAjouter = new Contenant(txtNomIngredient.Text, 
                        Convert.ToInt32(txtQuantiteIngredient.Text));
                }
                else
                {
                    objetInventairePourIngredientAAjouter = new Ustensile(txtNomIngredient.Text, 
                        Convert.ToInt32(txtQuantiteIngredient.Text));
                }

                Ingredient ingredientAAjouter = new Ingredient((ObjetInventaire)objetInventairePourIngredientAAjouter,
                    Convert.ToInt32(txtQuantiteIngredient.Text));
                lstIngredients.Items.Add(ingredientAAjouter);

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Erreur",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
