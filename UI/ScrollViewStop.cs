using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewStop : MonoBehaviour
{
    public int buttonSize;
    public int numberOfButtons;
    public int mValue;
    public RectTransform cont;
    // Update is called once per frame

    void Start()
    {
         mValue = buttonSize*numberOfButtons;
    }
    void Update()
    {
        if(cont.offsetMax.y < 0) 
        { 
             cont.offsetMax = new Vector2(); //Sets its value back.
             cont.offsetMin = new Vector2(); //Sets its value back.
        }

        if(cont.offsetMax.y>(numberOfButtons*buttonSize)-buttonSize)
        { 
         cont.offsetMax = new Vector2(0,(numberOfButtons*buttonSize)-buttonSize); 
         cont.offsetMin = new Vector2(); 
        }
    }
}
