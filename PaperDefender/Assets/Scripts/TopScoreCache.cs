using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopScoreCache : MonoBehaviour
{
    [SerializeField] public int topScoreCache;
    int HighScore;
    

    // Start is called before the first frame update
    void Start()
    {
        SetUpSingleton();

    }

    // Update is called once per frame
    void Update()
    {
        HighScore = FindObjectOfType<GameSession>().GetScore(); 
        if (HighScore > topScoreCache)
        {
            topScoreCache = HighScore;
        }
    }

    private void SetUpSingleton()
    {
        int numberOfMusicPlayers = FindObjectsOfType<DontDestroryBG>().Length;

        if (numberOfMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int ReturnTopScoreCache()
    {
        return topScoreCache;
    }
}
