using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //speed of character
    public float topSpeed = 10f;
    //Which way the sprite is facing
    bool facingRight = true;

    private void FixedUpdate()
    {
        //get move direction
        float move = Input.GetAxis("Horizontal");

        //add velocity to the rigidbody in the move direction * our speed
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * topSpeed, GetComponent<Rigidbody2D>().velocity.y);

        //if we're facing negative direcetion and not facing right, flip
        if(move > 0 && !facingRight)
        {
            Flip();
        }
        else if(move < 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        //saying we are facing opposite direction
        facingRight = !facingRight;

        //get the local scale
        Vector3 theScale = transform.localScale;

        //flip on x axis
        theScale.x *= -1;

        //apply that to the local scale
        transform.localScale = theScale;
    }
}
