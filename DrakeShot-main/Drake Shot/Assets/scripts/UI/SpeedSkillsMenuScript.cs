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
    [SerializeField] private Button fireRateSkillButton;
    [SerializeField] private TextMeshProUGUI fireRateSkillAddText;
    [SerializeField] private int fireRateSkillCost;
    [SerializeField] private float fireRateSkillEffectValue;
    [SerializeField] private Button bulletSpeedSkillButton;
    [SerializeField] private TextMeshProUGUI bulletSpeedSkillAddText;
    [SerializeField] private int bulletSpeedSkillCost;
    [SerializeField] private int bulletSpeedSkillEffectValue;
    [SerializeField] private GainSkillScript myGainSkillScript;

    private void Awake() {
        
        ArrangeButton(walkSpeedSkillAddText, walkSpeedSkillCost, walkSpeedSkillEffectValue, walkSpeedSkillButton, true);
        ArrangeButton(dodgeSkillAddText, dodgeSkillCost, dodgeSkillEffectValue, dodgeSkillButton, false);
        ArrangeButton(fireRateSkillAddText, fireRateSkillCost, fireRateSkillEffectValue, fireRateSkillButton, false);
        ArrangeButton(bulletSpeedSkillAddText, bulletSpeedSkillCost, bulletSpeedSkillEffectValue, bulletSpeedSkillButton, false);

        return;

        void ArrangeButton(TextMeshProUGUI addText, int cost, float  effectValue, Button button, bool isInteractable) {
            
            addText.text += "\nCost: " + cost + "\nValue: " + effectValue;
            
            button.interactable = isInteractable;
            
        }
        
    }
    
    public void UnlockWalkSpeedSkill() {
        
        if (myGainSkillScript != null && myGainSkillScript.TryAndApplySkillEffect(walkSpeedSkillCost, "Speed", walkSpeedSkillEffectValue)) {
            walkSpeedSkillButton.interactable = false;

            dodgeSkillButton.interactable = true;
            fireRateSkillButton.interactable = true;
            bulletSpeedSkillButton.interactable = true;
        }
        
    }

    public void UnlockSkill(string skillType) {
        
        if (myGainSkillScript != null) {
            switch (skillType) {
                case "Dodge":
                    if (myGainSkillScript.TryAndApplySkillEffect(dodgeSkillCost, skillType, dodgeSkillEffectValue)) {
                        CloseButton(dodgeSkillButton);
                    }
                
                    break;

                case "Fire Rate":
                    if (myGainSkillScript.TryAndApplySkillEffect(fireRateSkillCost, "Fire Rate", fireRateSkillEffectValue)) {
                        CloseButton(fireRateSkillButton);
                    }
                    
                    break;

                case "Bullet Speed":
                    if (myGainSkillScript.TryAndApplySkillEffect(bulletSpeedSkillCost, "Bullet Speed", bulletSpeedSkillEffectValue)) {
                        CloseButton(bulletSpeedSkillButton);
                    }
                    
                    break;
            }
        }

        return;
        
        void CloseButton(Button button) {
            
            button.interactable = false;
            
        }
        
    }
    
}