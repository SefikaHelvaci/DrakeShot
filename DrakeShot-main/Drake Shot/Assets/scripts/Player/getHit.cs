using UnityEngine;

public class getHit : MonoBehaviour
{

    private PlayerScript _myPlayerScript;
    
    public int monsterDMG = 1;
    
    //its possible that we could just leave the dmg as it is 
    //but increase the projectiles instead
    //so that everything can be contained here 
    //this is just for collision with a monster anyways

    private void Awake() {
        
        _myPlayerScript = GetComponent<PlayerScript>();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"{gameObject.name} (tag: {gameObject.tag}) collided with {collision.gameObject.name} (tag: {collision.gameObject.tag})");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hurt(monsterDMG);
            
            recoilScript recoil = 
                collision.gameObject.GetComponent<recoilScript>();

            if (recoil != null)
            {
                float strength = 5f; 
                
                Vector3 hitDirection = (collision.transform.position - transform.position).normalized; 
                
                recoil.onHit(strength, hitDirection);
            }
        }
    }

    private void hurt(int dmg)
    {
        if (Random.Range(Mathf.Epsilon, 100f) > _myPlayerScript.PlayerDodge) {
            _myPlayerScript.PlayerHealth -= dmg * ((100 - _myPlayerScript.PlayerArmor) / 100f);
        }
        
        Debug.Log($"You crashed into a monster! -1 HP. Curr HP: {_myPlayerScript.PlayerHealth}");
        
        if (_myPlayerScript.PlayerHealth == 0)
        {
            Debug.Log($"YOU DIED");
            Destroy(gameObject);
        }
    }
}
