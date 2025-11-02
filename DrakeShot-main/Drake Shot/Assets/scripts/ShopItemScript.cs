using UnityEngine;

public class ShopItemScript : MonoBehaviour {
    
    public int price;
    public int effectValue;
    public GameObject textE; 

    private void Start() {
        
        textE.SetActive(false);
        
    }
    
    private void OnTriggerStay2D(Collider2D other) {
        
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E)) {
            AttemptPurchase();
        }
        
        void AttemptPurchase() {

            PlayerScript myPlayerScript = other.GetComponent<PlayerScript>();
            
            if (myPlayerScript.TryAndBuyItem(price, tag, effectValue)) {
                Destroy(gameObject);
            }
            
        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.CompareTag("Player")) {
            textE.SetActive(true);
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        
        if (other.CompareTag("Player")) {
            textE.SetActive(false);
        }
        
    }
    
}