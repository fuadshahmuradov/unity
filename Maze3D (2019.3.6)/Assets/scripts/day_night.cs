using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class day_night : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float speed = 3;
    private float m;
    void Update()
    {
        m = speed * Time.deltaTime;
        transform.Rotate(Vector3.right * m);
    }

}
