using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jobs : MonoBehaviour
{
    public GameObject text;
    public GameObject background;
    public Collider2D colPlayer;

    public static int scoreOne, scoreTwo, scoreTree;


    public Text textOne;
    public Text textTwo;
    public Text textTree;

    void Start()
    {
        Ferb();
    }

    public void Ferb()
    {
        scoreOne = Random.Range(1, 10);
        scoreTwo = Random.Range(1, 10);
        scoreTree = Random.Range(1, 10);
    }
    public void UpdateJobs()
    {
        if (scoreOne <= 0)
        {
            Score.score += 100;
        }
        if (scoreTwo <= 0)
        {
            Score.score += 100;
        }
        if (scoreTree <= 0)
        {
            Score.score += 100;
            
        }
    }

    void Viele()
    {
        if (scoreOne > 0)
        {
            textOne.text = "Посадка шмали " + scoreOne + " шт.";
        }
        else
        {
            textOne.text = "Посадка шмали выполнена.+100";
        }

        if (scoreTwo > 0)
        {
            textTwo.text = "Собрать шмали " + scoreTwo + " шт.";
        }
        else
        {
            textTwo.text = "Сбор шмали выполнен.+100";
        }

        if (scoreTree > 0)
        {
            textTree.text = "Продать шмали " + scoreTree + " шт.";
        }
        else
        {
            textTree.text = "Продажа шмали выполнено.+100";
        }
    }


    void Update()
    {
        Viele();
        if (colPlayer.IsTouching(GetComponent<BoxCollider2D>()))
        {
            text.SetActive(true);
            background.SetActive(true);
        }
        if (!colPlayer.IsTouching(GetComponent<BoxCollider2D>()))
        {
            text.SetActive(false);
            background.SetActive(false);
        }
    }
}
