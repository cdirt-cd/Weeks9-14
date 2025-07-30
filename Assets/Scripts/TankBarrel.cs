using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBarrel : MonoBehaviour
{
    public Camera gameCamera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 newRotation = transform.eulerAngles;
        //newRotation.z += 1f;
        //transform.eulerAngles = newRotation;
        Vector3 mousePositionInWorldSpace = gameCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePositionInWorldSpace.z = 0f;

        Vector3 start = transform.position;
        Vector3 end = mousePositionInWorldSpace;

        Vector3 direction = end - start;

        //Set the transform.up to be in the direction of the mouse
        transform.up = direction;
    }
}