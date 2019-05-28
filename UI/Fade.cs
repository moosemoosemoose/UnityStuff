using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public float time;
    public float delay;
    private Text text;
    public bool transition;
    public bool fadeOut = true;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        StartCoroutine(FadeTextToFullAlpha());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey && transition)
        {
            TransitionLevel.GoToNextLevel();
        }
    }
    public IEnumerator FadeTextToFullAlpha()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < .8f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / time));
            yield return null;
        }
        yield return new WaitForSeconds(delay);
        if (fadeOut)
        {
            StartCoroutine(FadeTextToNoAlpha());
        }
    }
    public IEnumerator FadeTextToNoAlpha()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / time));
            yield return null;
        }
        if (transition)
        {
            TransitionLevel.GoToNextLevel();
        }
        else
        {
            yield return new WaitForSeconds(delay);
            StartCoroutine(FadeTextToFullAlpha());
        }
    }
}
