using UnityEngine;

public class ShopItemScript : MonoBehaviour {
    
    public int price;
    public string itemType;
    public int effectValue;
    
    private void OnTriggerStay2D(Collider2D other) {
        
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E)) {
            AttemptPurchase();
        }
        
        void AttemptPurchase() {

            PlayerScript myPlayerScript = other.GetComponent<PlayerScript>();
            
            if (myPlayerScript.TryAndBuyItem(price, itemType, effectValue)) {
                Destroy(gameObject);
            }
            
        }
        
    }
    
}