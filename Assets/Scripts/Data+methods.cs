using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class Data {
    public static ARModel FindModelByName(string name)
    {
        return models.Find(m => m.Name == name);
    }
}