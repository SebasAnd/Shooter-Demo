using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivote : MonoBehaviour
{

    void Update()
    {
        Camera.main.transform.position = transform.position;
    }
}
