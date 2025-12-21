using UnityEngine;

public class CollectScript : MonoBehaviour {

    private PlayerScript _myPlayerScript;
    
    private void Awake() {
        
        _myPlayerScript = GetComponent<PlayerScript>();
        
    }
    
    public void Add(string type) {

        switch (type) {
            case "Gold":
                _myPlayerScript.PlayerGold++;
                
                break;
            
            case "XP":
                _myPlayerScript.PlayerXp++;
                
                break;
        }

    }
    
}