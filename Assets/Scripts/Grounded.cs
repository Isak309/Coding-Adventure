using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    public static bool grounded;
    public Transform rayStart, rayEnd;
    void Update()
    {
        Raycasting();
    }

    void Raycasting()
    {
        Debug.DrawLine(rayStart.position, rayEnd.position, Color.green);
        grounded = Physics2D.Linecast(rayStart.position, rayEnd.position, 1 << LayerMask.NameToLayer("Floor"));
        Debug.Log(grounded);
    }
}