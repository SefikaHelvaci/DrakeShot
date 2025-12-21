using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
    
    public static MenuScript Instance { get; private set; }
    
    [SerializeField] private GameObject escMenu;
    [SerializeField] private GameObject skillsMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject characterMenu;
    [SerializeField] private TextMeshProUGUI skillsMenuKeyRebindButtonText;
    [SerializeField] private TextMeshProUGUI interactionKeyRebindButtonText;
    [SerializeField] private TextMeshProUGUI characterMenuKeyRebindButtonText;
    [SerializeField] private TextMeshProUGUI characterMenuLeftText;
    [SerializeField] private TextMeshProUGUI characterMenuRightText;
    [SerializeField] private PlayerScript myPlayerScript;
    
    private GameObject _openedMenu;
    private KeyCode _skillMenuKey = KeyCode.K;
    private KeyCode _characterMenuKey = KeyCode.C;
    private KeyCode _interactionKey = KeyCode.E;
    private string _rebindButton = "none";
    
    public KeyCode InteractionKey => _interactionKey;

    private void Awake() {
        
        DontDestroyOnLoad(gameObject);
        
        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }
        
        _skillMenuKey = (KeyCode)PlayerPrefs.GetInt("SkillMenuKey", (int)_skillMenuKey);
        _characterMenuKey = (KeyCode)PlayerPrefs.GetInt("CharacterMenuKey", (int)_characterMenuKey);
        _interactionKey = (KeyCode)PlayerPrefs.GetInt("InteractionKey", (int)_interactionKey);
        
        skillsMenuKeyRebindButtonText.text = "Skills Menu Key: " + _skillMenuKey;
        interactionKeyRebindButtonText.text = "Interaction Key: " + _interactionKey;
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
                            PlayerPrefs.SetInt("SkillMenuKey", (int)a);
                            skillsMenuKeyRebindButtonText.text = "Skills Menu Key: " + a;
                        
                            break;
                    
                        case "Interaction Key Rebind Button":
                            _interactionKey = a;
                            PlayerPrefs.SetInt("InteractionKey", (int)a);
                            interactionKeyRebindButtonText.text = "Interaction Key: " + a;
                        
                            break;
                    
                        case "Character Info Menu Key Rebind Button":
                            _characterMenuKey = a;
                            PlayerPrefs.SetInt("CharacterMenuKey", (int)a);
                            characterMenuKeyRebindButtonText.text = "Character Menu Key: " + a;
                        
                            break;
                    }
                
                    _rebindButton = "none";
                
                    PlayerPrefs.Save();
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
        
        characterMenuLeftText.text = "Health: " + myPlayerScript.PlayerHealth + " / " + myPlayerScript.PlayerMaxHp + "\n";
        characterMenuLeftText.text += "Armor: " + myPlayerScript.PlayerArmor + "\n";
        characterMenuLeftText.text += "Gold: " + myPlayerScript.PlayerGold + "\n";
        characterMenuLeftText.text += "XP: " + myPlayerScript.PlayerXp;
        
        characterMenuRightText.text = "Fire Rate: " + myPlayerScript.PlayerFireRate + "\n";
        characterMenuRightText.text += "Attack: " + myPlayerScript.PlayerDamage + "\n";
        characterMenuRightText.text += "Speed: " + myPlayerScript.PlayerSpeed;

    }
    
    //This func. is not private because some buttons uses it.
    public void MenuToDo(GameObject menu) {
        
        DoMenuOp(menu);
        
    }
    
    //This func. is not private main menu button uses it.
    public void GoToMainMenu() {
        
        Time.timeScale = 1f;
        
        Destroy(transform.root.gameObject);
        
        if (myPlayerScript != null) {
            Destroy(myPlayerScript.gameObject);
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