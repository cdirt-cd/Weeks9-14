using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawing : MonoBehaviour
{
    public LineRenderer lineRenderer;

    private float timeHeldDown = 0f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 positionToAdd = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            positionToAdd.z = 0;


            lineRenderer.positionCount++;

            lineRenderer.SetPosition(lineRenderer.positionCount -1, positionToAdd);

        }

        if (Input.GetMouseButtonDown(1))
        {

          

            if(lineRenderer.positionCount != 0)

            {
                lineRenderer.positionCount--;
            }

       

        }

        if (Input.GetMouseButton(1))
        {

            timeHeldDown += Time.deltaTime;



            if (timeHeldDown >= 0.5f)
            {
              
                lineRenderer.positionCount--;

              

                Debug.Log("Held down activate");

                timeHeldDown = 0;
            }

        }
    }
}

