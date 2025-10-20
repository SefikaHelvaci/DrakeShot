using UnityEngine;

public class MobScript : MonoBehaviour {
    
    public int health = 10;
    public GameObject goldPrefab;
    public GameObject XPPrefab;
    public float cycleCoef = 1f;
    
    public void TakeDamage(int damageAmount) {
        
        void Die() {

            void AutoInstantiate(GameObject a) {
                Instantiate(a, transform.position + (Vector3)(Random.insideUnitCircle * cycleCoef), Quaternion.identity);
            }

            AutoInstantiate(goldPrefab);
            AutoInstantiate(XPPrefab);
        
            Destroy(gameObject);
        
        }
        
        health -= damageAmount;

        if (health <= 0) {
            Die();
        }
        
    }
    
}