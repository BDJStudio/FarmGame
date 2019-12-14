﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public bool isPause, isPlay, isMenu;
    public GameObject panel, Play, Pause;

    private Text score;
    private GameObject day;
    private GameObject player;
    private GameObject cam;
    private GameObject trigg_Grubing1, trigg_Grubing2, trigg_Grubing3, trigg_Grubing4;

    public void Start()
    {
        if (isPause)
        {
            Play.SetActive(false);
            panel.SetActive(false);
        }

        if (isMenu)
        {
            player = GameObject.Find("Player");
            cam = GameObject.Find("Main Camera");
            score = GameObject.Find("GUI_Money").GetComponent<Text>();
            day = GameObject.Find("GlobalTime");

            trigg_Grubing1 = GameObject.Find("Trigg_Grubing_Wheat");
            trigg_Grubing2 = GameObject.Find("Trigg_Grubing_Carrot");
            trigg_Grubing3 = GameObject.Find("Trigg_Grubing_Potato");
            trigg_Grubing4 = GameObject.Find("Trigg_Grubing_Tomato");
        }
    }

    public void OnMouseEnter()
    {
        gameObject.transform.localScale += new Vector3(.5f, .5f, .5f);
    }

    public void OnMouseExit()
    {
        gameObject.transform.localScale -= new Vector3(.5f, .5f, .5f);
    }

    private void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "Play":
                SceneManager.LoadScene("Game");
                Time.timeScale = 1;
                break;

            case "Help":
                break;

            case "Exit":
                Application.Quit();
                break;

            case "Main_Menu":
                if (isMenu)
                {
                    player.GetComponent<Controller>().OnApplicationQuit();
                    cam.GetComponent<Inventory>().OnApplicationQuit();
                    score.GetComponent<Score>().OnApplicationQuit();
                    day.GetComponent<GlTime>().OnApplicationQuit();

                    trigg_Grubing1.GetComponent<ActiveBttns>().OnApplicationQuit();
                    trigg_Grubing2.GetComponent<ActiveBttns>().OnApplicationQuit();
                    trigg_Grubing3.GetComponent<ActiveBttns>().OnApplicationQuit();
                    trigg_Grubing4.GetComponent<ActiveBttns>().OnApplicationQuit();

                    SceneManager.LoadScene("Menu");
                }
                break;

            case "Pause":
                if (isPause)
                {
                    Time.timeScale = 0;
                    panel.SetActive(true);
                    Pause.SetActive(false);
                    Play.SetActive(true);
                }
                break;

            case "Pause_Play":
                if (isPlay)
                {
                    Time.timeScale = 1;
                    panel.SetActive(false);
                    Pause.SetActive(true);
                    Play.SetActive(false);
                }
                break;
        }
    }
}
