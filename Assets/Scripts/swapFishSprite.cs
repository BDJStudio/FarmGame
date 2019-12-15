using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swapFishSprite : MonoBehaviour
{
	public Controller player;
	public Sprite[] fishesSprite;
	public fishingScript fishingScript;

	SpriteRenderer spriteRenderer;

	public void swapSprite()
	{
		spriteRenderer = player.newSpriteFish.GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = fishesSprite[fishingScript.catchFishID - 5];
	}
}
