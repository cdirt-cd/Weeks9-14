using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuckooClock : MonoBehaviour
{
    public Transform hourHand, minuteHand;

    public float hourDuration = 4f;

    private float currentTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        minuteHand.eulerAngles -= Vector3.forward * 360 * Time.deltaTime / hourDuration;

       


    }
}
