using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector3 direction;
    private Vector3 velocity;

    [SerializeField] public bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    private CharacterController controller;

    [SerializeField] private float gravity;
    [SerializeField] private float jumpHeight;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        InterfaceValidation();
    }

    public void InterfaceValidation()
    {
        if (!GameManager.Instance.userInInterface)
        {
            MovePlayer();
        }
    }
    private void MovePlayer()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (isGrounded)
        {
            float moveZ = Input.GetAxis("Vertical");
            float moveX = Input.GetAxis("Horizontal");

            //gravity -= gravity * Time.deltaTime;

            direction = new Vector3(moveX, 0, moveZ);

            direction = transform.TransformDirection(direction);
            direction *= moveSpeed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }

        }


        controller.Move(direction * Time.deltaTime);
        velocity.y += -gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * 2 * gravity);
    }



}
