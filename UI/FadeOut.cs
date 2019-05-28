using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public float time;
    public Image panel;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeTextToNoAlpha());
    }

    public IEnumerator FadeTextToNoAlpha()
    {
        panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 1);
        while (panel.color.a > 0f)
        {
            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, panel.color.a - (Time.deltaTime / time));
            yield return null;
        }
    }
}
