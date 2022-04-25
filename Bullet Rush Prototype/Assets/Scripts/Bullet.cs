using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int _damage = 100;
    readonly float _dissappearDistance = 100f;
    private void FixedUpdate()
    {   //dissappear after getting out of wiev range
        if(Vector3.Distance(gameObject.transform.position, PlayerController.Instance.transform.position) > _dissappearDistance)
        {
            gameObject.SetActive(false);
            PoolManager.Instance.poolDictionary["Bullet"].Enqueue(gameObject);
        }
    }
}
