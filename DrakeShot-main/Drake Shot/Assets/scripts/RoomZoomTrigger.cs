using System.Collections;
using UnityEngine;
using Unity.Cinemachine;

public class RoomZoomTrigger : MonoBehaviour
{
    
    [SerializeField] private float zoomedOutSize = 9f;
    [SerializeField] private float zoomSpeed = 2f;

    private CinemachineCamera _cinemachineCamera;
    private bool _triggered;

    private void Start() {
        
        _cinemachineCamera = FindFirstObjectByType<CinemachineCamera>();
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        if (_triggered) return;

        _triggered = true;
        StartCoroutine(ZoomOut());
    }

    IEnumerator ZoomOut()
    {
        float startSize = _cinemachineCamera.Lens.OrthographicSize;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * zoomSpeed;

            _cinemachineCamera.Lens.OrthographicSize =
                Mathf.Lerp(startSize, zoomedOutSize, t);

            yield return null;
        }
    }
}