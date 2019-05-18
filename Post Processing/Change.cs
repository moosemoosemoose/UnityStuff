using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

[RequireComponent(typeof(PostProcessingBehaviour))]
public class Change : MonoBehaviour
{
    PostProcessingProfile m_Profile;
    //[HideInInspector]
    public static int colorState;
    public Vector3 rgbZero;
    public Vector3 rgbR;
    public Vector3 rgbG;
    public Vector3 rgbB;

    void Awake()
    {
        colorState = 2;
        rgbZero = new Vector3(0.0f, 0.0f, 0.0f);
        rgbR = new Vector3(1.0f, 0.0f, 0.0f);
        rgbG = new Vector3(0.0f, 1.0f, 0.0f);
        rgbB = new Vector3(0.0f, 0.0f, 1.0f);
    }
    void OnEnable()
    {
        var behaviour = GetComponent<PostProcessingBehaviour>();

        if (behaviour.profile == null)
        {
            enabled = false;
            return;
        }

        m_Profile = Instantiate(behaviour.profile);
        behaviour.profile = m_Profile;
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (colorState != 0)
            {
                changeState(0); //red
            }

            else
                changeState(2);
        }
        if (Input.GetMouseButtonUp(1))
        {
            if (colorState != 1)
            {
                changeState(1); //red
            }

            else
                changeState(2);
        }
        if (Input.GetMouseButtonUp(2))
        {
            if (colorState != 2)
            {
                changeState(2); //red
            }
            
        }

    }

    void changeState(int cState)
    {
        colorState = cState;
        var colorGradingLayer = m_Profile.colorGrading.settings;

        switch (colorState)
        {
            case 0:
                colorGradingLayer.channelMixer.red = rgbR;
                colorGradingLayer.channelMixer.green = rgbZero;
                colorGradingLayer.channelMixer.blue = rgbZero;
                
                break;
            case 1:
                colorGradingLayer.channelMixer.red = rgbZero;
                colorGradingLayer.channelMixer.green = rgbZero;
                colorGradingLayer.channelMixer.blue = rgbB;
                
                break;
            case 2:
                colorGradingLayer.channelMixer.red = rgbR;
                colorGradingLayer.channelMixer.green = rgbG;
                colorGradingLayer.channelMixer.blue = rgbB;
                
                break;
        }

        m_Profile.colorGrading.settings = colorGradingLayer;
    }
}
