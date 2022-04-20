using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemyAI : MonoBehaviour
{
    /* The goal is arriving the target behind player and after that moving toward player
     */
    GameObject player;
    public float speed;
    bool isTargetReached;
    private void Start()
    {
        player = GameObject.Find("Player");
        GameObject target = GameObject.Find("BigEnemyTargets");
        Transform target0 = target.transform.GetChild(0).GetComponent<Transform>();
        Transform target1 = target.transform.GetChild(1).GetComponent<Transform>();
        isTargetReached = false;

        // Start Coroutine with closest target
        if (Vector3.Distance(gameObject.transform.position, target0.position) < Vector3.Distance(gameObject.transform.position, target1.position))
            StartCoroutine(MoveToTarget(target0, speed));
        else
            StartCoroutine(MoveToTarget(target1, speed));
    }
    private void OnTriggerEnter(Collider other) // check if target reached
    {
        if (other.gameObject.tag == "Target")
        {
            isTargetReached = true;
            StopAllCoroutines();
            StartCoroutine(MoveToTarget(player.transform, speed));
        }
    }
    
    IEnumerator MoveToTarget(Transform target, float speedTranslation)
    {
        while (gameObject.transform.position != target.position)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.position, speedTranslation * Time.deltaTime);
            yield return null;
        }
    }
}
