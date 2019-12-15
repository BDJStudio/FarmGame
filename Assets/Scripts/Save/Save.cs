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



    static public void SaveGrubing(string key, int items)
    {
        PlayerPrefs.SetInt(key, items);
    }


	static public void savePosajenieVegetables()
	{
		saveWheat();
		saveCarrot();
		savePotato();
		saveTomato();
	}

	static public void saveWheat()
	{
		if (GameObject.Find("Wheat_PickUp(Clone)") != null)
		{

			for (int i = 1; i <= 3; i++)
			{
				PlayerPrefs.SetInt("timeWheat" + i.ToString(), GameObject.Find("Wheat_" + i.ToString()).GetComponent<Growth>().hour);
				PlayerPrefs.SetInt("WheatSprite", GameObject.Find("Wheat_" + i.ToString()).GetComponent<Growth>().currentSprite);
				PlayerPrefs.SetFloat("WheatTimeToGrow", GameObject.Find("Wheat_" + i.ToString()).GetComponent<Growth>().timeInPercent);
			}
			PlayerPrefs.SetInt("Wheat", 1);
		}
	}
	static public void saveCarrot()
	{
		if (GameObject.Find("Carrot_PickUp(Clone)") != null)
		{
			for (int i = 1; i <= 3; i++)
			{
				PlayerPrefs.SetInt("timeCarrot" + i, GameObject.Find("Carrot_" + i).GetComponent<Growth>().hour);
				PlayerPrefs.SetInt("CarrotSprite", GameObject.Find("Carrot_" + i.ToString()).GetComponent<Growth>().currentSprite);
				PlayerPrefs.SetFloat("CarrotTimeToGrow", GameObject.Find("Carrot_" + i.ToString()).GetComponent<Growth>().timeInPercent);
			}

			PlayerPrefs.SetInt("Carrot", 1);
		}

	}
	static public void saveTomato()
	{

		if (GameObject.Find("Tomato_PickUp(Clone)") != null)
		{
			for (int i = 1; i <= 3; i++)
			{
				PlayerPrefs.SetInt("timeTomato" + i.ToString(), GameObject.Find("Tomato_" + i.ToString()).GetComponent<Growth>().hour);
				PlayerPrefs.SetInt("TomatoSprite", GameObject.Find("Tomato_" + i.ToString()).GetComponent<Growth>().currentSprite);
				PlayerPrefs.SetFloat("TomatoTimeToGrow", GameObject.Find("Tomato_" + i.ToString()).GetComponent<Growth>().timeInPercent);
			}

			PlayerPrefs.SetInt("Tomato", 1);
		}
	}

	static public void savePotato()
	{

		if (GameObject.Find("Potato_PickUp(Clone)") != null)
		{
			for (int i = 1; i <= 3; i++)
			{
				PlayerPrefs.SetInt("timePotato" + i, GameObject.Find("Potato_" + i).GetComponent<Growth>().hour);
				PlayerPrefs.SetInt("PotatoSprite", GameObject.Find("Potato_" + i.ToString()).GetComponent<Growth>().currentSprite);
				PlayerPrefs.SetFloat("PotatoTimeToGrow", GameObject.Find("Potato_" + i.ToString()).GetComponent<Growth>().timeInPercent);
			}

			PlayerPrefs.SetInt("Potato", 1);
		}
	}

	static public void saveEnergy()
	{
		PlayerPrefs.SetInt("Energy", GameObject.Find("Main Camera").GetComponent<Power>().currentEnergy);
	}
}
  
