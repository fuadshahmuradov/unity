using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
	private Animator anim;
	private SpriteRenderer sr;
	private float speed = 3f;
	
	private float min_X= -2.5f;
	private float max_X= 2.5f;
	public Text timer_Text;
	public Text cointext;
	private int coincount=0;
	private int timer;
	private int health = 2;
	public GameObject heart;
	public GameObject heart2;

	public Joystick joystick;
	
	public AudioClip hurt;
	public AudioClip coin;
	public AudioClip gameover;

	
	public AudioClip backGroundMusic;

    void Awake ()
    {
        anim = GetComponent<Animator>();
		sr = GetComponent<SpriteRenderer>();
    }

	void Start()
	{
		Screen.fullScreen = false; 
		Time.timeScale = 1f;
		heart.GetComponent<Renderer>().enabled=true;		
		heart2.GetComponent<Renderer>().enabled=true;		
		AudioSource audio = GetComponent<AudioSource>();
		audio.clip = backGroundMusic;
		audio.Play();	
		StartCoroutine(CountTime());
		timer = 0;
	}	
	
    void Update()
    {
        Move();
		PlayerBounds();
		CountCoin();
		changeHealth();
    }
	
	void PlayerBounds()
	{
		Vector3 temp = transform.position;
		
		if(temp.x > max_X)
		{
			temp.x = max_X;		
		} else if(temp.x < min_X)
		{
			temp.x = min_X;	
		}		
		
		transform.position = temp;
	}
	
	void Move()
	{
		float h = joystick.Horizontal;
		//float h = Input.GetAxisRaw("Horizontal");
		
		Vector3 temp = transform.position;
		
		if(h > 0)
		{
			temp.x += speed * Time.deltaTime;
			sr.flipX = false;
			
			anim.SetBool("walk",true);
			
		} else if (h < 0)
		{
			temp.x -= speed * Time.deltaTime;
			sr.flipX = true;
			
			anim.SetBool("walk",true);

		} else if (h == 0)
		{
			anim.SetBool("walk",false);
		}			
		
		transform.position = temp;
		
	}
	
	IEnumerator RestartGame() 
	{
		yield return new WaitForSecondsRealtime(2f);
		UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);		
	}
	
	IEnumerator CountTime()
	{
		yield return new WaitForSeconds(1f);
		timer++;

		timer_Text.text = ""+ timer;
		
		StartCoroutine(CountTime());
	}		
	
	void CountCoin()
	{
		cointext.text = ": "+ coincount;
	}
	
	void OnTriggerEnter2D(Collider2D target)
	{
		AudioSource audio = GetComponent<AudioSource>();
						
		if(target.tag == "knife")
		{
			audio.PlayOneShot(hurt);
			health--;
			if(health<=0) die();
		}	

		if(target.tag == "coin")
		{
			target.GetComponent<Renderer>().enabled=false;
			audio.PlayOneShot(coin);
			coincount++;
		}	
	}	
	
	void changeHealth()
	{
		if (health == 1)
		{
			heart2.GetComponent<Renderer>().enabled=false;
		}	
		if (health == 0)
		{
			heart.GetComponent<Renderer>().enabled=false;		
		}
	}	
	
	void die()
	{
		AudioSource audio = GetComponent<AudioSource>();
		Time.timeScale = 0f;
		audio.PlayOneShot(gameover);
		StartCoroutine(RestartGame()); 
	}	
}













