using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoMenu : MonoBehaviour
{
    public static bool LaunchIsSelected = false;
    public GameObject InfoMenuUI;

    void Update()
    {
        if (LaunchIsSelected)
        {
            InfoMenuUI.SetActive(true);
        }
        else
        {
            InfoMenuUI.SetActive(false);
        }
    }

    public void LaunchSelected()
    {
        FindObjectOfType<SpaceXAPIController>().GetId();
        FindObjectOfType<SpaceXAPIController>().DisplayPopUp();

        LaunchIsSelected = true;
    }

    public void CloseInfoMenu()
    {
        LaunchIsSelected = false;
    }
}
