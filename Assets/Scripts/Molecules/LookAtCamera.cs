using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public Camera targetCamera;

    public GameObject axisPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        transform.LookAt(targetCamera.transform.position, Vector3.up);
        //transform.RotateAround(Vector3.up, angle);
    }
}
