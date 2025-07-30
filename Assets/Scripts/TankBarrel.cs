using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBarrel : MonoBehaviour
{
    private Camera gameCamera;

    //private GameObject tankBarrel;

    // Start is called before the first frame update
    void Start()
    {
        gameCamera = Camera.main;

        //tankBarrel = GameObject.FindObjectOfType<TankBarrel>().gameObject;
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
        transform.right = direction;
    }
}