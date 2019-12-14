using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    public GameObject[] power;
    public int N;

    void Start()
    {
        N = power.Length;
    }

    void Update()
    {
        switch (N)
        {
            case 0:
                power[0].SetActive(false);
                power[1].SetActive(false);
                power[2].SetActive(false);
                power[3].SetActive(false);
                break;
            case 1:
                power[0].SetActive(true);
                power[1].SetActive(false);
                power[2].SetActive(false);
                power[3].SetActive(false);
                break;
            case 2:
                power[0].SetActive(true);
                power[1].SetActive(true);
                power[2].SetActive(false);
                power[3].SetActive(false);
                break;
            case 3:
                power[0].SetActive(true);
                power[1].SetActive(true);
                power[2].SetActive(true);
                power[3].SetActive(false);
                break;
            case 4:
                power[0].SetActive(true);
                power[1].SetActive(true);
                power[2].SetActive(true);
                power[3].SetActive(true);
                break;
        }
    }
}
