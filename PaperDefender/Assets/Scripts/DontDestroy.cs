using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{

   
    void Awake()
    {
        GameObject[] MusicPlayer = GameObject.FindGameObjectsWithTag("dontdestroy");

        if (MusicPlayer.Length > 2)
        {
            Destroy(this.gameObject);
        }
        else
        {
        
            DontDestroyOnLoad(gameObject);
        }
    }


}
