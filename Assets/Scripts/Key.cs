using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    [SerializeField]
    private Text pickUpText;
    public static bool correctKey = false;
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
        QuestText.text = "print(\"Hello, World\")";
        correctKey = true;
    }


}
