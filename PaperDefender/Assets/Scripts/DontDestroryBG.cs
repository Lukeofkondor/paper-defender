using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroryBG : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SetUpSingleton();
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


}
