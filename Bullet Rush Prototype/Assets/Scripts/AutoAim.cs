using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAim : MonoBehaviour
{
    [SerializeField] float range;
    [SerializeField] GameObject player;
    [SerializeField] bool isThisRightGun;
    GameObject currentGun;
    GameObject currentTarget;
    bool isTargetInRange;
    PlayerController playerController;


    private void Start()
    {
        isTargetInRange = false;
        currentGun = gameObject;
        playerController = player.GetComponent<PlayerController>();
        StartCoroutine("FireCheck");
    }
    private void LateUpdate() // late update used for overriding animation. 
    {
        Collider[] colliderArray = Physics.OverlapSphere(transform.position,range);
        Vector3 distance = new Vector3(0,0,0);
        isTargetInRange = false;
        foreach (Collider collider in colliderArray)
        {
            if (collider.tag == "Enemy")
            {
                // Find closest enemy
                Vector3 newDistance = collider.transform.position - gameObject.transform.position;
                if(newDistance.magnitude > distance.magnitude)
                {
                    currentTarget = collider.gameObject; // set current target
                    AutoAiming();
                    isTargetInRange = true;
                }
            }
            else
            {
                currentTarget = null;
            }
        }
    }

    IEnumerator FireCheck()
    {
        for (; ; )
        {
            if (isTargetInRange)
            {
                if (isThisRightGun)
                    playerController.FireInRightGun();
                else
                    playerController.FireInLeftGun();

                isTargetInRange = false;
            }
            yield return new WaitForSeconds(.1f);
        }
    }
  

    private void AutoAiming()
    {
        currentGun.transform.LookAt(currentTarget.transform);
        if(isThisRightGun)
            currentGun.transform.Rotate(0f, 90f, 0f);
        else
            currentGun.transform.Rotate(0f,-90f,0f);
    }


}
