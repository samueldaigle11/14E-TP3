using System;
using System.Windows;
using TP214E.Data;

namespace TP214E
{
    public partial class FenetreObjetInventaire : Window
    {
        private AccesseurBaseDeDonnees accesseurBaseDeDonnees;
        private ObjetInventaire objetInventaireAModifier;

        public ObjetInventaire ObjetInventaireAModifier
        {
            get { return objetInventaireAModifier; }
            set { objetInventaireAModifier = value; }
        }

        public FenetreObjetInventaire(AccesseurBaseDeDonnees accesseurBaseDeDonnees)
        {
            InitializeComponent();

            this.accesseurBaseDeDonnees = accesseurBaseDeDonnees;
        }

        private void AjouterAInventaire()
        {
            try
            {
                ObjetInventaire nouvelObjetInventaire;
                VerifierChampQuantiteFormulaire(txtQuantite.Text);

                if (radioAliment.IsChecked == true)
                {
                    VerifierChampDatePeremptionFormulaire(txtDatePeremption.Text);

                    nouvelObjetInventaire = new Aliment(txtNom.Text, Convert.ToInt32(txtQuantite.Text), txtUnite.Text,
                    DateTime.Parse(txtDatePeremption.Text).ToLocalTime());
                }
                else if (radioContenant.IsChecked == true)
                {
                    nouvelObjetInventaire = new Contenant(txtNom.Text, Convert.ToInt32(txtQuantite.Text));
                }
                else
                {
                    nouvelObjetInventaire = new Ustensile(txtNom.Text, Convert.ToInt32(txtQuantite.Text));
                }

                accesseurBaseDeDonnees.AjouterObjet(nouvelObjetInventaire);
                DialogResult = true;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Erreur",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ModifierDansInventaire()
        {
            try
            {
                ObjetInventaire nouvelObjetInventaire;
                VerifierChampQuantiteFormulaire(txtQuantite.Text);

                if (radioAliment.IsChecked == true)
                {
                    VerifierChampDatePeremptionFormulaire(txtDatePeremption.Text);

                    nouvelObjetInventaire = new Aliment(txtNom.Text, Convert.ToInt32(txtQuantite.Text), txtUnite.Text,
                        DateTime.Parse(txtDatePeremption.Text).ToLocalTime());
                }
                else if (radioContenant.IsChecked == true)
                {
                    nouvelObjetInventaire = new Contenant(txtNom.Text, Convert.ToInt32(txtQuantite.Text));
                }
                else
                {
                    nouvelObjetInventaire = new Ustensile(txtNom.Text, Convert.ToInt32(txtQuantite.Text));
                }

                accesseurBaseDeDonnees.ModifierObjet(objetInventaireAModifier.Id, nouvelObjetInventaire);
                DialogResult = true;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Erreur",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CreerOuModifierObjetInventaire(object sender, RoutedEventArgs e)
        {
            if (objetInventaireAModifier == null)
            {
                AjouterAInventaire();
            }
            else
            {
                ModifierDansInventaire();
            }
        }

        private void AnnulerEtFermer(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
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

        private void VerifierChampQuantiteFormulaire(string quantite)
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

        private void VerifierChampDatePeremptionFormulaire(string chaineDate)
        {
            if (chaineDate == "")
            {
                throw new ArgumentException("La date de péremption doit être entrée.");
            }

            if (DateTime.Parse(chaineDate) < DateTime.Now)
            {
                throw new ArgumentException("La date de péremption doit être dans le futur.");
            }
        }

        public void InitializerFenetrePourUneModificationDObjet(ObjetInventaire objetAModifier)
        {
            ObjetInventaireAModifier = objetAModifier;
            Title = "Modification d'un objet/aliment";
            lbl_titreFenetre.Content = "Modification d'un objet";

            CocherLeBonBoutonRadioSelonObjetAModifier(objetAModifier);
            DesactiverLesBoutonsRadio();
            RemplirChampsCorrectementSelonLObjetAModifier(objetAModifier);
        }

        private void DesactiverLesBoutonsRadio()
        {
            radioAliment.IsEnabled = false;
            radioContenant.IsEnabled = false;
            radioUstensile.IsEnabled = false;
        }

        private void CocherLeBonBoutonRadioSelonObjetAModifier(ObjetInventaire objetAModifier)
        {
            if (objetAModifier.GetType() == typeof(Contenant))
            {
                radioContenant.IsChecked = true;
            }
            else if (objetAModifier.GetType() == typeof(Ustensile))
            {
                radioUstensile.IsChecked = true;
            }
        }

        private void RemplirChampsCorrectementSelonLObjetAModifier(ObjetInventaire objetAModifier)
        {
            txtNom.Text = objetAModifier.Nom;
            txtQuantite.Text = objetAModifier.Quantite.ToString();

            if (objetAModifier.GetType() == typeof(Aliment))
            {
                txtUnite.Text = ((Aliment)objetAModifier).Unite;
                txtDatePeremption.Text = ((Aliment)objetAModifier).DatePeremption.ToString();
            }
        }
    }
}
