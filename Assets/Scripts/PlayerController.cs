using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5f;
    private float direction = 1f;
    private float direction2 = -1f;


    private Camera gameCamera;


    void Start()
    {
        gameCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 heroPositionInScreenSpace = gameCamera.WorldToScreenPoint(transform.position);


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 pos = transform.position;

            pos.x += direction2 * speed * Time.deltaTime;

            transform.position = pos;

            //Debug.Log("Left Arrow Pressed: " + pos.x + ", " + pos.y);

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 pos = transform.position;

            pos.x += direction * speed * Time.deltaTime;

            transform.position = pos;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 pos = transform.position;

            pos.y += direction2 * speed * Time.deltaTime;

            transform.position = pos;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 pos = transform.position;

            pos.y += direction * speed * Time.deltaTime;

            transform.position = pos;
        }
    }
}
