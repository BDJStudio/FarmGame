using System.Collections;
using UnityEngine;

public class LightTwo : MonoBehaviour
{
    public GlTime gltim;
    public int pes;
    public int per;

    void Update()
    {
        pes = gltim.hour;
        per = gltim.minute;

        if (pes == 12)//Если у тебя 12 часов и если у тебя день то день меняем на ночь
        {
            if (gameObject.GetComponent<Light>().intensity > 0.5f)
            {
                StartCoroutine(Timer());
                gameObject.GetComponent<Light>().intensity -= 0.01f;
            }
            else gameObject.GetComponent<Light>().intensity = 0.5f;

        }
        else if(pes == 23 && per == 59 )//Если у тебя 23 часа 59 минут(да да если поставить просто 24 часо оно не работает)и если у тебя ночь то ночь меняем на день
        {
            if (gameObject.GetComponent<Light>().intensity < 1.6f)
            {
                StartCoroutine(Timer());
                gameObject.GetComponent<Light>().intensity += 0.01f;
            }
            else gameObject.GetComponent<Light>().intensity = 1.6f;
        }
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.5f);//Плавное изменение 
    }

    
}
