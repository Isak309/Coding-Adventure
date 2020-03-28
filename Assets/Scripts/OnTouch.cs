using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnTouch : MonoBehaviour
{
    [SerializeField]
    private Text pickUpText;
    public static bool correctKey = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckTouches();
    }

    void CheckTouches()
    {
        //Check incorrect
        for (int i = 0; i < Input.touchCount; ++i)
        {
            Vector2 test = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
            RaycastHit2D hit = Physics2D.Raycast(test, (Input.GetTouch(i).position));
            if (hit.collider && hit.collider.tag == "CorrectText")
            {
                Debug.Log("CorrectText");
                Text QuestText = GameObject.Find("Canvas/Quest").GetComponent<Text>();
                QuestText.text = "print(\"Hello, World\")";
                correctKey = true;
            }
        }

        //Check correct
        for (int i = 0; i < Input.touchCount; ++i)
        {
            Vector2 test = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
            RaycastHit2D hit = Physics2D.Raycast(test, (Input.GetTouch(i).position));
            if (hit.collider && hit.collider.tag == "IncorrectText")
            {
                Debug.Log("IncorrectText");
                Text QuestText = GameObject.Find("Canvas/Quest").GetComponent<Text>();
                QuestText.text = "Print(\"Hello, World\")";
                correctKey = false;
            }
        }
    }
}
