using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillButtonScript : MonoBehaviour {
    
    public TextMeshProUGUI addText;
    public int skillCost;
    public string skillType;
    public float effectValue;
    private PlayerScript _myPlayer;
    private Button _myButton;

    private void Start() {
        
        addText.text = addText.text + "\nCost: " + skillCost + "\nValue: " + effectValue;
        
        _myPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        _myButton = GetComponent<Button>();

    }
    
    public void UnlockSkill() {
        
        if (_myPlayer == null) {
            return;
        }
        
        if (_myPlayer.TryAndApplySkillEffect(skillCost, skillType, effectValue)) {
            _myButton.interactable = false;
        }
        
    }
    
}