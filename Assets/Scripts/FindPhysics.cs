using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class FindPhysics : MonoBehaviour
{

    public GameObject centerObj;
    public GameObject oscillator;
    public GameObject kineticBar;
    public GameObject potentialBar;
    public GameObject velVector;
    public GameObject accVector;
    
    private float springConst;

    private Vector3 center;

    private float potentialEnergy;
    private float kineticEnergy;
    private float velocity;
    private float acceleration;
    private float mass;

    private float prevDist;



    // Start is called before the first frame update
    void Start()
    {
        mass = oscillator.GetComponent<Rigidbody>().mass;
        center = centerObj.transform.localPosition; 
    }

    // Update is called once per frame
    void Update()
    {
        mass = oscillator.GetComponent<Rigidbody>().mass;
        float dist = updateMags();

        updateComponents();
        prevDist = dist;
    }

    float updateMags()
    {
        float dist = (oscillator.transform.localPosition - center).z;
        velocity = HarmonicMotion.velocity;
        acceleration = HarmonicMotion.acceleration;
        springConst = HarmonicMotion.springConst;

        kineticEnergy = (0.5f * mass * velocity * velocity);
        potentialEnergy = 0.5f * springConst * dist * dist;

        return dist;
    }

    void updateComponents()
    {

        //Update velocity vector
        velVector.transform.localScale = new Vector3(0.2f, Mathf.Abs(velocity) / 5, 0.2f);
        Vector3 offset = new Vector3(0f, 0f, Mathf.Abs(velocity) / 5 + 0.5f);
        if (velocity > 0)
        {
            velVector.transform.localPosition = offset;

        }
        else
        {
            velVector.transform.localPosition = -offset;

        }

        //Update acceleration vector
        accVector.transform.localScale = new Vector3(0.1f, -Mathf.Abs(acceleration) / 5, 0.1f);
        Vector3 accOffset = new Vector3(0f, 0f, -Mathf.Abs(acceleration) / 5 + 0.5f);
        if (acceleration > 0)
        {
            accVector.transform.localPosition = -accOffset;
        }
        else
        {
            accVector.transform.localPosition = accOffset;
        }

        kineticBar.transform.localScale = new Vector3(1f, (float)kineticEnergy / 10, 1f);
        kineticBar.transform.localPosition = new Vector3(kineticBar.transform.localPosition.x, (float)kineticEnergy / 20, kineticBar.transform.localPosition.z);

        potentialBar.transform.localScale = new Vector3(1f, (float)potentialEnergy / 10, 1f);
        potentialBar.transform.localPosition = new Vector3(potentialBar.transform.localPosition.x, (float)potentialEnergy / 20, potentialBar.transform.localPosition.z);
    }
}
