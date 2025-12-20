using UnityEngine;

public class bulletMonster : MonoBehaviour {

    [SerializeField] private GameObject bullet;
    
    [SerializeField] private float fireRate;
    [SerializeField] private float nextFire;

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