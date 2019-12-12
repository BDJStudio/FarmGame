using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public bool isPause;

    private Text score;
    private GameObject day;
    private GameObject player;
    private GameObject cam;

    public void Start()
    {
        player = GameObject.Find("Player");
        cam = GameObject.Find("Main Camera");
        score = GameObject.Find("GUI_Money").GetComponent<Text>();
        day = GameObject.Find("GlobalTime");
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
                break;
            case "Help":
                break;
            case "Exit":
                Application.Quit();
                break;
            case "Main_menu":
                if (isPause)
                {
                    player.GetComponent<Controller>().OnApplicationQuit();
                    cam.GetComponent<Inventory>().OnApplicationQuit();
                    score.GetComponent<Score>().OnApplicationQuit();
                    day.GetComponent<GlTime>().OnApplicationQuit();
                }
                SceneManager.LoadScene("Menu");
                break;
        }
    }
}
