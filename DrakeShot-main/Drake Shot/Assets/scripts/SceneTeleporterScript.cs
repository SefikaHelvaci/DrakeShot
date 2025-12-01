using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTeleporterScript : MonoBehaviour
{

    public GameObject textE;
    public string sceneToGo;
    
    private void Start() {
        
        textE.gameObject.SetActive(false);
        
    }
    
    private void OnTriggerStay2D(Collider2D other) {

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E)) {
            SceneManager.LoadScene(sceneToGo);
        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.CompareTag("Player")) {
            textE.SetActive(true);
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        
        if (other.CompareTag("Player")) {
            textE.SetActive(false);
        }
        
    }
    
}