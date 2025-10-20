using UnityEngine;

public class Collectible : MonoBehaviour {
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.CompareTag("Player")) {
            
            PlayerResources resources = other.GetComponent<PlayerResources>();
            
            if (CompareTag("Gold")) {
                resources.Add(0);
            }
            else if (CompareTag("XP")) {
                resources.Add(1);
            }
            
            Destroy(gameObject);
            
        }
        
    }
    
}