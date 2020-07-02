using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditPhysics : MonoBehaviour
{
    public Vector3 gravity;
    public Rigidbody ball;
    public GameObject rope;
    public HingeJoint hinge;
    public ConfigurableJoint ballJoint;
    public float angDrag;
    public float mass;
    public float length;

    private float origLength;
    private float origMass;

    //private Transform stringTrans;
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = gravity;
        ball.mass = mass;
        ball.angularDrag = angDrag;

        rope.transform.localScale = new Vector3(0.05f, length, 0.05f);
        rope.transform.localPosition = new Vector3(0f, -length, 0f);


        ball.transform.localPosition = new Vector3(0f, -2 * length - 0.25f, 0f);
        ball.transform.localScale = new Vector3(1f, 1f, 1f);
        ball.transform.localScale *= Mathf.Sqrt(mass);
        ballJoint.connectedAnchor = new Vector3(0f, -2 * length + 0.25f, 0f);

        origLength = length;
        origMass = mass;

    }

    // Update is called once per frame
    void Update()
    {
        Physics.gravity = gravity;
        ball.mass = mass;
        ball.angularDrag = angDrag;

        if (origMass != mass)
        {

            ball.transform.localScale = new Vector3(1f, 1f, 1f);
            ball.transform.localScale *= Mathf.Sqrt(mass);
        }

        if (length != origLength)
        {
            rope.transform.localScale = new Vector3(0.05f, length, 0.05f);
            rope.transform.localPosition = new Vector3(0f, - length, 0f);


            ball.transform.localPosition = new Vector3(0f, -2 * length - 0.25f, 0f);
            ballJoint.connectedAnchor = new Vector3(0f, -2 * length + 0.25f, 0f);

            origLength = length;
        }
    }
}
