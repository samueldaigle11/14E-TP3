using System;
using System.Collections.Generic;
using System.Windows;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TP214E.Data
{
    public class AccesseurBaseDeDonnees
    {
        private MongoClient clientMongoDB;
        private IMongoDatabase baseDeDonnees;

        public AccesseurBaseDeDonnees()
        {
            clientMongoDB = OuvrirConnexion();

            try
            {
                baseDeDonnees = clientMongoDB.GetDatabase("TP3DB");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " 
                                + exception.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public List<Plat> ObtenirPlats()
        {
            return baseDeDonnees.GetCollection<Plat>("plats").Aggregate().ToList();
        }

        public void AjouterPlat(Plat platAAjouter)
        {
            IMongoCollection<Plat> platCollection =
                baseDeDonnees.GetCollection<Plat>("plats");

            platCollection.InsertOne(platAAjouter);
        }

        public void SupprimerPlat(Plat platASupprimer)
        {
            IMongoCollection<Plat> platCollection =
                baseDeDonnees.GetCollection<Plat>("plats");

            var filtre = Builders<Plat>.Filter.Eq("_id", platASupprimer.Id);
            platCollection.DeleteOne(filtre);
        }

        public void AjouterObjet(ObjetInventaire objetAAjouter)
        {
            IMongoCollection<ObjetInventaire> objetInventaireCollection = 
                baseDeDonnees.GetCollection<ObjetInventaire>("objetsInventaire");

            objetInventaireCollection.InsertOne(objetAAjouter);
        }

        public void SupprimerObjet(ObjetInventaire objetASupprimer)
        {
            IMongoCollection<ObjetInventaire> objetInventaireCollection = 
                baseDeDonnees.GetCollection<ObjetInventaire>("objetsInventaire");

            var filtre = Builders<ObjetInventaire>.Filter.Eq("_id", objetASupprimer.Id);
            objetInventaireCollection.DeleteOne(filtre);
        }

        public void ModifierObjet(ObjectId idObjetAModifier, ObjetInventaire objetAvecModifications)
        {
            IMongoCollection<ObjetInventaire> objetInventaireCollection = 
                baseDeDonnees.GetCollection<ObjetInventaire>("objetsInventaire");

            var filtre = Builders<ObjetInventaire>.Filter.Eq("_id", idObjetAModifier);
            var modifications = Builders<ObjetInventaire>.Update
                .Set("Nom", objetAvecModifications.Nom)
                .Set("Quantite", objetAvecModifications.Quantite);

            if (objetAvecModifications.GetType() == typeof(Aliment))
            {
                modifications = Builders<ObjetInventaire>.Update
                    .Set("Nom", objetAvecModifications.Nom)
                    .Set("Quantite", objetAvecModifications.Quantite)
                    .Set("Unite", ((Aliment)objetAvecModifications).Unite)
                    .Set("DatePeremption", ((Aliment)objetAvecModifications).DatePeremption);
            }

            objetInventaireCollection.UpdateOne(filtre, modifications);
        }

        public void AjouterCommande(Commande commandeAAjouter)
        {
            IMongoCollection<Commande> commandeCollection = baseDeDonnees.GetCollection<Commande>("Commandes");
            commandeCollection.InsertOne(commandeAAjouter);
        }

        public List<Commande> ObtenirCommandes()
        {
            return baseDeDonnees.GetCollection<Commande>("Commandes").Aggregate().ToList();
        }

        public List<ObjetInventaire> ObtenirObjetsInventaire()
        {
            return baseDeDonnees.GetCollection<ObjetInventaire>("objetsInventaire").Aggregate().ToList();
        }

        public List<ObjetInventaire> ObtenirObjetsInventaireSelonNom(string nomObjetsRecherches)
        {
            IMongoCollection<ObjetInventaire> objetsInventaireCollection = baseDeDonnees.GetCollection<ObjetInventaire>("objetsInventaire");
            
            var filtre = Builders<ObjetInventaire>.Filter.Eq("Nom", nomObjetsRecherches);
            return objetsInventaireCollection.Find(filtre).ToList();
        }

        private MongoClient OuvrirConnexion()
        {
            MongoClient clientBaseDeDonnees = null;

            try
            {
                clientBaseDeDonnees = new MongoClient("mongodb://localhost:27017/TP3DB");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return clientBaseDeDonnees;
        }
    }
}