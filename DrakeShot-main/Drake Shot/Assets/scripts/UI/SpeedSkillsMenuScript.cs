using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeedSkillsMenuScript : MonoBehaviour {
    
    private PlayerScript _myPlayerScript;
    
    [SerializeField] private Button walkSpeedSkillButton;
    [SerializeField] private TextMeshProUGUI walkSpeedSkillAddText;
    [SerializeField] private int walkSpeedSkillCost;
    [SerializeField] private float walkSpeedSkillEffectValue;
    
    [SerializeField] private Button dodgeSkillButton;
    [SerializeField] private TextMeshProUGUI dodgeSkillAddText;
    [SerializeField] private int dodgeSkillCost;
    [SerializeField] private float dodgeSkillEffectValue;

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