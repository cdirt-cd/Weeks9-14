using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InputCircleMouseStuff : MonoBehaviour
{

    public Camera gameCamera;
    public float speed = 0f;
    public float clickableRadius = 0.5f;


    private bool followMouse = false;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
        OnDoughClick();


    }

    void OnDoughClick()
    {
        Vector3 mousePositionInWorldSpace = gameCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePositionInWorldSpace.z = 0f;
        //Debug.Log("Mouse Position in World Space: " + mousePositionInWorldSpace);

        Vector3 dough1PositionInScreenSpace = gameCamera.WorldToScreenPoint(transform.position);

        Vector3 inputPos = transform.position;
        Vector3 mousePos = mousePositionInWorldSpace;
        mousePos.z = 0f;

        float distanceBetween = Vector3.Distance(inputPos, mousePos);
        //Debug.Log(distanceBetween);




        if (Input.GetMouseButtonDown(0))
        {
            if (distanceBetween <= clickableRadius)
            {
                followMouse = true;
            }
        }



        if (followMouse == true)
        {
            Vector3 start = transform.position;
            Vector3 target = mousePositionInWorldSpace;
            Vector3 directionToMove = target - start;
            transform.position = transform.position + directionToMove * speed;
        }



        //SpriteRenderer randomRenderer = GetComponent<SpriteRenderer>();
        //Transform randomTransform = GetComponent<Transform>();
        //randomTransform.position 
    }
}
