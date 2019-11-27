using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBttns : MonoBehaviour
{
    public GameObject Bttn;
    public bool isPickButtn;
    public bool PickUp, isWheat, isCarrot, isTomato, isPotato;

    public GameObject[] arr;
    public GameObject bttn;

    public void Start()
    {
        if (!isPickButtn)
        {
            if (isWheat)
            {
                bttn = GameObject.Find("Bttn_Grubing_Wheat");
            }

            if (isCarrot)
            {
                bttn = GameObject.Find("Bttn_Grubing_Carrot");
            }

            if (isTomato)
            {
                bttn = GameObject.Find("Bttn_Grubing_Tomato");
            }

            if (isPotato)
            {
                bttn = GameObject.Find("Bttn_Grubing_Potato");
            }
        }
        
    }

    public void Update()
    {
        // условие для кнопки "посадить" что бы она появлялась после того как мы соберем урожай
        if (!isPickButtn)
        {
            arr = GameObject.FindGameObjectsWithTag("Finish");

            if (Bttn.GetComponent<Grubing>().isDelete && arr.Length <= 0)
            {
                Bttn.GetComponent<Grubing>().isDelete = false;
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
}
