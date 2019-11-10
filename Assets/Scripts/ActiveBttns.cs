using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBttns : MonoBehaviour
{
    public bool wet;

    public void OnMouseDown()
    {
        wet = true;
    }
}
