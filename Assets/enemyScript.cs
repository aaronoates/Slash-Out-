using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class enemyScript : MonoBehaviour
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
    private int[] waitTimes = new int[] { 1000, 3000, 5000, 7000 };
    private string[] colors = new string[] { "red", "blue", "yellow", "green" };
    


    public Transform centerObject; // the object that the sword will rotate around, in this case the player character.

    public float rotationSpeed; // how fast the swing is.
    public UnityEngine.Vector3 defaultposition = new UnityEngine.Vector3(128f, 12.7f, -0.5f); // the default position of the sword object.
    public UnityEngine.Quaternion defaultrotation = UnityEngine.Quaternion.Euler(0f, -190.65f, 0f); // the default rotation of the sword object.


    // Start is called before the first frame update
    void Start()
    {
        transform.position = defaultposition; // moves the sword to the default position.

        
    }

    // Update is called once per frame
    void Update()
    {
        int waitTime = Random.Range(0, waitTimes.Length);
        Thread.Sleep(waitTime);
        int color = Random.Range(0, colors.Length);

        if (colors[color] == "red" && !shouldRotate) // ensures you can't spam an attack, you need to wait until the swing animation finishes for should rotate to be set to false.
        {
            Debug.Log("turn blade red");
            shouldRotateright = false;
            shouldRotateup = false;
            shouldRotatedown = false;
            shouldRotatedownLeft = false;
            shouldRotatedownRight = false;
            shouldRotateupLeft = false;
            shouldRotateupRight = false;

            transform.Rotate(0, 90, 0); //rotates the tip of the blade to be facing to the right-hand side of the character before the swing.


            shouldRotate = true;
            shouldRotateleft = true;





        }

        if (shouldRotate && shouldRotateleft)
        {
            SwipeLeft();
        }

        if (colors[color] == "blue" && !shouldRotate)
        {
            Debug.Log("turn blade blue");
            shouldRotateleft = false;
            shouldRotateup = false;
            shouldRotatedown = false;
            shouldRotatedownLeft = false;
            shouldRotatedownRight = false;
            shouldRotateupLeft = false;
            shouldRotateupRight = false;
            transform.Translate(0f, 0f, 60f); //sword needed to be moved so that the swing is in the desired range around the player.
            transform.Rotate(0, -90, 0); // same as above, but facing left


            shouldRotate = true;
            shouldRotateright = true;


        }

        if (shouldRotate && shouldRotateright)
        {
            SwipeRight();
        }

        if (colors[color] == "yellow" && !shouldRotate)
        {
            Debug.Log("turn blade blue");
            shouldRotateright = false;
            shouldRotateleft = false;
            shouldRotatedown = false;
            shouldRotatedownLeft = false;
            shouldRotatedownRight = false;
            shouldRotateupLeft = false;
            shouldRotateupRight = false;
            transform.Translate(-30f, 0f, 40f); // adjusting sword position before swing
            transform.Rotate(0, 0, -90); //rotates the tip of the blade to be pointing downwards before an up-swing.
            shouldRotate = true;
            shouldRotateup = true;
        }

        if (shouldRotate && shouldRotateup)
        {
            SwipeUp();
        }

        if (colors[color] == "green" && !shouldRotate)
        {
            shouldRotateright = false;
            shouldRotateleft = false;
            shouldRotateup = false;
            //shouldRotatedown = false;
            shouldRotatedownLeft = false;
            shouldRotatedownRight = false;
            shouldRotateupLeft = false;
            shouldRotateupRight = false;
            transform.Translate(30f, 60f, 50f); // adjusting sword position before swing
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

            transform.Rotate(0, 45, -90); // sets the tip of the blade to be pointing down and to the right before a swing.
            shouldRotate = true;
            shouldRotateupLeft = true;
        }

        if (shouldRotate && shouldRotateupLeft)
        {
            SwipeUpLeft();
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
        Debug.Log(totalRotation);
        if (totalRotation >= 180f)
        {
            shouldRotate = false;
            shouldRotateright = false;
            transform.position = defaultposition;
            transform.rotation = defaultrotation;
            //Debug.Log("Object has rotated 180 degrees, stopping rotation.");
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
        transform.RotateAround(centerObject.position, UnityEngine.Vector3.forward, rotationSpeed * Time.deltaTime);
        transform.RotateAround(centerObject.position, UnityEngine.Vector3.down, rotationSpeed * Time.deltaTime);
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
}
