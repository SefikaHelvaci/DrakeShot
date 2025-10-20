using UnityEngine;

public class PlayerScript : MonoBehaviour {
    
    //Make them private after test
    public int playerHealth = 10;
    public int playerDamage;
    public int playerArmor;
    public int playerGold;
    public int playerXP;
    
    public void Add(string type) {

        switch (type) {
            case "Gold":
                playerGold++;
                break;
            case "XP":
                playerXP++;
                break;
        }

    }
    
    public bool TryToBuyItem(int price, string itemType, int effectValue) {
        
        void ApplyEffect() {
            
            if (itemType == "Health") {
                playerHealth += effectValue;
            }
            else if (itemType == "Damage") {
                playerDamage = effectValue;
            }
            else if (itemType == "Armor") {
                playerArmor  += effectValue;
            }
            
        }
        
        if (playerGold >= price) {
            playerGold -= price;
            ApplyEffect();
            return true;
        }
        
        return false;
        
    }
    
}