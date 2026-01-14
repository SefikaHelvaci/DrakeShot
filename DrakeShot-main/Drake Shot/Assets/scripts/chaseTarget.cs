using UnityEngine;
using System.Collections;

public class chaseTarget : MonoBehaviour
{
    // commented these out in case this one doesent work
    //or has bugs down the road
    //because these work fine other than pushing the player
    //into the walls
    
    
    //public GameObject movingObject;  
    //public GameObject targetPosition; 
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 1f;

    private Transform _target;
    private bool isFrozen = false;
    private Color ogColor;
    private SpriteRenderer rend;
    
    public bool IsCurrentlyFrozen => isFrozen;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {

        _target = PlayerScript.Instance.transform;
        
        if (rend == null) {
            rend = GetComponent<SpriteRenderer>();
        }

        // Store the monster's original color for unfrozen state
        if (rend != null) {
            ogColor = rend.color;
        }
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

        if (_target != null && !isFrozen)
        {
            Vector2 nextPos = Vector2.MoveTowards(rb.position, _target.position, speed * Time.deltaTime);
            rb.MovePosition(nextPos);
        }
        
    }

    public void freezeTheBeastAgain(float time)
    {
        StopAllCoroutines();
        StartCoroutine(freezeTheBeast(time));
    }

    private IEnumerator freezeTheBeast(float time)
    {
        isFrozen = true;
        rend.color = Color.cyan;
        yield return new WaitForSeconds(time);
        isFrozen = false;
        rend.color = ogColor;

    }
}
