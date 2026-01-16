using UnityEngine;
using UnityEngine.UI;

public class hpBar : MonoBehaviour
{
    [SerializeField] private PlayerScript myPlayerScript;
    
    private Slider _slider;
    

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        myPlayerScript = player.GetComponent<PlayerScript>();
        if (myPlayerScript == null)
        {
            _slider.value = 0;
        }
        if (_slider == null)
            _slider = GetComponent<Slider>();

        _slider.minValue = 0;
        _slider.maxValue = myPlayerScript.PlayerMaxHp;
        _slider.value = myPlayerScript.PlayerHealth;
    }

    void Update()
    {
        if (myPlayerScript == null || myPlayerScript.PlayerHealth == null)
        {
            _slider.value = 0;
            return;
        }
        _slider.value = myPlayerScript.PlayerHealth;   // update every frame
    }
}