using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotHead : MonoBehaviour
{
    private void Awake()
    {
        print("RobotHead.cs");
        Destroy(gameObject, 3f);
    }
}
