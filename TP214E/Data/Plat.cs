﻿using System.Collections.Generic;
using System.Globalization;
using MongoDB.Bson;
namespace TP214E.Data
{
    public class Plat
    {
        private ObjectId _id;
        private string _nom;
        private double _prix;
        private List<Ingredient> _ingredients;

        public Plat(string pNom, double pPrix, List<Ingredient> pIngredients)
        {
            Nom = pNom;
            Prix = pPrix;
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
            set { _nom = value; }
        }

        public double Prix
        {
            get { return _prix; }
            set { _prix = value; }
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