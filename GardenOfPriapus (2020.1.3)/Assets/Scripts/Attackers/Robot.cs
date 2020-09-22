using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField] GameObject head;
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        print("Robot.cs");
        GameObject otherObject = otherCollider.gameObject;
        if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
    public void Rise()
    {
        GetComponent<Animator>().SetTrigger("rise");
    }
    public void Walk()
    {
        GetComponent<Animator>().SetBool("isWalking", true);
    }

    private void OnDestroy()
    {
        Instantiate(head, transform.position, transform.rotation);
    }
}
