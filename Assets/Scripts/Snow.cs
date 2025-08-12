using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour
{
    public ParticleSystem snowParticles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleSnow();
        }
    }

    void ToggleSnow()
    {
        if (snowParticles.isPlaying)
        { 
           snowParticles.Stop(false, ParticleSystemStopBehavior.StopEmittingAndClear);
        }       
        else if (snowParticles.isPlaying)
        {
            snowParticles.Play();
        }

    }
}
