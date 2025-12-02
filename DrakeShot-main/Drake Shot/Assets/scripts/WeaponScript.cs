using UnityEngine;

public class WeaponScript : MonoBehaviour {
    
    public GameObject bulletPrefab;
    public Transform weaponTransform;

    void Update() {
        
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f; 
        
        weaponTransform.right = mousePos - weaponTransform.position;
        
        if (Input.GetButtonDown("Fire1")) {
            Instantiate(bulletPrefab, weaponTransform.position + (weaponTransform.right * 1f), weaponTransform.rotation);
        }
    
    }
    
}