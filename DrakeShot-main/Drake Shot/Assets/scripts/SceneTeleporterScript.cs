using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTeleporterScript : MonoBehaviour {

    public string sceneToGo;
    
    private void OnTriggerStay2D(Collider2D other) {

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E)) {
            SceneManager.LoadScene(sceneToGo);
        }
        
    }
    
}