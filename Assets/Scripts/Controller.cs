using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;

public class Controller : MonoBehaviour
{
	public GameObject poplavok;//поплавок для клонирования
    public BuoyancyEffector2D water;
    public SpriteRenderer fishSprite;//Объект, на который кидаем спрайт рыбы
    public GlTime timeCount;
    public GameObject newSpriteFish;
	public GameObject[] forLoadPrefabs;

	GameObject newPoplavok;//поплавок, который кидаем
    CapsuleCollider2D collide;
    BoxCollider2D collideForPoplav;//чекер для удаления поплавка
	BoxCollider2D colliderOnPoplav;//коллайдер на поплавке

	SpriteRenderer startSpR;
    Transform trans;
	Transform transPoplavok;

    Animator anim;
	Rigidbody2D rb;
	Rigidbody2D poplavokRb; //rb поплавка

	fishingScript fishingScript;

	Vector2 powerFishing = new Vector2(10f, 10f);//сила броска;

	const float throwMultiplyer = 0.005f; //1% силы броска;
	const float minRange = 30f;//начальная точка отсчёта для броска поплавка;

	public float horizontalSpeed;
    public float power, powBack;
    public bool poplavokInWater = false;

	float powerPredel = 100f;
	float speedX;
    bool boolForButton = false;
	bool throwed = false;

    public float n;
    public GameObject activ;
    public GameObject Bttn_Fishing;

    public Sprite[] buttons;

    void Start()
	{
        activ.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
		trans = GetComponent<Transform>();
		collide = GetComponent<CapsuleCollider2D>();
		collideForPoplav = GetComponent<BoxCollider2D>();
		fishingScript = GetComponent<fishingScript>(); 
		startSpR = poplavok.GetComponent<SpriteRenderer>();

        transform.position = Load.LoadVector2(name);


		//загрузка растений


		if (PlayerPrefs.GetInt("Wheat") == 1)
		{
			Instantiate(forLoadPrefabs[0], new Vector3(-18.47f, -8.11f, 0), Quaternion.identity);

		}

		if (PlayerPrefs.GetInt("Tomato") == 1)
		{
			Instantiate(forLoadPrefabs[1], new Vector3(-31.77f, -7.93f, 0), Quaternion.identity);
		}

		if (PlayerPrefs.GetInt("Carrot") == 1)
		{
			Instantiate(forLoadPrefabs[2], new Vector3(), Quaternion.identity);

		}

		if (PlayerPrefs.GetInt("Potato") == 1)
		{
			Instantiate(forLoadPrefabs[3], new Vector3(-26.85f, -8.11f, 0), Quaternion.identity);
		}

		for (int i = 1; i <= 3; i++)
		{
			GameObject.Find("Wheat_" + i).GetComponent<Growth>().hour = PlayerPrefs.GetInt("timeWheat" + i.ToString());
			GameObject.Find("Wheat_" + i).GetComponent<SpriteRenderer>().sprite = GameObject.Find("Wheat_" + i).GetComponent<Growth>().sprites[PlayerPrefs.GetInt("WheatSprite")];
		}

		for(int i = 1; i <=3; i++)
		{
			GameObject.Find("Tomato_" + i).GetComponent<Growth>().hour = PlayerPrefs.GetInt("timeTomato" + i.ToString());
			GameObject.Find("Tomato_" + i).GetComponent<SpriteRenderer>().sprite = GameObject.Find("Tomato_" + i).GetComponent<Growth>().sprites[PlayerPrefs.GetInt("TomatoSprite")];
		}

		for (int i = 1; i <= 3; i++)
		{
			GameObject.Find("Carrot_" + i).GetComponent<Growth>().hour = PlayerPrefs.GetInt("timeCarrot" + i.ToString());
			GameObject.Find("Carrot_" + i).GetComponent<SpriteRenderer>().sprite = GameObject.Find("Carrot_" + i).GetComponent<Growth>().sprites[PlayerPrefs.GetInt("CarrotSprite")];
		}

		for (int i = 1; i <= 3; i++)
		{
			GameObject.Find("Potato_" + i).GetComponent<Growth>().hour = PlayerPrefs.GetInt("timePotato" + i.ToString());
			GameObject.Find("Potato_" + i).GetComponent<SpriteRenderer>().sprite = GameObject.Find("Potato_" + i).GetComponent<Growth>().sprites[PlayerPrefs.GetInt("PotatoSprite")];
		}



		PlayerPrefs.SetInt("Wheat", 0);
		PlayerPrefs.SetInt("Tomato", 0);
		PlayerPrefs.SetInt("Potato", 0);
		PlayerPrefs.SetInt("Carrot", 0);

	}

