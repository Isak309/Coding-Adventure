using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnTouch : MonoBehaviour
{
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
        foreach (Touch touch in Input.touches)
        {
            if (touch.position.x < Screen.width / 3 && touch.position.y < Screen.height / 2.1)
            {
                Debug.Log("Touched Joystick");
            }
            else
            {
                Debug.Log("Touched Elsewhere");
                Vector2 test = Camera.main.ScreenToWorldPoint(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(test, (touch.position));
                if (hit.collider && hit.collider.tag == "CorrectText")
                {
                    Debug.Log("CorrectText");
                    Text QuestText = GameObject.Find("Canvas/Quest").GetComponent<Text>();
                    QuestText.text = "print(\"Hello, World\")";
                    correctKey = true;
                }
                else if (hit.collider && hit.collider.tag == "IncorrectText")
                {
                    Debug.Log("IncorrectText");
                    Text QuestText = GameObject.Find("Canvas/Quest").GetComponent<Text>();
                    QuestText.text = "Print(\"Hello, World\")";
                    correctKey = false;
                }
            }
        }
    }
}
