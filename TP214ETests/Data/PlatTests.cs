using System;
using System.Collections.Generic;
using System.Windows.Documents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;

namespace TP214E.Data.Tests
{
    [TestClass()]
    public class PlatTests
    {
        [TestMethod()]
        public void Plat_test_accesseur_Id()
        {
            List<Ingredient> lstIngredients = new List<Ingredient>();
            Aliment frites = new Aliment("Frites", 300, "grammes", DateTime.Now);
            Ingredient ingredient = new Ingredient(frites, 200);
            lstIngredients.Add(ingredient);
            Plat plat = new Plat("poutine", 10.00, lstIngredients);
            ObjectId id = ObjectId.GenerateNewId();

            plat.Id = id;

            Assert.AreEqual(plat.Id, id);
        }

        [TestMethod()]
        public void Plat_ToString_retourne_la_bonne_string()
        {
            List<Ingredient> lstIngredients = new List<Ingredient>();
            Aliment frites = new Aliment("Frites",300,"grammes", DateTime.Now);
            Ingredient ingredient = new Ingredient(frites, 200);
            lstIngredients.Add(ingredient);
            Plat plat = new Plat("poutine", 10.00, lstIngredients);

            string chaineRetournee = plat.ToString();

            Assert.AreEqual(chaineRetournee, "poutine 10,00 $");
        }
    }
}