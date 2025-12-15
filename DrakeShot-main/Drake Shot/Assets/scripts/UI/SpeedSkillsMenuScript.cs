using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeedSkillsMenuScript : MonoBehaviour {
    
    private PlayerScript _myPlayerScript;
    
    public Button walkSpeedSkillButton;
    public TextMeshProUGUI walkSpeedSkillAddText;
    public int walkSpeedSkillCost;
    public float walkSpeedSkillEffectValue;
    
    public Button dodgeSkillButton;
    public TextMeshProUGUI dodgeSkillAddText;
    public int dodgeSkillCost;
    public float dodgeSkillEffectValue;

    private void Start() {
        
        _myPlayerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        
        walkSpeedSkillAddText.text += "\nCost: " + walkSpeedSkillCost + "\nValue: " + walkSpeedSkillEffectValue;
        dodgeSkillAddText.text += "\nCost: " + dodgeSkillCost + "\nValue: " + dodgeSkillEffectValue;
        
        dodgeSkillButton.interactable = false;

    }
    
    public void UnlockWalkSpeedSkill() {
        
        if (_myPlayerScript != null && _myPlayerScript.TryAndApplySkillEffect(walkSpeedSkillCost, "Speed", walkSpeedSkillEffectValue)) {
            walkSpeedSkillButton.interactable = false;

            dodgeSkillButton.interactable = true;
        }
        
    }
    
}