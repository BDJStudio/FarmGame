using System.Collections;
using UnityEngine;

public class LightTwo : MonoBehaviour
{
    public GlTime gltim;
    public int per;
    public int pes;

    void Update()
    {
        pes = gltim.day;
        if (pes % 2 == 0)
        {
            if (gameObject.GetComponent<Light>().intensity < 1.6f)
            {
                StartCoroutine(Timer());
                gameObject.GetComponent<Light>().intensity += 0.01f;
            }
            else gameObject.GetComponent<Light>().intensity = 1.6f;

        }
        else if(pes % 2 != 0)
        {
            if (gameObject.GetComponent<Light>().intensity > 0.5f)
            {
                StartCoroutine(Timer());
                gameObject.GetComponent<Light>().intensity -= 0.01f;
            }
            else gameObject.GetComponent<Light>().intensity = 0.5f;
        }
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.5f);
    }

    
}
