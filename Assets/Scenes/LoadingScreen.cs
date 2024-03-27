using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadingScreen : MonoBehaviour
{
    
    public GameObject Loading_Screen;
    public Image loadingBarFill;

    public void LoadScene(int SceneId)
    {
        StartCoroutine(LoadSceneAsync(SceneId));
    }

    IEnumerator LoadSceneAsync (int SceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneId);
        Loading_Screen.SetActive(true);
        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            loadingBarFill.fillAmount = progressValue;
            yield return null;
        }
    }
}
