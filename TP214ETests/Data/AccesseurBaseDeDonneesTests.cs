using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP214E.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace TP214E.Data.Tests
{
    [TestClass()]
    public class AccesseurBaseDeDonneesTests
    {
        //[TestMethod()]
        //public void AccesseurBaseDeDonnees_constructeur_utilise_OuvrirConnexion()
        //{
        //    // arrange
        //    var accesseurBaseDonneesMock = new Mock<IAccesseurBaseDeDonnees>();

        //    accesseurBaseDonneesMock.

        //    accesseurBaseDonneesMock.Verify(x => x.Ouv);
        //}

        // test inutile finalement
        //[TestMethod()]
        //public void AccesseurBD_ObtenirPlats_retourne_bon_nombre_plats()
        //{
        //    // arrange
        //    var accesseurBaseDonneesMock = new Mock<IAccesseurBaseDeDonnees>();
        //    List<Plat> plats = new List<Plat>();
        //    Plat plat = new Plat("poutine", 10.00);
        //    plats.Add(plat);
        //    plat = new Plat("Salade", 8.00);
        //    plats.Add(plat);

        //    // act
        //    accesseurBaseDonneesMock.Setup(x => x.ObtenirPlats()).Returns(plats);
        //    plats = accesseurBaseDonneesMock.Object.ObtenirPlats();

        //    // assert
        //    Assert.AreEqual(plats.Count, 2);
        //}

        //[TestMethod()]
        //public void AccesseurBD_ObtenirPlats_appelle_get_collection()
        //{
        //    // arrange
        //    AccesseurBaseDeDonnees accesseurBD = new AccesseurBaseDeDonnees();
        //    var accesseurBaseDonneesMock = new Mock<IAccesseurBaseDeDonnees>();
        //    accesseurBaseDonneesMock.Object.SetBasicProperties(accesseurBD);
        //    List<Plat> plats = new List<Plat>();

        //    // act
        //    accesseurBaseDonneesMock.Setup(x => x.ObtenirPlats()).Returns(plats);
        //    plats = accesseurBaseDonneesMock.Object.ObtenirPlats();

        //    // assert
        //    accesseurBaseDonneesMock.Verify(x => x.);
        //}


        //[TestMethod()]
        //public void AccesseurBD_AjouterObjet_ajoute_bien_l_objet()
        //{
        //    // arrange
        //    var accesseurBaseDonneesMock = new Mock<IAccesseurBaseDeDonnees>();
        //    List<Plat> plats = new List<Plat>();
        //    Plat plat = new Plat("poutine", 10.00);
        //    plats.Add(plat);
        //    plat = new Plat("Salade", 8.00);
        //    plats.Add(plat);

        //    // act
        //    accesseurBaseDonneesMock.Setup(x => x.ObtenirPlats()).Returns(plats);
        //    plats = accesseurBaseDonneesMock.Object.ObtenirPlats();

        //    // assert
        //    Assert.AreEqual(plats.Count, 2);
        //}

        [TestMethod()]
        public void SupprimerObjetTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ModifierObjetTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AjouterCommandeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ObtenirCommandesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ObtenirObjetsInventaireTest()
        {
            Assert.Fail();
        }
    }
}