using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class collision03 : MonoBehaviour
{
    bool isGun;
    public AudioClip soundCollectedObject;
    public AudioClip noammo;
    public GameObject sight;
    public GameObject bulletcount;
    // Start is called before the first frame update
    void Start()
    {
        isGun = false;
        changeTexture("gun", isGun);
        GameObject.Find("UI_sight").GetComponent<fire>().enabled = false;
        GameObject.Find("UI_texture_gun").GetComponent<RawImage>().enabled = false;
        sight.SetActive(false);
        bulletcount.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource audio = GetComponent<AudioSource>();
        if (Input.GetButtonDown("Fire1"))
        {
                if (GameObject.Find("UI_texture_gun").GetComponent<RawImage>().enabled == true)
                {
                    int bullet = GameObject.Find("UI_sight").GetComponent<fire>().bullets;
                    if (bullet <= 0)
                    {
                        audio.PlayOneShot(noammo);
                        isGun = false;
                    }
                }
        }
    }
    void OnControllerColliderHit(ControllerColliderHit c)
    {
        if (c.gameObject.tag == "gun")
        {
            isGun = true;
            changeTexture("gun", isGun);
            GameObject.Find("UI_message_for_user").GetComponent<message_for_user>().showText(c.gameObject.tag + " collected!");
            Destroy(c.gameObject);
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = soundCollectedObject;
            audio.Play();
            sight.SetActive(true);
            GameObject.Find("UI_sight").GetComponent<fire>().bullets = 20;
            bulletcount.SetActive(true);
            GameObject.Find("UI_bullet_count").GetComponent<UnityEngine.UI.Text>().text = "Bullets: " + GameObject.Find("UI_sight").GetComponent<fire>().bullets + "/20";
            GameObject.Find("UI_sight").GetComponent<fire>().enabled = true;
        }
        if (c.gameObject.tag == "door")
        {
            GameObject.Find("UI_message_for_user").GetComponent<message_for_user>().showText("Nice! You found \n the correct door!");
            c.collider.enabled = false;
        }
        if (c.gameObject.tag == "door2")
        {
            GameObject.Find("UI_message_for_user").GetComponent<message_for_user>().showText("No..");
        }
        if (c.gameObject.tag == "info")
        {
            Destroy(c.gameObject);
            GameObject.Find("UI_message_for_user").GetComponent<message_for_user>().showText("Kill all the enemies \n to proceed.");
        }
        if (c.gameObject.tag == "info2")
        {
            Destroy(c.gameObject);
            GameObject.Find("UI_message_for_user").GetComponent<message_for_user>().showText("Be careful ahead!");
        }
        if (c.gameObject.tag =="ring")
        {
            SceneManager.LoadScene("end");
        }

    }
    void changeTexture(string obj, bool show)
    {
        GameObject.Find("UI_texture_" + obj).GetComponent<RawImage>().enabled = show;
    }

    IEnumerator Wait1sec()
    {
        yield return new WaitForSecondsRealtime(1f);
    }
}
