using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitLevel : MonoBehaviour
{
    [SerializeField]
    private Text exitText;
    private bool exitAllowed;

    public string LevelToLoad;

    // Start is called before the first frame update
    void Start()
    {
        exitText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (exitAllowed && OnTouch.correctKey == true)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.position.x < Screen.width / 3 && touch.position.y < Screen.height / 2.1)
                {
                    Debug.Log("Touched Joystick");
                }
                else
                {
                    SceneManager.LoadScene(LevelToLoad);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            exitText.gameObject.SetActive(true);
            exitAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            exitText.gameObject.SetActive(false);
            exitAllowed = false;
        }
    }
}
