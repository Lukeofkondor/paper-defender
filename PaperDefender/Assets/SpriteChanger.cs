using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour

{ 

    private float curHealth;
    public SpriteRenderer myRenderer;
    public Sprite moonboss;
    public Sprite moonboss2;


    void start()
    {
        moonboss = gameObject.GetComponent<SpriteRenderer>().sprite;
        curHealth = FindObjectOfType<Enemy>().EnemyGetHealth();

    }

    private void Update()
    {
        if (gameObject)

        moonboss = moonboss2;
    }

   

    /*if (curHealth >= 500f)
        {
            myRenderer.sprite = moonboss2;
        }
        else
        {
            myRenderer.sprite = moonboss2;
        }*/



}
