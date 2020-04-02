using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnTouch : MonoBehaviour
{
    private Text pickUpText;
    public static bool correctKey = false;

    //Pause GameObject
    public GameObject pauseMenu;
    public GameObject resume;
    public GameObject mainMenu;

    public string sceneName;
    public bool isPaused;


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
                Debug.Log("Touched Joystick");
            }
            else
            {
                Debug.Log("Touched Elsewhere");
                
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
            if (hit.collider && hit.collider.tag == "Pause")
            {
                MenuController.isPaused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
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

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ReturnToMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }
}
