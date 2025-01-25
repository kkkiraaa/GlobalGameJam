using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    [SerializeField] int money;

    public int trrry;
    public int total_money;
    public Text moneyText;

    public void Start()
    {
        money = PlayerPrefs.GetInt("money");
        total_money = PlayerPrefs.GetInt("total_money");
    }

    public void ButtonClick()
    {
        money++;
        total_money++;
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.SetInt("total_money", total_money);
    }

    public void ButtonClick1Ach()
    {
        if (total_money >= 100 && trrry < 1)
        {
            money += 50;
            trrry++;
        }
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.SetInt("trrry", trrry);
    }

    public void ButtonClickIdle()
    {
        if (money >= 500)
        {
            money -= 500;
            StartCoroutine(IdleFarm());
        }
    }

    IEnumerator IdleFarm()
    {
        yield return new WaitForSeconds(1);
        money = money + 1;
        PlayerPrefs.SetInt("money", money);
        StartCoroutine(IdleFarm());
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = money.ToString();
    }
}
