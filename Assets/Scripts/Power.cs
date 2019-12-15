using UnityEngine;
using UnityEngine.UI;

public class Power : MonoBehaviour
{

	public int maxEnergy = 60;
	public int minEnergy = 1;
	public int currentEnergy = 0;
	int maxEnergyStart;


	public Text powerText;


	void OnEnable()
    {
		powerText = GameObject.Find("power").GetComponent<Text>();
		currentEnergy = PlayerPrefs.GetInt("Energy");
		updateEnergyText();

    }

    void Update()
    {
	}

	public  void updateEnergyText()//обновить спрайт эенергии
	{
		powerText.text = currentEnergy + "/" + maxEnergy;
		
	}

	public  void addCurrentEnergy(int addEnergy)//добавить энергию 
	{
		currentEnergy += addEnergy;
		
		updateEnergyText();
	}

	public void setCurrentEnergy(int addEnergy)//добавить энергию 
	{
		currentEnergy = addEnergy;

		updateEnergyText();
	}

	public bool minusCurrentEnergy(int minusEnergy)//отнять энергию
	{
		if(currentEnergy - minusEnergy >= 0)
		{
			currentEnergy -= minusEnergy;
			updateEnergyText();
			return true;
		}
		else
		{
			return false;
		}
	}

	public  void maxCurrentEnergy()
	{
		currentEnergy = maxEnergy;
		updateEnergyText();
	}

	public  void changeMaxEnergy(int newMax)//Увеличить количество макс. энергии
	{
		maxEnergy = newMax;
		updateEnergyText();
	}

	public  void resetMaxEnergy()//Вернуть первоначальное значение максимальной энергии
	{
		maxEnergy = maxEnergyStart;
		updateEnergyText();
	}

}
