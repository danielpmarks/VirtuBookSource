using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;

public class Pendulum_Motion : MonoBehaviour
{
    public GameObject swinging;
    public GameObject rope;
    public GameObject ball;

    private float startTime;
    public float length;
    public float gravity;

    public Slider lengthSlider;
    public Slider gravitySlider;

    private float period;

    void Start()
    {
        startTime = (float) Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        rope.transform.localScale = new Vector3(0.25f, length / 2, 0.25f);
        rope.transform.localPosition = new Vector3(0f, -length / 2, 0f);

        ball.transform.localPosition = new Vector3(0f, -length, 0f);

        period = Mathf.Sqrt((float) length/100 / gravity) * 2 * ((float) Math.PI);
        float angle = Mathf.Sin((Time.time - startTime) / period);
        print(angle);
        swinging.transform.localEulerAngles = new Vector3(0f,0f, 30*angle);
    }

    public void updateLength()
    {
        length = lengthSlider.value;
    }

    public void updateGravity()
    {
        gravity = gravitySlider.value;
    }
}
