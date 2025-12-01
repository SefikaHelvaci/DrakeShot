using System.Collections;
using UnityEngine;

public class acidWater : MonoBehaviour
{

    public int damage = 1;
    private bool dmgable = true;

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
        if (col.CompareTag("Player") && dmgable)
        {

            getHit hitScript = col.GetComponent<getHit>();
            if (hitScript != null)
            {
                StartCoroutine(waterDamage(hitScript));
            }
        }
    }


    IEnumerator waterDamage(getHit hitScript)
    {
        dmgable = false;
        hitScript.HP -= damage;
        Debug.Log("Player got soaked by water. HP now: " + hitScript.HP);
        
        if(hitScript.HP <= 0){
            Debug.Log("Player drowned :(");
            Destroy(hitScript.gameObject);
            yield break;
        }
        yield return new WaitForSeconds(hitSpeed);
        dmgable = true;
    }




}
