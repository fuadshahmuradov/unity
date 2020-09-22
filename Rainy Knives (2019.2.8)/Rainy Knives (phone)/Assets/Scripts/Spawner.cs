using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Spawner : MonoBehaviour
{
	
	public GameObject knife;
	public GameObject coin;
	private float min_X= -2.5f;
	private float max_X= 2.5f;
	private float count = 0;	
	
    void Start()
    {
        StartCoroutine(StartSpawning());
		StartCoroutine(StartSpawningCoins());
    }

	IEnumerator StartSpawning ()
	{
		yield return new WaitForSeconds(Random.Range(0.5f, 1f));
		if (count == 3)
		{
			coin.GetComponent<Renderer>().enabled=true;
			count--;
		}
		GameObject k = Instantiate(knife);
		
		float x = Random.Range(min_X,max_X);
		count++;
		
		k.transform.position = new Vector2(x, transform.position.y);
        StartCoroutine(StartSpawning());
	}	
	
	IEnumerator StartSpawningCoins ()
	{
		coin.GetComponent<Renderer>().enabled=true;

		yield return new WaitForSeconds(Random.Range(6f, 16f));

		GameObject k = Instantiate(coin);
				
		float x = Random.Range(min_X,max_X);
		
		k.transform.position = new Vector2(x, transform.position.y);
		
        StartCoroutine(StartSpawningCoins());
	}	

	
}













