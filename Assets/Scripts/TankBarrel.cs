using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBarrel : MonoBehaviour
{
    public GameObject tankBulletPrefab;

    public float tankBulletMoveDuration = 5f;

    public AudioSource tankBarrelFired;



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


        bool spaceClick = Input.GetKeyDown(KeyCode.Space);

        if (spaceClick)
        {
            GameObject spawnedTankBullets = Instantiate(tankBulletPrefab, transform.position, Quaternion.identity);
            Debug.Log(spawnedTankBullets.name);

           

            TankBullet tankBulletScript = spawnedTankBullets.GetComponent<TankBullet>();
            if (tankBulletScript == null)
            {
                Debug.Log("Script not found");
            }
            else
            {
                tankBulletScript.moveDuration = tankBulletMoveDuration;
            }
            tankBarrelFired.Play();


        }
    }
}