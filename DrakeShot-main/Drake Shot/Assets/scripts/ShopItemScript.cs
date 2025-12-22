using UnityEngine;
using TMPro;

public class ShopItemScript : MonoBehaviour {
    
    [SerializeField] private TextMeshPro addText;
    [SerializeField] private int price;
    [SerializeField] private int effectValue;
    [SerializeField] private bool isRepurchasable;

    private BuyScript _myBuyScript;
    private bool _isPlayerInZone;

    private void Awake() {
        
        addText.text = addText.text + "Cost: " + price + "\nValue: " + effectValue;
        addText.gameObject.SetActive(false);
        
    }
    
    private void Update() {
        
        if (_isPlayerInZone && Input.GetKeyDown(MenuScript.Instance.InteractionKey)) {
            AttemptPurchase();
        }
        
        return;

        void AttemptPurchase() {
            
            if (_myBuyScript.TryAndBuyItem(price, tag, effectValue) && !isRepurchasable) {
                Destroy(gameObject);
            }
            
        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.CompareTag("Player")) {
            addText.gameObject.SetActive(true);
            
            _isPlayerInZone = true;
            
            _myBuyScript = other.GetComponent<BuyScript>();
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        
        if (other.CompareTag("Player")) {
            addText.gameObject.SetActive(false);
            
            _isPlayerInZone = false;

            _myBuyScript = null;
        }
        
    }
    
}