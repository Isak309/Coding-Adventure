using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WrongKey : MonoBehaviour
{
    [SerializeField]
    private Text pickUpText;
    private void Start()
    {
        pickUpText.gameObject.SetActive(false);
    }

    /*private void OnMouseDown()
    {
        PickUp();
    }*/

    private void PickUp()
    {
        Text QuestText = GameObject.Find("Canvas/Quest").GetComponent<Text>();
        QuestText.text = "Print(\"Hello, World\")";
        Key.correctKey = false;
    }
}
