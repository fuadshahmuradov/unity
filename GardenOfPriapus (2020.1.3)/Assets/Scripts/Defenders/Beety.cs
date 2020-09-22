using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beety : MonoBehaviour
{
    [SerializeField] float boomDamage = 800;
    [SerializeField] GameObject mud;
    GameObject enemy;

    private void OnTriggerStay2D(Collider2D otherCollider)
    {
        print("Beety.cs");
        Attacker attacker = otherCollider.GetComponent<Attacker>();
        enemy = otherCollider.gameObject;
        if (attacker)
        {
            GetComponent<Animator>().SetTrigger("isBoom");
        }
    }

    public void Boom()
    {
        enemy.GetComponent<Health>().DealDamage(boomDamage);
        GetComponent<Health>().DealDamage(1000);
    }

    private void OnDestroy()
    {
        Instantiate(mud, transform.position, transform.rotation);
    }

}
