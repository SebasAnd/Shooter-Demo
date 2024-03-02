using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public Animator playerAnimator;

    [SerializeField] public GameObject currentWeapon;
    [SerializeField] public GameObject weaponHolder;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform walkCameraPosition;
    [SerializeField] private Transform shootCameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponentInChildren<Animator>();
    }

    public void PlaySelectedDance(int dance)
    {
        playerAnimator.SetLayerWeight(playerAnimator.GetLayerIndex("Dance Layer"), 1);
        playerAnimator.SetInteger("Dance", dance);
    }
    private void AnimationUpdate()
    {
        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");


        if (moveZ > 0 && moveX == 0)
        {
            playerAnimator.SetInteger("Walk", 1);
        }
        if (moveX > 0 && moveZ > 0)
        {
            playerAnimator.SetInteger("Walk", 5);
        }
        if (moveX < 0 && moveZ > 0)
        {
            playerAnimator.SetInteger("Walk", 6);
        }
        if (moveX > 0 && moveZ == 0)
        {
            playerAnimator.SetInteger("Walk", 3);
        }
        if (moveX < 0 && moveZ == 0)
        {
            playerAnimator.SetInteger("Walk", 4);
        }

        if (moveZ < 0 && moveX < 0)
        {
            playerAnimator.SetInteger("Walk", 7);
        }
        if (moveZ < 0 && moveX > 0)
        {
            playerAnimator.SetInteger("Walk", 8);
        }
        if (moveZ < 0 && moveX == 0)
        {
            playerAnimator.SetInteger("Walk", 2);
        }
        if (moveZ < 0 && moveX == 0)
        {
            playerAnimator.SetInteger("Walk", 2);
        }
        if (moveZ == 0 && moveX == 0)
        {
            playerAnimator.SetInteger("Walk", 0);
        }



    }

    private void Update()
    {
        AnimationUpdate();
        WeaponRemover();
        ShootWeaponManager();

    }

    public void ShootWeaponManager()
    {
        if (weaponHolder.transform.childCount > 1 && Input.GetButtonDown("Fire1"))
        {
            currentWeapon.GetComponent<GunBehaviour>().ShootManager();
        }

    }

    public void WeaponRemover()
    {
        if (weaponHolder.transform.childCount > 1 && Input.GetKey("q"))
        {
            ReleaseWeapon();
        }
    }

    public void AttachWeapon(GameObject weapon)
    {
        weapon.transform.SetParent(weaponHolder.transform);
        playerAnimator.SetLayerWeight(playerAnimator.GetLayerIndex("GunHolder"), 1);
        weapon.GetComponent<BoxCollider>().isTrigger = true;
        weapon.GetComponent<GunBehaviour>().UpdatePosition();
        weapon.GetComponent<Rigidbody>().isKinematic = true;
        currentWeapon = weapon;
        mainCamera.transform.SetParent(weaponHolder.transform);
        mainCamera.transform.localPosition = shootCameraPosition.localPosition;

    }
    public void ReleaseWeapon()
    {
        if (weaponHolder.transform.childCount > 1)
        {
            currentWeapon.transform.SetParent(null);
            playerAnimator.SetLayerWeight(playerAnimator.GetLayerIndex("GunHolder"), 0);
            currentWeapon.GetComponent<BoxCollider>().isTrigger = false;
            currentWeapon.GetComponent<Rigidbody>().isKinematic = false;
            currentWeapon.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(1, 1, 5f));
            currentWeapon = null;
            mainCamera.transform.SetParent(transform);
            mainCamera.transform.localPosition = walkCameraPosition.transform.localPosition;
            ManagerUI.Instance.NoHoldingWeapon();

        }

    }



    // Update is called once per frame

}
