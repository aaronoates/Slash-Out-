using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

public class DirectionalSlashes : MonoBehaviour
{
    private float totalRotation = 0f;
    private bool shouldRotate = false;
    private bool shouldRotateleft = false;
    private bool shouldRotateright = false;
    private bool shouldRotateup = false;
    private bool shouldRotatedown = false;
    private bool shouldRotateupRight = false;
    private bool shouldRotateupLeft = false;
    private bool shouldRotatedownLeft = false;
    private bool shouldRotatedownRight = false;
   
        
    public Transform centerObject;
    
    public float rotationSpeed;
    public UnityEngine.Vector3 defaultposition = new UnityEngine.Vector3(128f, 12.7f, -0.5f);
    public UnityEngine.Quaternion defaultrotation = UnityEngine.Quaternion.Euler(0f, 12.251f, 0f);
    
    //public Vector3 defaultrotation = new Vector3(0f, 0f, 0f);
    //private Vector3 neutralPosition = new Vector3(261.3f, 10.4f, 171.7037f);
    // Start is called before the first frame update
    void Start()
    {
        transform.position = defaultposition;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a") && !shouldRotate) // ensures you can't spam an attack, you need to wait until the swing animation finishes.
        {
            
            transform.Rotate(0, 90, 0);
      

            shouldRotate = true;
            shouldRotateleft = true;
            
           
            
            
            
        }

        if (shouldRotate && shouldRotateleft)
        {
            SwipeLeft();
        }

        if (Input.GetKeyDown("d") && !shouldRotate)
        {
            transform.Translate(0f, 0f, 60f);
            transform.Rotate(0, -90, 0);
            

            shouldRotate = true;
            shouldRotateright = true;
            
            
        }

        if (shouldRotate && shouldRotateright)
        {
            SwipeRight();
        }

        if (Input.GetKeyDown("w") && !shouldRotate)
        {
            transform.Translate(-30f, 0f, 40f);
            transform.Rotate(0, 0, -90);
            shouldRotate = true;
            shouldRotateup = true;
        }

        if (shouldRotate && shouldRotateup)
        {
            SwipeUp();
        }

        if (Input.GetKeyDown("s") && !shouldRotate)
        {
            transform.Translate(30f, 60f, 50f);
            transform.Rotate(0, 0, 90);
            shouldRotate = true;
            shouldRotatedown = true;
        }

        if (shouldRotate && shouldRotatedown)
        {
            SwipeDown();
        }


    }

    void SwipeRight()
    {

        //Debug.Log("Center Object Position (SwipeRight): " + centerObject.position);
        
        transform.RotateAround(centerObject.position, UnityEngine.Vector3.up, rotationSpeed * Time.deltaTime);
        totalRotation += rotationSpeed * Time.deltaTime;
       
        if (totalRotation >= 180f)
        {
            shouldRotate = false;
            shouldRotateleft = false;
            transform.position = defaultposition;
            transform.rotation = defaultrotation;
            Debug.Log("Object has rotated 180 degrees, stopping rotation.");
            totalRotation = 0f;

        }
    }

    void SwipeLeft()
    {
        Debug.Log("Center Object Position (SwipeLeft): " + centerObject.position);
        transform.RotateAround(centerObject.position, UnityEngine.Vector3.down, rotationSpeed * Time.deltaTime);
        totalRotation += rotationSpeed * Time.deltaTime;
        if (totalRotation >= 180f)
        {
            shouldRotate = false;
            shouldRotateright = false;
            transform.position = defaultposition;
            transform.rotation = defaultrotation;
            Debug.Log("Object has rotated 180 degrees, stopping rotation.");
            totalRotation = 0f;

        }
    }

    void SwipeUp()
    {
        transform.RotateAround(centerObject.position, UnityEngine.Vector3.forward, rotationSpeed * Time.deltaTime);
        totalRotation += rotationSpeed * Time.deltaTime;
        if (totalRotation >= 180f)
        {
            shouldRotate = false;
            shouldRotateup = false;
            transform.position = defaultposition;
            transform.rotation = defaultrotation;
            Debug.Log("Object has rotated 180 degrees, stopping rotation.");
            totalRotation = 0f;

        }
    }

    void SwipeDown()
    {
        transform.RotateAround(centerObject.position, UnityEngine.Vector3.back, rotationSpeed * Time.deltaTime);
        totalRotation += rotationSpeed * Time.deltaTime;
        if (totalRotation >= 180f)
        {
            shouldRotate = false;
            shouldRotatedown = false;
            transform.position = defaultposition;
            transform.rotation = defaultrotation;
            Debug.Log("Object has rotated 180 degrees, stopping rotation.");
            totalRotation = 0f;

        }
    }
}
