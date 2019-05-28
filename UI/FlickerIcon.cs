using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlickerIcon : MonoBehaviour
{
    public float iconFadeTimerDuration;
    private float timer;
    public float startingTime;
    public float emergencyTime;
    private bool flickering = false;
    public Image image;

    void Start()
    {
        image = GetComponent<Image>();
        timer = startingTime;
        flickering = false;
        image.gameObject.SetActive(true);
       //StartBlinking();
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer < (startingTime * 0.5f) && flickering == false && timer > 0)
        {
            flickering = true;
            StartBlinking();

        }

        else if (timer < emergencyTime && timer > 0)
        {
            iconFadeTimerDuration *= 0.5f;
        }

        else if (timer <= 0)
        {
            flickering = false;
            StopBlinking();
            timer = startingTime;
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
            image.gameObject.SetActive(false);

        }
    }

    IEnumerator Blink()
    {
        while (true)
        {
            switch (image.color.a.ToString())
            {
                case "0":
                    image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
                    yield return new WaitForSeconds(iconFadeTimerDuration);
                    break;
                case "1":
                    image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
                    yield return new WaitForSeconds(iconFadeTimerDuration);
                    break;
            }
        }
    }

    void StartBlinking()
    {
        StopCoroutine("Blink");
        StartCoroutine("Blink");
    }

    void StopBlinking()
    {
        StopCoroutine("Blink");
    }
}
