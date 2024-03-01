using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Windows.Speech;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector3 direction;
    private CharacterController controller;

    private double gravity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
    private void MovePlayer()
    {
        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        gravity -= 9.81 * Time.deltaTime;

        direction = new Vector3(moveX, (float)gravity, moveZ);

        direction = transform.TransformDirection(direction);
        direction *= moveSpeed;
        controller.Move(direction * Time.deltaTime);
    }



}
