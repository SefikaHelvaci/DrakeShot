using UnityEngine;

public class PlayerResources : MonoBehaviour {
    
    //Make them private after test
    public int playerGold = 0;
    public int playerXP = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }
    
    public void Add(int type) {

        switch (type) {
            
            case 0:
                playerGold++;
                break;
            case 1:
                playerXP++;
                break;
            
        }

    }
    
}