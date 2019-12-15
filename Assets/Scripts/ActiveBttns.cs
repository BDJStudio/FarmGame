﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBttns : MonoBehaviour
{
    public DataBase db;
    public Inventory inv;

    public GameObject Bttn;

    public bool isPickButtn, isNightButtn;
    public bool PickUp, isWheat, isCarrot, isTomato, isPotato;

    public GameObject[] arr, arr2, arr3, arr4;

	public GameObject bttn;

    public void Start()
    {

        inv = GameObject.Find("Main Camera").GetComponent<Inventory>();
        db = GameObject.Find("Main Camera").GetComponent<DataBase>();
    }

    public void Update()
    {

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
				else
				{
					Bttn.GetComponent<Grubing>().isDelete = true;
				}
            }

            if (isCarrot)
            {
                bttn = GameObject.Find("Bttn_Grubing_Carrot");
                if (arr2.Length == 0)
                {
                    Bttn.GetComponent<Grubing>().isDelete = false;
                }
				else
				{
					Bttn.GetComponent<Grubing>().isDelete = true;
				}
			}

            if (isTomato)
            {
                bttn = GameObject.Find("Bttn_Grubing_Tomato");
                if (arr3.Length == 0)
                {
                    Bttn.GetComponent<Grubing>().isDelete = false;
                }
				else
				{
					Bttn.GetComponent<Grubing>().isDelete = true;
				}
			}

            if (isPotato)
            {
                bttn = GameObject.Find("Bttn_Grubing_Potato");
                if (arr4.Length == 0)
                {
                    Bttn.GetComponent<Grubing>().isDelete = false;
                }
				else
				{
					Bttn.GetComponent<Grubing>().isDelete = true;
				}
			}
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (isNightButtn)
        {
            if (collision.tag == "Player")
            {
                Bttn.SetActive(true);
            }
            else
            {
                Bttn.SetActive(false);
            }
        }

        if (isPickButtn)
        {
            if (collision.tag == "Player" && PickUp == true)
            {
                Bttn.SetActive(true);

            }
        }
        else if(!isNightButtn)
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

    }

}
