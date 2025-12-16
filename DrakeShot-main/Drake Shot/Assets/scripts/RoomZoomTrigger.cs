using System.Collections;
using UnityEngine;


public class RoomZoomTrigger : MonoBehaviour
{
    public Camera targetCamera; // drag Main Camera
    public float zoomedOutSize = 9f;
    public float zoomSpeed = 2f;

    bool triggered;

    void Awake()
    {
        if (targetCamera == null)
            targetCamera = Camera.main;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered) return;
        if (!other.CompareTag("Player")) return;

        triggered = true;
        StartCoroutine(ZoomOut());
    }

    IEnumerator ZoomOut()
    {
        float startSize = targetCamera.orthographicSize;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * zoomSpeed;
            targetCamera.orthographicSize =
                Mathf.Lerp(startSize, zoomedOutSize, t);
            yield return null;
        }
    }
}
