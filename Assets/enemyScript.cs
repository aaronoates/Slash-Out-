using System.Collections;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    private bool isSwinging = false; // true if the sword is mid-swing.

    private float totalRotation = 0f; // keeps track of how far the sword has rotated (in degrees) throughout the current swing.
    private int[] waitTimes = new int[] { 1000, 3000, 5000, 7000 };
    private string[] directions = new string[] { "up", "down", "left", "right", "upleft", "upright", "downleft", "downright" }; // the different directions the sword can swing in.
    private UnityEngine.Vector3[] offsets = new UnityEngine.Vector3[8]; // offsets for each swing. These are implemented for reusability. If the code is imported into another scene, the offsets can be adjusted to move the sword to the desired position before the swing.
    private UnityEngine.Vector3[] axes = new UnityEngine.Vector3[8]; // rotation axes for each swing direction
    public Transform centerObject; // the object around which the sword rotates.
    public float rotationSpeed; // the speed at which the blade rotates.
    public UnityEngine.Vector3 swingstartposition; // the position from which the swing starts.
    public UnityEngine.Vector3 defaultoffset;
    public UnityEngine.Vector3 upswingoffset;
    public UnityEngine.Vector3 rightswingoffset;
    public UnityEngine.Vector3 leftswingoffset;
    public UnityEngine.Vector3 downswingoffset;
    public UnityEngine.Vector3 upleftoffset;
    public UnityEngine.Vector3 uprightoffset;
    public UnityEngine.Vector3 downrightoffset;
    public UnityEngine.Vector3 downleftoffset; // the offsets to be put into the offsets array.
    public UnityEngine.Vector3 trueDefault; // the default position + the default offset (if necessary when imported to a different scene).
    public UnityEngine.Vector3 upleftaxis;
    public UnityEngine.Vector3 uprightaxis;
    public UnityEngine.Vector3 downleftaxis;
    public UnityEngine.Vector3 downrightaxis; // the axes to be added to the axes array.
    private Vector3 defaultPosition; // the default position of the sword
    private Quaternion defaultRotation; // the default rotation of the sword.

    void Start()
    {
        defaultPosition = transform.position;
        defaultRotation = transform.rotation;
        offsets[0] = upswingoffset;
        offsets[1] = downswingoffset;
        offsets[2] = leftswingoffset;
        offsets[3] = rightswingoffset;
        offsets[4] = upleftoffset;
        offsets[5] = uprightoffset;
        offsets[6] = downleftoffset;
        offsets[7] = downrightoffset;
        axes[0] = UnityEngine.Vector3.forward;
        axes[1] = UnityEngine.Vector3.back;
        axes[2] = UnityEngine.Vector3.down;
        axes[3] = UnityEngine.Vector3.up;
        axes[4] = upleftaxis;
        axes[5] = uprightaxis;
        axes[6] = downleftaxis;
        axes[7] = downrightaxis; //adds the elements to each respective array
        StartCoroutine(PerformRandomSwings()); // coroutines allow different programs to be running at the same time.
    }

    IEnumerator PerformRandomSwings() // an interface that is used to iterate over collections of objects or elements, in this case wait times, directions.
    {
        while (true)
        {
            int waitTimeIndex = Random.Range(0, waitTimes.Length); // the index of randomly selected wait time before the next attack
            int directionIndex = Random.Range(0, directions.Length); // the index of randomly selected direction of the next attack.

            yield return new WaitForSeconds(waitTimes[waitTimeIndex] / 1000f); // gets wait time and converts the wait time to seconds.

            string direction = directions[directionIndex]; // the randomly selected swing direction.
            PerformSwing(direction);
        }
    }

    void PerformSwing(string direction)
    {
        if (!isSwinging) // ensures that a new swing cannot begin until the current swing is complete.
        {
            isSwinging = true;

            StartCoroutine(AnimateSwing(direction));
        }
    }

    IEnumerator AnimateSwing(string direction)
    {
        Vector3 swingOffset = GetSwingOffset(direction);
        Vector3 rotationAxis = GetRotationAxis(direction);
        Vector3 startPosition = transform.position; // sets the current position to be the start position of the swing.
        Quaternion startRotation = transform.rotation; // sets the current rotation to be the start rotation of the swing.
        float targetRotation = 180f; // 180 degrees of rotation.

        while (totalRotation < targetRotation)
        {
            float angle = rotationSpeed * Time.deltaTime;
            transform.RotateAround(centerObject.position, rotationAxis, angle); // rotates the sword around the center object along the axis of rotation at the given rotation speed.
            totalRotation += Mathf.Abs(angle); // increments the total rotation frame-by-frame.
            yield return null;
        }

        transform.position = startPosition + swingOffset; // sets the start position of the sword according to the given offset.
        transform.rotation = startRotation;

        totalRotation = 0f; // resets the rotation value to be 0 for the next rotation.
        isSwinging = false; //swing has completed.
    }

    Vector3 GetSwingOffset(string direction) // chooses the offset based on the input direction.
    {

        if (direction == "up")
        {
            return offsets[0];
        }
        else if (direction == "down")
        {
            return offsets[1];
        }
        else if (direction == "left")
        {
            return offsets[2];
        }
        else if (direction == "right")
        {
            return offsets[3];
        }
        else if (direction == "upleft")
        {
            return offsets[4];
        }
        else if (direction == "upright")
        {
            return offsets[5];
        }
        else if (direction == "downleft")
        {
            return offsets[6];
        }
        else
        {
            return offsets[7];
        }

    }

    Vector3 GetRotationAxis(string direction)
    {
        //chooses the rotation axis based on the input direction.
        if (direction == "up")
        {
            return axes[0];
        }
        else if (direction == "down")
        {
            return axes[1];
        }
        else if (direction == "left")
        {
            return axes[2];
        }
        else if (direction == "right")
        {
            return axes[3];
        }
        else if (direction == "upleft")
        {
            return axes[4];
        }
        else if (direction == "upright")
        {
            return axes[5];
        }
        else if (direction == "downleft")
        {
            return axes[6];
        }
        else
        {
            return axes[7];
        }

    }

    Vector3 GetInitialRotation(string direction) // sets the initial rotation to be whatever it needs to be before swinging. For example, before swinging up, the sword would need to be pointing down.
    {
        switch (direction)
        {
            case "up":
                return new Vector3(0f, 0f, -90f);
            case "down":
                return new Vector3(0f, 0f, 90f);
            case "left":
                return new Vector3(0f, 90f, 0f);
            case "right":
                return new Vector3(0f, -90f, 0f);
            case "upleft":
                return new Vector3(0f, 45f, -90f);
            case "upright":
                return new Vector3(0f, -45f, -90f);
            case "downleft":
                return new Vector3(0f, 45f, 90f);
            case "downright":
                return new Vector3(0f, -45f, 90f);
            default:
                return Vector3.zero;
        }
    }


}




