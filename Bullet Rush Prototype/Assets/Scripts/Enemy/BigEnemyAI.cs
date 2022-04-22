using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemyAI : Enemy
{
    /* The goal is arriving the target behind player and after that moving toward player
     */
    bool isTargetReached;
    Transform target0, target1;
    private void Start()
    {
        GameObject target = PlayerController.Instance.transform.GetChild(2).gameObject;     //"BigEnemyTargets"
        target0 = target.transform.GetChild(0).GetComponent<Transform>();
        target1 = target.transform.GetChild(1).GetComponent<Transform>();
        isTargetReached = false;

        ChaseClosestTarget();
    }
    private void OnEnable() 
    {
        ChaseClosestTarget();
    }
    private void ChaseClosestTarget() // Start Coroutine with closest target
    {
        try
        {
            if (Vector3.Distance(gameObject.transform.position, target0.position) < Vector3.Distance(gameObject.transform.position, target1.position))
                StartCoroutine(MoveToTarget(target0, speed));
            else
                StartCoroutine(MoveToTarget(target1, speed));
        }
        catch
        {
            Debug.Log("First run of OnEnable is earlyer than start. So first OnEnable is throwing a null expectation");
        }
    }
    private void OnTriggerEnter(Collider other) // check if target reached
    {
        if (other.gameObject.tag == "Target")
        {
            isTargetReached = true;
            StopAllCoroutines();
            StartCoroutine(MoveToTarget(PlayerController.Instance.transform, speed));
        }
    }
    
}
