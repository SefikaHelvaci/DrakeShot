using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SkillButtonScript : MonoBehaviour {
    
        public PlayerScript myPlayer;
        public TextMeshProUGUI addText;
        public int skillCost;
        public string skillType;
        public float effectValue;

        private void Start() {
        
            addText.text = addText.text + "\nCost: " + skillCost + "\nValue: " + effectValue;
        
        }
    
        public void UnlockSkill() {
        
            if (myPlayer.TryAndApplySkillEffect(skillCost, skillType, effectValue)) {
                GetComponent<Button>().interactable = false;
            }
        
        }
    
    }
}