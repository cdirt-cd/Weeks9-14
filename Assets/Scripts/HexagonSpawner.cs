using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexagonSpawner : MonoBehaviour

{

    public GameObject hexagonPrefab;

    public Button hexagonColourizerButton;

    public HexagonCounter hexagonCounter;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (Vector3)Random.insideUnitCircle * 5;
    }

    public void OnSpawnClick()
    {
        Vector3 spawnPosition = transform.position + (Vector3)Random.insideUnitCircle * 2;


        //Vector3 spawnPosition = transform.position + Random.insideUnitCircle * 5;
        //spawnPosition.z = 0f;


        //spawned a new hexagon when the button is clicked
        GameObject spawnedHexagonObject = Instantiate(hexagonPrefab, spawnPosition, Quaternion.identity);
 //Get access to its hexagon script
        Hexagon spawnedHexagon = spawnedHexagonObject.GetComponent<Hexagon>();
        //spawnedHexagon.onColourChange is the event of this

       //we are adding a new listener which will do something every time the colour of this hexagon changes
        hexagonColourizerButton.onClick.AddListener(spawnedHexagon.OnClickColourChange);
       
        spawnedHexagon.onColourChange.AddListener(hexagonCounter.InscreaseCount);


    }

}
