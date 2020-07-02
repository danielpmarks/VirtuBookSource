using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatePhysics : MonoBehaviour
{
    public GameObject kinEnergyBar;
    public GameObject potEnergyBar;

    public GameObject velVector;
    public GameObject accVector;

    public GameObject tracking;
    private float velocity;
    private float acceleration;
    private Vector3 center;

    public BoxCollider trigger;

    private double potentialEnergy;
    private double kineticEnergy;
    private double totalEnergy;

    private Transform kinTransform;
    private Transform potTransform;
    // Start is called before the first frame update
    void Start()
    {
        kinTransform = kinEnergyBar.transform;
        potTransform = potEnergyBar.transform;

        kineticEnergy = 0;
        potentialEnergy = 0;

        center = tracking.transform.localPosition;
        
    }

    // Update is called once per frame
    void Update()
    {
        velocity = tracking.GetComponent<Rigidbody>().velocity.z;
        Vector3 position = tracking.transform.localPosition;
        float positionMag = (position - center).z;
        float springForce = 10;
        float mass = tracking.GetComponent<Rigidbody>().mass;
        //print(springForce);
        acceleration = springForce * positionMag * positionMag / mass * 0.5f;

        UpdateVectors();

        if (totalEnergy != 0)
        {
           // print("Update");
            kineticEnergy = tracking.GetComponent<Rigidbody>().mass * tracking.GetComponent<Rigidbody>().velocity.sqrMagnitude * 0.5 / 10;
            potentialEnergy = acceleration * mass / 10;

            

            kinTransform.localScale = new Vector3(1f, (float)kineticEnergy / 4, 1f);
            kinTransform.localPosition = new Vector3(kinTransform.localPosition.x, (float)kineticEnergy / 8, kinTransform.localPosition.z);
            if (potentialEnergy >= 0)
            {
                potTransform.localScale = new Vector3(1f, (float)potentialEnergy / 4, 1f);
                potTransform.localPosition = new Vector3(potTransform.localPosition.x, (float)potentialEnergy / 8, potTransform.localPosition.z);
            } else
            {
                potTransform.localScale = new Vector3(0f, 0f, 0f);
                potTransform.localPosition = new Vector3(potTransform.localPosition.x, 0f, potTransform.localPosition.z);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        totalEnergy = tracking.GetComponent<Rigidbody>().mass * 0.5 * tracking.GetComponent<Rigidbody>().velocity.sqrMagnitude / 10;
       
        
    }

    private void UpdateVectors()
    {
        velVector.transform.localScale = new Vector3(0.2f, Mathf.Abs(velocity) / 2, 0.2f);
        Vector3 offset = new Vector3(0f, 0f, Mathf.Abs(velocity) / 2 + 0.5f);
        if (velocity > 0)
        {
            velVector.transform.localPosition = offset;
            
        } else
        {
            velVector.transform.localPosition = -offset;
            
        }

        accVector.transform.localScale = new Vector3(0.1f, Mathf.Abs(acceleration), 0.1f);
        Vector3 accOffset = new Vector3(0f, 0f, Mathf.Abs(acceleration) + 0.5f);
        if (tracking.transform.localPosition.z > center.z)
        {
            accVector.transform.localPosition = -accOffset;
            //print(offset);
        } else
        {
            accVector.transform.localPosition = accOffset;
        }

        //print(acceleration);
    }
}
