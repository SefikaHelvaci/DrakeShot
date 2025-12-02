using UnityEngine;

public class bullet : MonoBehaviour
{
    public float moveSpeed = 7f;
    public int damage = 1;

    private Rigidbody2D rb;
    private Transform player;
    private Vector2 moveDirection;
    public float destructionTime = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        GameObject p = GameObject.FindGameObjectWithTag("Player");

        if (p != null)
        {
            player = p.transform;

            moveDirection = (player.position - transform.position).normalized * moveSpeed;
            rb.linearVelocity = moveDirection;
        }
        else
        {
            rb.linearVelocity = transform.right * moveSpeed;
        }
        
        Destroy(gameObject, destructionTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            getHit hitScript = col.GetComponent<getHit>();

            if (hitScript != null)
            {
                hitScript.HP -= damage;
                Debug.Log("Bullet hit player. HP now: " + hitScript.HP);

                if (hitScript.HP <= 0)
                {
                    Debug.Log("Player died!");
                    Destroy(col.gameObject);
                }
            }

            Destroy(gameObject);
        }
    }
}