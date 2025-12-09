using UnityEngine;



public class bossBrain : MonoBehaviour
{

    public bool allDead = false;
    public bossPart[] limbs;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public bool limbsAlive(bossPart p)
    //checks if parts other than this are alive
    {
        foreach (bossPart limb in limbs)
        {
            if (limb != p && limb.HP > 0)
            {
                return true;
            }
        }

        return false;
    }

    public void amIalive()
    {
        foreach (bossPart limb in limbs)
        {
            if (limb.HP > 1)
            {
                return;
            }
        }
        
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
