using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
	// public AudioClip select;

	// Start is called before the first frame update
	void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void startGame()
	{
		SceneManager.LoadScene("SelectPlayer");
	}	
	
	public void openMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}
	
	public void openAbout()
	{
		SceneManager.LoadScene("About");
	}

	public void youngSelected()
	{
		//StartCoroutine(Selected());
		SceneManager.LoadScene("SampleScene");
	}

	public void oldSelected()
	{
		//StartCoroutine(Selected());
		SceneManager.LoadScene("SampleScene");
	}

	
	/* IEnumerator Selected()
	{
		AudioSource audio = GetComponent<AudioSource>();
		yield return new WaitForSecondsRealtime(2f);
		audio.PlayOneShot(select);
	} */

}
