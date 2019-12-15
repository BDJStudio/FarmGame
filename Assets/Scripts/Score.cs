using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Score : MonoBehaviour
{
    public static int score;
    private Text scoreText;
    void Start()
    {
        scoreText = GetComponent<Text>();
        score = Load.LoadScore("GUImoney");//Загружем данные из сохранения
        //Каждый заход в игру даем себе 100р.
        score = 100;
        ///////////////
        
    }

    void Update()
    {
        scoreText.text = score.ToString();
    }

#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        if(pause) Save.SaveScore("GUImoney", score);
    }
#endif
    public void OnApplicationQuit()
    {
        Save.SaveScore("GUImoney", score);//Сохраняем данные в сохранение
    }

}
