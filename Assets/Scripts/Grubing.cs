using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grubing : MonoBehaviour
{
    public GameObject activate;

    public ActiveBttns bttns;
    public GlTime gltim;
    public Sprite[] ground;

    private int time;

    public void Start()
    {
        activate.SetActive(false);
        gltim.minute = time;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            activate.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            activate.SetActive(false);
        }
    }

    public void Update()
    {
        if (bttns.wet == true)
        {
            switch (gltim.minute)
            {
                case 1:
                    GetComponent<SpriteRenderer>().sprite = ground[0];

                    break;
                case 2:
                    GetComponent<SpriteRenderer>().sprite = ground[1];

                    break;
                case 3:
                    GetComponent<SpriteRenderer>().sprite = ground[2];

                    break;
            }
        }
    }
}
