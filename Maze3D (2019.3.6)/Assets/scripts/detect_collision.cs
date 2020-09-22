using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class detect_collision : MonoBehaviour
{
	private int health;
	public bool  isGun;
	private bool  isKey;
    private bool isMatches;
    private int usedGun = 0;
	public AudioClip soundCollectedObject;
    public AudioClip noammo;
    public AudioClip gameover;
    public AudioClip win;
    public AudioClip hurt;
    //public AudioClip fireSound;
    public GameObject sight;
    public GameObject bulletcount;
    private bool showHint = false;
    private float timer = 0;
    public float displayTime = 5.0f;
    public Text hintGUI;
    public GameObject campfire;
    public ParticleSystem smokeSystem;
    public ParticleSystem fireSystem;
    int fireEmit;
    


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        isKey=false;
		isGun=false;
        isMatches = false;
        fireEmit = 0;
		health=50;
		changeTexture("key", isKey);
		changeTexture("gun", isGun);
        changeTexture("matches", isMatches);
        GameObject.Find("UI_sight").GetComponent<fire>().enabled = false;
        GameObject.Find("UI_texture_gun").GetComponent<RawImage>().enabled = false;
        sight.SetActive(false);
        bulletcount.SetActive(false);
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        smokeSystem.Emit(fireEmit);
        fireSystem.Emit(fireEmit);

        AudioSource audio = GetComponent<AudioSource>();
        if (Input.GetButtonDown("Fire1"))
        {
            if (usedGun == 0)
            {
                if (GameObject.Find("UI_texture_gun").GetComponent<RawImage>().enabled == true)
                {
                    int bullet = GameObject.Find("UI_sight").GetComponent<fire>().bullets;
                    if (bullet <= 0)
                    {
                        audio.PlayOneShot(noammo);
                        usedGun++;
                        isGun = false;
                    }
                }
            }
            else
            {
                audio.PlayOneShot(noammo);
            }
        }

        if (showHint)
        {
            if (timer < displayTime)
            {
                timer += Time.deltaTime;
            }
            else
            {
                hintGUI.enabled = false;
                showHint = false;
                timer = 0;
            }
        }

        if (health <= 0)
        {
            RestartGame();
        }
    }


    void showHintGUI(string txt)
    {
        hintGUI.text = txt;
        hintGUI.enabled = true;
        this.showHint = true;
    }

    void  changeTexture (string obj,bool show)
	{
		GameObject.Find("UI_texture_" + obj).GetComponent<RawImage>().enabled = show;
	}

	
	void  OnControllerColliderHit (ControllerColliderHit c)
	{
		if (c.gameObject.tag == "firstAidKit")
		{
			health = 100;
			GameObject.Find("health_bar").GetComponent<health_bar>().setHealth(health);
			GameObject.Find("UI_message_for_user").GetComponent<message_for_user>().showText(c.gameObject.tag + " collected!");
			Destroy(c.gameObject);
			AudioSource audio = GetComponent<AudioSource>();
			audio.clip = soundCollectedObject;
			audio.Play();
		}
		if (c.gameObject.tag == "gun")
		{
			isGun=true;
			changeTexture("gun", isGun);
			GameObject.Find("UI_message_for_user").GetComponent<message_for_user>().showText(c.gameObject.tag + " collected!");
			Destroy(c.gameObject);
			AudioSource audio = GetComponent<AudioSource>();
			audio.clip = soundCollectedObject;
			audio.Play();
            usedGun = 0;
            sight.SetActive(true);
            GameObject.Find("UI_sight").GetComponent<fire>().bullets = 20;
            bulletcount.SetActive(true);
            GameObject.Find("UI_bullet_count").GetComponent<UnityEngine.UI.Text>().text = "Bullets: " + GameObject.Find("UI_sight").GetComponent<fire>().bullets + "/20";
            GameObject.Find("UI_sight").GetComponent<fire>().enabled = true;
        }
		if (c.gameObject.tag == "key")
		{
			isKey=true;
			changeTexture("key", isKey);
			GameObject.Find("UI_message_for_user").GetComponent<message_for_user>().showText(c.gameObject.tag + " collected!");
			Destroy(c.gameObject);
			AudioSource audio = GetComponent<AudioSource>();
			audio.clip = soundCollectedObject;
			audio.Play();
		}
        if (c.gameObject.tag == "fiery")
        {
            GameObject.Find("UI_message_for_user").GetComponent<message_for_user>().showText("GAME OVER!");
            Destroy(c.gameObject);
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(gameover);
            Time.timeScale = 0;
            RestartGame();
        }
        if (c.gameObject.tag == "door")
        {
            if (isKey)
            {
                GameObject.Find("UI_message_for_user").GetComponent<message_for_user>().showText("You have completed \n the game level!");
                //Destroy(c.gameObject);
                AudioSource audio = GetComponent<AudioSource>();
                audio.PlayOneShot(win);
                StartCoroutine(WaitForIt(1.0F));
            }
        }
        if (c.gameObject.tag == "door2")
        {
            
            {
                GameObject.Find("UI_message_for_user").GetComponent<message_for_user>().showText("You have completed \n the game level!");
                //Destroy(c.gameObject);
                AudioSource audio = GetComponent<AudioSource>();
                audio.PlayOneShot(win);
                StartCoroutine(WaitForIt2(1.0F));
            }
        }
        if (c.gameObject.tag == "matches")
        {
            isMatches = true;
            changeTexture("matches", isMatches);
            GameObject.Find("UI_message_for_user").GetComponent<message_for_user>().showText(c.gameObject.tag + " collected!");
            Destroy(c.gameObject);
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = soundCollectedObject;
            audio.Play();
        }
        if (c.gameObject.tag == "fire")
        {
            if(isMatches)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    lightFire(campfire);
                    isMatches = false;
                    changeTexture("matches", isMatches);
                }
            }
        }
        if (c.gameObject.tag == "enemy")
        {
            AudioSource audio1 = GetComponent<AudioSource>();
            audio1.PlayOneShot(hurt);
            health -= 25; 
        }
    }

    void lightFire( GameObject cmpfire)
    {
        fireEmit = 1;
        cmpfire.GetComponent<AudioSource>().Play();
        //AudioSource audio = GetComponent<AudioSource>();
        //audio.clip = fireSound;
        //audio.playOnAwake = true;
    }

    IEnumerator WaitForIt(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("scene02");
    }

    IEnumerator WaitForIt2(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("scene03");
    }

    void RestartGame()
    {
        StartCoroutine(Wait3secs());
        SceneManager.LoadScene("SampleScene");
    }

    IEnumerator Wait3secs()
    {
        yield return new WaitForSecondsRealtime(3f);
    }
}
