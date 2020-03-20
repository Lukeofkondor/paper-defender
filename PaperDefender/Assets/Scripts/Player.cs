using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // config parameters
    [Header("Player Movement")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 0.2f;
    [SerializeField] int health = 200;

    [Header("Projectile")]
    [SerializeField] GameObject playerLazer;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.1f;

    [Header("FX")]
    [SerializeField] AudioClip playerDeathSFX;
    [SerializeField] AudioClip playerShootSFX;
    [SerializeField] float playerVolume;
    [SerializeField] GameObject explosion;
    [SerializeField] float durationofExplosion = .2f;
    [SerializeField] GameObject hurt;
    [SerializeField] float durationofHurt = .05f;


    Coroutine firingCoroutine;

    //cached refs

    float xMin;
    float xMax;
    float yMin;
    float yMax;

      


    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();

       
    }

    // Update is called once per frame
    void Update()
    {
        move();
        fire();
    }



    private void fire()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinuously());
           

        }

        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }

    }




    //move boundaries
    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }
  
    //
    private void move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
     
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            AudioSource.PlayClipAtPoint(playerShootSFX, Camera.main.transform.position, playerVolume);
            Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y + 0.5f);   
            GameObject lazer = Instantiate(playerLazer, currentPosition, Quaternion.identity) as GameObject;
            lazer.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        StartCoroutine(playerHurt());
        if (!damageDealer) { return;  }
        if (health <= 0)
        {

            Die();
            FindObjectOfType<SceneLoader>().LoadGameOver();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       StopCoroutine(playerHurt());
    }

    private void Die()
    {
        StartCoroutine(playerDeath());


    }

    IEnumerator playerDeath()
    {

        AudioSource.PlayClipAtPoint(playerDeathSFX, Camera.main.transform.position, playerVolume);
        GameObject Explosion = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
        Destroy(Explosion, durationofExplosion);
        gameObject.SetActive(false); 
        yield return new WaitForSeconds(2f);


    }

    IEnumerator playerHurt()
    {

        GameObject Explosion = Instantiate(hurt, transform.position, Quaternion.identity) as GameObject;
        yield return new WaitForSeconds(0.2f);
        Destroy(Explosion);



    }

    public int GetHealth()
    {
        return health;
    }

}
