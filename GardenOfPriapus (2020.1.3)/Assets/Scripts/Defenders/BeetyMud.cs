using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetyMud : MonoBehaviour
{
    GameObject enemy;

    private void OnTriggerStay2D(Collider2D otherCollider)
    {
        print("BeetyMud.cs");
        Attacker attacker = otherCollider.GetComponent<Attacker>();
        if (attacker)
        {
            enemy = otherCollider.gameObject;
            attacker.GetComponent<Animator>().SetBool("isMuddy", true);
        }
    }
    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        enemy.GetComponent<Animator>().SetBool("isMuddy", false);
        Destroy(gameObject);
    }
}
