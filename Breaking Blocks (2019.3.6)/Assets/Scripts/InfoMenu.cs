using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InfoMenu : MonoBehaviour
{
    public GameObject infoMenuUI;
    public GameObject helpMenuUI;
    public GameObject mainMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            mainMenuUI.SetActive(true);
            infoMenuUI.SetActive(false);
            helpMenuUI.SetActive(false);
        }
    }
    public void OpenHelp()
    {
        mainMenuUI.SetActive(false);
        helpMenuUI.SetActive(true);
    }
}

