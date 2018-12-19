using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderShop : ScriptableObject {

    [SerializeField] int trophyCost = 100;
    [SerializeField] int cactusCost = 100;

    public int GetTrophyCost() { return trophyCost; }
    public int GetCactusCost() { return cactusCost; }
}
