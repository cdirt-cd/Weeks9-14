using UnityEngine;
using System.Collections;

public class UpgradeSpawner : MonoBehaviour
{
    public GameObject upgradePrefab;          // the object that will be spawned
    public float spawnInterval = 10f;         // time between spawns
    public Vector2 spawnAreaMin;              // where it can spawn
    public Vector2 spawnAreaMax;              // where it can spawn

    private void Start()
    { // start the coroutine to spawn upgrades
        StartCoroutine(SpawnUpgrades());
    }
    // coroutine to spawn upgrades
    private IEnumerator SpawnUpgrades()
    {// infinite loop to spawn upgrades
        while (true)
        {
            //determines spawn area
            Vector2 randomPos = new Vector2(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y)
            );

            //checks if the spawn area is empty
            Instantiate(upgradePrefab, randomPos, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
