using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ManagerUI : MonoBehaviour
{
    public static ManagerUI Instance { get; private set; }

    [SerializeField] private Image crossHair;
    [SerializeField] private GameObject indicator;

    [SerializeField] private Sprite defaultCrossHair;
    [SerializeField] private Sprite weaponCrossHair;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }


    public void FoundSelectable()
    {
        indicator.SetActive(true);
    }
    public void IsNotSelectable()
    {
        indicator.SetActive(false);
    }
    public void HoldingWeapon()
    {
        crossHair.sprite = weaponCrossHair;
        crossHair.color = Color.magenta;
    }
    public void NoHoldingWeapon()
    {
        crossHair.sprite = defaultCrossHair;
        crossHair.color = Color.white;
    }
}
