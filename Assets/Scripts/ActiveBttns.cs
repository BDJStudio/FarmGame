using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBttns : MonoBehaviour
{
    public GameObject Bttn;
    public bool isPickButtn;
    public bool PickUp;

    public GameObject[] arr;

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
