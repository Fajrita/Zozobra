using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public string sceneName = "";
    public void Start()
    {
        StartCoroutine(SplashScreen(sceneName));
    }

    public void ChangeScenes(string sceneName)
    {
        SceneManager.LoadScene(sceneName); 
    }

    IEnumerator SplashScreen(string sceneName)
    {
        yield return new WaitForSeconds(5);
        ChangeScenes(sceneName);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
