using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ConservationOfMomentum : MonoBehaviour
{
    public float distance;
    public GameObject spinner;
    public GameObject[] weights;

    public Slider slider;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = slider.value;

        weights[0].transform.localPosition = new Vector3(distance, 3.5f, 0f);
        weights[1].transform.localPosition = new Vector3(-distance, 3.5f, 0f);

        spinner.transform.Rotate(0f, 1/distance * 10, 0f, Space.Self);
    }
}
