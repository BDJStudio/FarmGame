using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grubing : MonoBehaviour
{
    public GameObject activate, player;
    public bool isDelete;
    public int ID_items; // тут пишем ИД итема из датабейс овоща который собираемся давать

    private DataBase db;
    private Inventory inv;

    public void Start()
    {
        inv = GameObject.Find("Main Camera").GetComponent<Inventory>();
        db = GameObject.Find("Main Camera").GetComponent<DataBase>();
    }

    public void OnMouseDown()
    {
        // при нажатии на кнопку ище в инвентаре нужные семена и их колл-во
        inv.SearchItems(db.items[ID_items], 1);

        // тут мы их садим
        if (inv.searchINT == ID_items)
        {
            player.GetComponent<Animator>().SetBool("BoolGrub", true);
            Instantiate(activate, transform.position + new Vector3(2, -5.1f, 0), Quaternion.identity);
            StartCoroutine(Delete());
        }
    }


    // функция прячет кнопку
    IEnumerator Delete()
    {
        
        yield return new WaitForSeconds(0.9f);
        inv.UpdateInventory();
        gameObject.SetActive(false);
        isDelete = true;

        player.GetComponent<Animator>().SetBool("BoolGrub", false);
    }
}
