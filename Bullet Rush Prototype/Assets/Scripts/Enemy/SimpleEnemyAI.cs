using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyAI : Enemy
{
    private void Start()
    {
        StartCoroutine(MoveToTarget(PlayerController.Instance.transform, speed));
    }

    private void OnEnable()
    {
        try
        {
            StartCoroutine(MoveToTarget(PlayerController.Instance.transform, speed));
        }
        catch (System.Exception)
        {
            // TODO: Find a better solition for first run or make it a function and call it when enabled
            Debug.Log("First run of OnEnable is earlyer than start. So first OnEnable is throwing a null expectation");
        }
    }
}
