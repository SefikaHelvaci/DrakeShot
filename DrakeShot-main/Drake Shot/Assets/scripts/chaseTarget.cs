using UnityEngine;

public class chaseTarget : MonoBehaviour
{
    // commented these out in case this one doesent work
    //or has bugs down the road
    //because these work fine other than pushing the player
    //into the walls
    
    
    //public GameObject movingObject;  
    //public GameObject targetPosition; 
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 1f; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //if (targetPosition != null)
        //{
            //movingObject.transform.position = Vector3.MoveTowards(
                //movingObject.transform.position,
                //targetPosition.transform.position,
                //speed * Time.deltaTime
            //);
        //}

        if (target != null)
        {
            Vector2 nextPos = Vector2.MoveTowards(rb.position, target.position, speed * Time.deltaTime);
            rb.MovePosition(nextPos);
        }
        
    }
}
