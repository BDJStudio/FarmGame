using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sleeping : MonoBehaviour
{

	private GameObject player;
	private GameObject canvas;
	private Power pow;
	public GlTime gltime;
	

	int day;
    void Start()
    {
		player = GameObject.Find("Player");
		canvas = GameObject.Find("Canvas");
		pow = GameObject.Find("Main Camera").GetComponent<Power>();
    }

	public void sleepStartCor()
	{
		StartCoroutine(sleep());
	}

	public IEnumerator sleep()
	{
		if (gltime.day % 2 != 0)
		{
			gltime.day += 1;
		}
			player.SetActive(false);
			canvas.SetActive(false);
		
		yield return new WaitForSeconds(3);
		StartCoroutine(wakeUp());

	}

	public IEnumerator wakeUp()
	{
		gltime.day += 1;

		yield return new WaitForSeconds(3);

		player.SetActive(true);
		canvas.SetActive(true);
		pow.setCurrentEnergy(pow.maxEnergy);
	}
}
