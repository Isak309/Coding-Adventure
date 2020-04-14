using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnTouch : MonoBehaviour
{
    //transform for gun to shoot

    private Text pickUpText;
    public static bool correctKey = false;
    public static bool incorrectKey = false;


    public string sceneName;
    public bool isPaused;
    public bool useless;

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
            Vector2 test = Camera.main.ScreenToWorldPoint(touch.position);
            RaycastHit2D hit = Physics2D.Raycast(test, (touch.position));
            if (touch.position.x < Screen.width / 3 && touch.position.y < Screen.height / 2.1)
            {
                useless = true;
            }
            else
            {
                useless = false;
                if (hit.collider && hit.collider.tag == "CorrectText")
                {
                    Text QuestText = GameObject.Find("Canvas/Quest").GetComponent<Text>();
                    QuestText.text = "<color=green>print</color>(\"Hello, World\")";
                    correctKey = true;
                    incorrectKey = false;
                }
                else if (hit.collider && hit.collider.tag == "IncorrectText")
                {
                    Text QuestText = GameObject.Find("Canvas/Quest").GetComponent<Text>();
                    QuestText.text = "<color=green>Print</color>(\"Hello, World\")";
                    correctKey = false;
                    incorrectKey = true;
                }
            }


        }
    }
}
