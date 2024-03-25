using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Block : MonoBehaviour
{
    public LayerMask layerMask;
    public HealthBar healthbar;
    public int currentHealth;
    public DirectionalSlashes slash;
    public UnityEngine.Vector3 defaultposition = new UnityEngine.Vector3(128f, 12.7f, -0.5f); // the default position of the sword object.
    public UnityEngine.Quaternion defaultrotation = UnityEngine.Quaternion.Euler(0f, 12.251f, 0f); // the default rotation of the sword object.
    void blockdamage(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player")) 
        {
            healthbar.SetHealth(currentHealth);
            slash.transform.rotation = defaultrotation;
            slash.transform.position = defaultposition;
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            healthbar.SetHealth(currentHealth);
            slash.transform.rotation = defaultrotation;
            slash.transform.position = defaultposition;
        }
    }
}
