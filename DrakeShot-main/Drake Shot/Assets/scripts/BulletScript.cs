using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 7f;
    public int damage = 1;
    public float destructionTime = 5f;

    private Rigidbody2D rb;

    void Start() {
        
        rb = GetComponent<Rigidbody2D>();
        
        rb.linearVelocity = transform.right * moveSpeed; 
        
        Destroy(gameObject, destructionTime);
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        
        if (other.CompareTag("Enemy")) {
            
            MobScript myEnemy = other.GetComponent<MobScript>();
            
            myEnemy.TakeDamage(damage); 
            
            Destroy(gameObject);
        }
        
    }
    
}