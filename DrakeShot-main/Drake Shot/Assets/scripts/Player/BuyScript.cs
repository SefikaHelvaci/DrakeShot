using UnityEngine;

public class BuyScript : MonoBehaviour {
    
    private PlayerScript _myPlayerScript;
    
    private void Awake() {
        
        _myPlayerScript = GetComponent<PlayerScript>();
        
    }
    
    public bool TryAndBuyItem(int price, string itemType, float effectValue) {

        if (_myPlayerScript.PlayerGold >= price) {
            _myPlayerScript.PlayerGold -= price;
            
            ApplyEffect();
            
            return true;
        }

        return false;

        void ApplyEffect() {

            switch (itemType) {
                case "Health":
                    _myPlayerScript.PlayerHealth += effectValue;
                    
                    break;
                
                case "Weapon":
                    _myPlayerScript.PlayerDamage = Mathf.RoundToInt(effectValue);
                    
                    break;
                
                case "Armor":
                    _myPlayerScript.PlayerArmor = Mathf.RoundToInt(effectValue);
                    
                    break;
                
                case "Poison":
                    _myPlayerScript.PlayerPoisonDamage = effectValue;
                    
                    break;
            }
                    
        }
        
    }
    
}