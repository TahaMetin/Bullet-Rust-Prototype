using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    [SerializeField] int health;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            other.TryGetComponent<Bullet>(out Bullet bullet);
            DecreaseHealth(bullet.damage);
        }
    }

    public void DecreaseHealth(int amount) 
    {
        health -= amount; // decrease health given amount
        if (IsDead()) // check if enemy dead
        {
            Destroy(gameObject); // Destroy gameobject who attached this script
        }
    }

    private bool IsDead() // Check if health more than 0
    {
        if (health > 0)
            return false;
        return true;
    }


}
