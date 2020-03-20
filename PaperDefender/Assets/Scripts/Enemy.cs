using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] int scoreValue = 150; 


    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;

    [SerializeField] GameObject enemyLazer;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] GameObject explosion;
    [SerializeField] float durationofExplosion = .2f;

    [SerializeField] AudioClip enemyDeathNoise;
    [SerializeField] AudioClip enemyLazerNoise;
    [SerializeField] float enemyVolume;
 




    // Start is called before the first frame update
    void Start()
    {
        shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
      

    }

    // Update is called once per frame
    void Update()
    {
        CountdownAndShoot();
    }

    private void CountdownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            AudioSource.PlayClipAtPoint(enemyLazerNoise, Camera.main.transform.position, enemyVolume);
            Fire();
            shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);

        }
    }

    private void Fire()
    {
        GameObject lazer = Instantiate(enemyLazer, transform.position, Quaternion.identity) as GameObject;
        if (tag == "boss")
        {
           
        }
        else
        {
            lazer.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        }
       


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        ProcessHit(damageDealer);


    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (!damageDealer) { return; }
        if (health <= 0f)
        {
          
            Die();

        }

    }

    private void Die()
    {
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
        Destroy(gameObject);
        GameObject Explosion = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
        Destroy(Explosion, durationofExplosion);
        AudioSource.PlayClipAtPoint(enemyDeathNoise, Camera.main.transform.position, enemyVolume);
    }

    public float EnemyGetHealth()
    {
        return health;
    }


}


