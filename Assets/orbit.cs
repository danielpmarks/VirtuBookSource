using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class orbit : MonoBehaviour
{
    public GameObject planet;
    public GameObject sun;
    public float speed;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 planetPos = planet.transform.localPosition;
        Vector3 sunPos = sun.transform.localPosition;

        distance = (sunPos - planetPos).magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        planet.transform.localPosition = new Vector3(distance * Mathf.Sin(Time.time * speed), planet.transform.localPosition.y, distance * Mathf.Cos(Time.time * speed));
    }
}
