using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scarecrow : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D otherCollider)
    {
        print("Scarecrow.cs");
        Attacker attacker = otherCollider.GetComponent<Attacker>();

        if(attacker)
        {

        }
    }
}
