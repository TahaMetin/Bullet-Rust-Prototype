using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float bulletSpeed = 10000f;
    public GameObject gunRotatePoint0, gunRotatePoint1, bulletSpawnPoint0, bulletSpawnPoint1, bullet, managerScripts;
    Touch touch;
    private void Update()
    {
        if(Input.touchCount > 0) 
        {
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved)
            {
                float speedModifier = 0.01f;
                transform.position = new Vector3(
                    transform.position.x + touch.deltaPosition.x * speedModifier,
                    transform.position.y,
                    transform.position.z + touch.deltaPosition.y * speedModifier);
            }
        }
    }
    private void OnTriggerEnter(Collider other) // detect enemy touch and finish game
    {
        if(other.tag == "Enemy")
        {
            managerScripts.GetComponent<UIManager>().ShowLosePopup();
        }
    }
    private void Fire(GameObject spawnPoint,GameObject gunRotatePoint) 
    {
        Vector3 position = spawnPoint.GetComponent<Transform>().position;
        Vector3 shootDirection = (position - gunRotatePoint.transform.position).normalized;
        Rigidbody bulletClone = (Rigidbody)Instantiate(bullet.GetComponent<Rigidbody>(), position, transform.rotation);
        bulletClone.velocity = shootDirection * bulletSpeed;
    }

    public void FireInRightGun()
    {
        Fire(bulletSpawnPoint0, gunRotatePoint0);
    }
    public void FireInLeftGun()
    {
        Fire(bulletSpawnPoint1, gunRotatePoint1);
    }

    
}
