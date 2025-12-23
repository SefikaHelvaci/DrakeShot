using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IceSkillTree : MonoBehaviour
{
    [SerializeField] private Button tierOneButton;
    [SerializeField] private TextMeshProUGUI tierOneAddText;
    [SerializeField] private int tierOneCost;
    [SerializeField] private int tierOneEffectValue;
    
    [SerializeField] private Button tierTwo1Button;
    [SerializeField] private TextMeshProUGUI tierTwo1AddText;
    [SerializeField] private int tierTwo1Cost;
    [SerializeField] private int tierTwo1EffectValue;
    
    [SerializeField] private Button tierTwo2Button;
    [SerializeField] private TextMeshProUGUI tierTwo2AddText;
    [SerializeField] private int tierTwo2Cost;
    [SerializeField] private int tierTwo2EffectValue;
    
    [SerializeField] private Button tierThree1Button;
    [SerializeField] private TextMeshProUGUI tierThree1AddText;
    [SerializeField] private int tierThree1Cost;
    [SerializeField] private int tierThree1EffectValue;
    
    [SerializeField] private Button tierThree2Button;
    [SerializeField] private TextMeshProUGUI tierThree2AddText;
    [SerializeField] private int tierThree2Cost;
    [SerializeField] private int tierThree2EffectValue;
    
    [SerializeField] private Button iceBreathButton;
    [SerializeField] private TextMeshProUGUI iceBreathAddText;
    [SerializeField] private int iceBreathCost;
    [SerializeField] private int iceBreathEffectValue;
    
    [SerializeField] private GainSkillScript myGainSkillScript;
    
    private void Awake() {
        
        ArrangeButton(tierOneAddText, tierOneCost, tierOneEffectValue, tierOneButton, true);
        ArrangeButton(tierTwo1AddText, tierTwo1Cost, tierTwo1EffectValue, tierTwo1Button, false);
        ArrangeButton(tierTwo2AddText, tierTwo2Cost, tierTwo2EffectValue, tierTwo2Button, false);
        ArrangeButton(tierThree1AddText, tierThree1Cost, tierThree1EffectValue, tierThree1Button, false);
        ArrangeButton(tierThree2AddText, tierThree2Cost, tierThree2EffectValue, tierThree2Button, false);
        ArrangeButton(iceBreathAddText, iceBreathCost, iceBreathEffectValue, iceBreathButton, false);
        return;
        
        void ArrangeButton(TextMeshProUGUI addText, int cost, float  effectValue, Button button, bool isInteractable) {
            
            addText.text += "\nCost: " + cost + "\nValue: " + effectValue;
            
            button.interactable = isInteractable;
            
        }
    }
    
    public void unlockTierOne() {
        
        if (myGainSkillScript != null && myGainSkillScript.TryAndApplySkillEffect(tierOneCost, "TierOne", tierOneEffectValue)) {
            tierOneButton.interactable = false;

            tierTwo1Button.interactable = true;
            tierTwo2Button.interactable = true;
        }
        
    }
    
    public void unlockSkill(string skillName) {
        switch (skillName) {
            case "tierOne":
                if (myGainSkillScript.TryAndApplySkillEffect(tierOneCost, "TierOne", tierOneEffectValue)) {
                    CloseButton(tierOneButton);
                    tierTwo1Button.interactable = true;
                    tierTwo2Button.interactable = true;
                }
                break;

            case "tierTwo1":
                if (myGainSkillScript.TryAndApplySkillEffect(tierTwo1Cost, "TierTwo1", tierTwo1EffectValue)) {
                    CloseButton(tierTwo1Button);
                    tierThree1Button.interactable = true;
                }
                break;

            case "tierTwo2":
                if (myGainSkillScript.TryAndApplySkillEffect(tierTwo2Cost, "TierTwo2", tierTwo2EffectValue)) {
                    CloseButton(tierTwo2Button);
                    tierThree2Button.interactable = true;
                }
                break;

            case "tierThree1":
                if (myGainSkillScript.TryAndApplySkillEffect(tierThree1Cost, "TierThree1", tierThree1EffectValue)) {
                    CloseButton(tierThree1Button);
                    iceBreathButton.interactable = true;
                }
                break;

            case "tierThree2":
                if (myGainSkillScript.TryAndApplySkillEffect(tierThree2Cost, "TierThree2", tierThree2EffectValue)) {
                    CloseButton(tierThree2Button);
                    iceBreathButton.interactable = true;
                }
                break;

            case "iceBreath":
                if (myGainSkillScript.TryAndApplySkillEffect(iceBreathCost, "IceBreath", iceBreathEffectValue)) {
                    CloseButton(iceBreathButton);
                }
                break;
        }
    }

    private void CloseButton(Button button) {
        if (button != null) {
            button.interactable = false;
        }
    }
}

