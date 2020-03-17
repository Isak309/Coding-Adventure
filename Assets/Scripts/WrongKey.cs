using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WrongKey : MonoBehaviour
{
    [SerializeField]
    private Text pickUpText;
    private bool pickUpAllowed;
    private void Start()
    {
        pickUpText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (pickUpAllowed && Input.GetButtonDown("Interact"))
        {
            //TODO: create condition to figure out if this is
            //correct "key" (piece of code) or not.
            //Call function depending on that
            PickUp();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            pickUpText.gameObject.SetActive(true);

            //value that becomes true when inside area
            pickUpAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            pickUpText.gameObject.SetActive(false);

            //becomes false now because its out of bounds
            pickUpAllowed = false;
        }
    }

    private void PickUp()
    {
        Text QuestText = GameObject.Find("Canvas/Quest").GetComponent<Text>();
        QuestText.text = "Print(\"Hello, World\")";
        Key.correctKey = false;
    }
}
