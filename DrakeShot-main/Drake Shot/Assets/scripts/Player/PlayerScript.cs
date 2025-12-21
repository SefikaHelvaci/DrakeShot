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
    public int PlayerDamage {
        
        get => playerDamage;
        set => playerDamage = value;
        
    }
    public int PlayerArmorLevel => playerArmorLevel;
    public int PlayerGold {
        
        get => playerGold;
        set => playerGold = value;
        
    }
    public int PlayerXp {
        
        get => playerXp;
        set => playerXp = value;
        
    }
    public float PlayerSpeed {
        
        get => playerSpeed;
        set => playerSpeed = value;
        
    }
    public float PlayerBulletSpeed => playerBulletSpeed;
    public float PlayerFireRate => playerFireRate;

    private void Awake() {
        
        DontDestroyOnLoad(gameObject);
        
    }
    
}