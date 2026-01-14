using System.Collections;
using UnityEngine;

public class MiniBossRandomSpawner : MonoBehaviour {
    
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnInterval = 5f;
    [SerializeField] private int enemiesPerWave = 1;
    [SerializeField] private int maxSpawnWave = 50;
    [SerializeField] private float cycleCoef = 5f;
    
    private Coroutine _spawnCoroutine = null;
    private int _currentSpawnWave = 0;

    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.CompareTag("Player") && _spawnCoroutine == null) {
            Debug.Log("entered");
            _spawnCoroutine = StartCoroutine(SpawnCoroutine());
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        
        if (other.CompareTag("Player") && _spawnCoroutine != null) {
            Debug.Log("exited");
            StopCoroutine(_spawnCoroutine);
            
            _spawnCoroutine = null;
        }
        
    }

    private IEnumerator SpawnCoroutine() {
        
        while (_currentSpawnWave < maxSpawnWave) {
            Debug.Log("inside while");
            
            Spawn();

            _currentSpawnWave++;
            
            yield return new WaitForSeconds(spawnInterval);
        }
        
        yield break;

        void Spawn() {
        
            for (int i = 0; i < enemiesPerWave; i++) {
                Instantiate(enemyPrefab, transform.position + (Vector3)(Random.insideUnitCircle * cycleCoef), 
                    Quaternion.identity);
                Debug.Log("spawned");
            }
        
        }
        
    }
    
}