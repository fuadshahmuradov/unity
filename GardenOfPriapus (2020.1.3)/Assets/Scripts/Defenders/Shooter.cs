using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;
    [SerializeField] GameObject gun2;
    AttackerSpawner myLaneSpawner;
    Animator animator;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";

    AudioSource audioSource;
    [SerializeField] AudioClip projectileSound;

    private void Awake()
    {
        print("Shooter.cs");
        if (GetComponent<AudioSource>())
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }
    
    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawners)
        {
            bool IsCloseEnough = 
                (Mathf.Abs(spawner.transform.position.y - transform.position.y) 
                 <= Mathf.Epsilon);
            if(IsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        if  (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void Fire()
    {
        if(projectileSound)
        audioSource.PlayOneShot(projectileSound);
        GameObject newProjectile = 
            Instantiate(projectile,  gun.transform.position, gun.transform.rotation)
            as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        if(gun2)
        {
            GameObject newProjectile2 =
            Instantiate(projectile, gun2.transform.position, gun.transform.rotation)
            as GameObject;
            newProjectile2.transform.parent = projectileParent.transform;
        }
    }
    
}
