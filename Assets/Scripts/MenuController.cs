using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour
{
    public string sceneName;
    public GameObject pauseMenu;
    public Canvas pauseButton;
    public static bool isPaused;


    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        PauseCondition();
    }

    private void PauseCondition()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.position.x < 200 && touch.position.y > 500)
            {
                Vector2 test = Camera.main.ScreenToWorldPoint(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(test, (touch.position));
                if (hit)
                {
                    Debug.Log(hit.transform.name);
                    if (hit.transform.name == "Pause" && !pauseMenu.activeInHierarchy)
                    {
                        pauseMenu.SetActive(true);
                        isPaused = true;
                        Time.timeScale = 0f;
                    }

                }
            }
        }
    }
    public void OnMouseDown()
    {

        if (!pauseMenu.activeInHierarchy)
        {
            pauseMenu.SetActive(true);
            isPaused = true;
            Time.timeScale = 0f;
        }
        if (pauseMenu.activeInHierarchy)
        {
            pauseMenu.SetActive(false);
            isPaused = false;
            Time.timeScale = 1f;
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

