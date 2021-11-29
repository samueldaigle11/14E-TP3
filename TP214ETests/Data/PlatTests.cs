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
            Ingredient ingredient = new Ingredient("Frites", 300, "grammes", "aliment");
            lstIngredients.Add(ingredient);
            Plat poutine = new Plat("poutine", 10.00, "Plat principal", lstIngredients);
            ObjectId id = ObjectId.GenerateNewId();

            poutine.Id = id;

            Assert.AreEqual(poutine.Id, id);
        }

        [TestMethod()]
        public void Plat_ToString_retourne_la_bonne_string()
        {
            List<Ingredient> lstIngredients = new List<Ingredient>();
            Ingredient ingredient = new Ingredient("Frites", 300, "grammes", "aliment");
            lstIngredients.Add(ingredient);
            Plat poutine = new Plat("poutine", 10.00, "Plat principal", lstIngredients);

            string chaineRetournee = poutine.ToString();

            Assert.AreEqual(chaineRetournee, "poutine 10,00 $");
        }
    }
}