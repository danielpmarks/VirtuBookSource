using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    public GameObject button;

    //New values for scale and position of object
    public Vector3 transformPosition;
    public Vector3 scaleTo;

    //Current scale and rotation when expanded
    private Vector3 currentScale;
    private Vector3 currentRotation;

    //Initial position and scale of GameObject before expansion
    [HideInInspector]
    public Vector3 initialScale;
    [HideInInspector]
    public Vector3 initialPosition;
    [HideInInspector]
    public Quaternion initialRotation;

   

    //Other molecules which will disappear when this GameObject is tapped
    public GameObject[] molecules;

    

    //Position vectors and boolean for original location of two fingers for scaling
    private Vector2 originalDistance;
    private float originalAngle;
    private bool startTap1;
    private bool startTap2;
    private Vector2 center;

    //Boolean indicating whether the user has tapped within the collider of the GameObject
    private bool tapped;

    //Boolean to indicate whether the GameObject has been expanded already
    [HideInInspector]
    public bool expanded;


    // Start is called before the first frame update
    void Start()
    {
     
        expanded = false;
        initialScale = transform.localScale;
        initialPosition = transform.localPosition;
        initialRotation = transform.localRotation;
        startTap1 = true;
        startTap2 = true;
        center = new Vector2(Screen.width / 2, Screen.height / 2);
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tapped && !expanded)
        {
            Expand();
            button.SetActive(true);
        }

        if (expanded)
        {
            //If there is one finger touching the screen, rotate the object based on the angle of the finger to the center of the screenf
            if (Input.touchCount == 1)
            {
                print("One touch");
                startTap2 = true;

                Touch touchZero = Input.GetTouch(0);
                //Store intial position and angle of double touch
                if (startTap1)
                {
                    originalAngle = Vector2.Angle(touchZero.position, center);
                    startTap1 = false;
                }

                float newAngle = Vector2.Angle(touchZero.position, center);


                //Find transform angle in the form of a Vector3
                
                float transformAngle = newAngle - originalAngle;


                var rot = Quaternion.AngleAxis(10 * transformAngle, Vector3.up);
               
                transform.localRotation = rot;
            } else if (Input.touchCount == 2){
                //print("Two touch");
                startTap1 = true;

                // Store both touches.
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);


                //Store intial position and angle of double touch
                if (startTap2)
                {
                    Vector2 doubleTap1 = touchZero.position;
                    Vector2 doubleTap2 = touchOne.position;
                    originalDistance = doubleTap1 - doubleTap2;
                    startTap2 = false;
                }

                print(startTap2);

                //Find new distance and angle between fingers
                Vector2 newDistance = touchZero.position - touchOne.position;


                // Find the magnitude of the vector (the distance) between the touches in each frame.
                float originalMag = originalDistance.magnitude;
                float scaleMag = newDistance.magnitude;

                // Scale factor based on the distances between the original touches and pinches
                float scaleBy = scaleMag / originalMag;

                transform.localScale = currentScale * scaleBy;
                

            } else {
                currentScale = transform.localScale;
                startTap1 = true;
                startTap2 = true;
            }

        }
        
    }


    public void Expand()
    {
        
        transform.localScale = scaleTo;
        transform.localPosition = transformPosition;
        currentScale = transform.localScale;
        foreach (GameObject molecule in molecules)
        {
            molecule.SetActive(false);
        }
        expanded = true;

        tapped = false;
    }

    private void OnMouseDown()
    {
        tapped = true;
    }

    public void activate()
    {
        gameObject.SetActive(true);
    }

}
