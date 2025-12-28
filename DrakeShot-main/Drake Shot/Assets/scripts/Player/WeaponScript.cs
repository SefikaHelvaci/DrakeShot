using System.Collections;
using UnityEngine;

public class WeaponScript : MonoBehaviour {
    
    [SerializeField] private GameObject bulletPrefab;
    
    private PlayerScript _myPlayerScript;
    private Vector3 _aimDirection;
    private Camera _mainCamera;
    private Coroutine _firingCoroutine;

    private void Awake() {
        
        _myPlayerScript = GetComponent<PlayerScript>();
        
    }

    private void Update() {

        if (Time.timeScale != 0f) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f; 
        
            _aimDirection = (mousePos - transform.position).normalized;
            
            if (Input.GetButtonDown("Fire1") && _firingCoroutine == null) {
                _firingCoroutine = StartCoroutine(FireContinuously());
            }
        }
        
    }
    
    IEnumerator FireContinuously() {
        
        while (Input.GetButton("Fire1")) {
            Quaternion bulletRotation = Quaternion.Euler(0, 0, Mathf.Atan2(_aimDirection.y, _aimDirection.x) * Mathf.Rad2Deg);
            
            GameObject newBulletObj = Instantiate(bulletPrefab, transform.position + (_aimDirection * 1f), bulletRotation);
            Bullet bulletScript = newBulletObj.GetComponent<Bullet>();
            bulletScript.Setup(_myPlayerScript.PlayerBulletSpeed, _myPlayerScript.PlayerDamage);
            
            yield return new WaitForSeconds(_myPlayerScript.PlayerFireRate);
        }

        _firingCoroutine = null;

    }
    
}