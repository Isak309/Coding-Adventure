using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnTouch : MonoBehaviour
{
    private Text pickUpText;
    public static bool correctKey = false;
    public static bool incorrectKey = false;

    //Pause GameObject
    public GameObject pauseMenu;
    public GameObject resume;
    public GameObject mainMenu;

    public string sceneName;
    public bool isPaused;
    public bool useless;

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
                    QuestText.text = "print(\"Hello, World\")";
                    correctKey = true;
                    incorrectKey = false;
                }
                else if (hit.collider && hit.collider.tag == "IncorrectText")
                {
                    Text QuestText = GameObject.Find("Canvas/Quest").GetComponent<Text>();
                    QuestText.text = "Print(\"Hello, World\")";
                    correctKey = false;
                    incorrectKey = true;
                }
            }
            /*if (hit.collider && hit.collider.tag == "Pause")
            {
                MenuController.isPaused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }*/
            /*if (hit.collider && hit.collider.tag == "Resume")
            {
                MenuController.isPaused = false;
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
            }
            if (hit.collider && hit.collider.tag == "MainMenu")
            {
                MenuController.isPaused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }*/
        }
    }
}
