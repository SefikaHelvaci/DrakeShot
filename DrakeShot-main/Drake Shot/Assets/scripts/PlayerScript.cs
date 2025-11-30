using UnityEngine;

public class PlayerScript : MonoBehaviour {
    
    //Make them private after test
    public int playerHealth = 10;
    public int playerDamage;
    public int playerArmor;
    public int playerGold;
    public int playerXp;
    public float playerSpeed = 3.0f;

    private void Awake() {
        
        DontDestroyOnLoad(gameObject);
        
    }
    
    public void Add(string type) {

        switch (type) {
            case "Gold":
                playerGold++;
                break;
            case "XP":
                playerXp++;
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
                case "Weapon":
                    playerDamage = effectValue;
                    break;
                case "Armor":
                    playerArmor  += effectValue;
                    break;
            }
                    
        }
        
    }

    public bool TryAndApplySkillEffect(int cost, string skillType, float effectValue) {

        if (playerXp >= cost) {
            playerXp -= cost;
            ApplyEffect();
            return true;
        }
        
        return false;
        
        void ApplyEffect() {

            switch (skillType) {
                case "Speed":
                    playerSpeed += effectValue;
                    break;
            }
                    
        }
        
    }
    
}