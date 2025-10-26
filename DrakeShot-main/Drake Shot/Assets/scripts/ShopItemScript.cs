using UnityEngine;

public class ShopItemScript : MonoBehaviour {
    
    public int price;
    public string itemType;
    public int effectValue;
    private bool _isPlayerInRange = false;
    public KeyCode purchaseKey = KeyCode.E;
    
    void Update() {
            
        if (_isPlayerInRange && Input.GetKeyDown(purchaseKey)) {
            AttemptPurchase();
        }
        
        void AttemptPurchase() {
            
            PlayerScript myPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
                
            bool success = myPlayer.TryToBuyItem(price, itemType, effectValue);
                
            if (success) {
                Destroy(gameObject);
            }
            
        }
            
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.CompareTag("Player")) {
            _isPlayerInRange = true;
        }
        
    }
    
    private void OnTriggerExit2D(Collider2D other) {
        
        if (other.CompareTag("Player")) {
            _isPlayerInRange = false;
        }
        
    }
    
}