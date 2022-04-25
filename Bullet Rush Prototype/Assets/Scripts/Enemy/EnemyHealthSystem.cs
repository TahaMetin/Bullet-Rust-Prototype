using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    [SerializeField] int health;
    string _tag;
    private void Start()
    {
        if (gameObject.GetComponent<BigEnemyAI>() != null) // Determine enemy tag
            _tag = "BigEnemy";
        else if (gameObject.GetComponent<SimpleEnemyAI>() != null)
            _tag = "SimpleEnemy";
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            other.TryGetComponent<Bullet>(out Bullet bullet);
            DecreaseHealth(bullet._damage);
        }
    }
    public void DecreaseHealth(int amount) 
    {
        health -= amount; // decrease health given amount
        if (IsDead()) // check if enemy dead
        {
            gameObject.SetActive(false);
            PoolManager.Instance.poolDictionary[_tag].Enqueue(gameObject);
        }
    }
    private bool IsDead() // Check if health more than 0
    {
        if (health > 0)
            return false;
        return true;
    }
}
