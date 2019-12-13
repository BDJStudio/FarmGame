using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBttns : MonoBehaviour
{
    public DataBase db;
    public Inventory inv;

    public GameObject Bttn;
    public bool isPickButtn;
    public bool PickUp, isWheat, isCarrot, isTomato, isPotato;

    public GameObject[] arr, arr2, arr3, arr4;
    public GameObject bttn;

    private GameObject Wheat;

    public void Start()
    {
        inv = GameObject.Find("Main Camera").GetComponent<Inventory>();
        db = GameObject.Find("Main Camera").GetComponent<DataBase>();

        Wheat = GameObject.Find("Wheat_PickUp");
        
    }

    public void Update()
    {
        // замути булл что бы не спавнить кнопку когда растение посажено, то бишь булл должнен быть в посадке, а кнопка ссылаться на него

        // условие для кнопки "посадить" что бы она появлялась после того как мы соберем урожай
        if (!isPickButtn)
        {
            arr = GameObject.FindGameObjectsWithTag("1");
            arr2 = GameObject.FindGameObjectsWithTag("4");
            arr3 = GameObject.FindGameObjectsWithTag("2");
            arr4 = GameObject.FindGameObjectsWithTag("3");

           
            if (isWheat)
            {
                bttn = GameObject.Find("Bttn_Grubing_Wheat");
                if(arr.Length == 0)
                {
                    Bttn.GetComponent<Grubing>().isDelete = false;
                }
            }

            if (isCarrot)
            {
                bttn = GameObject.Find("Bttn_Grubing_Carrot");
                if (arr2.Length == 0)
                {
                    Bttn.GetComponent<Grubing>().isDelete = false;
                }
            }

            if (isTomato)
            {
                bttn = GameObject.Find("Bttn_Grubing_Tomato");
                if (arr3.Length == 0)
                {
                    Bttn.GetComponent<Grubing>().isDelete = false;
                }
            }

            if (isPotato)
            {
                bttn = GameObject.Find("Bttn_Grubing_Potato");
                if (arr4.Length == 0)
                {
                    Bttn.GetComponent<Grubing>().isDelete = false;
                }
            }
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (isPickButtn)
        {
            if (collision.tag == "Player" && PickUp == true)
            {
                Bttn.SetActive(true);

            }
        }
        else
        {
            if (collision.tag == "Player" && !Bttn.GetComponent<Grubing>().isDelete)
            {
                Bttn.SetActive(true);
            }
            else
            {
                Bttn.SetActive(false);
            }
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Bttn.SetActive(false);
        }
    }

    public void OnApplicationQuit()//  при выходе из игры
    {
        if (isWheat)
        {
            bttn = GameObject.Find("Bttn_Grubing_Wheat");
            if (arr.Length != 0)
            {
                inv.AddItem(1, db.items[1], 1, db.items[1].price);
                inv.UpdateInventory();
            }
        }

        if (isCarrot)
        {
            bttn = GameObject.Find("Bttn_Grubing_Carrot");
            if (arr2.Length != 0)
            {
                inv.SearchForSameItem(db.items[4], 1, db.items[4].price);
            }
        }

        if (isTomato)
        {
            bttn = GameObject.Find("Bttn_Grubing_Tomato");
            if (arr3.Length != 0)
            {
                inv.SearchForSameItem(db.items[2], 1, db.items[2].price);
            }
        }

        if (isPotato)
        {
            bttn = GameObject.Find("Bttn_Grubing_Potato");
            if (arr4.Length != 0)
            {
                inv.SearchForSameItem(db.items[3], 1, db.items[3].price);
            }
        }
    }

}
