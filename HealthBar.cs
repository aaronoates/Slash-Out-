using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
public class HealthBar : MonoBehaviour

{
    //This script manages the player and enemy healthbars. All "onhit" functions will send damage data to this script to reduce health.

    //Required variables.
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public bool blocking = false;
    public int maxHealth = 100;
    public int currentHealth;
    public bool game = false;


    public void SetMaxHealth(int health)
    {
        //Sets the max health to the on screen healthbar.
        slider.maxValue = health;
        slider.value = health;
        //Gives the on screen healthbar green health when health is high, yellow when health is half, and red when health is low.
        fill.color = gradient.Evaluate(1f);

    }
    public void SetHealth(int health)
    {
        //Sets health to reduced value after damage is taken.
        slider.value = health;
        //Colour is updated to represent damage taken.
        fill.color = gradient.Evaluate(slider.normalizedValue);

    }

    public void TakeDamage(int damage)
    {
        if (!blocking) // If not blocking, take full damage
        {
            currentHealth -= damage;
        }
        else // If blocking, take reduced damage
        {
            currentHealth -= damage / 2;
        }

        SetHealth(currentHealth);
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            //Sets game to true and sends data to Victory and Defeat scripts to trigger win and loss screens.

            game = true;


        }
    }


}




