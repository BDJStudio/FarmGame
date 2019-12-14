using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOne : MonoBehaviour
{
    public float timeT;
    public float timeSec;
    public float timeMin;

    public bool check = true;
    public bool checkTwo;
    

    void Start()
    {
        GetComponent<Light>().intensity = timeT;
    }

    void FixedUpdate()
    {
        if (check == true)
        {
            timeSec -= Time.deltaTime;
        }
        else
        {
            
            if (timeT >= 0.5f && checkTwo == false)
            {
                Timer();
                Num();

            }
            if (checkTwo == true && timeT <= 1.6f)
            {
                Timer();
                NumTwo();
            }
        }

        if (timeSec <= 0)
        {
            timeSec = 5;
            timeMin++;
            if (checkTwo == true && timeT <= 1.6f)
            {
                Timer();
                NumTwo();
            }
            if (timeT >= 0.5f && checkTwo == false)
            {
                Timer();
                Num();

            }
        }

        GetComponent<Light>().intensity = timeT;
    }


    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5f);
    }

    

    void Num()
    {

        check = false;

        if (timeT != 1.6f)
        {
        timeT += 0.01f;
        
        }
        

        if (timeT >= 1.6f)
        {
            check = true;
            checkTwo = true;
            timeT = 1.6f;
            
        }
        StartCoroutine(Timer());
        
    }
    void NumTwo()
    {

        check = false;

        if (timeT != 0.5f)
        {
            timeT -= 0.01f;
        }

        if (timeT <= 0.5f)
        {
            check = true;
            checkTwo = false;
            timeT = 0.5f;
        }
        StartCoroutine(Timer());
        
    }
}
