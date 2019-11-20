using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sell : MonoBehaviour
{
    //ТУТА буид магазин
    public Collider2D colPlayer;
    
    public Inventory inv;
    //Потом удалить
    bool check = false;
    
    void Update()
    {
        if (colPlayer.IsTouching(GetComponent<Collider2D>()))
        {
            inv.ClearInventory();
            check = true;
        }
        if (check == true && !colPlayer.IsTouching(GetComponent<Collider2D>()))
        {
            check = false;
        }
    }
}
