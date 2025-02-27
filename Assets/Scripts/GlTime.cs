﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlTime : MonoBehaviour
{
    public int hour;// = 60 мин
    public int minute; // = 6 сек
    public float second; // = 1 сек
    public int day;// = 24 часа

    void Start()
    {
        hour = 0; //Random.Range(0, 23);
        minute = 0; //Random.Range(0, 14);
    }

    void Update()
    {
        second += Time.deltaTime;
        if(second >= 6f)//6 сек = минута
        {
            second = 0;
            minute += 1;
        }
        if (minute >= 60)//60 мин = 1 час
        {
            minute = 0;
            hour += 1;
        }
        if (hour >= 24)
        {
            hour = 0;
            day += 1;
        }
    }

    
}
