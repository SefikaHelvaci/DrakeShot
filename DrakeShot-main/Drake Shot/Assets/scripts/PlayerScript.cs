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
    
    public bool TryAndBuyItem(int price, string itemType, int effectValue) {
        
        if (playerGold >= price) {
            playerGold -= price;
            ApplyEffect();
            return true;
        }
        
        return false;
        
        void ApplyEffect() {

            switch (itemType) {
                case "Health":
                    playerHealth += effectValue;
                    break;
                case "Damage":
                    playerDamage = effectValue;
                    break;
                case "Armor":
                    playerArmor  += effectValue;
                    break;
            }
                    
        }
        
    }
    
}