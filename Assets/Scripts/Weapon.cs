using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform gun;
    // Start is called before the first frame update
    public void OnMouseDown()
    {
        Debug.Log("Pew Pew");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
