using UnityEngine;

public class Bullet : MonoBehaviour {
    
    [SerializeField] private float destructionTime = 5f;
    
    private Rigidbody2D _rb;
    private int _bulletDamage;

    private void Awake() {
        
        _rb = GetComponent<Rigidbody2D>();
        
        Destroy(gameObject, destructionTime);
        
    }
    
    public void Setup(float speed, int damage) {

        _rb.linearVelocity = transform.right * speed;
        
        _bulletDamage = damage;
        
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Enemy")) {
            if(other.GetComponent<MobScript>() != null) {
                other.GetComponent<MobScript>().TakeDamage(_bulletDamage); 
            }
            else {
                other.GetComponent<bossPart>().TakeDamage(_bulletDamage);
            }
            
            Destroy(gameObject);
        }

    }
    
}