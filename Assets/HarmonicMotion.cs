using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HarmonicMotion : MonoBehaviour
{
    public GameObject cube;
    private Transform cubeTransform;
    
    private float freq;
    private float spring;
    public static float springConst;
    public static float velocity;
    public static float acceleration;

    private float dampening;


    private float startTime;
    private float amplitude;

    public Slider dampeningSlider;
    public Slider massSlider;
    public Slider springKSlider;


    // Start is called before the first frame update
    void Start()
    {
        springConst = spring;
        freq = (float) Math.Sqrt(spring / cube.GetComponent<Rigidbody>().mass);
        startTime = Time.time;
        cubeTransform = cube.transform;
        amplitude = 0;
    }

    // Update is called once per frame
    void Update()
    {
        freq = (float)Math.Sqrt(spring / cube.GetComponent<Rigidbody>().mass);
        if (Input.GetKey(KeyCode.Space))
        {
            reset();
        }
        float currentTime = Time.time;
        float timeDiff = currentTime - startTime;
        float dampeningCoef = 1 / (dampening * timeDiff / 10 + 1);
        
        cubeTransform.localPosition = new Vector3(0f, 1f, amplitude * Mathf.Cos((timeDiff) * freq) * dampeningCoef);
        velocity = -amplitude * freq * Mathf.Sin((timeDiff) * freq) * dampeningCoef;
        acceleration = -amplitude * freq * freq * Mathf.Cos((timeDiff) * freq) * dampeningCoef;
    }

    public void reset()
    {
        cubeTransform.localPosition = new Vector3(0f, 1f, 2f);
        amplitude = cubeTransform.localPosition.z;
        cube.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        startTime = Time.time;
    }

    public void setDampening()
    {
        dampening = dampeningSlider.value;
    }

    public void setSpringK()
    {
        spring = springKSlider.value;
        springConst = spring;
    }

    public void setMass()
    {
        cube.GetComponent<Rigidbody>().mass = massSlider.value;
    }
}
