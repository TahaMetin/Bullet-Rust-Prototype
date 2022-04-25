using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemyAI : Enemy
{
    /* The goal is arriving the target behind player and after that moving toward player
     */
    bool _isTargetReached;
    Transform _target0, _target1;
    private void Start()
    {
        GameObject target = PlayerController.Instance.transform.GetChild(0).gameObject;     //"BigEnemyTargets" keep this gameobject at top
        _target0 = target.transform.GetChild(0).GetComponent<Transform>();
        _target1 = target.transform.GetChild(1).GetComponent<Transform>();
        _isTargetReached = false;
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
            if (Vector3.Distance(gameObject.transform.position, _target0.position) < Vector3.Distance(gameObject.transform.position, _target1.position))
                StartCoroutine(MoveToTarget(_target0, speed));
            else
                StartCoroutine(MoveToTarget(_target1, speed));
        }
        catch
        {
            // TODO: Find a better solition for first run or make it a function and call it when enabled
            Debug.Log("First run of OnEnable is earlyer than start. So first OnEnable is throwing a null expectation");
        }
    }
    private void OnTriggerEnter(Collider other) // check if target reached
    {
        if (other.gameObject.tag == "Target")
        {
            _isTargetReached = true;
            StopAllCoroutines();
            StartCoroutine(MoveToTarget(PlayerController.Instance.transform, speed));
        }
    }
    
}
