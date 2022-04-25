using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAim : MonoBehaviour
{
    [SerializeField] float range;
    [SerializeField] GameObject player;
    [SerializeField] bool isThisRightGun;
    GameObject _currentGun;
    GameObject _currentTarget;
    bool _isTargetInRange;
    PlayerController _playerController;
    private void Start()
    {
        _isTargetInRange = false;
        _currentGun = gameObject;
        _playerController = player.GetComponent<PlayerController>();
        StartCoroutine("FireCheck");
    }
    private void LateUpdate() // late update used for overriding animation. 
    {
        Collider[] colliderArray = Physics.OverlapSphere(transform.position,range);
        Vector3 distance = new Vector3(0,0,0);
        _isTargetInRange = false;
        foreach (Collider collider in colliderArray)
        {
            if (collider.tag == "Enemy")
            {
                // Find closest enemy
                Vector3 newDistance = collider.transform.position - gameObject.transform.position;
                if(newDistance.magnitude > distance.magnitude)
                {
                    _currentTarget = collider.gameObject; // set current target
                    AutoAiming();
                    _isTargetInRange = true;
                }
            }
            else
            {
                _currentTarget = null;
            }
        }
    }
    IEnumerator FireCheck()
    {
        for (; ; )
        {
            if (_isTargetInRange)
            {
                if (isThisRightGun)
                    _playerController.FireInRightGun();
                else
                    _playerController.FireInLeftGun();

                _isTargetInRange = false;
            }
            yield return new WaitForSeconds(.1f);
        }
    }
    private void AutoAiming()
    {
        _currentGun.transform.LookAt(_currentTarget.transform);
        if(isThisRightGun)
            _currentGun.transform.Rotate(0f, 90f, 0f); //adjust rotation for character shoulder
        else
            _currentGun.transform.Rotate(0f,-90f,0f);
    }
}
