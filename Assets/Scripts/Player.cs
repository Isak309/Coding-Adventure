using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //create characters rigidbody
    private Rigidbody2D rigidbody2d;
    private float move;
    //speed of character
    public float topSpeed;
    //jump velocity of character
    public float jumpVelocity;
    public float jumpVelocity2;
    //Which way the sprite is facing
    bool facingRight = true;

    public Joystick joystick;

    //check if character is touching ground
    public bool isGrounded, canDoubleJump;
    public LayerMask groundLayers;
    private void Awake()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        InteractWithText();
        Move();


        int nbTouches = Input.touchCount;
        if (nbTouches > 0)
        {
            print(nbTouches + " touch(es) detected");
            for (int i = 0; i < nbTouches; i++)
            {
                Touch touch = Input.GetTouch(i);
                print("Touch index " + touch.fingerId + " detected at position " + touch.position);
            }
        }
        //if we're facing negative direcetion and not facing right, flip
        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    public void Move()
    {
        //get move direction
        move = joystick.Horizontal * topSpeed;
        float verticalMove = joystick.Vertical;
        //add velocity to the rigidbody in the move direction * our speed
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * topSpeed, GetComponent<Rigidbody2D>().velocity.y);
        if (verticalMove >= 0.5 && isGrounded)
        {
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
            canDoubleJump = true;
        }
        else //not using this right now
        {
            if (canDoubleJump && Input.GetButtonDown("Jump"))
            {
                rigidbody2d.velocity = Vector2.up * jumpVelocity2;
                canDoubleJump = false;
            }
        }
    }

    public void InteractWithText()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                Debug.Log("Something Hit");
                if (raycastHit.collider.name == "Soccer")
                {
                    Debug.Log("Soccer Ball clicked");
                }

                //OR with Tag

                if (raycastHit.collider.CompareTag("SoccerTag"))
                {
                    Debug.Log("Soccer Ball clicked");
                }
            }
        }
    }
}
