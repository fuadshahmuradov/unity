using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardIce : MonoBehaviour
{
    [SerializeField] float freezeTime = 5;
    float attackTime = 0.5f;
    GameObject defender;

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        print("WizardIce.cs");
        GameObject otherObject = otherCollider.gameObject;
        if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherObject);
            StartCoroutine(Freeze(otherObject));
        }
    }

    IEnumerator Freeze(GameObject otherObject)
    {
        defender = otherObject;
        yield return new WaitForSeconds(attackTime);
        if (otherObject.transform.Find("Body").GetComponent<SpriteRenderer>() != null)
        {
            otherObject.transform.Find("Body").GetComponent<SpriteRenderer>().color = Color.cyan;
        }
        if (otherObject.GetComponent<Animator>())
        {
            otherObject.GetComponent<Animator>().enabled = false;
        }
        if (otherObject.GetComponent<Shooter>())
        {
            otherObject.GetComponent<Shooter>().enabled = false;
        }
        if(otherObject.GetComponent<Scarecrow>())
        {
            otherObject.GetComponent<BoxCollider2D>().enabled = false;
        }

        yield return new WaitForSeconds(freezeTime);
        if (otherObject.transform.Find("Body").GetComponent<SpriteRenderer>() != null)
        {
            otherObject.transform.Find("Body").GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (otherObject.GetComponent<Animator>())
        {
            otherObject.GetComponent<Animator>().enabled = true;
        }
        if (otherObject.GetComponent<Shooter>())
        {
            otherObject.GetComponent<Shooter>().enabled = true;
        }
        if (otherObject.GetComponent<Scarecrow>())
        {
            otherObject.GetComponent<BoxCollider2D>().enabled = true ;
        }
    }
    public void Walk()
    {
        GetComponent<Animator>().SetBool("isAttacking", false);
    }

    private void OnDestroy()
    { 
        Destroy(defender);
    }
}
