using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player02 : MonoBehaviour
{
    public AudioClip gameover;
    public GameObject sight;
    public GameObject bulletcount;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        sight.SetActive(false);
        bulletcount.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnControllerColliderHit(ControllerColliderHit c)
    {
        if (c.gameObject.tag == "fiery" || c.gameObject.tag == "spikes")
        {
            GameObject.Find("UI_message_for_user").GetComponent<message_for_user>().showText("GAME OVER!");
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(gameover);
            StartCoroutine(WaitForIt(1.0F));
        }
        if (c.gameObject.tag == "spiketrigger")
        {
            Destroy(c.gameObject);
            GameObject.Find("downspikes").GetComponent<spikemove>().enabled = true;
        }
    }

     IEnumerator WaitForIt(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("scene02");
    }
}