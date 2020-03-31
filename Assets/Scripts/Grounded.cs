using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Player>();
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
