using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyAI : Enemy
{
    private void Start()
    {
        StartCoroutine(MoveToTarget(PlayerController.Instance.gameObject.transform, speed));
    }


}
