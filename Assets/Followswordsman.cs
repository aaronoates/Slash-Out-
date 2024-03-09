using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followswordsman : MonoBehaviour
{
    public GameObject swordsman;
    private Vector3 offset = new Vector3(20, 100, 45);
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = swordsman.transform.position + offset;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
