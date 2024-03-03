using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameManager gameManager;

    [SerializeField] private Gun gun;

    [SerializeField] private Transform bulletIndicator;

    public Transform rightHand;
    public Transform rightElbow;
    public Transform leftHand;
    public Transform leftElbow;

    private void Start()
    {
        gameManager = GameManager.Instance;

    }
    public void UpdatePosition()
    {
        transform.SetLocalPositionAndRotation(gun.armState.position, gun.armState.rotation);
    }

    public void ShootManager()
    {
        PlayerCamera playerCam = gameManager.playerCamera;

        if (gun.weaponType == Gun.WeaponType.Parabolic)
        {
            GameObject currentAmmo = gun.projectile;
            currentAmmo.GetComponent<Ammo>().spawnTime = gun.bulletDuration;
            playerCam.ShootParabolic(currentAmmo, bulletIndicator, gun.force);
        }
        if (gun.weaponType == Gun.WeaponType.Gavity)
        {
            GameObject currentAmmo = gun.projectile;
            currentAmmo.GetComponent<Ammo>().spawnTime = gun.bulletDuration;
            playerCam.ShootGravity(currentAmmo, bulletIndicator, gun.force);
        }
        if (gun.weaponType == Gun.WeaponType.Extra)
        {
            GameObject currentAmmo = gun.projectile;
            currentAmmo.GetComponent<Ammo>().spawnTime = gun.bulletDuration;
            playerCam.ShootExtra(currentAmmo, bulletIndicator, gun.force);
        }

    }

}
