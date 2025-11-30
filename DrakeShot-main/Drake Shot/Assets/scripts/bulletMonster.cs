using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMonster : MonoBehaviour {

    [SerializeField]
    GameObject bullet;
    
    //private these after testing
    public float fireRate;
    public float nextFire;

    // Use this for initialization
    void Start () {
        fireRate = 1f;
        nextFire = Time.time;
    }
	
    // Update is called once per frame
    void Update () {
        CheckIfTimeToFire ();
    }

    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire) {
            Instantiate (bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
		
    }

}