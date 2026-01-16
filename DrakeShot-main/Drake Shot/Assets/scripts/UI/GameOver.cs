using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    
    public static GameOver Instance;

    public TextMeshProUGUI gameOverText;
    public Button restartButton;

    private void Awake()
    {
        Debug.Log("GameOver Awake");
        if (Instance == null)
        {
            Instance = this;
        }else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        Debug.Log("GameOver Start");
        if (gameOverText != null) gameOverText.gameObject.SetActive(false);
        if (restartButton != null) restartButton.gameObject.SetActive(false);
    }

    public void itsGameOver()
    {
        if (gameOverText != null) gameOverText.gameObject.SetActive(true);
        if (restartButton != null) restartButton.gameObject.SetActive(true);
        
        
        Time.timeScale = 0f; 
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}