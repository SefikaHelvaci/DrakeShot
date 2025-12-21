using UnityEngine;

public class GainSkillScript : MonoBehaviour {
    
    private PlayerScript _myPlayerScript;
    
    private void Awake() {
        
        _myPlayerScript = GetComponent<PlayerScript>();
        
    }
    
    public bool TryAndApplySkillEffect(int cost, string skillType, float effectValue) {

        if (_myPlayerScript.PlayerXp >= cost) {
            _myPlayerScript.PlayerXp -= cost;
            
            ApplyEffect();
            
            return true;
        }

        return false;

        void ApplyEffect() {

            switch (skillType) {
                case "Speed":
                    _myPlayerScript.PlayerSpeed += effectValue;
                    
                    break;
            }
                    
        }
        
    }
    
}