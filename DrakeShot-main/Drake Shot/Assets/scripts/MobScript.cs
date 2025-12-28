using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class MobScript : MonoBehaviour {

    [SerializeField] private GameObject goldPrefab;
    [SerializeField] private GameObject xpPrefab;
    [SerializeField] private float health = 10;
    [SerializeField] private float cycleCoef = 1f;

    [SerializeField] private float freezeChance = 30f;
    [SerializeField] private bool tierOneUnlocked = true;
    [SerializeField] private bool tierTwo1Unlocked = true;
    [SerializeField] private bool tierTwo2Unlocked = true;
    [SerializeField] private bool tierThree1Unlocked = true;
    [SerializeField] private bool tierThree2Unlocked = true;
    [SerializeField] private chaseTarget chaser;
    [SerializeField] private PlayerScript playerScript;
    [SerializeField] public int freezeDMG = 5;
    [SerializeField] public float freezeSplashRadius = 10f;
    private bool _isPoisoned = false;

    private void Awake() {
        
        playerScript = FindFirstObjectByType<PlayerScript>();
        
    }

    public void TakeDamage(int damageAmount) {
        
        health -= damageAmount;
        
        if (playerScript.PlayerPoisonDamage != 0f && !_isPoisoned) {
            StartCoroutine(ApplyPoisonDamage());
        }

        if (tierOneUnlocked && chaser != null)
        {
            roll4freeze();
        }

        if (tierTwo1Unlocked && chaser != null)
        {
            roll4freeze();
            health -= freezeDMG;

        }

        if (tierTwo2Unlocked && chaser != null && playerScript != null)
        {
            roll4freeze();
            playerScript.beastFrozen();
        }

        if (health <= 0)
        {
            Die();
        }

        return;

        void Die()
        {

            if (tierThree1Unlocked && chaser != null)
            {
                freezeSplash();

            }

            AutoInstantiate(goldPrefab);
            AutoInstantiate(xpPrefab);

            Destroy(gameObject);

            return;

            void AutoInstantiate(GameObject a)
            {

                Instantiate(a, transform.position + (Vector3)(Random.insideUnitCircle * cycleCoef),
                    Quaternion.identity);

            }

        }

        void roll4freeze()
        {
            float rand = Random.Range(0f, 100f);
            if (rand < freezeChance)
            {
                chaser.freezeTheBeastAgain(1f);
            }
        }

        void freezeSplash()
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, freezeSplashRadius);
            foreach (var hitCollider in hitColliders)
            {
                MobScript mob = hitCollider.GetComponent<MobScript>();
                if (mob != null && mob.gameObject != this.gameObject)
                {
                    chaseTarget neighborMovement = hitCollider.GetComponent<chaseTarget>();
                    if (neighborMovement != null)
                    {
                        float halfDuration = 0.5f;
                        //might change this...
                        //depends is the player can just stack up freezes 
                        //and stalls everything
                        neighborMovement.freezeTheBeastAgain(halfDuration);
                    }

                }

            }
        }
        
        IEnumerator ApplyPoisonDamage() {
            _isPoisoned = true;
            
            for (int i = 0; i < 2; i++) {
                yield return new WaitForSeconds(1f);
            
                health -= playerScript.PlayerPoisonDamage;
                
                if (health <= 0) {
                    Die();
                    yield break;
                }
            }

            _isPoisoned = false;
        }
        
    }
}