using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_bar : MonoBehaviour
{
	private int health = 50;
	private Texture2D currentColor;
	public GUIStyle style;
	public Texture2D textureGreen;
	public Texture2D textureYellow;
	public Texture2D textureRed;
	public Texture2D textureBlack;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void  OnGUI ()
	{
		if (health >= 67)
			currentColor = textureGreen;
		else if (health >= 34)
				currentColor = textureYellow;
			else
				currentColor = textureRed;
		style.normal.background = textureBlack;
		GUI.Box( new Rect(0, 25, 100, 20), "", style);
		style.normal.background = currentColor;
		GUI.Box( new Rect(0, 25, health, 20), "", style);
	}
	
	public void  setHealth ( int value  )
	{
		health = value;
	}

}
