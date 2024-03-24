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
   
       
    public UnityEngine.Transform centerObject; // the object that the sword will rotate around, in this case the player character.
    public UnityEngine.Vector3 swingstartposition;
    public UnityEngine.Vector3 upswingoffset;
    public UnityEngine.Vector3 rightswingoffset;
    public UnityEngine.Vector3 leftswingoffset;
    public UnityEngine.Vector3 downswingoffset;
    public UnityEngine.Vector3 upleftoffset;
    public UnityEngine.Vector3 uprightoffset;
    public UnityEngine.Vector3 downrightoffset;
    public UnityEngine.Vector3 downleftoffset;
    public UnityEngine.Vector3 upleftaxis = new UnityEngine.Vector3(0, -1, 1);
    public float rotationSpeed; // how fast the swing is.
    public UnityEngine.Vector3 defaultposition; // the default position of the sword object.
    public UnityEngine.Quaternion defaultrotation; // the default rotation of the sword object.
    
    
    // Start is called before the first frame update
    void Start()
    {
        defaultposition = transform.position; // moves the sword to the default position.
        defaultrotation = transform.rotation;
        //transform.position = defaultposition;

        Debug.Log(defaultrotation);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a") && !shouldRotate) // ensures you can't spam an attack, you need to wait until the swing animation finishes for should rotate to be set to false.
        {
            shouldRotateright = false;
            shouldRotateup = false;
            shouldRotatedown = false;
            shouldRotatedownLeft = false;
            shouldRotatedownRight = false;
            shouldRotateupLeft = false;
            shouldRotateupRight = false;

            transform.Rotate(0, 90, 0); //rotates the tip of the blade to be facing to the right-hand side of the character before the swing.
            transform.position = swingstartposition + leftswingoffset; // swing start position and offsets are implemented for the purposes of reusability. The programmer can manually set where the swing can start from in the Unity editor instead of hard-coding it.
            Debug.Log(transform.position);
            shouldRotate = true; 
            shouldRotateleft = true;
            
           
            
            
            
        }

        if (shouldRotate && shouldRotateleft) 
        {
            SwipeLeft();
        }

        
        
        if (Input.GetKeyDown("d") && !shouldRotate)
        {
            shouldRotateleft = false;
            shouldRotateup = false;
            shouldRotatedown = false;
            shouldRotatedownLeft = false;
            shouldRotatedownRight = false;
            shouldRotateupLeft = false;
            shouldRotateupRight = false;
          //  transform.Translate(0f, 0f, 60f); //sword needed to be moved so that the swing is in the desired range around the player.
            transform.Rotate(0, -90, 0); // same as above, but facing left
            transform.position = swingstartposition + rightswingoffset;
            Debug.Log(transform.position);

            shouldRotate = true;
            shouldRotateright = true;
            
            
        }

        if (shouldRotate && shouldRotateright)
        {
            SwipeRight();
        }

        if (Input.GetKeyDown("w") && !shouldRotate)
        {
            shouldRotateright = false;
            shouldRotateleft = false;
            shouldRotatedown = false;
            shouldRotatedownLeft = false;
            shouldRotatedownRight = false;
            shouldRotateupLeft = false;
            shouldRotateupRight = false;
            // transform.Translate(-30f, 0f, 40f); // adjusting sword position before swing
            transform.position = swingstartposition + upswingoffset;
            transform.Rotate(0, 0, -90); //rotates the tip of the blade to be pointing downwards before an up-swing.
            shouldRotate = true;
            shouldRotateup = true;
        }

        if (shouldRotate && shouldRotateup)
        {
            SwipeUp();
        }

        if (Input.GetKeyDown("s") && !shouldRotate)
        {
            shouldRotateright = false;
            shouldRotateleft = false;
            shouldRotateup = false;
            //shouldRotatedown = false;
            shouldRotatedownLeft = false;
            shouldRotatedownRight = false;
            shouldRotateupLeft = false;
            shouldRotateupRight = false;
            //transform.Translate(30f, 60f, 50f); // adjusting sword position before swing
            transform.position = swingstartposition + downswingoffset;
            transform.Rotate(0, 0, 90); // rotates the tip of the blade to be facing upwards before a down-swing.
            shouldRotate = true;
            shouldRotatedown = true;
        }

        if (shouldRotate && shouldRotatedown)
        {
            SwipeDown();
        }

        if (Input.GetKeyDown("q") && !shouldRotate)
        {
            shouldRotateright = false;
            shouldRotateleft = false;
            shouldRotateup = false;
            shouldRotatedown = false;
            shouldRotatedownLeft = false;
            shouldRotatedownRight = false;
            //shouldRotateupLeft = false;
            shouldRotateupRight = false;
            transform.position = swingstartposition + upleftoffset;
            transform.Rotate(0, 0, -90);
            transform.Rotate(0, 45, 0);// sets the tip of the blade to be pointing down and to the right before a swing.
            shouldRotate = true;
            shouldRotateupLeft = true;
        }

        if (shouldRotate && shouldRotateupLeft)
        {
            SwipeUp();
            SwipeLeft();
        }

        if (Input.GetKeyDown("e") && !shouldRotate)
        {
            shouldRotateright = false;
            shouldRotateleft = false;
            shouldRotateup = false;
            shouldRotatedown = false;
            shouldRotatedownLeft = false;
            shouldRotatedownRight = false;
            shouldRotateupLeft = false;
            //shouldRotateupRight = false;
            transform.position = swingstartposition + uprightoffset;
            transform.Rotate(0, 0, -90);
            transform.Rotate(0, -45, 0);// sets the tip of the blade to be pointing down and to the right before a swing.
            shouldRotate = true;
            shouldRotateupRight = true;
        }


        if (shouldRotate && shouldRotateupRight)
        {
            SwipeUp();
            SwipeRight();
        }

        if (Input.GetKeyDown("x") && !shouldRotate)
        {
            shouldRotateright = false;
            shouldRotateleft = false;
            shouldRotateup = false;
            shouldRotatedown = false;
            //shouldRotatedownLeft = false;
            shouldRotatedownRight = false;
            shouldRotateupLeft = false;
            shouldRotateupRight = false;
            transform.position = swingstartposition + downleftoffset;
            transform.Rotate(0, 0, 90);
            transform.Rotate(0, 45, 0);// sets the tip of the blade to be pointing down and to the right before a swing.
            shouldRotate = true;
            shouldRotatedownLeft = true;
        }
        if (shouldRotate && shouldRotatedownLeft)
        {
            SwipeDown();
            SwipeLeft();
        }

        if (Input.GetKeyDown("c") && !shouldRotate)
        {
            shouldRotateright = false;
            shouldRotateleft = false;
            shouldRotateup = false;
            shouldRotatedown = false;
            shouldRotatedownLeft = false;
            //shouldRotatedownRight = false;
            shouldRotateupLeft = false;
            shouldRotateupRight = false;
            transform.position = swingstartposition + downrightoffset;
            transform.Rotate(0, 0, 90);
            transform.Rotate(0, -45, 0);// sets the tip of the blade to be pointing down and to the right before a swing.
            shouldRotate = true;
            shouldRotatedownRight = true;
        }
        if (shouldRotate && shouldRotatedownRight)
        {
            SwipeDown();
            SwipeRight();
        }

    }

    void SwipeRight()
    {

        //Debug.Log("Center Object Position (SwipeRight): " + centerObject.position);
        
        transform.RotateAround(centerObject.position, UnityEngine.Vector3.up, rotationSpeed * Time.deltaTime); //rotates the blade around the center point along the y-axis at the given rotation speed
        totalRotation += rotationSpeed * Time.deltaTime;
        Debug.Log(totalRotation);

        if (totalRotation >= 180f) //sword has swung in a 180 degree arc
        {
            shouldRotate = false; // sword can be swung again
            shouldRotateleft = false;
            transform.position = defaultposition; // returns the sword to the default position and rotation.
            transform.rotation = defaultrotation;
            //Debug.Log("Object has rotated 180 degrees, stopping rotation.");
            totalRotation = 0f; // total rotation is reset for the next invocation.

        }
    }

    void SwipeLeft()
    {
        //Debug.Log("Center Object Position (SwipeLeft): " + centerObject.position);
        transform.RotateAround(centerObject.position, UnityEngine.Vector3.down, rotationSpeed * Time.deltaTime);
        totalRotation += rotationSpeed * Time.deltaTime;
       
        if (totalRotation >= 180f)
        {
            shouldRotate = false;
            shouldRotateright = false;
            transform.position = defaultposition; // sets the position of sword back to default position
            transform.rotation = defaultrotation; // sets the rotation of sword back to default rotation

            totalRotation = 0f;

        }
    }

    void SwipeUp()
    {
        transform.RotateAround(centerObject.position, UnityEngine.Vector3.forward, rotationSpeed * Time.deltaTime);
        totalRotation += rotationSpeed * Time.deltaTime;
        Debug.Log(totalRotation);
        if (totalRotation >= 180f)
        {
            shouldRotate = false;
            shouldRotateup = false;
            transform.position = defaultposition;
            transform.rotation = defaultrotation;
            //Debug.Log("Object has rotated 180 degrees, stopping rotation.");
            totalRotation = 0f;

        }
    }

    void SwipeDown()
    {
        transform.RotateAround(centerObject.position, UnityEngine.Vector3.back, rotationSpeed * Time.deltaTime);
        totalRotation += rotationSpeed * Time.deltaTime;
        Debug.Log(totalRotation);
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

    void SwipeUpLeft()
    {
        //transform.RotateAround(centerObject.position, UnityEngine.Vector3.down, rotationSpeed * Time.deltaTime);
        transform.RotateAround(centerObject.position, upleftaxis, rotationSpeed * Time.deltaTime);
        
        
        
        
        totalRotation += rotationSpeed * Time.deltaTime;
        if (totalRotation >= 180f)
        {
            shouldRotate = false;
            shouldRotateupLeft = false;
            transform.position = defaultposition;
            transform.rotation = defaultrotation;
            Debug.Log("Object has rotated 180 degrees, stopping rotation.");
            totalRotation = 0f;


        }
    }

    void SwipeUpRight()
    {
        transform.RotateAround(centerObject.position, UnityEngine.Vector3.forward, rotationSpeed * Time.deltaTime);
        transform.RotateAround(centerObject.position, UnityEngine.Vector3.up, rotationSpeed * Time.deltaTime);
        totalRotation += rotationSpeed * Time.deltaTime;
        if (totalRotation >= 180f)
        {
            shouldRotate = false;
            shouldRotateupRight = false;
            transform.position = defaultposition;
            transform.rotation = defaultrotation;
            Debug.Log("Object has rotated 180 degrees, stopping rotation.");
            totalRotation = 0f;


        }
    }
}
