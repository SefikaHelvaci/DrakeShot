using UnityEngine;

namespace UI
{
    public class QuitButtonScript : MonoBehaviour {
    
        //Should work in .exe game.
        public void QuitGame() {
        
            Application.Quit();
        
        }
    
    }
}