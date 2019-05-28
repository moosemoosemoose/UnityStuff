using UnityEngine;
using UnityEngine.PostProcessing;

[RequireComponent(typeof(PostProcessingBehaviour))]
public class finalVignette : MonoBehaviour
{
    PostProcessingProfile m_Profile;
    public LifeSupport lifeSupport;

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

    void Start()
    {
        m_Profile.vignette.enabled=true;
    }

    void Update()
    {

        Check();
        
    }

   
    void Check()
    {
        var vignette = m_Profile.vignette.settings;
        vignette.intensity = 1 - (lifeSupport.batteryLevel / lifeSupport.startingBatteryLevel);
        vignette.smoothness = Mathf.Abs(Mathf.Sin(Time.realtimeSinceStartup) * 0.99f) + 0.01f;
        m_Profile.vignette.settings = vignette;
    }
}