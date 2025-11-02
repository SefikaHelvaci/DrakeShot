using UnityEngine;

public class MobScript : MonoBehaviour {
    
    public int health = 10;
    public float cycleCoef = 1f;
    public GameObject goldPrefab;
    public GameObject XPPrefab;
    
    private void TakeDamage(int damageAmount) {
        
        health -= damageAmount;

        if (health <= 0) {
            Die();
        }
        
        void Die() {
        
            void AutoInstantiate(GameObject a) {
                Instantiate(a, transform.position + (Vector3)(Random.insideUnitCircle * cycleCoef), Quaternion.identity);
            }
        
            AutoInstantiate(goldPrefab);
            AutoInstantiate(XPPrefab);
                
            Destroy(gameObject);
                
        }
        
    }
    
}