using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlTime : MonoBehaviour
{
    public int hour;
    public int minute; 
    public float second; 
    public int day;

    void Start()
    {
        hour = 0;
        minute = 0;
    }

    void Update()
    {
        second += Time.deltaTime;
        if (second >= 1f)//1 сек = минута
        {
            second = 0;
            minute += 1;
        }
        if (minute >= 60)//60 сек = 1 час
        {
            minute = 0;
            hour += 1;
        }
        if (hour >= 24)//24 минуты = 1 день
        {
            hour = 0;
            day += 1;
        }
    }

    
}
