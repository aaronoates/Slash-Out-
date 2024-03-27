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

    public UnityEngine.GameObject character;
    public UnityEngine.Transform centerObject; // the object that the sword will rotate around, in this case the player character.
    public UnityEngine.Vector3 swingstartposition; // the starting position of the swing.
    public UnityEngine.Vector3 leftoffset; // offsets are implemented for the purposes of reusability. (0,0,0) in my environment is not necessarily (0,0,0) in Logan's or Sam's, so the offsets allow users on different computers to adjuct the positions of the sword during swings to fit their environment.
    public UnityEngine.Vector3 rightoffset;
    public UnityEngine.Vector3 upoffset;
    public UnityEngine.Vector3 downoffset;
    public UnityEngine.Vector3 uprightoffset;
    public UnityEngine.Vector3 downrightoffset;
    public UnityEngine.Vector3 upleftoffset;
    public UnityEngine.Vector3 downleftoffset;
    public UnityEngine.Vector3 uprightaxis = new UnityEngine.Vector3(0, 1, 1); // the axes for diagonal swings.
    public UnityEngine.Vector3 upleftaxis = new UnityEngine.Vector3(0, -1, 1);
    public UnityEngine.Vector3 downleftaxis = new UnityEngine.Vector3(0, -1, -1);
    public UnityEngine.Vector3 downrightaxis = new UnityEngine.Vector3(0, 1, -1);
    public float rotationSpeed; // how fast the swing is.
    //public UnityEngine.Vector3 defaultposition; // the default position of the sword object.
    public UnityEngine.Quaternion defaultrotation; // the default rotation of the sword object.


    // Start is called before the first frame update
    void Start()
    {
        transform.position = character.transform.position + swingstartposition; // moves the sword to the default position
        defaultrotation = transform.rotation; // sets the default rotation of the sword.


    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown("a") && !shouldRotate) // ensures you can't spam an attack, you need to wait until the swing animation finishes for should rotate to be set to false.
        {

            shouldRotateright = false; // these booleans ensure that if you are swinging in one direction, say up, you cant swing in any other direction.
            shouldRotateup = false;
            shouldRotatedown = false;
            shouldRotatedownLeft = false;
            shouldRotatedownRight = false;
            shouldRotateupLeft = false;
            shouldRotateupRight = false;
            transform.position = character.transform.position + swingstartposition;
            transform.Rotate(0, 90, 0); //rotates the tip of the blade to be facing to the right-hand side of the character before the swing.
             // swing start position and offsets are implemented for the purposes of reusability. The programmer can manually set where the swing can start from in the Unity editor instead of hard-coding it.

            shouldRotate = true;
            shouldRotateleft = true;





        }

        if (shouldRotate && shouldRotateleft)
        {
            Swipe(UnityEngine.Vector3.down, shouldRotateleft);
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
            transform.position = character.transform.position + swingstartposition;
            //  transform.Translate(0f, 0f, 60f); //sword needed to be moved so that the swing is in the desired range around the player.
            transform.Rotate(0, -90, 0); // same as above, but facing left
            
            //Debug.Log(transform.position);

            shouldRotate = true;
            shouldRotateright = true;


        }

        if (shouldRotate && shouldRotateright)
        {
            Swipe(UnityEngine.Vector3.up, shouldRotateright);
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

            transform.position = character.transform.position + swingstartposition;
            transform.Rotate(0, 0, -90); //rotates the tip of the blade to be pointing downwards before an up-swing.
            shouldRotate = true;
            shouldRotateup = true;
        }

        if (shouldRotate && shouldRotateup)
        {
            Swipe(UnityEngine.Vector3.forward, shouldRotateup);
        }

        if (Input.GetKeyDown("s") && !shouldRotate)
        {
            shouldRotateright = false;
            shouldRotateleft = false;
            shouldRotateup = false;

            shouldRotatedownLeft = false;
            shouldRotatedownRight = false;
            shouldRotateupLeft = false;
            shouldRotateupRight = false;

            transform.position = character.transform.position + swingstartposition;
            transform.Rotate(0, 0, 90); // rotates the tip of the blade to be facing upwards before a down-swing.
            shouldRotate = true;
            shouldRotatedown = true;
        }

        if (shouldRotate && shouldRotatedown)
        {
            Swipe(UnityEngine.Vector3.back, shouldRotatedown);
        }

        if (Input.GetKeyDown("q") && !shouldRotate)
        {
            shouldRotateright = false;
            shouldRotateleft = false;
            shouldRotateup = false;
            shouldRotatedown = false;
            shouldRotatedownLeft = false;
            shouldRotatedownRight = false;

            shouldRotateupRight = false;
            transform.position = character.transform.position + swingstartposition;
            transform.Rotate(0, 0, -90);
            transform.Rotate(0, 45, 0);// sets the tip of the blade to be pointing down and to the right before a swing.
            shouldRotate = true;
            shouldRotateupLeft = true;
        }

        if (shouldRotate && shouldRotateupLeft)
        {
            Swipe(upleftaxis, shouldRotateupLeft);
            

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

            transform.position = character.transform.position + swingstartposition;
            transform.Rotate(0, 0, -90);
            transform.Rotate(0, -45, 0);// sets the tip of the blade to be pointing down and to the right before a swing.
            shouldRotate = true;
            shouldRotateupRight = true;
        }


        if (shouldRotate && shouldRotateupRight)
        {
            Swipe(uprightaxis, shouldRotateupRight);
            
        }

        if (Input.GetKeyDown("x") && !shouldRotate)
        {
            shouldRotateright = false;
            shouldRotateleft = false;
            shouldRotateup = false;
            shouldRotatedown = false;

            shouldRotatedownRight = false;
            shouldRotateupLeft = false;
            shouldRotateupRight = false;
            transform.position = character.transform.position + swingstartposition;
            transform.Rotate(0, 0, 90);
            transform.Rotate(0, 45, 0);// sets the tip of the blade to be pointing down and to the right before a swing.
            shouldRotate = true;
            shouldRotatedownLeft = true;
        }
        if (shouldRotate && shouldRotatedownLeft)
        {
            Swipe(UnityEngine.Vector3.back, shouldRotatedownLeft);
            Swipe(UnityEngine.Vector3.down, shouldRotatedownLeft);
        }

        if (Input.GetKeyDown("c") && !shouldRotate)
        {
            shouldRotateright = false;
            shouldRotateleft = false;
            shouldRotateup = false;
            shouldRotatedown = false;
            shouldRotatedownLeft = false;

            shouldRotateupLeft = false;
            shouldRotateupRight = false;
            transform.position = character.transform.position + swingstartposition;
            transform.Rotate(0, 0, 90);
            transform.Rotate(0, -45, 0);// sets the tip of the blade to be pointing down and to the right before a swing.
            shouldRotate = true;
            shouldRotatedownRight = true;
        }
        if (shouldRotate && shouldRotatedownRight)
        {
            Swipe(downrightaxis, shouldRotatedownRight);
            //Swipe(UnityEngine.Vector3.up, shouldRotatedownRight);
        }

    }

    void Swipe(UnityEngine.Vector3 rotationaxis, bool shouldRotateThisWay)
    {



        transform.RotateAround(centerObject.position, rotationaxis, rotationSpeed * Time.deltaTime); //rotates the blade around the center point along the given axis at the given rotation speed
        totalRotation += rotationSpeed * Time.deltaTime; // the rotation value at the current frame.


        if (totalRotation >= 180f) //sword has swung in a 180 degree arc
        {
            shouldRotate = false; // sword can be swung again
            shouldRotateThisWay = false;
            transform.position = character.transform.position + swingstartposition; // returns the sword to the default position and rotation.
            transform.rotation = defaultrotation;
            //Debug.Log("Object has rotated 180 degrees, stopping rotation.");
            totalRotation = 0f; // total rotation is reset for the next invocation.

        }
    }



}