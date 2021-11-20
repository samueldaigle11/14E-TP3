using MongoDB.Bson;
namespace TP214E.Data
{
    public class Plat
    {
        private ObjectId _id;
        private string _nom;
        private double _prix;

        public Plat(string pNom, double pPrix)
        {
            Nom = pNom;
            Prix = pPrix;
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

        public override string ToString()
        {
            return $"{Nom} {Prix:C2}";
        }
    }
}