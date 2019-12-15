using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grubing : MonoBehaviour
{
    public GameObject activate, player;
    public bool isDelete;
    public int ID_items;  // тут пишем ИД итема из датабейс овоща который собираемся давать

	public int powerWheat = 5;
	public int powerCarrot = 10;
	public int powerTomato = 20;
	public int powerPotato = 35;

	private int i = 0;
	private int powerMinus;

    private DataBase db;
    private Inventory inv;
	private Power pow;

	private bool lowPowerBool = false;
	private bool swapColor = false;

	public void Start() 
    {
        inv = GameObject.Find("Main Camera").GetComponent<Inventory>();
        db = GameObject.Find("Main Camera").GetComponent<DataBase>();

		pow = GameObject.Find("Main Camera").GetComponent<Power>();

		pow.updateEnergyText();

	}



    public void OnMouseDown()
    {

		// при нажатии на кнопку ище в инвентаре нужные семена и их колл-во




		inv.SearchItems(db.items[ID_items], 1, false);

		switch (activate.name.Split('_')[0])
		{
			case "Wheat":
				powerMinus = powerWheat;
				break;
			case "Carrot":
				powerMinus = powerCarrot;
				break;
			case "Tomato":
				powerMinus = powerTomato;
				break;
			case "Potato":
				powerMinus = powerPotato;
				break;
		}

		print(powerMinus);

		// тут мы их садим
		if (inv.searchINT == ID_items && pow.minusCurrentEnergy(powerMinus))
		{
			inv.SearchItems(db.items[ID_items], 1);

			player.GetComponent<Animator>().SetBool("BoolGrub", true);
			Instantiate(activate, transform.position + new Vector3(2, -2.2f, 0), Quaternion.identity);

			StartCoroutine(Delete());


		}

    }


    // функция прячет кнопку
    IEnumerator Delete()
    {
        isDelete = true;

        yield return new WaitForSeconds(0.1f);
        player.GetComponent<Animator>().SetBool("BoolGrub", false);
        inv.UpdateInventory();
		gameObject.SetActive(false);
        
    }

}
