using UnityEngine;

public class acidWater : MonoBehaviour
{

    public int damage = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            getHit hitScript = col.GetComponent<getHit>();

            if (hitScript != null)
            {
                hitScript.HP -= damage;
                Debug.Log("Player got soaked by water. HP now: " + hitScript.HP);

                if (hitScript.HP <= 0)
                {
                    Debug.Log("Player died!");
                    Destroy(col.gameObject);
                }
            }

            Destroy(gameObject);
        }
    }
}
