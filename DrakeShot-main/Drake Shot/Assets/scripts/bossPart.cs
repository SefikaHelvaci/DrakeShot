using UnityEngine;

public class bossPart : MonoBehaviour
{
    public int maxHP = 100;
    public int HP;
    public Material wounded;
    
    private Renderer rend;
    private bossBrain brain;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HP = maxHP;
        rend = GetComponent<Renderer>();
        brain = GetComponentInParent<bossBrain>();
    }

    public void TakeDamage(int damageAmount)
    {

        HP -= damageAmount;

        if (HP <= 0)
        {
            HP = 0;
            if (brain.limbsAlive(this))
            {
                rend.material = wounded;
            }
        }
    }
}
