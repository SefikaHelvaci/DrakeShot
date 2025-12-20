using UnityEngine;
using TMPro;

public class ShopItemScript : MonoBehaviour {
    
    public int price;
    public int effectValue;
    public TextMeshPro addText;
    private MenuScript _myMenuScript;

    private void Start() {
        
        _myMenuScript = GameObject.FindWithTag("Canvas").GetComponent<MenuScript>();
        
        addText.text = addText.text + "Cost: " + price + "\nValue: " + effectValue;
        addText.gameObject.SetActive(false);
        
    }
    
    private void OnTriggerStay2D(Collider2D other) {
        
        if (other.CompareTag("Player") && Input.GetKeyDown(_myMenuScript.InteractionKey)) {
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