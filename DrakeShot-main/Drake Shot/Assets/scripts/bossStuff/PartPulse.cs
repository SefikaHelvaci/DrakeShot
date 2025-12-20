using UnityEngine;
using System.Collections;

public class PartPulse : MonoBehaviour
{
    
    public float pulseScale = 1.25f;
    public float pulseSpeed = 6f;
    Coroutine pulseCoroutine;
    
    public void StartPulsing(float duration)
    {
        if (pulseCoroutine != null) StopCoroutine(pulseCoroutine);
        pulseCoroutine = StartCoroutine(PulseRoutine(duration));
    }

    IEnumerator PulseRoutine(float duration)
    {
        float t = 0f;
        Vector3 baseScale = transform.localScale;
        while (t < duration)
        {
            float s = 1f + (Mathf.Sin(Time.time * pulseSpeed) * 0.5f + 0.5f) * (pulseScale - 1f);
            transform.localScale = baseScale * s;
            t += Time.deltaTime;
            yield return null;
        }
        transform.localScale = baseScale;
        pulseCoroutine = null;
    }
}


