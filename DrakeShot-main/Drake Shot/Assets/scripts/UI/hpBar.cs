using UnityEngine;
using UnityEngine.UI;

public class hpBar : MonoBehaviour
{
    [SerializeField] private PlayerScript myPlayerScript;
    
    private Slider _slider;

    void Start()
    {
        if (_slider == null)
            _slider = GetComponent<Slider>();

        _slider.minValue = 0;
        _slider.maxValue = myPlayerScript.PlayerMaxHp;
        _slider.value = myPlayerScript.PlayerHealth;
    }

    void Update()
    {
        _slider.value = myPlayerScript.PlayerHealth;   // update every frame
    }
}