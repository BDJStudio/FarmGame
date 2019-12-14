using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataBase : MonoBehaviour
{
    public List<Item> items = new List<Item>(); //список элементов инвентаря
}

[System.Serializable]

public class Item
{
    public int id;
    public string name;
    public Sprite img;
    public int price;
}