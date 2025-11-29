using UnityEngine;
using UnityEngine.UI;

public class hpBar : MonoBehaviour
{
    public Slider slider;
    public getHit playerHP;

    void Start()
    {
        if (slider == null)
            slider = GetComponent<Slider>();
        
        if (playerHP == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
                playerHP = player.GetComponent<getHit>();
        }

        if (playerHP == null)
        {
            Debug.LogError("HealthBar: Could not find getHit script on Player.");
            return;
        }

        slider.minValue = 0;
        slider.maxValue = playerHP.maxHP;
        slider.value = playerHP.HP;
    }

    void Update()
    {
        if (playerHP != null)
            slider.value = playerHP.HP;   // update every frame
    }
}