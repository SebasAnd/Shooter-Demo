using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIkAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform rightHandIKTarget;
    public Transform rightElbowIKTarget;
    public Transform leftHandIKTarget;
    public Transform leftElbowIKTarget;

    public float handIKAmount = 1f;
    public float elbowIKAmount = 1f;

    private Animator playerAnimator;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();

    }
    private void OnAnimatorIK(int layerIndex)
    {
        if (leftHandIKTarget != null)
        {
            playerAnimator.SetIKRotationWeight(AvatarIKGoal.LeftHand, handIKAmount);
            playerAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, handIKAmount);
            playerAnimator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandIKTarget.position);
            playerAnimator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandIKTarget.rotation);
        }
        if (rightHandIKTarget != null)
        {
            playerAnimator.SetIKRotationWeight(AvatarIKGoal.RightHand, handIKAmount);
            playerAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, handIKAmount);
            playerAnimator.SetIKPosition(AvatarIKGoal.RightHand, rightHandIKTarget.position);
            playerAnimator.SetIKRotation(AvatarIKGoal.RightHand, rightHandIKTarget.rotation);
        }
        if (leftElbowIKTarget != null)
        {
            playerAnimator.SetIKHintPosition(AvatarIKHint.LeftElbow, leftElbowIKTarget.position);
            playerAnimator.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, elbowIKAmount);
        }
        if (rightElbowIKTarget != null)
        {
            playerAnimator.SetIKHintPosition(AvatarIKHint.RightElbow, rightElbowIKTarget.position);
            playerAnimator.SetIKHintPositionWeight(AvatarIKHint.RightElbow, elbowIKAmount);
        }


    }
}
