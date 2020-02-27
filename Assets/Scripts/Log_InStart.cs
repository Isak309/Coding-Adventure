using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log_InStart : MonoBehaviour
{
    public void changeloginscene(string scenename)
    {
        Application.LoadLevel(scenename);
    }
}
