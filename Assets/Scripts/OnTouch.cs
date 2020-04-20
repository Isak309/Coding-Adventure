using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

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
        //Question text
        TextMeshPro Question = GameObject.Find("Question").GetComponent<TextMeshPro>();

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
                //Level 0
                if(hit.collider.name == "CorrectAnswer0")
                {
                    TextMeshPro CorrectAnswer = GameObject.Find("CorrectAnswer0").GetComponent<TextMeshPro>();//Set value to green text
                    TextMeshPro IncorrectAnswer = GameObject.Find("IncorrectAnswer0").GetComponent<TextMeshPro>();//Reset value to black text

                    CorrectAnswer.text = ("<color=white>High Level</color>");//green text
                    IncorrectAnswer.text = ("Low Level");//black text

                    Question.text = ("Python is a \n<color=white>High Level</color> \nProgramming language");

                    correctKey = true; //can now exit
                    incorrectKey = false;
                }
                if (hit.collider.name == "IncorrectAnswer0")
                {
                    TextMeshPro CorrectAnswer = GameObject.Find("CorrectAnswer0").GetComponent<TextMeshPro>(); //Reset value to black text
                    TextMeshPro IncorrectAnswer = GameObject.Find("IncorrectAnswer0").GetComponent<TextMeshPro>();//Set value to green text

                    CorrectAnswer.text = ("High Level");//black text
                    IncorrectAnswer.text = ("<color=white>Low Level</color>");//green text
                    Question.text = ("Python is a \n<color=white>Low Level</color> \nProgramming language");

                    correctKey = false; //cant exit anymore
                    incorrectKey = true;
                }
                //Level 1
                if (hit.collider.name == "CorrectAnswer1")
                {
                    TextMeshPro CorrectAnswer = GameObject.Find("CorrectAnswer1").GetComponent<TextMeshPro>();//Set value to green text
                    TextMeshPro IncorrectAnswer = GameObject.Find("IncorrectAnswer1").GetComponent<TextMeshPro>();//Reset value to black text

                    CorrectAnswer.text = ("<color=white>print</color>");//green text
                    IncorrectAnswer.text = ("Print");//black text

                    Question.text = ("<color=white>print</color>(\"Hello World\")");

                    correctKey = true; //can now exit
                    incorrectKey = false;
                }
                if (hit.collider.name == "IncorrectAnswer1")
                {
                    TextMeshPro CorrectAnswer = GameObject.Find("CorrectAnswer1").GetComponent<TextMeshPro>(); //Reset value to black text
                    TextMeshPro IncorrectAnswer = GameObject.Find("IncorrectAnswer1").GetComponent<TextMeshPro>();//Set value to green text

                    CorrectAnswer.text = ("print");//black text
                    IncorrectAnswer.text = ("<color=white>Print</color>");//green text

                    Question.text = ("<color=white>Print</color>(\"Hello World\")");

                    correctKey = false; //cant exit anymore
                    incorrectKey = true;
                }
            }
        }
    }
}
