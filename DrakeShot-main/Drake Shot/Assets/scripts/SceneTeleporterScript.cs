using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTeleporterScript : MonoBehaviour {

    [SerializeField] private TextMeshPro addText;
    [SerializeField] private string sceneToGo;
    [SerializeField] private Vector3 positionToGo;

    private Collider2D _myOther;
    private bool _isPlayerInZone;

    private void Awake() {
        
        addText.gameObject.SetActive(false);
        
    }

    private void Update() {
        
        if (_isPlayerInZone && Input.GetKeyDown(MenuScript.Instance.InteractionKey)) {
            SceneManager.LoadScene(sceneToGo);
            
            _myOther.transform.position = positionToGo;
        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.CompareTag("Player")) {
            addText.text = MenuScript.Instance.InteractionKey.ToString();
            addText.gameObject.SetActive(true);
            
            _isPlayerInZone = true;

            _myOther = other;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        
        if (other.CompareTag("Player")) {
            addText.gameObject.SetActive(false);
            
            _isPlayerInZone = false;

            _myOther = null;
        }
        
    }
    
}