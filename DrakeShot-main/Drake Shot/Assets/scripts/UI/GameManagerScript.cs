using UnityEngine;

public class GameManagerScript : MonoBehaviour {

    public static GameManagerScript Instance;

    private void Awake() {

        DontDestroyOnLoad(gameObject);

        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }
        
    }
    
}