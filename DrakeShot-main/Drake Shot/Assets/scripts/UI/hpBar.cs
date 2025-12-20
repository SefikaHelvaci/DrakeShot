using UnityEngine;
using UnityEngine.UI;

public class hpBar : MonoBehaviour
{
    private Slider _slider;
    private PlayerScript _myPlayerScript;

    void Start()
    {
        if (_slider == null)
            _slider = GetComponent<Slider>();
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) {

            _myPlayerScript = player.GetComponent<PlayerScript>();
            
        }

        _slider.minValue = 0;
        _slider.maxValue = _myPlayerScript.playerMaxHp;
        _slider.value = _myPlayerScript.playerHealth;
    }

    void Update()
    {
        _slider.value = _myPlayerScript.playerHealth;   // update every frame
    }
}