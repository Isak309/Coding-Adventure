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
        QuestText.text = "~~~~(\"Hello, World\")";

        //generate text for instructions
        Text instructionsText = GameObject.Find("Canvas/Instructions").GetComponent<Text>();
        instructionsText.text = "Complete the python code " +
            "\nunder the wavy lines!";

        //remove Instructions after 3 seconds
        Destroy(GameObject.Find("Canvas/Instructions").GetComponent<Text>(), 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
