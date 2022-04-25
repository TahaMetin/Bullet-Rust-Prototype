using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;

    public void SetIsMovingTrue()
    {
        playerAnimator.SetBool("IsMoving", true);
    }
    public void SetIsMovingFalse()
    {
        playerAnimator.SetBool("IsMoving", false);
    }
}
