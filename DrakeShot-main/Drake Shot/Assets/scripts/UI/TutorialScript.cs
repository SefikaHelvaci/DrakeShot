using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour {
    
    public void PlayTutorial() {
        
        SceneManager.LoadScene("Arena");
        
    }
    
}