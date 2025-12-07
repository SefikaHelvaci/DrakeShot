using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 7f;
    public int damage = 1;
    public float destructionTime = 5f;

    private Rigidbody2D _rb;

    private void Start() {
        
        _rb = GetComponent<Rigidbody2D>();
        
        _rb.linearVelocity = transform.right * moveSpeed; 
        
        Destroy(gameObject, destructionTime);
        
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if (!other.CompareTag("Enemy")) {
            return;
        }
        
        MobScript myEnemy = other.GetComponent<MobScript>();
            
        myEnemy.TakeDamage(damage); 
            
        Destroy(gameObject);

    }
    
}