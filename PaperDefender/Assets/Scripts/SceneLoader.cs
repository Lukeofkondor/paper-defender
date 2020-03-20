using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 2f;

    public void LoadGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(1);
        FindObjectOfType<GameSession>().ResetGame();

    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
       
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }

    public void LoadGameOver()
    {
        StartCoroutine(GameOver());

    }

    IEnumerator GameOver()
    {

       
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene(2);


    }

    public int ReturnSceneNumber()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        return currentSceneIndex;
    }


}
