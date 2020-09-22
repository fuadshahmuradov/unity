using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 100;

    AudioSource audioSource;
    [SerializeField] AudioClip attackSound;

    private void Awake()
    {
        print("Defender.cs");
        audioSource = GetComponent<AudioSource>();
    }

    public int GetStarCost()
    {
        return starCost;
    }

    public void AddStars(int amount)
    {
        FindObjectOfType<StarDisplay>().AddStars(amount);
    }

    public void AttackSound()
    {
        if (attackSound)
            audioSource.PlayOneShot(attackSound, 0.25f);
    }
}
