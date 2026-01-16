using System.Collections;
using UnityEngine;

public class acidWater : MonoBehaviour
{

    public int damage = 1;
    public float shakeAmount = 0.1f;
    public Transform playerSprite;
    private bool isShaking = false;
    private bool damageable = true;
    

    public float hitSpeed = 1f;
    //^^ privatize this one after tests

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Transform shakey = other.transform.Find("shakeEffect");
            if (shakey != null && !isShaking)
            {
                isShaking = true;
                StartCoroutine(takeAcidDmg(shakey));
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player") && damageable)
        {
            PlayerScript myPlayerScript = col.GetComponent<PlayerScript>();
            if (myPlayerScript != null)
            {
                StartCoroutine(waterDamage(myPlayerScript));
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isShaking = false;
        }
    }


    IEnumerator waterDamage(PlayerScript myPlayerScript)
    {
        myPlayerScript.PlayerHealth -= damage;
        //Debug.Log("Player got soaked by water. HP now: " + myPlayerScript.PlayerHealth);
        
        if(myPlayerScript.PlayerHealth <= 0){
            //Debug.Log("Player drowned :(");
            if (GameOver.Instance == null)
            {
                Debug.LogError("GameOver.Instance is NULL");
            }
            else
            {
                GameOver.Instance.itsGameOver();
            }
            Destroy(myPlayerScript.gameObject);
            yield break;
        }
        yield return new WaitForSeconds(hitSpeed);
        damageable = true;
    }

    IEnumerator takeAcidDmg(Transform sprite)
    {
        Vector3 origin = Vector3.zero;

        while (sprite != null && isShaking)
        {
            float x = Random.Range(-1f, 1f) * shakeAmount;
            float y = Random.Range(-1f, 1f) * shakeAmount;

            sprite.localPosition = new Vector3(origin.x + x, origin.y + y, origin.z);

            yield return null;
        }

        if (sprite != null)
            {
                sprite.localPosition = origin;
            }
        }
    }
