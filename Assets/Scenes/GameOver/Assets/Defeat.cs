using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Defeat : MonoBehaviour
{
    public HealthBar healthbar;
    public Hitbox hit;
    public GameObject GameOverobject;
    public static bool IsGameOver = false;
    public GameObject PlayerHealthBarObject;
    public GameObject EnemyHealthBarObject;
    public GameObject PauseButton;

    public void Update()
    {
        
        if (hit.game == true)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        GameOverobject.SetActive(true);
        Time.timeScale = 0;
        IsGameOver = true;
        PlayerHealthBarObject.SetActive(false);
        EnemyHealthBarObject.SetActive(false);
        PauseButton.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        IsGameOver = false;
        PlayerHealthBarObject.SetActive(true);
        EnemyHealthBarObject.SetActive(true);
        PauseButton.SetActive(true);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        IsGameOver = false;
        PlayerHealthBarObject.SetActive(true);
        EnemyHealthBarObject.SetActive(true);
        PauseButton.SetActive(true);
    }

}
