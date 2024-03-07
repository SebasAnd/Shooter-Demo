using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BunnyController : MonoBehaviour
{
    [SerializeField] private Animator bunnyAnimator;
    // Start is called before the first frame update
    void Start()
    {
        bunnyAnimator = GetComponent<Animator>();
    }

    public void ChangeDance(bool status)
    {
        bunnyAnimator.SetBool("Macarena", status);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
