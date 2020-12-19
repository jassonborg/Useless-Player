using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{

    //Money Pickup
    public int currentMoney;
    public Text moneyText;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("CurrentMoney"))
        {
            currentMoney = PlayerPrefs.GetInt("CurrentMoney");
        }
        else
        {
            currentMoney = 0;
            PlayerPrefs.SetInt("CurrentMoney", 0);
        }

        moneyText.text = "$ " + currentMoney;
    }

    public void addMoney(int moneyToAdd)
    {
        currentMoney += moneyToAdd;
        moneyText.text = "$ " + currentMoney;
    }

    public void subtractMoney(int moneyToSubtract)
    {
        if (currentMoney - moneyToSubtract <= 0)
        {
            Debug.Log("You Don't have enough Money");
        }
        else
        {
            currentMoney -= moneyToSubtract;
            moneyText.text = "$ " + currentMoney;
        }
    }
}
