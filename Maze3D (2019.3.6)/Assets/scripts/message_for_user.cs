using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class message_for_user : MonoBehaviour
{
	private float timer;
	private float showTime;
	private bool  activeTimer;
	private string message;
	private Text uiText;
	
	void  startTimer ()
	{
		timer = 0.0f;
		showTime = 3.0f;
		uiText.text = message;
		activeTimer = true;
	}
	
	void  Start ()
	{
		uiText = GetComponent<Text>();
	}
	
	void  Update ()
	{
		if (activeTimer)
		{
			timer += Time.deltaTime;
			if (timer > showTime)
			{
				activeTimer = false;
				uiText.text = "";
			}
		}
	}
	
	public void  showText ( string m  )
	{
		message = m;
		startTimer();
	}

	
}
