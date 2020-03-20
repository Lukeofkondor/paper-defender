using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonAndLowPass : MonoBehaviour
{
    [SerializeField] float lowFreq = 3000f;
    [SerializeField] float highFreq = 8000f;

    private AudioLowPassFilter LowPassFilter;
    float lowPassTimer = 2f;

    void Awake()
    {
        GameObject[] MusicPlayer = GameObject.FindGameObjectsWithTag("dontdestroy");
        LowPassFilter = GetComponent<AudioLowPassFilter>();
        SetUpSingleton();

    }


    private void SetUpSingleton()
    
    {
        int numberOfMusicPlayers = FindObjectsOfType<SingletonAndLowPass>().Length;

        if (numberOfMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Start()
    {

    }

    public void Update()
    {
        LowPassActivate();
    }

    private void LowPassActivate()
    {
        int SceneNumber = FindObjectOfType<SceneLoader>().ReturnSceneNumber();
        if (SceneNumber == 1)
        {
            LowPassFilter.cutoffFrequency = highFreq;
        }
        else
        {
            StartCoroutine(GoLowFreq(LowPassFilter, lowPassTimer, lowFreq));
        }

    }

    public IEnumerator GoLowFreq(AudioLowPassFilter audioLowPassFilter, float duration, float targetFreq)
    {
        float currentTime = 0;
        float start = audioLowPassFilter.cutoffFrequency;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            LowPassFilter.cutoffFrequency = Mathf.Lerp(start, targetFreq, currentTime / duration);
            yield return null;
        }
        yield break;

    }

    public IEnumerator GoHighFreq(AudioLowPassFilter audioLowPassFilter, float duration, float targetFreq)
    {
        float currentTime = 0;
        float start = audioLowPassFilter.cutoffFrequency;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            LowPassFilter.cutoffFrequency = Mathf.Lerp(start, targetFreq, currentTime / duration);
            yield return null;
        }
        yield break;
    }

}



