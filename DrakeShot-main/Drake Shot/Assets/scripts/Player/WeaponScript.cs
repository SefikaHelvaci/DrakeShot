using System.Collections;
using UnityEngine;

public class WeaponScript : MonoBehaviour {
    
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform weaponTransform;
    
    private PlayerScript _myPlayerScript;
    private Coroutine _firingCoroutine;
    private WaitForSeconds _fireDelay;

    private void Awake() {
        
        _myPlayerScript = GetComponent<PlayerScript>();
        
        _fireDelay = new WaitForSeconds(_myPlayerScript.PlayerFireRate);
        
    }

    private void Update() {

        if (Time.timeScale != 0f) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f; 
        
            weaponTransform.right = mousePos - weaponTransform.position;
        
            if (Input.GetButtonDown("Fire1") && _firingCoroutine == null) {
                _firingCoroutine = StartCoroutine(FireContinuously());
            }
        }
        
    }
    
    IEnumerator FireContinuously() {
        
        while (Input.GetButton("Fire1")) {
            GameObject newBulletObj = Instantiate(bulletPrefab, weaponTransform.position + (weaponTransform.right * 1f), weaponTransform.rotation);
            Bullet bulletScript = newBulletObj.GetComponent<Bullet>();
            bulletScript.Setup(_myPlayerScript.PlayerBulletSpeed, _myPlayerScript.PlayerDamage);
            
            yield return _fireDelay;
        }

        _firingCoroutine = null;

    }
    
}