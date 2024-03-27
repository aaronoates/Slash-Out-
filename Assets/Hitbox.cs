using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Hitbox : MonoBehaviour
{
    //This script will check if a collision occurs and will access the healthbar script to deplete health.

    //Required variables
    public Vector3 v3Knockback = new Vector3(0, 5, 15);
    public LayerMask layerMask;
    public HealthBar healthbar;
    public bool canTakeDamage = true;
    public KeyCode blockKey = KeyCode.B;
    public GameObject Text;
    public bool blocking = false;
    int damage = 2;

    private void OnTriggerEnter(Collider other)
    {
        //Checks if a box collider with the " is trigger " function enabled connects to an object with the specified layer
        if (layerMask == (layerMask | (1 << other.transform.gameObject.layer)))
        {
            Hurtbox h = other.GetComponent<Hurtbox>();
            //activates on hit function to deal required damage.
            if (h != null && other.GetComponent<Hitbox>() == null)
            {
                Debug.Log("HIT");
                OnHit(h);
            }
        }
    }

    protected virtual void OnHit(Hurtbox h)

    {
        if (canTakeDamage)
        {
            //If damage can be taken it will access the healthbar script to reduce damage
            Debug.Log("HIT");
            healthbar.TakeDamage(damage);
            h.cc.v3MoveDirection = v3Knockback;
        }

        if (Input.GetKey(blockKey))
        {
            //If blocking, set the "BLOCK!" text on screen.
            healthbar.TakeDamage(damage);
            Text.SetActive(true);
        }
    }

    public void Update()
    {
        // Similar to the onhit function, activate the "BLOCK!" text on screen when the block button is held.
        if (Input.GetKey(blockKey))
        {
            blocking = true;
            Text.SetActive(true);

        }
        else
        {
            //If block button is released, turn off blocking state and the "BLOCK!" text.
            blocking = false;
            Text.SetActive(false);

        }

    }
}
