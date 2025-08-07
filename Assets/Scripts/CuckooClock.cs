using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuckooClock : MonoBehaviour
{
    public Transform hourHand, minuteHand;

    public Chime chime;

    public float hourDuration = 4f;

    private float currentTime = 0f;
    private Coroutine activeClockCoroutine;
    private IEnumerator activeHandsCoroutine;


    // Start is called before the first frame update
    void Start()
    {
        chime = gameObject.GetComponentInChildren<Chime>();
        //activeClockCoroutine = StartCoroutine(ClockUpdate());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Stop()
    {
        Debug.Log("Stopping the coroutine");
        if (activeClockCoroutine != null)
        {
            StopCoroutine(activeClockCoroutine);
        }
        if (activeHandsCoroutine != null)
        {
            StopCoroutine(activeHandsCoroutine);
        }
    }

    IEnumerator ClockUpdate()
    {
        Debug.Log("Starting clock update");
        //When ClockUpdate coroutine finishes - we want to start it again
        while (true)
        {
            //We use this syntax specifically when we're yield returning the StartCoroutine
            //And can't access the return value of StartCoroutine
            activeHandsCoroutine = MoveHandsAnHour();
            yield return StartCoroutine(activeHandsCoroutine);
        }

        //Debug.Log("We've reached the end of the ClockUpdate coroutine");
    }

    IEnumerator MoveHandsAnHour()
    {
        currentTime = 0f;
        while (currentTime < hourDuration)
        {
            currentTime += Time.deltaTime;

            //Move the hour hand clockwise
            hourHand.eulerAngles -= Vector3.forward * 360 * Time.deltaTime / hourDuration / 12;

            //Move the minute hand clockwise
            //When an hour has passed (4 seconds), the minute hand should move -360 degrees

            //Vector3.forward gives us just the z value which we can use to rotate the object
            //along the z-axis (which rotates us in 2D)
            minuteHand.eulerAngles -= Vector3.forward * 360 * Time.deltaTime / hourDuration;

            //When we've hit an hour of time, the clock is going to "chime"
            if (currentTime > hourDuration)
            {
                if (chime == null)
                {
                    Debug.Log("We have not assigned the chime as a child of this object");
                }
                else
                {
                    currentHour++;
                    //It's time to chime
                    chime.PlayChime();
                }

            }

            yield return null;
        }
        Debug.Log("We've finished MoveHandsAnHour coroutine");
    }
}
