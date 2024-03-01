using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GunData", menuName = "Scriptable Objects", order = 1)]
public class Gun : ScriptableObject
{
    // Start is called before the first frame update
    public Transform armState;
    public GameObject projectile;

    public float force;
    public float bulletDuration;

    public enum WeaponType { Parabolic, Gavity, Extra };
    public WeaponType weaponType;

}
