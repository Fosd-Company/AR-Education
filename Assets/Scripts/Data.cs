using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Data
{
    public static List<ARModel> models = new List<ARModel> {
        new ARModel(1, "Atom", "Particles", "Complete Physics for Cambridge"),
            new ARModel(2, "Axe", "Prehistoric Tools", "World History"),
            new ARModel(3, "Bow", "Prehistoric Tools", "World History"),
            new ARModel(4, "Capside", "Virus Parts", "Oxford Natural Sciences"),
            new ARModel(5, "Caravel", "History", "Prentice Hall American History"),
            new ARModel(6, "Digestion", "Body Parts", "Anatomy & Physiology"),
            new ARModel(7, "DNA", "Molecules", "Anatomy & Physiology"),
            new ARModel(8, "Earth", "Geography", "Oxford Essential Biology"),
            new ARModel(9, "Fungus", "Environment", "Oxford Essential Biology"),
            new ARModel(10, "Tree", "Environment", "Oxford Essential Biology"),
            new ARModel(11, "Omicron", "Virus", "Medical Microbiology"),
    };

    public static ARModel FindModelByName(string name)
    {
        return models.Find(m => m.Name == name);
    }
}

public class ARModel
{
    public int ID { get; }
    public string Name { get; }
    public string Type { get; }
    public string Book { get; }

    public ARModel(int id, string name, string type, string book) {
        ID = id;
        Name = name;
        Type = type;
        Book = book;
    }
}