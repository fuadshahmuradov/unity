using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCreator : MonoBehaviour
{
	public GameObject crossHairBlock;
	public GameObject block3hit;
	public GameObject block2hit;
	public GameObject block1hit;
	public GameObject unbreakableBlock;

	void Start()
	{
		crossHairBlock = Instantiate(crossHairBlock);
		crossHairBlock.transform.position = new Vector3(0f, 0.0f, -1);
	}

	private void Update()
	{
		MoveLeft();
		MoveRight();
		MoveDown();
		MoveUp();
		SpawnBlock4();
		SpawnBlock3();
		SpawnBlock2();
		SpawnBlock1();
		Clear();
	}

	void SpawnBlock4()
	{
		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			GameObject k = Instantiate(unbreakableBlock);
			Vector3 pos = crossHairBlock.transform.position;
			k.transform.position = pos;
		}
	}
	void SpawnBlock3()
	{
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			GameObject k = Instantiate(block3hit);
			Vector3 pos = crossHairBlock.transform.position;
			k.transform.position = pos;
		}
	}
	void SpawnBlock2()
	{
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			GameObject k = Instantiate(block2hit);
			Vector3 pos = crossHairBlock.transform.position;
			k.transform.position = pos;
		}
	}
	void SpawnBlock1()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			GameObject k = Instantiate(block1hit);
			Vector3 pos = crossHairBlock.transform.position;
			k.transform.position = pos;
		}
	}
	
	void MoveLeft()
	{
		if (Input.GetKeyDown(KeyCode.LeftArrow))
			crossHairBlock.transform.position -= new Vector3(0.5f, 0.0f, 0);
	}
	void MoveRight()
	{
		if (Input.GetKeyDown(KeyCode.RightArrow))
			crossHairBlock.transform.position += new Vector3(0.5f, 0.0f, 0);
	}
	void MoveDown()
	{
		if (Input.GetKeyDown(KeyCode.DownArrow))
			crossHairBlock.transform.position -= new Vector3(0.0f, 0.5f, 0);
	}
	void MoveUp()
	{
		if (Input.GetKeyDown(KeyCode.UpArrow))
			crossHairBlock.transform.position += new Vector3(0.0f, 0.5f, 0);
	}
	void Clear()
	{
		if(Input.GetKeyDown(KeyCode.C))
		{
			Object[] allObjects = GameObject.FindGameObjectsWithTag("Breakable");
			foreach (GameObject obj in allObjects)
			{
				Destroy(obj);
			}
			Object[] allObjects1 = GameObject.FindGameObjectsWithTag("Unbreakable");
			foreach (GameObject obj in allObjects1)
			{
				Destroy(obj);
			}
		}
	}
	/*
	IEnumerator StartSpawning()
	{
		yield return new WaitForSeconds(Random.Range(0.5f, 1f));
		if (count == 3)
		{
			coin.GetComponent<Renderer>().enabled = true;
			count--;
		}
		GameObject k = Instantiate(knife);

		float x = Random.Range(min_X, max_X);
		count++;

		k.transform.position = new Vector2(x, transform.position.y);
		StartCoroutine(StartSpawning());
	}

	IEnumerator StartSpawningCoins()
	{
		coin.GetComponent<Renderer>().enabled = true;

		yield return new WaitForSeconds(Random.Range(6f, 16f));

		GameObject k = Instantiate(coin);

		float x = Random.Range(min_X, max_X);

		k.transform.position = new Vector2(x, transform.position.y);

		StartCoroutine(StartSpawningCoins());
	}
	*/

}













