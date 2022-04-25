using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    /*  TODO: Add a shooting animation for making arm straight when shooting
     *  or disable arm animations. For better visual when running and shooting at the same time.
     */
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
