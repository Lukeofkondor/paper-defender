using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopScoreDisplay : MonoBehaviour
{
    [SerializeField] int topScore;
    Text scoreText;
    TopScoreCache topScoreCache;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        topScoreCache = FindObjectOfType<TopScoreCache>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = topScoreCache.ReturnTopScoreCache().ToString();
         //gameSession.GetScore().ToString();
    }



}
