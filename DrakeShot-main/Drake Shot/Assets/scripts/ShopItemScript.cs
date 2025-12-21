using UnityEngine;
using TMPro;

public class ShopItemScript : MonoBehaviour {
    
    [SerializeField] private TextMeshPro addText;
    [SerializeField] private int price;
    [SerializeField] private int effectValue;

    private void Awake() {
        
        addText.text = addText.text + "Cost: " + price + "\nValue: " + effectValue;
        addText.gameObject.SetActive(false);
        
    }
    
    private void OnTriggerStay2D(Collider2D other) {
        
        if (other.CompareTag("Player") && Input.GetKeyDown(MenuScript.Instance.InteractionKey)) {
            AttemptPurchase();
        }

        return;

        void AttemptPurchase() {
            
            if (other.GetComponent<PlayerScript>().TryAndBuyItem(price, tag, effectValue)) {
                Destroy(gameObject);
            }
            
        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.CompareTag("Player")) {
            addText.gameObject.SetActive(true);
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        
        if (other.CompareTag("Player")) {
            addText.gameObject.SetActive(false);
        }
        
    }
    
}