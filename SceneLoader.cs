
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.ComponentModel;

public class SceneLoader : MonoBehaviour
{

    //Required variables

    //This script will create a loading screen and will then transition into the next scene of the game.
    public GameObject LoadingScreen;
    public Slider loadingbar;
    public GameObject BoutSelect;
    public GameObject Menu;


    public void LoadScene(int levelIndex)
    {
        //Will transition into specified scene. levelIndex contains the number value for which scene to transition to.
        StartCoroutine(LoadSceneAsynchronously(levelIndex));
    }

    IEnumerator LoadSceneAsynchronously(int levelIndex)
    {
        //Will remove UI elements to display loading screen.
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);
        BoutSelect.SetActive(false);
        Menu.SetActive(false);
        LoadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            loadingbar.value = operation.progress;
            yield return null;
        }
    }

}


