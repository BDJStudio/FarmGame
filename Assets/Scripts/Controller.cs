using UnityEngine;
using System;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Threading;
using System.Threading.Tasks;

public class Controller : MonoBehaviour
{
	public GameObject poplavok;//поплавок для клонирования

	public BuoyancyEffector2D water;

	public SpriteRenderer fishSprite;//Объект, на который кидаем спрайт рыбы

	public GlTime timeCount;

	public GameObject newSpriteFish;

	GameObject newPoplavok;//поплавок, который кидаем


	CapsuleCollider2D collide;

	BoxCollider2D collideForPoplav;//чекер для удаления поплавка
	BoxCollider2D colliderOnPoplav;//коллайдер на поплавке

	SpriteRenderer startSpR;

	Transform trans;
	Transform transPoplavok;

	Rigidbody2D rb;
	Rigidbody2D poplavokRb; //rb поплавка

	fishingScript fishingScript;

	Vector2 powerFishing = new Vector2(10f, 10f);//сила броска;

	const float throwMultiplyer = 0.005f; //1% силы броска;
	const float minRange = 30f;//начальная точка отсчёта для броска поплавка;

	public float horizontalSpeed;

	public float power = 1f;

	public bool poplavokInWater = false;

	float powerPredel = 100f;

	float speedX;

	bool boolForButton = false;
	bool throwed = false;

	void Start()
	{

		rb = GetComponent<Rigidbody2D>();
		trans = GetComponent<Transform>();
		collide = GetComponent<CapsuleCollider2D>();
		collideForPoplav = GetComponent<BoxCollider2D>();
		fishingScript = GetComponent<fishingScript>();
		startSpR = poplavok.GetComponent<SpriteRenderer>();

		
	}

	public void LeftButtonDown()
	{
		transform.localScale = new Vector3(-0.2f, 0.2f, 0.2f);
		speedX = -horizontalSpeed;
	}
	public void RightButtonDown()
	{
		speedX = horizontalSpeed;
		transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
	}
	public void Stop()
	{
		speedX = 0;
	}


	public void Update()
	{
		if (boolForButton)
		{
			updateForThrow();
		}


		switch(fishingScript.fishingTime) // nado yslovie
		{
			case 1:
				poplavokRb.AddForce(new Vector2(0, -0.05f), ForceMode2D.Impulse);
				break;
		}



		water.surfaceLevel = 0.7f - power;

		deletePoplavok();
	}

	public IEnumerator bulk()
	{
		yield return new WaitForSeconds(0.5f);

	}

	public void FixedUpdate()
	{
		transform.Translate(speedX, 0, 0);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		//тут пишем тригеры))
	}


	async void updateForThrow()
	{
		await Task.Run(() => changePower());
		//		await Task.Run(() => )
	}

	void changePower()//изменение силы броска
	{

		bool powerToBack = true;
		boolForButton = true;


		if (!throwed)
		{
			if (power <= powerPredel && powerToBack == true)
			{
				power++;
				if (power == powerPredel)
				{
					powerToBack = false;
				}
			}
		}


		if (powerToBack == false)
		{
			power--;
			if (power <= 1)
			{
				powerToBack = true;
			}
		}

		print(power);


	}

	public void startButtonFishing()
	{
		boolForButton = true;
	}

	public void stopButtonFishing()
	{

		boolForButton = false;

		power *= throwMultiplyer;

		fishing();

	}

	public void fishing()
	{
		//Vector2 backFishing = new Vector2();//сила возврата


		if (!newPoplavok)//Проверка, кинут ли поплавок
		{
			if (trans.localScale.x > 0f)
			{
				newPoplavok = Instantiate(poplavok, trans.localPosition + new Vector3(1f, 2f), Quaternion.identity);//создание поплавка
				newSpriteFish = GameObject.FindGameObjectsWithTag("FishSprite")[1];
				//poplavok.GetComponent<SpriteRenderer>().sprite = startSpR.sprite;


				fishingScript.StartCoroutine(fishingScript.checkFishfor());
				fishingScript.fishingTime = UnityEngine.Random.Range(5, 10);//рандомное время для вылавливания рыбы

				if (powerFishing.x < 0)
				{
					powerFishing.x = -powerFishing.x;
				}
			}
			else
			{
				newPoplavok = Instantiate(poplavok, trans.localPosition + new Vector3(-1f, 2f), Quaternion.identity);//тут тоже, но в другую сторону

				if (powerFishing.x > 0)
				{
					powerFishing.x = -powerFishing.x;
				}
			}

			colliderOnPoplav = newPoplavok.GetComponent<BoxCollider2D>();//получение коллайдера, шобы потом удаляться

			Physics2D.IgnoreCollision(colliderOnPoplav, collide);//отключение коллизии на одном из триггеров, шобы не удаляться при появлении, 

			poplavokRb = newPoplavok.GetComponent<Rigidbody2D>();
			transPoplavok = newPoplavok.GetComponent<Transform>();



			Vector2 backVector = new Vector2(trans.position.x - transPoplavok.position.x, trans.position.y - transPoplavok.position.y);//Вычисление направления к игроку

			poplavokRb.AddForce(powerFishing);//создание и бросок
			throwed = true;
		}
		else

		{
			poplavokRb.AddForceAtPosition(-(transPoplavok.position - trans.localPosition) * 15f, trans.localPosition);//притягивание поплавка назад
		}


	}
	void deletePoplavok()
	{
		try
		{
			if (newPoplavok.GetComponent<BoxCollider2D>().IsTouching(water.GetComponent<BoxCollider2D>()))
			{
				poplavokInWater = true;
			}
			else
			{
				poplavokInWater = false;
			}
		}
		catch { }



		if (newPoplavok)
		{
			{
				if (newPoplavok.GetComponent<BoxCollider2D>().IsTouching(collideForPoplav))//удаление поплавка при соприкосновении с игроком
				{
					Destroy(newPoplavok);
					throwed = false;

					fishingScript.StopAllCoroutines();

					if (fishingScript.catched)
					{
						fishingScript.getFish();
					}

				}

				if (-(transPoplavok.position.x - trans.position.x) > 5f)
				{
					poplavokRb.AddForceAtPosition(new Vector2(5f, 1f), trans.localPosition);//ограничение длины лески по -х (я засунул это сюда потому что данная функция чиллит в update())
				}
				else if (transPoplavok.position.x - trans.position.x > 5f)
				{
					poplavokRb.AddForceAtPosition(new Vector2(-5f, 1f), trans.localPosition);////ограничение длины лески по х
				}
			}
		}
	}
}