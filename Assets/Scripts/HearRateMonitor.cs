using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartRateMonitor : MonoBehaviour
{
    public float speed = 3f; // Speed of the movement
   
    private float screenWidth;
   
    [Range(0, 1)]
    public float beep;
    public AnimationCurve HeartLine;
    

    // Start is called before the first frame update
    void Start()
    {
        beep = 0;

        screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
    }

    
    void Update()
    {
        Vector2 newPosition = transform.position;
        newPosition.x += speed * Time.deltaTime;
        newPosition.y = HeartLine.Evaluate(beep) * 50;
        transform.position = newPosition;
        //transform.position += new Vector3(transform.position.x += speed * Time.deltaTime);
        //transform.position += new Vector3(transform.position.y, HeartLine.Evaluate(beep));


        if (transform.position.x > screenWidth)
        {
            
            transform.position = new Vector2(-screenWidth, transform.position.y);
        }

        beep += Time.deltaTime;
        if (beep > 1)
        {
            beep = 0;
        }
    }
}


