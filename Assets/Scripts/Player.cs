using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform gun;
    //create characters rigidbody
    private Rigidbody2D rigidbody2d;
    private float move;
    //speed of character
    public float topSpeed;
    //jump velocity of character
    public float jumpVelocity;
    public float jumpVelocity2;
    public float fallMultiplyers;
    //Which way the sprite is facing
    bool facingRight = true;

    //animator
    public Animator animator;

    public Joystick joystick;

    //check if character is touching ground
    public bool canDoubleJump;
    private void Awake()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
    }

    public void Start()
    {

    }

    private void Update()
    {
        Move();
        animator.SetFloat("New Float", Mathf.Abs(move));

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
        theScale.x *= -1;
        transform.localScale = theScale;
        gun.transform.Rotate(0f, 180f, 0f);
    }
    public void Move()
    {
        //get move direction
        move = joystick.Horizontal * topSpeed;
        float verticalMove = joystick.Vertical;
        //add velocity to the rigidbody in the move direction * our speed
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * topSpeed, GetComponent<Rigidbody2D>().velocity.y);
        if (move > 0.1 || move < -0.1)
        {

           //my_Animator.SetBool("movement", true);
        }
        else
        {
        }

        if (verticalMove >= 0.5 && Grounded.grounded)
        {
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
            canDoubleJump = true;
        }
        else //not using this right now
        {
            if (canDoubleJump && Input.GetButtonDown("Jump"))
            {
                rigidbody2d.velocity = Vector2.up * jumpVelocity2 * Time.deltaTime;
                canDoubleJump = false;
            }
        }
        if(rigidbody2d.velocity.y < 0)
        {
            rigidbody2d.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplyers * Time.deltaTime;
        }
    }
}
