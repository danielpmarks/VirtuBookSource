using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public GameObject button;

    public void Start()
    {
        button.SetActive(false);
    }
    

    public void Shrink()
    {
        print("button pressed");
        foreach (Transform child in transform)
        {
            Select childSelect = child.GetComponent<Select>();
            Vector3 initialPosition = childSelect.initialPosition;
            Vector3 initialScale = childSelect.initialScale;
            Quaternion initialRotation = childSelect.initialRotation;

            Transform childTransform = child.GetComponent<Transform>();

            childTransform.localScale = initialScale;
            childTransform.localPosition = initialPosition;
            childTransform.localRotation = initialRotation;

            child.gameObject.SetActive(true);

            childSelect.expanded = false;
            button.SetActive(false);
        }
    }
}
