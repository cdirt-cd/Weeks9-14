using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartRateMonitor : MonoBehaviour
{
    public float speed = 3f; // Speed of the movement
    private float screenWidth;

    // Start is called before the first frame update
    void Start()
    {
        // Calculate the screen width in world units
        screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the game object to the right
        transform.position += new Vector3(Vector2.right.x * speed * Time.deltaTime, 0, 0);

        // Check if the game object has reached the right edge of the screen
        if (transform.position.x > screenWidth)
        {
            // Reset the position to the left edge
            transform.position = new Vector2(-screenWidth, transform.position.y);
        }
    }
}


