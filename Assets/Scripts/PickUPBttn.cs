using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUPBttn : MonoBehaviour
{
    //это скрипт кнопки которая собирает урожай и добовляет его в инвентарь
    private DataBase db;
    private Inventory inv;
    private GameObject father; // сюда пишем имя префаба, что бы после сбора он удалился со сцены

    public string namePref;
    public int ID_items; // тут пишем ИД итема из датабейс овоща который собираемся давать
    public GameObject sp1, sp2, sp3;

    void Start()
    {
        inv = GameObject.Find("Main Camera").GetComponent<Inventory>();
        db = GameObject.Find("Main Camera").GetComponent<DataBase>();
        father = GameObject.Find(namePref);
    }

    public void OnMouseDown()
    {
        if (sp1.GetComponent<Growth>().Pick == true &&
            sp2.GetComponent<Growth>().Pick == true &&
            sp3.GetComponent<Growth>().Pick == true)
        {
            inv.SearchForSameItem(db.items[ID_items], 9, db.items[ID_items].price);
            inv.UpdateInventory();
            StartCoroutine(Delete());
        }
    }

    IEnumerator Delete()
    {
        yield return new WaitForSeconds(0.1f);

        Destroy(father);
    }

    public void OnMouseUp()
    {
        sp1.GetComponent<Growth>().Pick = false;
        sp2.GetComponent<Growth>().Pick = false;
        sp3.GetComponent<Growth>().Pick = false;
    }
    
}
