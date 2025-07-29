using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Hexagon : MonoBehaviour
{
    //declaring an eevnet which we can then invoke to get other objects to do things
    //when the colour is changed, anything listening to this event will run the corresponding method.
    public UnityEvent onColourChange;

    public TMP_Text counterText;
    private SpriteRenderer hexagonRenderer;
    // Start is called before the first frame update
    void Start()
    {
        hexagonRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickColourChange()
    {
        hexagonRenderer.color = Random.ColorHSV();

        //use invoke whenever the event is supposed to other things to do something
        //we are changing colour in this method so anything that is listening to colour change to do something
        onColourChange.Invoke();
    }
}
