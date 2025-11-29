using System;
using UnityEngine;

public class getHit : MonoBehaviour
{

    public int maxHP = 10;

    public int HP;

    public int monsterDMG = 1; 
    
    //its possible that we could just leave the dmg as it is 
    //but increase the projectiles instead
    //so that everything can be contained here 
    //this is just for collision with a monster anyways
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        HP -= dmg;
        Debug.Log($"You crashed into a monster! -1 HP. Curr HP: {HP}");

        if (HP <= 0)
        {
            HP = 0;
        }
        if (HP == 0)
        {
            Debug.Log($"YOU DIED");
            Destroy(gameObject);
        }
    }
}
