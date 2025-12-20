using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTeleporterScript : MonoBehaviour {

    public TextMeshPro addText;
    public string sceneToGo;
    public Vector3 positionToGo;
    private MenuScript _myMenuScript;
    
    private void Start() {

        _myMenuScript = GameObject.FindWithTag("Canvas").GetComponent<MenuScript>();
        
        addText.text = _myMenuScript.InteractionKey.ToString();
        addText.gameObject.gameObject.SetActive(false);
        
    }
    
    private void OnTriggerStay2D(Collider2D other) {
        
        if (other.CompareTag("Player") && Input.GetKeyDown(_myMenuScript.InteractionKey)) {
            SceneManager.LoadScene(sceneToGo);
            
            other.transform.position = positionToGo;
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