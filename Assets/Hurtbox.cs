using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    public HealthBar health;
    public PlayerMovement cc; 

    private void Start()
    {
        health = transform.GetComponentInParent<HealthBar>();
        cc = transform.GetComponentInParent<PlayerMovement>(); 
    }


}