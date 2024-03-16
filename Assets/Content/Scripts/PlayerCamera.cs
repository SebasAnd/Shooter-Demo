using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float mouseSensbility;
    [SerializeField] private Transform player;
    private GameManager gameManager;
    private ManagerUI gameManagerUI;
    private float rotationX;
    private float rotationY;
    void Start()
    {
        gameManager = GameManager.Instance;
        gameManagerUI = ManagerUI.Instance;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rotationX = 0;
        rotationY = 0;
        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        gameManagerUI.sliderS.onValueChanged.AddListener((value) => { ChangeSensbility(value); });
    }

    // Update is called once per frame
    void Update()
    {
        InterfaceU();
        SensbilityMovement();

    }

    private void InterfaceU()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            MouseShow(true);
            gameManager.player.PauseAllANimations();
        }
        else
        {
            MouseShow(false);
            Rotate();
            gameManager.player.ResumeAllANimations();
        }
    }

    private void MouseShow(bool show)
    {
        if (show)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            gameManager.userInInterface = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            gameManager.userInInterface = false;
        }
    }

    private void SensbilityMovement()
    {

        gameManagerUI.ChangeSense((float)this.mouseSensbility / 100);


    }


    private void ChangeSensbility(float value)
    {
        this.mouseSensbility = value * 100;
        SensbilityMovement();
    }

    private void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensbility * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensbility * Time.deltaTime;

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
