using UnityEngine;

public class Bullet : MonoBehaviour {
    
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

        if (other.CompareTag("Enemy")) {
            if(other.GetComponent<MobScript>() != null)
            {
                other.GetComponent<MobScript>().TakeDamage(damage); 
            }
            else
            {
                other.GetComponent<bossPart>().TakeDamage(damage);
            }
            
            
            Destroy(gameObject);
        }

    }
    
}