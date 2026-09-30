using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Quest : MonoBehaviour
{
    public int level;
    public int gold;
    public int experience;
    public string description;
    public bool haveItems;
    public List<Item> items;

    public void GenerateQuest()
    {
        level = Random.Range(1, 10);

        gold = level * (10+Random.Range(1, 10));
        experience = level * (100+Random.Range(10,100));
    }

    public void GenerateItems()
    {
        int itemsCount = Random.Range(1, 6);
        items.Clear();

        for (int i = 0; i < itemsCount; i++) {
            items.Add(GetRandomItem());
        }
    }

    private Item GetRandomItem()
    {
        Array values = Enum.GetValues(typeof(Item));
        int index = Random.Range(0, values.Length);
        return (Item)values.GetValue(index);
    }
}


public enum Item
{ 
    Sword,
    Axe,
    Shield,
    Bow,
    Dagger,
}
