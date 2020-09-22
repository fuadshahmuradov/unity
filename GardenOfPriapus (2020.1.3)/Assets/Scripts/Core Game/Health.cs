using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;

    AudioSource audioSource;
    [SerializeField] AudioClip deathSound;
    private void Awake()
    {
        print("Health.cs");
        if (GetComponent<AudioSource>())
        audioSource = GetComponent<AudioSource>();
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0 )
        {
            TriggerDeathVFX();
        }
    }
    public float  GetHealth()
    {
        return health;
    }

    private void TriggerDeathVFX()
    {
        if(deathSound)
        audioSource.PlayOneShot(deathSound);
        if (!deathVFX)
        {
            GetComponent<Animator>().SetBool("isDead", true);
            Destroy(gameObject, 1f);
        }
        else
        {
            GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
            Destroy(deathVFXObject, 1f);
            Destroy(gameObject);
        }
    }
}
