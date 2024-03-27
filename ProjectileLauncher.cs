using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    //This script will create more projectile objects and fire them at the player at specified intervals.

    //Required Variables.
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public float fireInterval = 1f;
    private float timeSinceLastFire = 0f;
    public Vector3 v3Direction;
    public float fSpeed = 0;


    void Update()
    {
        // Increment time since last fire
        timeSinceLastFire += Time.deltaTime;

        // Check if enough time has passed to fire again
        if (timeSinceLastFire >= fireInterval)
        {
            FireProjectile(v3Direction, fSpeed);

            // Reset the timer
            timeSinceLastFire = 0f;
        }
    }

    void FireProjectile(Vector3 v3Direction, float fSpeed)
    {
        // Instantiate a new projectile
        GameObject newProjectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        newProjectile.SetActive(true);

        // Get the Projectile component from the instantiated projectile
        Projectile projectileComponent = newProjectile.GetComponent<Projectile>();

        if (projectileComponent != null)

            // Set the direction and speed of the projectile
            projectileComponent.Shoot(v3Direction, bulletSpeed);
    }
}








