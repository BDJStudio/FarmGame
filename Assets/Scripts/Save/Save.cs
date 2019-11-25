using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    static public void SaveVector3(string key, Vector2 vector2)//Сохранение Местоположния
    {
        PlayerPrefs.SetFloat(key + "X", vector2.x);
        PlayerPrefs.SetFloat(key + "Y", vector2.y);
    }

    static public void SaveScore(string key, int text)//Сохранение ДЕНяг
    {
        PlayerPrefs.SetInt(key, text);
    }

    static public void SaveGlTimeDay(string key, int day)//Сохранение Дня
    {
        PlayerPrefs.SetInt(key, day);
    }

    static public void SaveInventory(string key, int id, int count, int price)//Сохранение инвентаря
    {
        PlayerPrefs.SetInt(key + "Id", id);
        PlayerPrefs.SetInt(key + "Count", count);
        PlayerPrefs.SetInt(key + "Price", price);
    }

}
