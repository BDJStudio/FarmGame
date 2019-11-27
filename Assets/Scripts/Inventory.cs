using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    public DataBase data;

    public List<ItemInventory> items = new List<ItemInventory>();

    public GameObject gameObjShow;

    public GameObject InventoryMainObject;
    public int maxCount;

    public Camera cam;
    public EventSystem es;

    public int currentID;
    public ItemInventory currentItem;

    public RectTransform movingObject;
    public Vector3 offset;

    public GameObject background;

    public int searchINT;

    public void Start()
    {
        if (items.Count == 0)
        {
            AddGraphics();
        }



        UpdateInventory();
    }

    public void Update()
    {

        if (currentID != -1)
        {
            MoveObject();
        }

        for (int i = 0; i < maxCount; i++) //фикс стака пустых ячеек
        {
            if (items[i].count > 1 && items[i].id != 0)
            {
                items[i].itemGameObj.GetComponentInChildren<Text>().text = items[i].count.ToString();
            }
            else
            {
                items[i].itemGameObj.GetComponentInChildren<Text>().text = "";
            }
        }
    }

    public void SearchForSameItem(Item item, int count, int price)
    {
        for (int i = 0; i < maxCount; i++)
        {
            if (items[i].id == item.id)
            {
                if (items[i].count < 32)
                {
                    items[i].count += count;

                    if (items[i].count > 32)
                    {
                        count = items[i].count - 32;
                        items[i].count = 32;//было в половину меньше
                    }
                    else
                    {
                        count = 0;
                        i = maxCount;
                    }
                }
            }
        }

        if (count > 0)
        {
            for (int i = 0; i < maxCount; i++)
            {
                if (items[i].id == 0)
                {
                    AddItem(i, item, count, price);
                    i = maxCount;
                }
            }
        }
    }

    public void InventoryButton()
    {
        background.SetActive(!background.activeSelf);
        if (background.activeSelf)
        {
            UpdateInventory();
        }
    }

    public void AddItem(int id, Item item, int count, int price)
    {
        items[id].id = item.id;
        items[id].count = count;
        items[id].itemGameObj.GetComponent<Image>().sprite = item.img;
        items[id].price = price;

        if (count > 1 && item.id != 0)
        {
            items[id].itemGameObj.GetComponentInChildren<Text>().text = count.ToString();
        }
        else
        {
            items[id].itemGameObj.GetComponentInChildren<Text>().text = "";
        }
    }

    public void AddInventoryItem(int id, ItemInventory invItem)
    {
        items[id].id = invItem.id;
        items[id].count = invItem.count;
        items[id].itemGameObj.GetComponent<Image>().sprite = data.items[invItem.id].img;
        items[id].price = invItem.price;

        if (invItem.count > 1 && invItem.id != 0)
        {
            items[id].itemGameObj.GetComponentInChildren<Text>().text = invItem.ToString();
        }
        else
        {
            items[id].itemGameObj.GetComponentInChildren<Text>().text = "";
        }
    }

    public void AddGraphics()
    {
        for (int i = 0; i < maxCount; i++)
        {
            GameObject newItem = Instantiate(gameObjShow, InventoryMainObject.transform) as GameObject;

            newItem.name = i.ToString();

            ItemInventory ii = new ItemInventory();
            ii.itemGameObj = newItem;

            RectTransform rt = newItem.GetComponent<RectTransform>();
            rt.localPosition = new Vector3(0, 0, 0);
            rt.localScale = new Vector3(1, 1, 1);
            newItem.GetComponentInChildren<RectTransform>().localScale = new Vector3(1, 1, 1);

            Button tempButton = newItem.GetComponent<Button>();

            tempButton.onClick.AddListener(delegate { SelectObject(); });

            items.Add(ii);
        }
    }

    public void UpdateInventory()
    {
        for (int i = 0; i < maxCount; i++)
        {
            if (items[i].id != 0 && items[i].count > 1)
            {
                items[i].itemGameObj.GetComponentInChildren<Text>().text = items[i].count.ToString();
            }
            else
            {
                items[i].itemGameObj.GetComponentInChildren<Text>().text = "";
            }

            items[i].itemGameObj.GetComponent<Image>().sprite = data.items[items[i].id].img;
        }
    }

    public void SelectObject()
    {
        if (currentID == -1)
        {
            currentID = int.Parse(es.currentSelectedGameObject.name);
            currentItem = CopyInventoryItem(items[currentID]);
            movingObject.gameObject.SetActive(true);
            movingObject.GetComponent<Image>().sprite = data.items[currentItem.id].img;

            AddItem(currentID, data.items[0], 0, 0);
        }
        else
        {
            ItemInventory II = items[int.Parse(es.currentSelectedGameObject.name)];

            if (currentItem.id != II.id)
            {
                AddInventoryItem(currentID, II);

                AddInventoryItem(int.Parse(es.currentSelectedGameObject.name), currentItem);
            }
            else
            {
                if (II.count + currentItem.count <= 16)
                {
                    II.count += currentItem.count;
                }
                else
                {
                    AddItem(currentID, data.items[II.id], II.count + currentItem.count - 16, data.items[II.id].price);

                    II.count = 16;
                }

                II.itemGameObj.GetComponentInChildren<Text>().text = II.count.ToString();

            }

            currentID = -1;

            movingObject.gameObject.SetActive(false);
        }
    }

    public void MoveObject()
    {
        Vector3 pos = Input.mousePosition + offset;
        pos.z = InventoryMainObject.GetComponent<RectTransform>().position.z;
        movingObject.position = cam.ScreenToWorldPoint(pos);
    }

    public ItemInventory CopyInventoryItem(ItemInventory old)
    {
        ItemInventory New = new ItemInventory();

        New.id = old.id;
        New.itemGameObj = old.itemGameObj;
        New.count = old.count;
        New.price = old.price;

        return New;
    }

    public void ClearInventory()//Это сделал я(ЛЕХА) все вопросы ко мине
    {
        for (int i = 0; i < maxCount; i++)
        {
            if (items[i].id >= 1)
            {
                for (int f = 0; f < items[i].count; f++)
                {
                    Score.score += items[i].price;
                }
            }

            AddItem(i, data.items[0], 1, 0);
        }
    }

    public void SearchItems(Item item, int count) // функция поиска нажного итема и его колличества в инвентаре
    {
        int n = 0;

        for (int i = 0; i < maxCount; i++)
        {
            if (items[i].id == item.id)
            {
                n++;

                if (items[i].count >= count && n <= 1)
                {
                    searchINT = items[i].id;

                    if (items[i].count > 1)
                        items[i].count--;
                    else
                        AddItem(i, data.items[0], 1, 0);
                }
            }
        }
    }
}

[System.Serializable]

public class ItemInventory
{
    public int id;
    public GameObject itemGameObj;

    public int count; //количество элементов
    public int price;

}
