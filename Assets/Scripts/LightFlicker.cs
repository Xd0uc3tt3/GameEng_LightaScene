using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public float minIntensity = 0.2f;
    public float maxIntensity = 1.5f;
    public float flickerIntervalMin = 0.01f;
    public float flickerIntervalMax = 0.15f;

    Light flickerLight;
    float baseIntensity;
    float nextFlickerTime;

    void Start()
    {
        flickerLight = GetComponent<Light>();
        baseIntensity = flickerLight.intensity;
        nextFlickerTime = Time.time + Random.Range(flickerIntervalMin, flickerIntervalMax);
    }

    void Update()
    {
        if (Time.time >= nextFlickerTime)
        {
            flickerLight.intensity = baseIntensity * Random.Range(minIntensity, maxIntensity);
            nextFlickerTime = Time.time + Random.Range(flickerIntervalMin, flickerIntervalMax);
        }
    }
}


