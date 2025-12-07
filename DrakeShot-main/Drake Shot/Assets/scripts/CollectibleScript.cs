using UnityEngine;

public class CollectibleScript : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other) {
        
        if (!other.CompareTag("Player")) {
            return;
        }
        
        PlayerScript myPlayer = other.GetComponent<PlayerScript>();
            
        myPlayer.Add(tag);
            
        Destroy(gameObject);

    }
    
}