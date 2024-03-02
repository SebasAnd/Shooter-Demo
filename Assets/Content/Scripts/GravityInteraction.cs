using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GravityInteraction : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private List<GameObject> inRadius;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Interactable")
        {
            inRadius.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Destroy everything that leaves the trigger
        if (other.tag == "Interactable")
        {
            inRadius.Remove(other.gameObject);
        }
    }

    private void Update()
    {
        for (int i = 0; i < inRadius.Count; i++)
        {
            if (Vector3.Distance(inRadius[i].transform.position, transform.position) < 1.0f)
            {
                inRadius[i].transform.RotateAround(transform.position, Vector3.up, 200 * Time.deltaTime);
                inRadius[i].transform.RotateAround(transform.position, Vector3.forward, 200 * Time.deltaTime);
            }
            else
            {
                inRadius[i].GetComponent<Rigidbody>().AddForce(transform.position - inRadius[i].transform.position);
            }


        }
    }
}
