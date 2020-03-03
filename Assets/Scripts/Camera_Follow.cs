using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform followPlayer;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    public void FixedUpdate()
    {
        //transform.position = new Vector3(followPlayer.position.x, followPlayer.position.y, followPlayer.position.z - 10);
        Vector3 desiredPosition = followPlayer.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(followPlayer);
    }
}
