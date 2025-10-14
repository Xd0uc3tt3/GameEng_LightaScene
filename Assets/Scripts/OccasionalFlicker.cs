using UnityEngine;

public class OccasionalFlicker : MonoBehaviour
{
    public float offIntensity = 0f;
    public float minFlashIntensity = 0.8f;
    public float maxFlashIntensity = 2f;
    public float fadeSpeed = 5f;
    public float minWait = 0.3f;
    public float maxWait = 5f;
    public float minFlashTime = 0.05f;
    public float maxFlashTime = 0.5f;

    Light flickerLight;
    float targetIntensity;
    float nextFlashTime;
    float flashEndTime;
    bool flashing;

    void Start()
    {
        flickerLight = GetComponent<Light>();
        flickerLight.intensity = offIntensity;
        ScheduleNextFlash();
    }

    void Update()
    {
        flickerLight.intensity = Mathf.Lerp(flickerLight.intensity, targetIntensity, Time.deltaTime * fadeSpeed);

        if (!flashing && Time.time >= nextFlashTime)
        {
            flashing = true;
            targetIntensity = Random.Range(minFlashIntensity, maxFlashIntensity);
            flashEndTime = Time.time + Random.Range(minFlashTime, maxFlashTime);
        }

        if (flashing && Time.time >= flashEndTime)
        {
            flashing = false;
            targetIntensity = offIntensity;
            ScheduleNextFlash();
        }
    }

    void ScheduleNextFlash()
    {
        nextFlashTime = Time.time + Random.Range(minWait, maxWait);
    }
}