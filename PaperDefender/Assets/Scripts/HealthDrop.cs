using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDrop : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    [SerializeField] float durationofExplosion = .2f;

    [SerializeField] AudioClip enemyDeathNoise;
    [SerializeField] AudioClip enemyLazerNoise;
    [SerializeField] float enemyVolume;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Die();
    }


    /* private void OnTriggerEnter2D(Collider2D other)
     {
         DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
         ProcessHit(damageDealer);*/


    private void Die()
    {
        Destroy(gameObject);
        GameObject Explosion = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
        Destroy(Explosion, durationofExplosion);
        AudioSource.PlayClipAtPoint(enemyDeathNoise, Camera.main.transform.position, enemyVolume);
    }
}
