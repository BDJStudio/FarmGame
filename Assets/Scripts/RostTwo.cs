using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RostTwo : MonoBehaviour
{
    public GlTime gltim;
    public Sprite[] sprites;
    public Collider2D colPlayer;

    private bool checkClick;
    private int n = 1;
    private float checkTime;
    public float time;
    private int ar;

    void Start()
    {
        ar = sprites.Length;
    }
    public void MidButtonTwo()
    {
        if (colPlayer.tag == "Player" && colPlayer.IsTouching(GetComponent<Collider2D>()))
        {
            checkClick = true;
            if (n == ar)
            {
                GetComponent<SpriteRenderer>().sprite = sprites[0];
                n = 0;
                Score.score += 1;
            }
        }
    }

    void Rost()
    {
        if (checkClick == true)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[n];
            n++;
            checkClick = false;
        }
    }

    void Update()
    {
        if (ar != n)
        {
            checkTime += gltim.second;
            if (time <= checkTime)
            {
                Rost();
                checkTime = 0;
            }
        }
    }
}
