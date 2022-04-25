using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float followingDistance = 15f;
    [SerializeField] float smoothSpeed = 0.125f;
    Vector3 velocity = Vector3.zero;
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPosition = new Vector3(player.position.x, transform.position.y, player.position.z - followingDistance);
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
