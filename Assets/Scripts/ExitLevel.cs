using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitLevel : MonoBehaviour
{
    [SerializeField]
    private Text exitText;
    private Text incorrectText;
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
                Vector2 test = Camera.main.ScreenToWorldPoint(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(test, (touch.position));
                if (touch.position.x < Screen.width && touch.position.y < Screen.height)
                {
                    if (hit.collider && hit.collider.tag == "Exit")
                    {
                        SceneManager.LoadScene(LevelToLoad);

                    }
                }
            }
        }
        else if (exitAllowed && OnTouch.incorrectKey == true)
        {

            foreach (Touch touch in Input.touches)
            {
                Vector2 test = Camera.main.ScreenToWorldPoint(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(test, (touch.position));
                if (touch.position.x < Screen.width && touch.position.y < Screen.height)
                {
                    if (hit.collider && hit.collider.tag == "Exit")
                    {
                        incorrectText.gameObject.SetActive(true);
                    }
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
