using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    public Player player;
    public float distanceGround;
    public bool grounded = false;
    public 
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Player>();
        distanceGround = GetComponent<Collider2D>().bounds.extents.y;
    }

    private void FixedUpdate()
    {
        if(!Physics2D.Raycast(transform.position, -Vector3.up, distanceGround + 0.1f))
        {
            grounded = false;
            print("Were in the air!");
        }
        else
        {
            grounded = true;
            print("grounded");
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        player.isGrounded = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        player.isGrounded = false;
    }
}
