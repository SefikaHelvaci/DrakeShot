using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class PlayButtonScript : MonoBehaviour {
    
        public void PlayGame() {
        
            SceneManager.LoadScene("Level1"); 
        
        }
    
    }
}