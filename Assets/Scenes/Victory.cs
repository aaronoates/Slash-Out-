using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public HealthBar healthbar;
    public Hitbox hit;
    public GameObject Victoryobject;
    public static bool IsGameOver = false;
    public GameObject PlayerHealthBarObject;
    public GameObject EnemyHealthBarObject;
    public GameObject PauseButton;

    public void Update()
    {

        if (hit.game == true)
        {
            Victoryover();
        }
    }

    public void Victoryover()
    {
        Victoryobject.SetActive(true);
        Time.timeScale = 0;
        IsGameOver = true;
        PlayerHealthBarObject.SetActive(false);
        EnemyHealthBarObject.SetActive(false);
        PauseButton.SetActive(false);
    }

    public void NextFight()
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


