using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public float spawnTime;
    void Start()
    {
        StartCoroutine(Life());
    }
    IEnumerator Life()
    {
        yield return new WaitForSeconds(spawnTime);
        Destroy(this.gameObject);

    }

}
