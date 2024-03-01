using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private Transform player;
    private GameManager gameManager;
    private float rotationX;
    private float rotationY;
    void Start()
    {
        gameManager = GameManager.Instance;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rotationX = 0;
        rotationY = 0;
        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();

    }

    private void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotationY += mouseX;
        rotationX -= mouseY;

        rotationX = Math.Clamp(rotationX, -90f, 90f);
        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        player.rotation = Quaternion.Euler(0, rotationY, 0);
    }

    public void ShootParabolic(GameObject projectile, Transform indicator, float force)
    {
        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        GameObject instantiatedProjectile = Instantiate(projectile, indicator.position, transform.rotation, gameManager.ammoUsed.transform);//cameraTransform.position, cameraTransform.forward,
        instantiatedProjectile.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0, 0, force));
    }
    public void ShootGravity(GameObject projectile, Transform indicator, float force)
    {
        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        GameObject instantiatedProjectile = Instantiate(projectile, indicator.position, transform.rotation, gameManager.ammoUsed.transform);//cameraTransform.position, cameraTransform.forward,
        instantiatedProjectile.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0, 0, force));
    }
    public void ShootExtra(GameObject projectile, Transform indicator, float force)
    {
        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        GameObject instantiatedProjectile = Instantiate(projectile, indicator.position, transform.rotation, gameManager.ammoUsed.transform);//cameraTransform.position, cameraTransform.forward,
        instantiatedProjectile.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0, 0, force));
    }
}
