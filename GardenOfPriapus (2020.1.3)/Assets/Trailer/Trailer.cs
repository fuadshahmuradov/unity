using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trailer : MonoBehaviour
{
    
    public void LightningSound()
    {
        GetComponent<AudioSource>().Play();
    }
}