	public void LeftButtonDown()
	{
        anim.SetBool("BoolRun", true);

		transform.localScale = new Vector3(-1, 1, 1);
		speedX = -horizontalSpeed;
	}

	public void RightButtonDown()
	{
        anim.SetBool("BoolRun", true);
        speedX = horizontalSpeed;
		transform.localScale = new Vector3(1, 1, 1);
	}

	public void Stop()
	{
        anim.SetBool("BoolRun", false);
        speedX = 0;
	}

    public void Update()
	{
        n += Time.deltaTime;

		if (boolForButton)
		{
			updateForThrow();
		}

        if (n >= 10 && n <= 11 && anim.GetBool("BoolRun") == false && anim.GetBool("BoolGrub") == false )
        {
            anim.SetBool("Idle", true);
        }
        else if (n > 11 || anim.GetBool("BoolGrub") == true)
        {
            n = 0;
            anim.SetBool("Idle", false);
        }

        /*if(fishingScript.fishingTime <= 1)
		{
            poplavokRb.AddForce(new Vector2(0, -0.05f), ForceMode2D.Impulse);
		}
        */
        switch (fishingScript.fishingTime) // nado yslovie 
        {
            case 1:
                poplavokRb.AddForce(new Vector2(0, -0.05f), ForceMode2D.Impulse);
                break;
        }

		water.surfaceLevel = 0.7f - power;

		deletePoplavok();
	}

	public void FixedUpdate()
	{
		transform.Translate(speedX, 0, 0);
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

		//print(power);
	}

	public void startButtonFishing()
	{
        // нужно условие границ рыбалки, пруда
        if (transform.position.x < 10f && transform.position.x > -16f)
        {
            boolForButton = true;
            activ.SetActive(true);

        }
	}

	public void stopButtonFishing()
	{
        if (transform.position.x < 10f && transform.position.x > -16f)
        {
            boolForButton = false;
            power *= throwMultiplyer;

            fishing();
        }
	}

	public void fishing()
	{
		//Vector2 backFishing = new Vector2();//сила возврата


		if (!newPoplavok)//Проверка, кинут ли поплавок
		{
			fishingScript.fishingTime = UnityEngine.Random.Range(5, 10);//рандомное время для вылавливания рыбы

			if (trans.localScale.x > 0f)
			{
				newPoplavok = Instantiate(poplavok, trans.localPosition + new Vector3(1f, 2f), Quaternion.identity);//создание поплавка
				newSpriteFish = GameObject.FindGameObjectsWithTag("FishSprite")[1];
				//poplavok.GetComponent<SpriteRenderer>().sprite = startSpR.sprite;


				fishingScript.StartCoroutine(fishingScript.checkFishfor());


				if (powerFishing.x < 0)
				{
					powerFishing.x = -powerFishing.x;
				}
			}
			else
			{
				newPoplavok = Instantiate(poplavok, trans.localPosition + new Vector3(-1f, 2f), Quaternion.identity);//тут тоже, но в другую сторону
				newSpriteFish = GameObject.FindGameObjectsWithTag("FishSprite")[1];


				fishingScript.StartCoroutine(fishingScript.checkFishfor());


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
			poplavokRb.AddForceAtPosition(-(transPoplavok.position - trans.localPosition) * powBack, trans.localPosition);//притягивание поплавка назад
		}
	}
	void deletePoplavok()
	{
        try
		{
			if (newPoplavok.GetComponent<BoxCollider2D>().IsTouching(water.GetComponent<BoxCollider2D>()))
            {
                Bttn_Fishing.GetComponent<Image>().sprite = buttons[1];
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

                    activ.SetActive(false);
                    Bttn_Fishing.GetComponent<Image>().sprite = buttons[0];

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

				if(trans.position.x < -20 || trans.position.x > 17)
				{
					Destroy(newPoplavok);
					throwed = false;

					activ.SetActive(false);
					Bttn_Fishing.GetComponent<Image>().sprite = buttons[0];

					fishingScript.StopAllCoroutines();
				}
			}
		}
	}

#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        Save.SaveVector3(name, transform.position);
    }
#endif
    public void OnApplicationQuit()
    {
        Save.SaveVector3(name, transform.position);//Сохраняем местоположение перед выходом из игры


		Save.saveTomato();
		Save.saveWheat();
		Save.savePotato();
		Save.saveCarrot();

	}
}