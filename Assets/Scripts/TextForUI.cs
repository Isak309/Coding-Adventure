using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextForUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //generate text for Quest
        Text QuestText = GameObject.Find("Canvas/Quest").GetComponent<Text>();
        QuestText.text = "cout ____ \"Let's Get Started!\" ;";

        //generate text for instructions
        Text instructionsText = GameObject.Find("Canvas/Instructions").GetComponent<Text>();
        instructionsText.text = "Find the Correct Missing Code !";

        //remove Instructions after 3 seconds
        Destroy(GameObject.Find("Canvas/Instructions").GetComponent<Text>(), 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
