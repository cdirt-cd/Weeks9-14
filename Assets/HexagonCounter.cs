using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HexagonCounter : MonoBehaviour
{
    public TMP_Text counterText;
    private int colourizedCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InscreaseCount()
    {
        colourizedCount++;
        counterText.text = colourizedCount.ToString();


    }
}
