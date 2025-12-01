using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTeleporterScript : MonoBehaviour {

    public TextMeshPro addText;
    public string sceneToGo;
    
    private void Start() {

        addText.text = MenuScript._interactionKey.ToString();
        addText.gameObject.gameObject.SetActive(false);
        
    }
    
    private void OnTriggerStay2D(Collider2D other) {

        if (other.CompareTag("Player") && Input.GetKeyDown(MenuScript._interactionKey)) {
            SceneManager.LoadScene(sceneToGo);
        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.CompareTag("Player")) {
            addText.gameObject.SetActive(true);
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        
        if (other.CompareTag("Player")) {
            addText.gameObject.SetActive(false);
        }
        
    }
    
}