using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GrowTarget : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Interactable")
        {
            other.transform.DOPunchScale(new Vector3(2.5f, 2.5f, 2.5f), 1);
            Destroy(this.gameObject);
        }
    }
}
