using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //This script will move the projectile in a specified direction at a specified speed.

    //Required variables
    public Vector3 v3Direction;
    public float fSpeed = 0;
    private Rigidbody rb;



    void Update()
    {
        // update direction and speed to new values while projectile moves.
        this.transform.position += v3Direction * fSpeed * Time.deltaTime;
    }

    public void Shoot(Vector3 v3Direction, float fSpeed)
    {
        //Gives the specified speed and direction to object
        this.fSpeed = fSpeed;
        this.v3Direction = v3Direction;
    }




}











