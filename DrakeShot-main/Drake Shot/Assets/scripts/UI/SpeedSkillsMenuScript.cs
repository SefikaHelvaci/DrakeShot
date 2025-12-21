using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeedSkillsMenuScript : MonoBehaviour {
    
    [SerializeField] private Button walkSpeedSkillButton;
    [SerializeField] private TextMeshProUGUI walkSpeedSkillAddText;
    [SerializeField] private int walkSpeedSkillCost;
    [SerializeField] private float walkSpeedSkillEffectValue;
    [SerializeField] private Button dodgeSkillButton;
    [SerializeField] private TextMeshProUGUI dodgeSkillAddText;
    [SerializeField] private int dodgeSkillCost;
    [SerializeField] private float dodgeSkillEffectValue;
    [SerializeField] private PlayerScript myPlayerScript;

    private void Start() {
        
        walkSpeedSkillAddText.text += "\nCost: " + walkSpeedSkillCost + "\nValue: " + walkSpeedSkillEffectValue;
        dodgeSkillAddText.text += "\nCost: " + dodgeSkillCost + "\nValue: " + dodgeSkillEffectValue;
        
        dodgeSkillButton.interactable = false;

    }
    
    public void UnlockWalkSpeedSkill() {
        
        if (myPlayerScript != null && myPlayerScript.TryAndApplySkillEffect(walkSpeedSkillCost, "Speed", walkSpeedSkillEffectValue)) {
            walkSpeedSkillButton.interactable = false;

            dodgeSkillButton.interactable = true;
        }
        
    }
    
}