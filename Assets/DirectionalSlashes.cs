using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalSlashes : MonoBehaviour
{
    private float totalRotation = 0f;
    private bool shouldRotate = true;

    public float rotationSpeed;
    //private Vector3 neutralPosition = new Vector3(261.3f, 10.4f, 171.7037f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldRotate)
        {
            transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
            totalRotation += rotationSpeed * Time.deltaTime;
            Debug.Log(totalRotation);
            if (totalRotation >= 180f)
            {
                shouldRotate = false;
                Debug.Log("Object has rotated 180 degrees, stopping rotation.");
               
            }
        }
        

    }
}
