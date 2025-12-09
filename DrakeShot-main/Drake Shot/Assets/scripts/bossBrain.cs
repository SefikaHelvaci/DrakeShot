using UnityEngine;

public class bossBrain : MonoBehaviour
{

    public bossPart[] limbs;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public bool limbsAlive(bossPart p)
    //checks if parts other than this are alive
    {
        foreach (bossPart l in limbs)
        {
            if (l != p && l.HP > 0)
            {
                return true;
            }
        }

        return false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
