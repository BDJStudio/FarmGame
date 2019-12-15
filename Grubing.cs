using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grubing : MonoBehaviour
{
    public GameObject activate, player;
    public bool isDelete;
    public int ID_items;  // тут пишем ИД итема из датабейс овоща который собираемся давать

	

    private DataBase db;
    private Inventory inv;
    private Power pow;

    public void Start() 
    {
        inv = GameObject.Find("Main Camera").GetComponent<Inventory>();
        db = GameObject.Find("Main Camera").GetComponent<DataBase>();

        pow = GameObject.Find("Main Camera").GetComponent<Power>();
    }

    public void OnMouseDown()
    {
        // при нажатии на кнопку ище в инвентаре нужные семена и их колл-во
        inv.SearchItems(db.items[ID_items], 1);

        // тут мы их садим
        if (inv.searchINT == ID_items && pow.N != 0)
        {
            player.GetComponent<Animator>().SetBool("BoolGrub", true);
            Instantiate(activate, transform.position + new Vector3(2, -2.2f, 0), Quaternion.identity);
			
            StartCoroutine(Delete());
            pow.N--;
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
