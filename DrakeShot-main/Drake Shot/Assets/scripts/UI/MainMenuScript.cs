using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {
    
    public void GoToMainMenu() {
        
        Time.timeScale = 1f;
        
        Destroy(transform.root.gameObject);
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        if (player != null) {
            Destroy(player);
        }
        
        SceneManager.LoadScene("Main Menu");
        
    }
    
}