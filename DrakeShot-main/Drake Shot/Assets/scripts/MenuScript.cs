using System;
using TMPro;
using UnityEngine;

public class MenuScript : MonoBehaviour {
    
    public GameObject escMenu;
    public GameObject skillsMenu;
    public GameObject settingsMenu;
    private GameObject _openedMenu;
    public TextMeshProUGUI skillsMenuKeyRebindButtonText;
    public TextMeshProUGUI interactionKeyRebindButtonText;
    private KeyCode _skillMenuKey = KeyCode.K;
    public static KeyCode InteractionKey = KeyCode.E;
    private string _rebindTarget = "none";

    private void Awake() {
        
        DontDestroyOnLoad(gameObject);
        
        escMenu.SetActive(false);
        skillsMenu.SetActive(false);
        settingsMenu.SetActive(false);
        
    }
    
    private void Start() {
        
        skillsMenuKeyRebindButtonText.text = "Skills Menu Key: " + _skillMenuKey;
        interactionKeyRebindButtonText.text = "Interaction Key: " + InteractionKey;

    }

    private void Update() {

        if (_rebindTarget.Equals("none")) {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                DoMenuOp(escMenu);
            }
            else if (Input.GetKeyDown(_skillMenuKey)) {
                DoMenuOp(skillsMenu);
            }
        }
        else {
            if (!Input.anyKeyDown) {
                return;
            }
            
            foreach (KeyCode a in Enum.GetValues(typeof(KeyCode))) {
                if (a == KeyCode.Mouse0 || a == KeyCode.Escape) {
                    continue;
                }

                if (!Input.GetKeyDown(a)) {
                    continue;
                }

                switch (_rebindTarget) {
                    case "skillsMenuKey":
                        _skillMenuKey = a;
                        skillsMenuKeyRebindButtonText.text = "Skills Menu Key: " + a;
                        
                        break;
                    
                    case "interactionKey":
                        InteractionKey = a;
                        interactionKeyRebindButtonText.text = "Interaction Key: " + a;
                        
                        break;
                }
                
                _rebindTarget = "none";
                
            }
        }
        
    }
    
    private void DoMenuOp(GameObject menu) {
            
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
    
    private void CloseMenu(GameObject menu) {
        
        menu.SetActive(false);
        _openedMenu = null;
        
        Time.timeScale = 1f;
        
    }
    
    private void OpenMenu(GameObject menu) {
            
        menu.SetActive(true);
        _openedMenu = menu;
            
        Time.timeScale = 0f;
            
    }
    
    private void OpenAnotherMenu(GameObject menu) {
            
        _openedMenu.SetActive(false);
        menu.SetActive(true);
        _openedMenu = menu;

    }
    
    //This func. is not private because resume button uses it.
    public void CloseEscMenuForResumeButton() {
        
        escMenu.SetActive(false);
        _openedMenu = null;
        
        Time.timeScale = 1f;
        
    }
    
    //This func. is not private because settings button uses it.
    public void OpenSettingsMenu() {
        
        DoMenuOp(settingsMenu);
        
    }
    
    //This func. is not private because back button uses it.
    public void CloseSettingsMenuForBackButton() {

        if (!_rebindTarget.Equals("none")) {
            return;
        }
        
        settingsMenu.SetActive(false);
        escMenu.SetActive(true);
        _openedMenu = escMenu;

    }
    
    //This func. is not private because skills menu key rebind button uses it.
    public void StartSkillsMenuKeyRebinding() {
        
        if (!_rebindTarget.Equals("none")) {
            return;
        }
        
        _rebindTarget = "skillsMenuKey";
        skillsMenuKeyRebindButtonText.text = "Waiting";
        
    }
    
    //This func. is not private because interaction key rebind button uses it.
    public void StartInteractionKeyRebinding() {
        
        if (!_rebindTarget.Equals("none")) {
            return;
        }
        
        _rebindTarget = "interactionKey";
        interactionKeyRebindButtonText.text = "Waiting";
        
    }
    
}