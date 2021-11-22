using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
    public class Ingredient
    {
        private ObjetInventaire _objetInventaire;
        private int _quantite;

        public ObjetInventaire ObjetInventaire
        {
            get { return _objetInventaire; }
            set { _objetInventaire = value; }
        }

        public int Quantite
        {
            get { return _quantite; }
            set { _quantite = value; }
        }

        public Ingredient(ObjetInventaire pObjetInventaire, int pQuantite)
        {
            ObjetInventaire = pObjetInventaire;
            Quantite = pQuantite;
        }

        public override string ToString()
        {
            return $"{ObjetInventaire.Nom} quantité: {Quantite}";
        }
    }
}
