using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)]
    float currentSpeed = 1f;
    GameObject currentTarget;
    AudioSource audioSource;
    [SerializeField] AudioClip attackSound;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
        audioSource = GetComponent<AudioSource>();
        print("Attacker.cs");
    }

    private void OnDestroy()
    {
        if(FindObjectOfType<LevelController>())
        {
            FindObjectOfType<LevelController>().AttackerKilled();
        }
        else
        {
            return;
        }
    }

    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if(!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    public float GetSpeed()
    {
        return currentSpeed;
    }
    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) { return; }
        Health health = currentTarget.GetComponent<Health>();
        if(health)
        {
            health.DealDamage(damage);
        }
    }

    public void AttackSound()
    {
        if(attackSound)
        audioSource.PlayOneShot(attackSound);
    }
}
