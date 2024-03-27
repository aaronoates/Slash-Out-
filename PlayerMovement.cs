using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour // Changed so wasd = ijkl
{
    //This script will give the player object movement using the I, J, K, and L keys.

    //Required variables.
    public float fMovespeed = 20;
    public float fGravity = -20;
    public float fJumpSpeed = 20;

    private CharacterController m_Controller;
    public Vector3 v3MoveDirection;
    private Animator m_Anim;

    public float fDrag = 0.085f;

    public float fTopSpeed = 20;
    public Vector3 v3MoveDirectionFlattened;

    void Start()
    {
        // Retrieves character controller, and animation components from unity 
        m_Controller = GetComponent<CharacterController>();
        m_Anim = GetComponentInChildren<Animator>();
    }

    void LateUpdate()
    {
        // Checks if one direction is pressed and others are not. One direction is pressed, object will move in desired direction through sending transform data to movement input variable.
        Vector3 v3UserInput = new Vector3();
        if (!Input.GetKey(KeyCode.I) && !Input.GetKey(KeyCode.J) && !Input.GetKey(KeyCode.K) && !Input.GetKey(KeyCode.L))
        {
            v3UserInput = Vector3.zero;
        }
        if (Input.GetKey(KeyCode.I))
        {
            v3UserInput += transform.forward;
        }

        if (Input.GetKey(KeyCode.L))
        {
            v3UserInput += -transform.right;
        }

        if (Input.GetKey(KeyCode.K))
        {
            v3UserInput += -transform.forward;
        }

        if (Input.GetKey(KeyCode.J))
        {
            v3UserInput += transform.right;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (m_Controller.isGrounded)
            {
                v3MoveDirection.y = fJumpSpeed;
            }
        }

        v3MoveDirectionFlattened = v3MoveDirection;
        v3MoveDirectionFlattened.y = 0;
        v3UserInput.y = 0;

        //Ensures movement does not exceed top speed.

        if ((v3MoveDirectionFlattened + v3UserInput).magnitude > fTopSpeed)
        {
            Vector3 v3Inverse = v3MoveDirectionFlattened.normalized * -1;

            Vector3 v3AdjustedInput = (Vector3.Dot(v3UserInput, v3MoveDirectionFlattened.normalized) * v3Inverse) + v3UserInput;
            v3UserInput = v3MoveDirection + (v3AdjustedInput * fMovespeed * Time.deltaTime);
            v3MoveDirection = v3UserInput;
        }
        else
        {
            //Move normally if top speed is not exceeded
            v3MoveDirection += v3UserInput.normalized * fMovespeed * Time.deltaTime;
        }

        //Activates controller movement

        m_Controller.Move(v3MoveDirection * Time.deltaTime);

        Vector3 v3LookDir = v3MoveDirection;
        v3LookDir.y = 0;

        transform.LookAt(transform.position + v3LookDir);
    }

}








