using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class ManagerUI : MonoBehaviour
{
    public static ManagerUI Instance { get; private set; }

    [SerializeField] private UnityEngine.UI.Image crossHair;
    [SerializeField] private GameObject indicator;

    [SerializeField] private Sprite defaultCrossHair;
    [SerializeField] private Sprite weaponCrossHair;
    [SerializeField] private GameObject releaseTip;

    [SerializeField] private TMPro.TMP_Text SensbilityText;

    [SerializeField] public UnityEngine.UI.Slider sliderS;

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
        releaseTip.gameObject.SetActive(true);
    }
    public void NoHoldingWeapon()
    {
        crossHair.sprite = defaultCrossHair;
        crossHair.color = Color.white;
        releaseTip.gameObject.SetActive(false);
    }

    public void ChangeSense(float value)
    {
        SensbilityText.text = "" + value.ToString("#.00");
    }

}
