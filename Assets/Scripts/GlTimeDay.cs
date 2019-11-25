using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GlTimeDay : MonoBehaviour
{
    public static int day;
    private Text dayText;
    void Start()
    {
        dayText = GetComponent<Text>();
        day = Load.LoatGlTimeDay("GlTimeDay");//Загружем данные из сохранения

    }

    void Update()
    {
        dayText.text = "Динь: " + day;
    }

#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        Save.SaveGlTimeDay("GlTimeDay", day);
    }
#endif

    private void OnApplicationQuit()
    {
        Save.SaveGlTimeDay("GlTimeDay", day);//Сохраняем данные в сохранение
    }
}
