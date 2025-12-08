using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

    private GameObject _myPlayer;
    
    private void Start() {
        
        _myPlayer = GameObject.FindGameObjectWithTag("Player");
        
    }

    public void GoToMainMenu() {
        
        Time.timeScale = 1f;
        
        Destroy(transform.root.gameObject);
        
        if (_myPlayer != null) {
            Destroy(_myPlayer);
        }
        
        SceneManager.LoadScene("Main Menu");
        
    }
    
}