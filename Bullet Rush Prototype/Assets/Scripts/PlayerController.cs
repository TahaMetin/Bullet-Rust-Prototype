using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    /*
     * WARNING: Keep "BigEnemyTargets" gameobject at index 0. BigEnemyAI is taking targets with index
     */

    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] float moveSpeedModifier =0.02f;
    [SerializeField] GameObject gunRotatePoint0, gunRotatePoint1, bulletSpawnPoint0, bulletSpawnPoint1, bullet;
    Vector2 _startPos;
    Vector2 _direction;
    float _moveSpeed;
    PlayerAnimatorController _playerAnimatorController;

    private void Start()
    {
        _playerAnimatorController = gameObject.GetComponent<PlayerAnimatorController>();
        _playerAnimatorController.SetIsMovingFalse();
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _startPos = touch.position;
                    break;
                case TouchPhase.Moved:
                    // Determine direction by comparing the current touch position with the initial one
                    _direction = touch.position - _startPos;
                    // Determine moveSpeed by normalized magnitude of direction vector 
                    _moveSpeed = _direction.normalized.magnitude * moveSpeedModifier;
                    Move();
                    break;
                case TouchPhase.Stationary:
                    // when touch is not moving but still exist
                    Move();
                    break;
                case TouchPhase.Ended:
                    // when touch ended set default values 
                    _moveSpeed = 0f;
                    _direction = Vector2.zero;
                    _playerAnimatorController.SetIsMovingFalse();
                    break;
            }
        }
    }
    private void Move() // move accordingly to direction and moveSpeed
    {
        Vector3 directionVector3 = new Vector3(_direction.x, 0f, _direction.y);
        transform.position = transform.position + directionVector3 * _moveSpeed * Time.deltaTime;
        transform.LookAt(directionVector3);
        _playerAnimatorController.SetIsMovingTrue();
    }
    private void OnTriggerEnter(Collider other) // detect enemy touch and finish game
    {
        if(other.tag == "Enemy")
        {
            EventManager.Instance.lose.Invoke();
        }
    }
    private void Fire(GameObject spawnPoint,GameObject gunRotatePoint) 
    {
        Vector3 bulletSpawnPosition = spawnPoint.GetComponent<Transform>().position;
        Vector3 shootDirection = (bulletSpawnPosition - gunRotatePoint.transform.position).normalized;
        Rigidbody bulletClone = PoolManager.Instance.SpawnFromPool("Bullet", bulletSpawnPosition).GetComponent<Rigidbody>();
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
