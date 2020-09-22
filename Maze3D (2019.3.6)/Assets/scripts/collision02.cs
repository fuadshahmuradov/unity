using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class collision02 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnControllerColliderHit(ControllerColliderHit c)
    {
        if (c.gameObject.tag == "door2")
        {

            {
                GameObject.Find("UI_message_for_user").GetComponent<message_for_user>().showText("You have completed \n the game level!");
                StartCoroutine(WaitForIt2(1.0F));
            }
        }
    }
    IEnumerator WaitForIt2(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("scene03");
    }
}
