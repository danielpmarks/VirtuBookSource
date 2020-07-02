using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friction : MonoBehaviour
{
    public PhysicMaterial mat;
    public GameObject cube;
    public float friction;
    // Start is called before the first frame update
    void Start()
    {
        mat.dynamicFriction = friction;
    }

    // Update is called once per frame
    void Update()
    {
        if(mat.dynamicFriction != friction)
        {
            mat.dynamicFriction = friction;
        }

        if(Input.GetKey(KeyCode.Space))
        {
            cube.transform.localPosition = new Vector3(0f, 1f, 2f);
            cube.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        }
    }
}
