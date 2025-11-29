using UnityEngine;

public class EscMenuScript : MonoBehaviour {
    
    public GameObject escMenu;
    private bool _escMenuActive; 
    
    private void Awake() {
        
        DontDestroyOnLoad(gameObject);
        
        escMenu.SetActive(false);
        
    }

    private void Update() {
        
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (_escMenuActive) {
                CloseEscMenu();
            }
            else {
                OpenEscMenu();
            }
        }
        
        void OpenEscMenu() {
            
            escMenu.SetActive(true);
            _escMenuActive = true;
            
            Time.timeScale = 0f;
            
        }
        
    }
    
    //This func. is not private or inside Update() because resume button uses it.
    public void CloseEscMenu() {
        
        escMenu.SetActive(false);
        _escMenuActive = false;
        
        Time.timeScale = 1f;
        
    }
    
}