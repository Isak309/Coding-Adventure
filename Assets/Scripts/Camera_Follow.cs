using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform playerMan;

    public void FixedUpdate()
    {
        transform.position = new Vector3(playerMan.position.x, playerMan.position.y, playerMan.position.z - 10);
    }
}
