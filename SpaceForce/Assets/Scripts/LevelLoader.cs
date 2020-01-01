using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    int currentSceneIndex;

    private void Start()
    {
        this.currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (this.currentSceneIndex == 0)
            StartCoroutine(this.WaitOutSplashScreen(seconds: 3));
    }

    public void LoadSplash()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(this.currentSceneIndex + 1);
    }

    public void RestartScene()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(this.currentSceneIndex);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene("Start");
    }

    public IEnumerator WaitOutSplashScreen(int seconds)
    {
        yield return new WaitForSeconds(seconds);

        this.LoadNextScene();
    }

    public void LoadYouLose()
    {
        SceneManager.LoadScene("LoseScreen");
    }
}
