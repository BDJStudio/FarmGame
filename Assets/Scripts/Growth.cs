using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growth : MonoBehaviour
{
    
    public Sprite[] sprites;
    
    public GameObject Trigger;
    public bool Pick, isGrowthing;
    public float time;

    public int hour;

	private float allTime;
	public float timeInPercent;
	public float onePercent;
	public float secondsToPercent;

	public int currentSprite;

    private GameObject Bttns;

    void Start()
    {
        Bttns = GameObject.Find("Bttn_Grubing_Wheat");
		allTime = time * 60;//время в секундах до выроста
		onePercent = allTime / 100;//один процент
	}

	public static void forAdd()
	{

	}

    void Update()
    {
		if(secondsToPercent >= onePercent)
		{
			timeInPercent++;
			secondsToPercent = 0;
		}

        // функция роста
        if (timeInPercent < 100) // растет пока не кончится время
        {
            Rost();
        }
        else // после готова к сбору
        {
			readyToPickUp();
		}

		if ((int)timeInPercent % 25 == 0)
		{
			currentSprite = (int)timeInPercent / 25;
		}
		GetComponent<SpriteRenderer>().sprite = sprites[currentSprite];
	}
	public void readyToPickUp()
	{
		Pick = true;
		Trigger.GetComponent<ActiveBttns>().PickUp = true;
	}

    void Rost()
    {
		secondsToPercent += Time.deltaTime;

		isGrowthing = true;


	}
}
