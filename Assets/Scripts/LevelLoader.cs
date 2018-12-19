using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    
    [SerializeField] int splashScreenDelay = 3;
    int currentSceneIndex;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(SplashScreenPause());
        }
    }

    IEnumerator SplashScreenPause()
    {
        yield return new WaitForSeconds(splashScreenDelay);
        LoadNextLevel();
    }

public void LoadNextLevel()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
