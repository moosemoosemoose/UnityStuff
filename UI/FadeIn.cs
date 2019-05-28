using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public float time;
    public Image panel;
    public GameObject[] objects;
    public bool activate = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("FadeTextToFullAlpha");
    }

    public IEnumerator FadeTextToFullAlpha()
    {
        panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 0);
        while (panel.color.a < .8f)
        {
            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, panel.color.a + (Time.deltaTime / time));
            yield return null;
        }
        if (activate)
        {
            ActivateObjects();
        }
    }
    void ActivateObjects()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(true);
        }
    }
}
