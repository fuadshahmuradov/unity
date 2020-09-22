using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troll : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        print("Troll.cs");
        GameObject otherObject = otherCollider.gameObject;
        if(otherObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
}
