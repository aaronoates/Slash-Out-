using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Defeat : MonoBehaviour
{
    //This script will trigger the loss screen when player health is depleted.

    //Required variables 
    public HealthBar healthbar;
    public Hitbox hit;
    public GameObject GameOverobject;
    public static bool IsGameOver = false;
    public GameObject PlayerHealthBarObject;
    public GameObject EnemyHealthBarObject;
    public GameObject PauseButton;

    public void Update()
    {
        //healthbar.game accesses the healthbar script and returns true if player health is depleted.
        if (healthbar.game == true)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        //Sets defeat screen and turns off unecessary UI
        GameOverobject.SetActive(true);
        Time.timeScale = 0;
        IsGameOver = true;
        PlayerHealthBarObject.SetActive(false);
        EnemyHealthBarObject.SetActive(false);
        PauseButton.SetActive(false);
    }

    public void Restart()
    {
        //Restarts the scene if button is clicked on defeat screen
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        IsGameOver = false;
        PlayerHealthBarObject.SetActive(true);
        EnemyHealthBarObject.SetActive(true);
        PauseButton.SetActive(true);
    }

    public void Menu()
    {
        //Transitions to main menu if button is clicked on defeat screen
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        IsGameOver = false;
        PlayerHealthBarObject.SetActive(true);
        EnemyHealthBarObject.SetActive(true);
        PauseButton.SetActive(true);
    }

}
