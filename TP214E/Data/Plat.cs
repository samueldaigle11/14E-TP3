using System;
using System.Collections.Generic;
using System.Globalization;
using MongoDB.Bson;
namespace TP214E.Data
{
    public class Plat : IPlat
    {
        private ObjectId _id;
        private string _nom;
        private double _prix;
        private string _categorie;
        private List<Ingredient> _ingredients;

        public Plat(string pNom, double pPrix, string pCategorie, List<Ingredient> pIngredients)
        {
            Nom = pNom;
            Prix = pPrix;
            Categorie = pCategorie;
            Ingredients = pIngredients;
        }

        public ObjectId Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nom
        {
            get { return _nom; }
            set
            {
                if (value != "")
                {
                    if (value.Length <= 20)
                    {
                        _nom = value;
                    }
                    else
                    {
                        throw new ArgumentException("Le nom doit être de 20 caractères et moins.");
                    }
                }
                else
                {
                    throw new ArgumentException("Le nom doit être entré.");
                }
            }
        }

        public double Prix
        {
            get { return _prix; }
            set
            {
                if (value > 0)
                {
                    _prix = value;
                }
                else
                {
                    throw new ArgumentException("Le prix doit être supérieur" +
                                                " à zéro.");
                }
            }
        }

        public string Categorie
        {
            get { return _categorie; }
            set
            {
                if (value != "")
                {
                    if (value.Length <= 20)
                    {
                        _categorie = value;
                    }
                    else
                    {
                        throw new ArgumentException("La catégorie doit être de 20 caractères et moins.");
                    }
                }
                else
                {
                    throw new ArgumentException("La catégorie doit être entrée.");
                }
            }
        }

        public List<Ingredient> Ingredients
        {
            get { return _ingredients; }
            set { _ingredients = value; }
        }

        public override string ToString()
        {
            return string.Format("{0} {1:0.##} $", Nom, Prix.ToString("0.00", new CultureInfo("fr-CA")));
        }
    }
}