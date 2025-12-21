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
    [SerializeField] private float dodgeSkillEffectValue;
    [SerializeField] private GainSkillScript myGainSkillScript;

    private void Start() {
        
        walkSpeedSkillAddText.text += "\nCost: " + walkSpeedSkillCost + "\nValue: " + walkSpeedSkillEffectValue;
        dodgeSkillAddText.text += "\nCost: " + dodgeSkillCost + "\nValue: " + dodgeSkillEffectValue;
        
        dodgeSkillButton.interactable = false;

    }
    
    public void UnlockWalkSpeedSkill() {
        
        if (myGainSkillScript != null && myGainSkillScript.TryAndApplySkillEffect(walkSpeedSkillCost, "Speed", walkSpeedSkillEffectValue)) {
            walkSpeedSkillButton.interactable = false;

            dodgeSkillButton.interactable = true;
        }
        
    }
    
}