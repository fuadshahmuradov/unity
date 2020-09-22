using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplay : MonoBehaviour
{
    [SerializeField] Text levelText;
    private void Awake()
    {
        print("LevelDisplay.cs");
        int maxLevel = PlayerPrefsController.GetMaxLevel();
        levelText.text = "(Level " + maxLevel + ")";
    }
}
