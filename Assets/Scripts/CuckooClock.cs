using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuckooClock : MonoBehaviour
{
    public Transform hourHand, minuteHand;

    public float hourDuration = 4f;

    public Chime chime;

    private float currentTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        chime = gameObject.GetComponentInChildren<Chime>();
    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(ClockUpdate());

    }

    IEnumerator ClockUpdate()
    {
        while (currentTime < hourDuration)
        {



            currentTime += Time.deltaTime;

            minuteHand.eulerAngles -= Vector3.forward * 360 * Time.deltaTime / hourDuration;

            hourHand.eulerAngles -= Vector3.forward * 360 * Time.deltaTime / hourDuration / 12;

            if (currentTime > hourDuration)
            {
                chime.PlayChime();

                currentTime = 0f;

            }

            yield return null;

        }
    }
}
