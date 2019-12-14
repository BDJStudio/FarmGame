using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{






		static public Vector2 LoadVector2(string key)//Загрузка Местоположения
    {
        if (PlayerPrefs.HasKey(key + "X"))//Проверка есть ли ключ
        {
            return new Vector2(PlayerPrefs.GetFloat(key + "X"),
                               PlayerPrefs.GetFloat(key + "Y"));
        }
        return Vector2.zero;//Первый раз зашел-> тебя кидает на координаты x:0 y:0
    }

    static public int LoadScore(string key)//Загрузка ДЕНяГ
    {
        if (PlayerPrefs.HasKey(key))//Проверка есть ли ключ
        {
            return PlayerPrefs.GetInt(key);
        }
        return 199;//Если нет ключа(или ты первый раз зашел в игру) даем 199 деняг
    }

    static public int LoadInventory(string key)//Загрузка инвентаря
    {
        if (PlayerPrefs.HasKey(key))//Проверка есть ли ключ
        {
            return PlayerPrefs.GetInt(key);
        }
        return 0;//хз
    }

    static public int LoatGlTimeDay(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return PlayerPrefs.GetInt(key);
        }
        return 1;
    }

    static public int LoadGrubing(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return PlayerPrefs.GetInt(key);
        }
        return 0;
    }
}
