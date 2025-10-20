using UnityEngine;

public class Mob : MonoBehaviour {
    
    public int health = 10;
    public GameObject goldPrefab;
    public GameObject XPPrefab;
    public float cycleCoef = 1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }
    
    public void TakeDamage(int damageAmount) {
        
        health -= damageAmount;

        if (health <= 0) {
            Die();
        }
        
    }
    
    public void Die() {

        void AutoInstantiate(GameObject a) {
            
            Instantiate(a, transform.position + (Vector3)(Random.insideUnitCircle * cycleCoef), Quaternion.identity);
            
        }

        AutoInstantiate(goldPrefab);
        AutoInstantiate(XPPrefab);
        
        Destroy(gameObject);
        
    }
    
}