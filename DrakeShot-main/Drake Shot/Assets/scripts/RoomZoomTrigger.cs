using System.Collections;
using UnityEngine;
using Unity.Cinemachine;

public class RoomZoomTrigger : MonoBehaviour
{
    public CinemachineCamera cinemachineCamera;
    public float zoomedOutSize = 9f;
    public float zoomSpeed = 2f;

    bool triggered;

    void Awake()
    {
        if (cinemachineCamera == null)
            cinemachineCamera = FindObjectOfType<CinemachineCamera>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        if (triggered) return;

        triggered = true;
        StartCoroutine(ZoomOut());
    }

    IEnumerator ZoomOut()
    {
        float startSize = cinemachineCamera.Lens.OrthographicSize;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * zoomSpeed;

            cinemachineCamera.Lens.OrthographicSize =
                Mathf.Lerp(startSize, zoomedOutSize, t);

            yield return null;
        }
    }
}