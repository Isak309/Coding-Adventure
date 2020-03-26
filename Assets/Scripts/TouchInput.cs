using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    public void Start()
    {
       
    }
    void Update()
    {
        BoxCollider2D myCollider = GetComponent<BoxCollider2D>();
        foreach (Touch touch in Input.touches)
        {

        }

        if (Input.touchCount > 0)
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            if (myCollider.OverlapPoint(wp))
            {
                //your code
                Debug.Log("Hello");
            }
        }
    }
}
