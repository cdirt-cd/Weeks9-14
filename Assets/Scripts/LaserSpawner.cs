using UnityEngine;
using System.Collections;

public class LaserSpawner : MonoBehaviour
{
    public GameObject laserPrefab;  // the prefab representing a continuous laser beam.
    public float initialRotationSpeed = 30f;  // the rotation speed of the spawner.
    public float speedIncreaseInterval = 30f;  // how often to increase the rotation speed.

    private float rotationSpeed;
    private GameObject[] lasers;  // array to hold the laser beams.

    private void Start()
    {
        // initialize the rotation speed and create an array for the lasers
        rotationSpeed = initialRotationSpeed;
        lasers = new GameObject[4];

        // 
        for (int i = 0; i < 4; i++)
        {
            
            float angle = i * 90f;
            // instantiate the laser beam; set its rotation relative to the spawner.
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.Euler(0f, 0f, angle));
            // parent the laser to the spawner so it will rotate with it.
            laser.transform.parent = transform;
            lasers[i] = laser;
        }

        // start the coroutine that increases the rotation speed over time.
        StartCoroutine(IncreaseRotationSpeed());
    }

    private void Update()
    {
    
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }

    // coroutine to gradually increase the spawner's rotation speed over time.
    private IEnumerator IncreaseRotationSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(speedIncreaseInterval);
            rotationSpeed += 10f;
            Debug.Log("Laser Spawner Speed Increased to: " + rotationSpeed);
        }
    }
}
