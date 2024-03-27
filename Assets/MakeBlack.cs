using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBlack : MonoBehaviour
{
    //This script will make the object become the colour black.
    //Required variables
    private Renderer rend;

    void Start()
    {
        //Uses rend unity function to get the renderer of object and sets the material colour to black
        rend = GetComponent<Renderer>(); 
        rend.material.color = Color.black; 
    }

}
