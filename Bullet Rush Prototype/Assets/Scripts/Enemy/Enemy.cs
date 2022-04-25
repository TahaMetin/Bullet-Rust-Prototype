using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public readonly float speed = 3f; 
    public IEnumerator MoveToTarget(Transform target, float speedTranslation)
    {
        if (target == null)
            yield break;
        while (gameObject.transform.position != target.position)    // move to te target position until reach the position
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.position, speedTranslation * Time.deltaTime);
            yield return null;
        }
    }

}
