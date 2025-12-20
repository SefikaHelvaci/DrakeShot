using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
    
    public GameObject escMenu;
    public GameObject skillsMenu;
    public GameObject settingsMenu;
    public GameObject characterMenu;
    private GameObject _openedMenu;
    public TextMeshProUGUI skillsMenuKeyRebindButtonText;
    public TextMeshProUGUI interactionKeyRebindButtonText;
    public TextMeshProUGUI characterMenuKeyRebindButtonText;
    public TextMeshProUGUI characterMenuLeftText;
    public TextMeshProUGUI characterMenuRightText;
    private KeyCode _skillMenuKey = KeyCode.K;
    private KeyCode _characterMenuKey = KeyCode.C;
    public static KeyCode InteractionKey = KeyCode.E;
    private string _rebindButton = "none";
    private GameObject _myPlayer;

    private void Awake() {
        
        DontDestroyOnLoad(gameObject);
        
    }
    
    private void Start() {
        
        _myPlayer = GameObject.FindGameObjectWithTag("Player");
        
        skillsMenuKeyRebindButtonText.text = "Skills Menu Key: " + _skillMenuKey;
        interactionKeyRebindButtonText.text = "Interaction Key: " + InteractionKey;
        characterMenuKeyRebindButtonText.text = "Character Menu Key: " + _characterMenuKey;

    }

    private void Update() {

        if (_rebindButton.Equals("none")) {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                DoMenuOp(escMenu);
            }
            else if (Input.GetKeyDown(_skillMenuKey)) {
                DoMenuOp(skillsMenu);
            }
            else if (Input.GetKeyDown(_characterMenuKey)) {
                UpdateCharacterMenuTexts();
                DoMenuOp(characterMenu);
            }
        }
        else {
            if (Input.anyKeyDown) {
                foreach (KeyCode a in Enum.GetValues(typeof(KeyCode))) {
                    if (a == KeyCode.Mouse0 || a == KeyCode.Escape || !Input.GetKeyDown(a)) {
                        continue;
                    }

                    switch (_rebindButton) {
                        case "Skills Menu Key Rebind Button":
                            _skillMenuKey = a;
                            skillsMenuKeyRebindButtonText.text = "Skills Menu Key: " + a;
                        
                            break;
                    
                        case "Interaction Key Rebind Button":
                            InteractionKey = a;
                            interactionKeyRebindButtonText.text = "Interaction Key: " + a;
                        
                            break;
                    
                        case "Character Info Menu Key Rebind Button":
                            _characterMenuKey = a;
                            characterMenuKeyRebindButtonText.text = "Character Menu Key: " + a;
                        
                            break;
                    }
                
                    _rebindButton = "none";
                
                }
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
    
    private void UpdateCharacterMenuTexts() {
        
        PlayerScript myPlayerScript = _myPlayer.GetComponent<PlayerScript>();
        
        characterMenuLeftText.text = "Health: " + myPlayerScript.playerHealth + " / " + "100" + "\n";
        characterMenuLeftText.text += "Armor: " + myPlayerScript.playerArmor + "\n";
        characterMenuLeftText.text += "Gold: " + myPlayerScript.playerGold + "\n";
        characterMenuLeftText.text += "XP: " + myPlayerScript.playerXp;
        characterMenuRightText.text = "Attack: " + myPlayerScript.playerDamage + "\n";
        characterMenuRightText.text += "Speed: " + myPlayerScript.playerSpeed;

    }
    
    //This func. is not private because some buttons uses it.
    public void MenuToDo(GameObject menu) {
        
        DoMenuOp(menu);
        
    }
    
    //This func. is not private main menu button uses it.
    public void GoToMainMenu() {
        
        Time.timeScale = 1f;
        
        Destroy(transform.root.gameObject);
        
        if (_myPlayer != null) {
            Destroy(_myPlayer);
        }
        
        SceneManager.LoadScene("Main Menu");
        
    }
    
    //This func. is not private because back button uses it.
    public void CloseSettingsMenuForBackButton() {

        if (!_rebindButton.Equals("none")) {
            return;
        }
        
        settingsMenu.SetActive(false);
        escMenu.SetActive(true);
        _openedMenu = escMenu;

    }
    
    //This func. is not private because menu key rebind buttons uses it.
    public void KeyRebinding(TextMeshProUGUI rebindButtonText) {
        
        if (!_rebindButton.Equals("none")) {
            return;
        }
        
        rebindButtonText.text = "Waiting";
        _rebindButton = rebindButtonText.transform.parent.name;
        
    }
    
}