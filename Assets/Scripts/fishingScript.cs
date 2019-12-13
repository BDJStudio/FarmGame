using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class fishingScript : MonoBehaviour
{
	public Controller player;
	public DataBase db;
	public Inventory inv;
	public swapFishSprite swapFish;
    
	public int fishes;

	SpriteRenderer fishSprite;


	public int fishingTime;

	public int catchFishID;

	float power;

	public bool catched;
	public bool coroutineStarted;


    void Start()
    {
		power = player.power;
		//fishes = 4;
        
		fishSprite = player.fishSprite;

		catched = false;
		fishingTime = 30;


    }

    public IEnumerator checkFishfor()//сорян ну рил жопа уже горит
    {
        /*if (fishingTime == 1)
        {

        }*/

        while (true)
        {
            yield return new WaitForSeconds(1f);

            checkFish();

        }
    }

    void checkFish()
	{
		if (player.poplavokInWater)
		{

			catchFish();
			//print("Ловлю");
			//print(fishingTime);
		}

	}

	public void catchFish()
	{
		if (fishingTime != 0 && !catched)
		{
			fishingTime--;
		}

		if (fishingTime == 0)
		{
			
			catchFishID = Random.Range(5, 7);// рандом выпадания ИД итемов из списка
			/*if (catchFishID < fishes / 2)
			{
				catchFishID = Random.Range(0, fishes);
			}*/
			


			catched = true;
			fishingTime--;
			swapFish.swapSprite();
		}
    }

	public void getFish()
	{
		inv.SearchForSameItem(db.items[catchFishID], 1, db.items[catchFishID].price);
		inv.UpdateInventory();


		catched = false;
	}
}
