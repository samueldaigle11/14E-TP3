using System.Collections.Generic;
using MongoDB.Bson;

namespace TP214E.Data
{
    public interface IPlat
    {
        ObjectId Id { get; set; }
        string Nom { get; set; }
        double Prix { get; set; }
        string Categorie { get; set; }
        List<Ingredient> Ingredients { get; set; }
    }
}