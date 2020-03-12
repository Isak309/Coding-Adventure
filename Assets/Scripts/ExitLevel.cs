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
        bool newKey = Key.correctKey;
        if (exitAllowed && Input.GetButtonDown("Interact") && newKey == true)
        {
            SceneManager.LoadScene(LevelToLoad);
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
