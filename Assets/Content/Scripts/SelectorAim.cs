using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorAim : MonoBehaviour
{
    RaycastHit HitInfo;
    ManagerUI managerUI;

    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        managerUI = ManagerUI.Instance;
        gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        Transform cameraTransform = transform;
        //Debug.DrawRay(cameraTransform.position, cameraTransform.forward * 100.0f, Color.red);

        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out HitInfo, 2.0f) && !gameManager.userInInterface)
        {
            if (HitInfo.transform.gameObject.tag == "Gun" && gameManager.player.currentWeapon == null)
            {
                managerUI.FoundSelectable();
                if (Input.GetKey("e"))
                {
                    gameManager.player.AttachWeapon(HitInfo.transform.gameObject);
                    managerUI.HoldingWeapon();
                }

            }
            else
            {
                managerUI.IsNotSelectable();
            }


        }
        else
        {
            managerUI.IsNotSelectable();
        }


    }
}
