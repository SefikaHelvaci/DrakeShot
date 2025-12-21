using UnityEngine;

public class PlayerScript : MonoBehaviour {
    
    [SerializeField] private int playerHealth = 100;
    [SerializeField] private int playerMaxHp = 100;
    [SerializeField] private int playerDamage = 1;
    [SerializeField] private int playerArmorLevel = 0;
    [SerializeField] private int playerGold = 0;
    [SerializeField] private int playerXp = 0;
    [SerializeField] private float playerSpeed = 5.0f;
    [SerializeField] private float playerFireRate = 0.2f;
    [SerializeField] private float playerBulletSpeed = 7.0f;

    public int PlayerHealth {
        
        get => playerHealth;
        set => playerHealth = Mathf.Clamp(value, 0, playerMaxHp);
        
    }
    public int PlayerMaxHp => playerMaxHp;
    public int PlayerDamage => playerDamage;
    public int PlayerArmorLevel => playerArmorLevel;
    public int PlayerGold => playerGold;
    public int PlayerXp => playerXp;
    public float PlayerSpeed => playerSpeed;
    public float PlayerBulletSpeed => playerBulletSpeed;
    public float PlayerFireRate => playerFireRate;

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