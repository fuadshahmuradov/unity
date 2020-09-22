using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] public float gameSpeed = 0.78f;

    void Start()
    {
        print("GameSession.cs");
    }

    void Update()
    {
        Time.timeScale = gameSpeed;
    }
}
