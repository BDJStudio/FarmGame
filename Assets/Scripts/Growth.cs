using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growth : MonoBehaviour
{
    
    public Sprite[] sprites;
    
    public GameObject Trigger;
    public bool Pick, isGrowthing;

    public float time;

    private int hour;
    private int minute;
    private float second;
    private int day;
    private float n;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[0];
    }

    void Update()
    {
        // это внутрений счетчик для роста растений
        second += Time.deltaTime;
        if (second >= 1f)
        {
            second = 0;
            minute += 1;
        }
        if (minute >= 60)
        {
            minute = 0;
            hour += 1;
        }
        if (hour >= 24)
        {
            hour = 0;
            day += 1;
        }

        n = hour; // тут пишем как вычислять время роста: минуты, часы или дни

        // функция роста
        if (time != n) // растет пока не кончится время
        {
            Rost();
        }
        else // после готова к сбору
        {
            Pick = true;
            Trigger.GetComponent<ActiveBttns>().PickUp = true;
        }

    }

    void Rost() //функция которая разделяет поставленое время роста на 5 и меняет спрайты роста в зависимости от него
    {
        isGrowthing = true;

        if (n >= 0 && n < time / 5)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
        else if (n >= time / 5 && n < 2 * time / 5)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
        else if (n >= 2 * time / 5 && n < 3 * time / 5)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[2];
        }
        else if (n >= 3 * time / 5 && n < 4 * time / 5)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[3];
        }
        else if (n >= 4 * time / 5 && n < 5 * time / 5)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[4];
        }
    }
}
