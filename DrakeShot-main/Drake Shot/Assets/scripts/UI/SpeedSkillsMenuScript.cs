using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeedSkillsMenuScript : MonoBehaviour {
    
    [SerializeField] private Button walkSpeedSkillButton;
    [SerializeField] private TextMeshProUGUI walkSpeedSkillAddText;
    [SerializeField] private int walkSpeedSkillCost;
    [SerializeField] private int walkSpeedSkillEffectValue;
    [SerializeField] private Button dodgeSkillButton;
    [SerializeField] private TextMeshProUGUI dodgeSkillAddText;
    [SerializeField] private int dodgeSkillCost;
    [SerializeField] private int dodgeSkillEffectValue;
    [SerializeField] private GainSkillScript myGainSkillScript;

    private void Awake() {
        
        walkSpeedSkillAddText.text += "\nCost: " + walkSpeedSkillCost + "\nValue: " + walkSpeedSkillEffectValue;
        dodgeSkillAddText.text += "\nCost: " + dodgeSkillCost + "\nValue: " + dodgeSkillEffectValue;
        
        walkSpeedSkillButton.interactable = true;
        dodgeSkillButton.interactable = false;

    }
    
    public void UnlockWalkSpeedSkill() {
        
        if (myGainSkillScript != null && myGainSkillScript.TryAndApplySkillEffect(walkSpeedSkillCost, "Speed", walkSpeedSkillEffectValue)) {
            walkSpeedSkillButton.interactable = false;

            dodgeSkillButton.interactable = true;
        }
        
    }
    
    public void UnlockDodgeSpeedSkill() {
        
        if (myGainSkillScript != null && myGainSkillScript.TryAndApplySkillEffect(dodgeSkillCost, "Dodge", dodgeSkillEffectValue)) {
            dodgeSkillButton.interactable = false;
        }
        
    }
    
}