using UnityEngine;

public class chaseTarget : MonoBehaviour
{
    
    public GameObject movingObject;  
    public GameObject targetPosition; 
    public float speed = 1f; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (targetPosition != null)
        {
            movingObject.transform.position = Vector3.MoveTowards(
                movingObject.transform.position,
                targetPosition.transform.position,
                speed * Time.deltaTime
            );
        }
        
    }
}
