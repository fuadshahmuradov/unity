using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderRemover : MonoBehaviour
{
    Camera mainCam;
    bool removerSelected=false;

    void Awake()
    {
        print("DefenderRemover.cs");
        removerSelected = false;
        mainCam = Camera.main;
    }

    private void OnMouseDown()
    {
        removerSelected = true;
       
    }

    void Update()
    {
        if(removerSelected)
        {
            GetComponent<SpriteRenderer>().color = Color.gray;
        }
        if (!removerSelected)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.GetRayIntersection(mainCam.ScreenPointToRay(Input.mousePosition));

            if (hit.collider != null && removerSelected && hit.transform.gameObject.tag=="removable")
            {
                Destroy(hit.transform.gameObject);
                removerSelected = false;
            }
        }
    }
}