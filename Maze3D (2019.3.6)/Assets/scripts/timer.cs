using UnityEngine;

public class timer : MonoBehaviour
{
	private float time;
	private float minutes;
	private float seconds;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
		minutes = Mathf.FloorToInt(time/60);
		seconds = Mathf.FloorToInt(time%60);
		print(minutes + ":" + seconds);
		string textToDisplay = minutes+":"+seconds;
		GameObject.Find("UI_timer").GetComponent<UnityEngine.UI.Text>().text = textToDisplay;
    }
}
