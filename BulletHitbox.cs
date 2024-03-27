using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BulletHitbox : MonoBehaviour
{
    public Vector3 v3Knockback = new Vector3(0, 5, 15);
    //This script will check if a collision occurs and will access the healthbar script to deplete health.
    //Same implementation as Hitbox script but object is destroyed after contact with objects.

    //Required variables
    public LayerMask layerMask;
    public HealthBar healthbar;
    public bool canTakeDamage = true;
    public KeyCode blockKey = KeyCode.B;
    public GameObject Bullet;
    private bool blocking = false;
    public bool game = false;
    public float bulletLifetime = 5f;
    int damage = 2;

    private void Start()
    { // Starts a countdown to destroy bullet if it does not hit anything and is out of camera view
        StartCoroutine(DestroyAfterDelay(bulletLifetime));
    }
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

        }
        //Bullet is destroyed after contact
        Destroy(gameObject);
    }



    public void Update()
    {


        if (Input.GetKey(blockKey))
        {
            //Activate block state if block button is held.
            blocking = true;

        }
        else
        {
            //Deactivate block state if block button is not held.
            blocking = false;

        }

    }
    private IEnumerator DestroyAfterDelay(float delay)
    { // This function will destroy the bullet after the specified delay time

        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

}











