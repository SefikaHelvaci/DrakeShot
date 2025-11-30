using System;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    
    //Make them private after test
    public int playerHealth = 10;
    public int playerDamage;
    public int playerArmor;
    public int playerGold;
    public int playerXp;
    public float playerSpeed = 3.0f;
    private bool _speedSkillUnlocked;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    void Update() {

        if (!_speedSkillUnlocked && Input.GetKeyDown(KeyCode.F1)) {
            TryAndUnlockSkill(1, "Speed", 1.5f);
        }
        
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

    public bool TryAndUnlockSkill(int cost, string skillType, float effectValue) {

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
                    _speedSkillUnlocked = true;
                    break;
            }
                    
        }
        
    }
    
}