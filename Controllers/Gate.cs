using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private Vector3 oSize;
    private Vector3 goneSize;
    private bool gone;
   
    void Start()
    {
        oSize = transform.localScale;
        goneSize = new Vector3(0, 0, 0);
    }

    void FixedUpdate()
    {
        checkForChanges();
    }

    void checkForChanges()
    {
        if (tag == "red" && Change.colorState == 0 && !gone)
        {
            this.gameObject.transform.localScale = goneSize;
            //Debug.Log("gate removed State is " + Change.colorState);
            gone = true;
        }
        else if (tag == "red" && Change.colorState != 0 && gone)
        {
            this.gameObject.transform.localScale = oSize;
            //Debug.Log("gate reappeared State is " + Change.colorState);
            gone = false;
        }

        if (tag == "blue" && Change.colorState == 1 && !gone)
        {
            this.gameObject.transform.localScale = goneSize;
            //Debug.Log("gate removed State is " + Change.colorState);
            gone = true;
        }
        else if (tag == "blue" && Change.colorState != 1 && gone)
        {
            this.gameObject.transform.localScale = oSize;
            //Debug.Log("gate reappeared State is " + Change.colorState);
            gone = false;
        }
    }
}
