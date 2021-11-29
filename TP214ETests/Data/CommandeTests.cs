using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace TP214E.Data.Tests
{
    [TestClass()]
    public class CommandeTests
    {
        // commentaire ajouté juste pour pouvoir push pour tester l'action gitHub tag TP3-V1.0.3-beta
        [TestMethod()]
        public void Commande_test_accesseur_Id()
        {
            Commande commande = new Commande();
            ObjectId id = ObjectId.GenerateNewId();

            commande.Id = id;

            Assert.AreEqual(commande.Id, id);
        }

        [TestMethod()]
        public void Commande_CalculerPrixAvantTaxes_donne_le_bon_nombre()
        {
            List<Ingredient> lstIngredients = new List<Ingredient>();
            Ingredient ingredient = new Ingredient("Frites", 300, "grammes", "aliment");
            lstIngredients.Add(ingredient);
            Plat poutine = new Plat("poutine", 10.00, "Plat principal", lstIngredients);
            Commande commande = new Commande();
            commande.AjouterPlat(poutine);
            commande.AjouterPlat(poutine);

            commande.CalculerPrixAvantTaxes();

            Assert.AreEqual(commande.PrixAvantTaxes, 20.00);
        }

        [TestMethod()]
        public void Commande_AjouterPlat_ajoute_le_plat_a_la_commande()
        {
            List<Ingredient> lstIngredients = new List<Ingredient>();
            Ingredient ingredient = new Ingredient("Frites", 300, "grammes","aliment");
            lstIngredients.Add(ingredient);
            Plat poutine = new Plat("poutine", 10.00, "Plat principal", lstIngredients);
            Commande commande = new Commande();

            commande.AjouterPlat(poutine);

            Assert.AreEqual(commande.Plats[0], poutine);
        }

        [TestMethod()]
        public void Commande_SupprimerPlat_supprime_le_plat_de_la_commande()
        {
            List<Ingredient> lstIngredientsPoutine = new List<Ingredient>();
            Ingredient ingredientFrites = new Ingredient("Frites", 300, "grammes", "aliment");
            lstIngredientsPoutine.Add(ingredientFrites);
            Plat poutine = new Plat("Poutine", 10.00, "Plat principal", lstIngredientsPoutine);

            List<Ingredient> lstIngredientsBurger = new List<Ingredient>();
            Ingredient ingredientBurger = new Ingredient("Viande Hachée", 300, "grammes", "aliment");
            lstIngredientsBurger.Add(ingredientBurger);
            Plat burger = new Plat("Burger", 15.00, "Plat principal", lstIngredientsBurger);
            Commande commande = new Commande();
            commande.AjouterPlat(poutine);
            commande.AjouterPlat(burger);

            Plat platQuiSeraSupprime = commande.Plats[0];

            commande.SupprimerPlat(poutine);

            Assert.AreNotEqual(commande.Plats[0], platQuiSeraSupprime);
        }

        [TestMethod()]
        public void Commande_CalculerTps_donne_le_bon_nombre()
        {
            List<Ingredient> lstIngredients = new List<Ingredient>();
            Ingredient ingredient = new Ingredient("Frites", 300, "grammes", "aliment");
            lstIngredients.Add(ingredient);
            Plat poutine = new Plat("poutine", 10.00, "Plat principal", lstIngredients);
            Commande commande = new Commande();
            commande.AjouterPlat(poutine);

            commande.CalculerPrixAvantTaxes();
            commande.CalculerTps();

            Assert.AreEqual(commande.Tps, 0.5);
        }

        [TestMethod()]
        public void Commande_CalculerTvq_donne_le_bon_nombre()
        {
            List<Ingredient> lstIngredients = new List<Ingredient>();
            Ingredient ingredient = new Ingredient("Frites", 300, "grammes", "aliment");
            lstIngredients.Add(ingredient);
            Plat poutine = new Plat("poutine", 10.00, "Plat principal", lstIngredients);
            Commande commande = new Commande();
            commande.AjouterPlat(poutine);

            commande.CalculerPrixAvantTaxes();
            commande.CalculerTvq();

            Assert.AreEqual(commande.Tvq, 0.9975);
        }

        [TestMethod()]
        public void Commande_CalculerPrixTotal_donne_le_bon_nombre()
        {
            List<Ingredient> lstIngredients = new List<Ingredient>();
            Ingredient ingredient = new Ingredient("Frites", 300, "grammes", "aliment");
            lstIngredients.Add(ingredient);
            Plat poutine = new Plat("poutine", 10.00, "Plat principal", lstIngredients);
            Commande commande = new Commande();
            commande.AjouterPlat(poutine);

            commande.CalculerPrixTotal();

            Assert.AreEqual(commande.PrixTotal, 1,4975);
        }

        [TestMethod()]
        public void Commande_ToString_retourne_la_bonne_string()
        {
            Commande commande = new Commande();
            DateTime dateDeLaCommande = commande.Date;

            string chaineAVerifier = commande.ToString();

            Assert.AreEqual(chaineAVerifier, $"{dateDeLaCommande} 0,00 $");
        }
    }
}