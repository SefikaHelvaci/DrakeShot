using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillButtonScript : MonoBehaviour {
    
    public TextMeshProUGUI addText;
    public int skillCost;
    public string skillType;
    public float effectValue;
    private PlayerScript _myPlayerScript;
    private Button _myButton;

    private void Start() {
        
        addText.text += "\nCost: " + skillCost + "\nValue: " + effectValue;
        
        _myPlayerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        _myButton = GetComponent<Button>();

    }
    
    public void UnlockSkill() {
        
        if (_myPlayerScript != null && _myPlayerScript.TryAndApplySkillEffect(skillCost, skillType, effectValue)) {
            _myButton.interactable = false;
        }
        
    }
    
}