using System;
using UnityEngine;


[Serializable]
public class Item
{
    public string id;
    public int amount;

    public Item(string id, int amount)
    {
        this.id = id;
        this.amount = amount;
    }
}