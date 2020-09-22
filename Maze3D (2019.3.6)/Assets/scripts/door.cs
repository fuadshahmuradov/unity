using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Animator animator;
    void OnTriggerEnter(Collider o)
    {
        if (o.tag == "Player")
        {
            o.SendMessage("showHintGUI", "Open the door");
            animator.SetTrigger("Open");
        }
           
    }
    void OnTriggerExit(Collider o)
    {
        if (o.tag == "Player")
            animator.SetTrigger("Close");
    }
}
