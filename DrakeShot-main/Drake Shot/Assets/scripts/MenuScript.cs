using UnityEngine;

public class MenuScript : MonoBehaviour {
    
    public GameObject escMenu;
    public GameObject skillsMenu;
    private GameObject _openedMenu;
    
    private void Awake() {
        
        DontDestroyOnLoad(gameObject);
        
        escMenu.SetActive(false);
        skillsMenu.SetActive(false);
        
    }

    private void Update() {

        if (Input.GetKeyDown(KeyCode.Escape)) {
            DoMenuOp(escMenu);
        }
        else if (Input.GetKeyUp(KeyCode.K)) {
            DoMenuOp(skillsMenu);
        }

        void DoMenuOp(GameObject menu) {
            
            if (!_openedMenu) {
                OpenMenu(menu);
            }
            else if (_openedMenu == menu) {
                CloseMenu(menu);
            }
            else {
                OpenAnotherMenu(menu);
            }
            
        }
        
        void CloseMenu(GameObject menu) {
        
            menu.SetActive(false);
            _openedMenu = null;
        
            Time.timeScale = 1f;
        
        }
        
        void OpenMenu(GameObject menu) {
            
            menu.SetActive(true);
            _openedMenu = menu;
            
            Time.timeScale = 0f;
            
        }

        void OpenAnotherMenu(GameObject menu) {
            
            _openedMenu.SetActive(false);
            menu.SetActive(true);
            _openedMenu = menu;

        }
        
    }
    
    //This func. is not private or inside Update() because resume button uses it.
    public void CloseEscMenuForResumeButton() {
        
        escMenu.SetActive(false);
        _openedMenu = null;
        
        Time.timeScale = 1f;
        
    }
    
}