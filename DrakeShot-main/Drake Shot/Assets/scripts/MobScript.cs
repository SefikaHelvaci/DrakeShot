using UnityEngine;

public class MobScript : MonoBehaviour {
    
    [SerializeField] private GameObject goldPrefab;
    [SerializeField] private GameObject xpPrefab;
    [SerializeField] private int health = 10;
    [SerializeField] private float cycleCoef = 1f;
    
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