using UnityEngine;

public class PlayerScript : MonoBehaviour {
    
    [SerializeField] private float playerHealth = 100;
    [SerializeField] private float playerMaxHp = 100;
    [SerializeField] private int playerDamage = 1;
    [SerializeField] private int playerArmor = 0;
    [SerializeField] private int playerGold = 0;
    [SerializeField] private int playerXp = 0;
    [SerializeField] private int playerSpeed = 5;
    [SerializeField] private float playerFireRate = 0.2f;
    [SerializeField] private int playerBulletSpeed = 7;
    [SerializeField] private int playerDodge = 0;
    [SerializeField] public int freeze4Heal = 10;
    [SerializeField] public int hpPerHeal = 5;

    public static PlayerScript Instance;
    
    private int frozenBeasts = 0;

    public void beastFrozen()
    {
        frozenBeasts++;
        if (frozenBeasts >= freeze4Heal)
        {
            healPlayer();
            frozenBeasts = 0;
        }
    }

    public void healPlayer()
    {
        playerHealth += hpPerHeal;
    }
    
    public float PlayerHealth {
        
        get => playerHealth;
        set => playerHealth = Mathf.Clamp(value, 0f, playerMaxHp);
        
    }
    public float PlayerMaxHp => playerMaxHp;
    public int PlayerDamage {
        
        get => playerDamage;
        set => playerDamage = value;
        
    }
    public int PlayerArmor {
        
        get => playerArmor;
        set => playerArmor = value;
        
    }
    public int PlayerGold {
        
        get => playerGold;
        set => playerGold = value;
        
    }
    public int PlayerXp {
        
        get => playerXp;
        set => playerXp = value;
        
    }
    public int PlayerSpeed {
        
        get => playerSpeed;
        set => playerSpeed = value;
        
    }
    public float PlayerFireRate {
        
        get => playerFireRate;
        set => playerFireRate = value;

    }
    public int PlayerBulletSpeed {
        
        get => playerBulletSpeed;
        set => playerBulletSpeed = value;
        
    }
    public int PlayerDodge {
        
        get => playerDodge;
        set => playerDodge = Mathf.Clamp(value, 0, 100);
        
    }

    private void Awake() {

        DontDestroyOnLoad(gameObject);

        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }
        
    }
    
}