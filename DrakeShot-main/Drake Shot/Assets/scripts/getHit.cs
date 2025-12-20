using System;
using UnityEngine;

public class getHit : MonoBehaviour
{

    public int monsterDMG = 1;

    private PlayerScript _myPlayerScript;
    
    //its possible that we could just leave the dmg as it is 
    //but increase the projectiles instead
    //so that everything can be contained here 
    //this is just for collision with a monster anyways

    private void Awake() {
        
        _myPlayerScript = GetComponent<PlayerScript>();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"{gameObject.name} (tag: {gameObject.tag}) collided with {collision.gameObject.name} (tag: {collision.gameObject.tag})");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hurt(monsterDMG);
        }
    }

    private void hurt(int dmg)
    {
        _myPlayerScript.playerHealth -= dmg;
        Debug.Log($"You crashed into a monster! -1 HP. Curr HP: {_myPlayerScript.playerHealth}");

        if (_myPlayerScript.playerHealth <= 0)
        {
            _myPlayerScript.playerHealth = 0;
        }
        if (_myPlayerScript.playerHealth == 0)
        {
            Debug.Log($"YOU DIED");
            Destroy(gameObject);
        }
    }
}
