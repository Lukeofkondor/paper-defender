using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    int score = 0;
    int health = 0;
    [SerializeField] int topScore = 0;

    void Start()
    {
        int width = 640; // or something else
        int height = 960; // or something else

        bool isFullScreen = false;

        Screen.SetResolution(width, height, isFullScreen);

        SetUpSingleton();
    }

    private void Update()
    {
        if(score > topScore)
        {
            topScore = score;
        }
    }



    private void SetUpSingleton()
    {
        int numberOfGameSessions = FindObjectsOfType<GameSession>().Length;

        if (numberOfGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public int GetTopScore()
    {

        return topScore;
    }

    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
    }

   
    public int GetHealth()
    {
        return health;
    }



    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public void WinGame()
    {

    }



}
