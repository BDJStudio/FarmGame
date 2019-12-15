using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Market : MonoBehaviour
{
    public DataBase data;
    public Inventory inv;

    public GameObject marketPanel, buttOk, buttClose;
    public GameObject background;
    public Collider2D colPlayer;

    private bool check = false;


    void Start()
    {

    }


    public void clickMarket()
    {
        marketPanel.SetActive(true);
    }

    public void ClickOkOne()
    {
        if (Score.score >= data.items[1].price)
        {
            inv.SearchForSameItem(data.items[1], 1, data.items[1].price);
            inv.UpdateInventory();

            Score.score -= data.items[1].price;
        }
    }

    public void ClickOkTwo()
    {
        if (Score.score >= data.items[2].price)
        {
            inv.SearchForSameItem(data.items[2], 1, data.items[2].price);
            inv.UpdateInventory();

            Score.score -= data.items[2].price;
        }
    }

    public void ClickOkTree()
    {
        if (Score.score >= data.items[3].price)
        {
            inv.SearchForSameItem(data.items[3], 1, data.items[3].price);
            inv.UpdateInventory();

            Score.score -= data.items[3].price;
        }
    }

    public void ClickOkFour()
    {
        if (Score.score >= data.items[4].price)
        {
            inv.SearchForSameItem(data.items[4], 1, data.items[4].price);
            inv.UpdateInventory();

            Score.score -= data.items[4].price;
        }
    }


    public void ClickClose() 
    {
        marketPanel.SetActive(false);
    }

    void Update()
    {
        if (check == false && colPlayer.IsTouching(GetComponent<Collider2D>()))
        {
            background.SetActive(!background.activeSelf);
            check = true;
        }
        if (check == true && !colPlayer.IsTouching(GetComponent<Collider2D>()))
        {
            background.SetActive(!background.activeSelf);
            check = false;
        }
    }
}
