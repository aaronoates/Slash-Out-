using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Hitbox : MonoBehaviour
{

    public Vector3 v3Knockback = new Vector3(0, 5, 15);

    public Hitbox hit;
    public LayerMask layerMask;
    public HealthBar healthbar;

    public int maxHealth = 100;
    public int currentHealth;

    public bool game = false;


    private void OnTriggerEnter(Collider other)
    {
        if (layerMask == (layerMask | (1 << other.transform.gameObject.layer)))
        {
            Hurtbox h = other.GetComponent<Hurtbox>();

            if (h != null && other.GetComponent<Hitbox>() == null)
            {
                Debug.Log("HIT");
                OnHit(h);
            }

            //if (h != null && other.GetComponent<Hitbox>() != null)
           // {
              //  Debug.Log("NULL");
              //  Nulling();
            //}
        }

    }

    protected virtual void OnHit(Hurtbox h)
    {
        Debug.Log("HIT");
        TakeDamage(1);
        h.cc.v3MoveDirection = v3Knockback;

    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthbar.SetHealth(currentHealth);
    }

    //public void Nulling()
   // {
       // Debug.Log("NULLIFICATION");

       // Collider hitboxCollider = GetComponent<Collider>();

      //  if (hitboxCollider != null)
       // {
          //  hitboxCollider.enabled = false;
        
          //  StartCoroutine(ReEnableCollider(hitboxCollider));

        //}


    //}

   // IEnumerator ReEnableCollider(Collider collider)
  //  {
       // yield return new WaitForSeconds(0.5f);
       // collider.enabled = true;


    //}
    public void Update()
    {
        if (currentHealth <= 0){

            game = true;
            Debug.Log("DEFEATED");

        }
    }
}