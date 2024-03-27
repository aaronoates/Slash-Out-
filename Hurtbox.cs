using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    //This script will send object health and position data to hitbox to trigger "onhit" function.
    public HealthBar health;
    public PlayerMovement cc;

    private void Start()
    {
        //Retrieves object health and position.
        health = transform.GetComponentInParent<HealthBar>();
        cc = transform.GetComponentInParent<PlayerMovement>();
    }


}



