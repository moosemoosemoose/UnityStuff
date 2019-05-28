using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashIntro : MonoBehaviour
{
    public float upTime;
    public float fadeOutTime;
    public Image blackScreen;
    public Text introText;
    private static float _lastframetime;
    public static float deltaTime;
    public bool faded;
    public static SplashIntro SIScript;

    void Awake()
    {
        SIScript = this;
    }

    void Start()
    {
        StartCoroutine(DelayedStart());
    }

    void Update()
    {
        deltaTime = Time.realtimeSinceStartup - _lastframetime;
        _lastframetime = Time.realtimeSinceStartup;

        if (upTime >= 0.0f - fadeOutTime)
        {
            upTime -= deltaTime;
            Debug.Log("Ticked down");
        }

        if (upTime <= 0.0f - fadeOutTime || faded == true)
        {
            Time.timeScale = 1;
            stopFade();
            Debug.Log("normal");
            blackScreen.gameObject.SetActive(false);
            introText.gameObject.SetActive(false);
            SplashIntro.SIScript.enabled = false;
            
        }

        if (upTime <= 0.0f)
        {
            startFade(fadeOutTime, deltaTime, _lastframetime);
            Debug.Log("fade out");

        }
    }

    IEnumerator startActivity(float fadeOutTime, float deltaTime, float _lastframetime)
    {
        deltaTime = Time.realtimeSinceStartup - _lastframetime;
        _lastframetime = Time.realtimeSinceStartup;
        
        Color bs = blackScreen.color;
        Color it = introText.color;
        bs.a -= (1.0f / fadeOutTime * deltaTime) * 48;
        it.a -= (1.0f / fadeOutTime * deltaTime) * 48;
        blackScreen.color = bs;
        introText.color = it;

        if (bs.a <= 0)
        {
            faded = true;
        }

        yield return null;

    }

    void startFade(float fadeOutTime, float deltaTime, float _lastframetime)
    {
        StopCoroutine("startActivity");
        StartCoroutine(startActivity(fadeOutTime, deltaTime, _lastframetime));
    }

    void stopFade()
    {
        StopCoroutine("startActivity");
    }
    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(.3f);
        faded = false;
        Time.timeScale = 0;
        _lastframetime = Time.realtimeSinceStartup;
    }
}
