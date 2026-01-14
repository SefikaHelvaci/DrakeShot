using UnityEngine;

public class GainSkillScript : MonoBehaviour {
    
    private PlayerScript _myPlayerScript;
    
    private void Awake() {
        
        _myPlayerScript = GetComponent<PlayerScript>();
        
    }
    
    public bool TryAndApplySkillEffect(int cost, string skillType, float effectValue) {

        if (TrySpendXp(cost)) {
            
            switch (skillType) {
                case "Speed":
                    _myPlayerScript.PlayerSpeed += (int)effectValue;

                    break;

                case "Dodge":
                    _myPlayerScript.PlayerDodge += (int)effectValue;

                    break;
                
                case "Bullet Speed":
                    _myPlayerScript.PlayerBulletSpeed += (int)effectValue;

                    break;
                
                case "Fire Rate":
                    _myPlayerScript.PlayerFireRate -= effectValue;

                    break;
            }
            
            return true;
        }

        return false;
        
    }
    
    private bool TrySpendXp(int cost) {
        
        if (_myPlayerScript.PlayerXp >= cost) {
            _myPlayerScript.PlayerXp -= cost;
            
            return true; 
        }
        
        return false;
        
    }
    
}