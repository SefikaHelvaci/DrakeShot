using UnityEngine;

public class recoilScript : MonoBehaviour
{
    
    public SpriteRenderer rend;
    public float recoilDuration;
    
    private bool isHit;
    private float recoilTime;
    private float recoilPwr;
    private Vector3 recoilDirr;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rend = transform.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isHit)
        {
            float temp = 1f - Mathf.Clamp01(recoilTime / recoilDuration);
            transform.position += recoilDirr * recoilPwr * temp * temp * Time.deltaTime;
            recoilTime += Time.deltaTime;

            if (recoilTime >= recoilDuration)
            {
                isHit = false;
                recoilTime = 0;
            }
        }
    }

    public void onHit(float hitPwr, Vector3 hitDirr)
    {
        recoilDirr = hitDirr;
        recoilPwr = hitPwr;
        isHit = true;
    }
}
