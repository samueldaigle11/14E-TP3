using System;
using System.Collections.Generic;
using System.Globalization;
using MongoDB.Bson;

namespace TP214E.Data
{
    public class Commande
    {
        private ObjectId _id;
        private List<Plat> _plats;
        private DateTime _date;
        private double _prixAvantTaxes;
        private double _tps;
        private double _tvq;
        private double _prixTotal;

        public Commande()
        {
            Plats = new List<Plat>();
            Date = ObtenirDateActuelleHeureDeLEst();
            PrixAvantTaxes = 0;
            Tps = 0;
            Tvq = 0;
            PrixTotal = 0;
        }

        public ObjectId Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public List<Plat> Plats
        {
            get { return _plats; }
            set { _plats = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public double PrixAvantTaxes
        {
            get { return _prixAvantTaxes; }
            set { _prixAvantTaxes = value; }
        }

        public double Tps
        {
            get { return _tps; }
            set { _tps = value; }
        }

        public double Tvq
        {
            get { return _tvq; }
            set { _tvq = value; }
        }

        public double PrixTotal
        {
            get { return _prixTotal; }
            set { _prixTotal = value; }
        }

        public static DateTime ObtenirDateActuelleHeureDeLEst()
        {
            TimeSpan heuresASoustraireDeUTCPourHeureDeLEst = new System.TimeSpan(5, 0, 0);
            DateTime dateActuelle = DateTime.UtcNow.Subtract(heuresASoustraireDeUTCPourHeureDeLEst);

            return dateActuelle;
        }

        public void CalculerPrixAvantTaxes()
        {
            PrixAvantTaxes = 0;

            foreach (Plat plat in _plats)
            {
                PrixAvantTaxes += plat.Prix;
            }
        }

        public void AjouterPlat(Plat pPlatAAjouter)
        {
            Plats.Add(pPlatAAjouter);
        }

        public void SupprimerPlat(Plat pPlatASupprimer)
        {
            Plats.Remove(pPlatASupprimer);
        }

        public void CalculerTps()
        {
            Tps = PrixAvantTaxes * 0.05;
        }

        public void CalculerTvq()
        {
            Tvq = PrixAvantTaxes * 0.09975;
        }

        public void CalculerPrixTotal()
        {
            CalculerPrixAvantTaxes();
            CalculerTps();
            CalculerTvq();
            PrixTotal = PrixAvantTaxes + Tps + Tvq;
        }

        public override string ToString()
        {
            double prixTotal = Math.Round(PrixTotal,2);

            return string.Format("{0} {1:0.##} $", Date,prixTotal.ToString("0.00", new CultureInfo("fr-CA")));
        }
    }
}
