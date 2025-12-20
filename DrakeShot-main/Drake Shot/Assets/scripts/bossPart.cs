using UnityEngine;

//TODO
//zoom out in the start of the fight
//make it so that material shows up (wounded material
//make bullets connect with the beast
//give it a flying pattern

public class bossPart : MonoBehaviour
{
    public int maxHP = 100;
    public int HP;
    public Material wounded;
    
    private SpriteRenderer rend;
    private bossBrain brain;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HP = maxHP;
        rend = GetComponent<SpriteRenderer>();
        brain = GetComponentInParent<bossBrain>();
    }
    
    /*
    void OnCollisionEnter(Collision collision)
    {
        bossPart part = collision.collider.GetComponent<bossPart>();
        if (part != null)
        {
            part.TakeDamage(1);
            Destroy(gameObject);
        }
    }
    */

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
            
            brain.amIalive();
        }
    }
}
