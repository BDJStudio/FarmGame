using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forAd : MonoBehaviour
{
	public Dictionary<string, GameObject> dictOfVegetables = new Dictionary<string, GameObject>();
	public GameObject[] vegetableGameObjects;


	public void Update()
	{
		vegetableGameObjects = GameObject.FindGameObjectsWithTag("Vegetable");

		for (int i = 0; i < vegetableGameObjects.Length; i++)
		{
			GameObject go = vegetableGameObjects[i];
			if (!dictOfVegetables.ContainsKey(go.name) && dictOfVegetables != null)
				dictOfVegetables.Add(go.name, go);
		}
	}



//при вызове методов полностью выращивают грядку с выбранным овощем. Не работает, если грядка не засажена
public void adWheat()
	{
		for(int i = 1; i <=3; i++)
		{
			GameObject wheatToGrow = dictOfVegetables["Wheat_" + i];

			Growth wheatGrowth = wheatToGrow.GetComponent<Growth>();

			wheatToGrow.GetComponent<SpriteRenderer>().sprite = wheatGrowth.sprites[4];
			wheatGrowth.hour = (int)wheatGrowth.time;
			wheatGrowth.timeInPercent = 100;
			wheatGrowth.readyToPickUp();
		}
		dictOfVegetables.Clear();
	}

	public void adTomato()
	{
		for (int i = 1; i <= 3; i++)
		{
			GameObject potatoToGrow = dictOfVegetables["Wheat_" + i];

			Growth potatoGrowth = potatoToGrow.GetComponent<Growth>();

			potatoToGrow.GetComponent<SpriteRenderer>().sprite = potatoGrowth.sprites[4];
			potatoGrowth.hour = (int)potatoGrowth.time;
			potatoGrowth.timeInPercent = 100;
			potatoGrowth.Pick = true;
			potatoGrowth.readyToPickUp();

			dictOfVegetables.Remove("Tomato_" + i);
		}
		dictOfVegetables.Clear();
	}
	public void adCarrot()
	{
		for (int i = 1; i <= 3; i++)
		{
			GameObject carrotToGrow = dictOfVegetables["Wheat_" + i];

			Growth carrotGrowth = carrotToGrow.GetComponent<Growth>();

			carrotToGrow.GetComponent<SpriteRenderer>().sprite = carrotGrowth.sprites[4];
			carrotGrowth.hour = (int)carrotGrowth.time;
			carrotGrowth.timeInPercent = 100;
			carrotGrowth.Pick = true;
			carrotGrowth.readyToPickUp();

			dictOfVegetables.Remove("Carrot_" + i);
		}
		dictOfVegetables.Clear();
	}
	public void adPotato()
	{
		for (int i = 1; i <= 3; i++)
		{
			GameObject wheatToGrow = dictOfVegetables["Wheat_" + i];

			Growth potatoGrowth = wheatToGrow.GetComponent<Growth>();

			wheatToGrow.GetComponent<SpriteRenderer>().sprite = potatoGrowth.sprites[4];
			potatoGrowth.hour = (int)potatoGrowth.time;
			potatoGrowth.timeInPercent = 100;
			potatoGrowth.Pick = true;
			potatoGrowth.readyToPickUp();

			dictOfVegetables.Remove("Potato_" + i);

		}
		dictOfVegetables.Clear();
	}




}
