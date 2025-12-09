using UnityEngine;

public class MobScript : MonoBehaviour {
    
    public int health = 10;
    public float cycleCoef = 1f;
    public GameObject goldPrefab;
    public GameObject xpPrefab;
    
    public void TakeDamage(int damageAmount) {
        
        health -= damageAmount;

        if (health <= 0) {
            Die();
        }

        return;

        void Die() {
            
            AutoInstantiate(goldPrefab);
            AutoInstantiate(xpPrefab);
                
            Destroy(gameObject);
            
            return;

            void AutoInstantiate(GameObject a) {
                
                Instantiate(a, transform.position + (Vector3)(Random.insideUnitCircle * cycleCoef), Quaternion.identity);
                
            }
            
        }
        
    }
    
}