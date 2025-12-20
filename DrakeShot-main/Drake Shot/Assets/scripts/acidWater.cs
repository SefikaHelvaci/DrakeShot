using System.Collections;
using UnityEngine;

public class acidWater : MonoBehaviour
{

    public int damage = 1;

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

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {

            PlayerScript myPlayerScript = col.GetComponent<PlayerScript>();
            if (myPlayerScript != null)
            {
                StartCoroutine(waterDamage(myPlayerScript));
            }
        }
    }


    IEnumerator waterDamage(PlayerScript myPlayerScript)
    {
        myPlayerScript.playerHealth -= damage;
        Debug.Log("Player got soaked by water. HP now: " + myPlayerScript.playerHealth);
        
        if(myPlayerScript.playerHealth <= 0){
            Debug.Log("Player drowned :(");
            Destroy(myPlayerScript.gameObject);
            yield break;
        }
        yield return new WaitForSeconds(hitSpeed);
    }




}
