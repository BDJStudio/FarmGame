using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlTime : MonoBehaviour
{
    public int hour;
    public int minute; 
    public float second; 
    public int day;

    public Text timeWorld;

    public Jobs jb;

    void Start()
    {
        hour = 0;
        minute = 0;
        second = 0;
        day = Load.LoatGlTimeDay("GlTimeDay");
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

            if (day % 2 == 0)
            {
                jb.Ferb();
            }
            else
            {
                GlTimeDay.day++;
                jb.UpdateJobs();
            }

            if (day > 1)
            {
                timeWorld.text = "День " + (day - 1).ToString();
            }
            else
                timeWorld.text = "День " + day.ToString();
        }
    }

}
