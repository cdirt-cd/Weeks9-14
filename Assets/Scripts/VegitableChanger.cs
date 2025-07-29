using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VegitableChanger : MonoBehaviour
{
    public Image foodImage;

    public Sprite brocoliSprite;

    public Sprite hamburgerSprite;
    //when we hover the vegitable
    //it will become a brocoli

    //when we unhover the food it will become a hamburger


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHover()
    {
        foodImage.sprite = brocoliSprite;
    }

    public void OnUnhover()
    {
        foodImage.sprite = hamburgerSprite;
    }
}
