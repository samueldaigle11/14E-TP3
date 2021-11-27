using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
    public class Ingredient
    {
        private string _nom;
        private int _quantite;
        private string _unite;
        private string _type;

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public int Quantite
        {
            get { return _quantite; }
            set { _quantite = value; }
        }

        public string Unite
        {
            get { return _unite; }
            set { _unite = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }


        public Ingredient(string pNom, int pQuantite, string pUnite, string pType)
        {
            Nom = pNom;
            Quantite = pQuantite;
            Unite = pUnite;
            Type = pType;
        }

        public override string ToString()
        {
            return $"{Nom} quantité: {Quantite} {Unite}";
        }
    }
}
