using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLink : MonoBehaviour
{
    private void Start()
    {
        print("OpenLink.cs");
    }
    public void OpenFacebook()
    {
        Application.OpenURL("https://www.facebook.com/shahmuradovsss");
    }
    public void OpenYouTube()
    {
        Application.OpenURL("https://www.youtube.com/channel/UC65HrLujSp6OQYsdhvYE88A");
    }
    public void OpenInstagram()
    {
        Application.OpenURL("https://www.instagram.com/fuadshahmuradov/");
    }
    public void OpenDiscord()
    {
        Application.OpenURL("https://discord.gg/uY85D4");
    }
    public void OpenReddit()
    {
        Application.OpenURL("https://www.reddit.com/user/fuadshahmuradov");
    }
}
