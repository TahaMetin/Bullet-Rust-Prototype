using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public readonly int damage = 100;
    private readonly float dissappearDistance = 100f;
    private void FixedUpdate()
    {
        if(Vector3.Distance(gameObject.transform.position, PlayerController.Instance.transform.position) > dissappearDistance)
        {
            gameObject.SetActive(false);
            PoolManager.Instance.poolDictionary["Bullet"].Enqueue(gameObject);
        }
    }
}
