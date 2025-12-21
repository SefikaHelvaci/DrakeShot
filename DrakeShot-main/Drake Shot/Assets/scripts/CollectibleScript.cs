using UnityEngine;

public class CollectibleScript : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.CompareTag("Player")) {
            other.GetComponent<CollectScript>().Add(tag);
            
            Destroy(gameObject);
        }

    }
    
}