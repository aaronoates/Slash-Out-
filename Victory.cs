using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    //This script will trigger the win screen when enemy health is depleted.

    //Required variables
    public HealthBar healthbar;
    public Hitbox hit;
    public GameObject Victoryobject;
    public static bool IsGameOver = false;
    public GameObject PlayerHealthBarObject;
    public GameObject EnemyHealthBarObject;
    public GameObject PauseButton;

    public void Update()
    {
        //healthbar.game accesses the healthbar script and returns true if enemy health is depleted.
        if (healthbar.game == true)
        {
            Victoryover();
        }
    }

    public void Victoryover()
    {
        //Sets victory screen and turns off unecessary UI
        Victoryobject.SetActive(true);
        Time.timeScale = 0;
        IsGameOver = true;
        PlayerHealthBarObject.SetActive(false);
        EnemyHealthBarObject.SetActive(false);
        PauseButton.SetActive(false);
    }

    public void NextFight()
    {
        //Transitions to next fight if button is clicked on victory screen
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        IsGameOver = false;
        PlayerHealthBarObject.SetActive(true);
        EnemyHealthBarObject.SetActive(true);
        PauseButton.SetActive(true);
    }

    public void Menu()
    {
        //Transitions to main menu if button is clicked on victory screen
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        IsGameOver = false;
        PlayerHealthBarObject.SetActive(true);
        EnemyHealthBarObject.SetActive(true);
        PauseButton.SetActive(true);
    }

}













