using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_ai : MonoBehaviour
{
    public float walkSpeed = 5.0f;
    public float attackDistance = 3.0f;
    public float attackRange = 10.0f;
    public float attackDelay = 1.0f;
    public float enemyHealth = 10.0f;
    private float timer = 0;

    void Hit()
    {
        Destroy(gameObject);
    }

    void OnTriggerStay(Collider o)
    {
        if (o.tag.Equals("Player"))
        {
            Quaternion rotationTarget = Quaternion.LookRotation
            (o.transform.position - transform.position);
            float originalX = transform.rotation.x;
            float originalZ = transform.rotation.z;
            Quaternion finalRotation = Quaternion.
            Slerp(transform.rotation, rotationTarget,5.0f * Time.deltaTime);
            finalRotation.x = originalX;
            finalRotation.z = originalZ;
            transform.rotation = finalRotation;
            float distance = Vector3.Distance(transform.position, o.transform.position);
            if (distance > attackDistance)
            {
                transform.Translate(Vector3.forward *walkSpeed * Time.deltaTime);
            }
            else
            {
                if (timer <= 0)
                {
                    //o.SendMessage("Hit", attackRange);
                    timer = attackDelay;
                }
            }
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
        }
    }
}